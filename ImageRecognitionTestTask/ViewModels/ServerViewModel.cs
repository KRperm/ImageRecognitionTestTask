using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM.Services;
using ImageRecognitionTestTask.Lifetime;
using ImageRecognitionTestTask.Server;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImageRecognitionTestTask.ViewModels
{
    public class ServerViewModel
    {
        public virtual bool IsServerStopped { get; set; }
        public virtual int ServerPort { get; set; }
        public virtual Guid SelectedImageId { get; set; }

        protected IMessageBoxService MessageBoxService { get; }
        protected IDispatcherService DispatcherService { get; }


        public ServerViewModel()
        {
            MessageBoxService = this.GetService<IMessageBoxService>();
            DispatcherService = this.GetService<IDispatcherService>();
            IsServerStopped = true;
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
            await server.RunLifetime(asyncCommand.CancellationTokenSource.Token).ConfigureAwait(false);
            server.StatusChanged -= OnServerStatusChanged;
            server.SessionStatusChanged -= OnServerSessionStatusChanged;
            server.ClientMessageRecieved -= OnServerSessionMessageRecieved;
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
    }
}
