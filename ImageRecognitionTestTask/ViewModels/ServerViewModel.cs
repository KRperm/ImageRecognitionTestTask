using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using ImageRecognitionTestTask.Database;
using ImageRecognitionTestTask.Lifetime;
using ImageRecognitionTestTask.Server;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognitionTestTask.ViewModels
{
    public class ServerViewModel : IDisposable
    {
        public virtual bool IsServerStopped { get; set; }
        public virtual int ServerPort { get; set; }
        [BindableProperty(OnPropertyChangedMethodName = nameof(NotifySelectedImageIdChanged))]
        public virtual Guid SelectedImageId { get; set; }
        public virtual Image SelectedImage { get; set; }
        public virtual int SelectedImageObjectCount { get; set; }
        public virtual BindingList<ImageRecord> ImageDataSource { get; set; }

        protected IMessageBoxService MessageBoxService { get; }
        protected IDispatcherService DispatcherService { get; }

        private readonly ImagesContext _dbContext;


        public ServerViewModel()
        {
            _dbContext = new ImagesContext();
            MessageBoxService = this.GetService<IMessageBoxService>();
            DispatcherService = this.GetService<IDispatcherService>();
            IsServerStopped = true;
            _dbContext.Images.LoadAsync().ContinueWith(_ =>
            {
                ImageDataSource = _dbContext.Images.Local.ToBindingList();
            }, TaskScheduler.FromCurrentSynchronizationContext());

            // defaults
            ServerPort = 2100;
        }

        public async Task RunServerAsync()
        {
            var asyncCommand = this.GetAsyncCommand(x => x.RunServerAsync());
            var endPoint = new IPEndPoint(IPAddress.Any, ServerPort);
            using var server = new AppServer(endPoint, Encoding.UTF8);
            server.StatusChanged += OnServerStatusChanged;
            server.SessionStatusChanged += OnServerSessionStatusChanged;
            server.ClientMessageRecieved += OnServerSessionMessageRecieved;
            server.ClientImagePathRecieved += OnClientImagePathRecieved;
            await server.RunLifetimeAsync(asyncCommand.CancellationTokenSource.Token).ConfigureAwait(false);
            server.StatusChanged -= OnServerStatusChanged;
            server.SessionStatusChanged -= OnServerSessionStatusChanged;
            server.ClientMessageRecieved -= OnServerSessionMessageRecieved;
            server.ClientImagePathRecieved -= OnClientImagePathRecieved;
        }

        protected void NotifySelectedImageIdChanged()
        {
            SelectedImage?.Dispose();
            SelectedImage = null;
            SelectedImageObjectCount = 0;

            if (_dbContext.Images.Local.Count <= 0)
            {
                return;
            }

            var record = _dbContext.Images.Local.Single(x => x.Id == SelectedImageId);
            SelectedImageObjectCount = record.ObjectCount;

            Image newImage;
            try
            {
                newImage = Image.FromFile(record.Path);
            }
            catch
            {
                newImage = null;
            }
            SelectedImage = newImage;
        }

        private void OnServerStatusChanged(object sender, LifetimeObjectStatusChangedEventArgs e)
        {
            if (e.NewStatus == LifetimeObjectBase.Status.StartingUp)
            {
                return;
            }
            if (e.Exception.IsNotIntended())
            {
                MessageBoxService.ShowMessage(e.Exception.TryGetIOExceptionMessage(), "Ошибка работы сервера");
            }
            DispatcherService.BeginInvoke(() => IsServerStopped = e.NewStatus == LifetimeObjectBase.Status.Finished);
            var statusMessage = e.NewStatus == LifetimeObjectBase.Status.Finished ? "Сервер остановлен" : "Сервер запущен";
            WriteMessage(statusMessage);
        }

        private void OnServerSessionStatusChanged(object sender, LifetimeObjectStatusChangedEventArgs e)
        {
            if (sender is not Session session)
            {
                throw new ArgumentException();
            }
            if (e.NewStatus == LifetimeObjectBase.Status.StartingUp)
            {
                return;
            }

            var message = "Клиент подключился";
            if (e.NewStatus == LifetimeObjectBase.Status.Finished)
            {
                message = e.Exception.IsNotIntended() ? $"Клиент отключился ({e.Exception.TryGetIOExceptionMessage()})" : "Клиент отключился";
            }
            WriteMessage(session.Id, session.ClientName, message);
        }

        private void OnServerSessionMessageRecieved(object sender, ClientMessageRecievedEventArgs e)
        {
            if (sender is not Session session)
            {
                throw new ArgumentException();
            }
            WriteMessage(session.Id, session.ClientName, $"Сообщение '{e.Message}'. Ответ '{e.Response}'");
        }

        private void OnClientImagePathRecieved(object sender, ImagePathRecievedEventArgs e)
        {
            DispatcherService.BeginInvoke(() =>
            {
                var record = new ImageRecord
                {
                    Path = e.Path,
                    ObjectCount = e.ObjectCount,
                };
                _dbContext.Images.Add(record);
                _dbContext.SaveChanges();
            });
        }

        private void WriteMessage(string message)
        {
            var timeString = DateTime.Now.ToLongTimeString();
            DispatcherService.BeginInvoke(() => Messenger.Default.Send($"{timeString}> {message}"));
        }

        private void WriteMessage(Guid sessionId, string clientName, string message)
        {
            var timeString = DateTime.Now.ToLongTimeString();
            var idString = $"[id сессии {sessionId.ToString()[..8]}...]";
            DispatcherService.BeginInvoke(() => Messenger.Default.Send($"{timeString} {clientName} {idString}> {message}"));
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
            SelectedImage?.Dispose();
        }
    }
}
