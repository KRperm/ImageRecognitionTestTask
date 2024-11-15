using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM.Services;
using ImageRecognitionTestTask.Server;
using System;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ImageRecognitionTestTask.ViewModels
{
    public class ServerViewModel : IDisposable
    {
        public virtual bool IsServerStopped { get; set; }
        public virtual int ServerPort { get; set; }
        public virtual Guid SelectedImageId { get; set; }

        protected IMessageBoxService MessageBoxService { get; }
        protected IDispatcherService DispatcherService { get; }
        private readonly AppServer _server = new();


        public ServerViewModel()
        {
            MessageBoxService = this.GetService<IMessageBoxService>();
            DispatcherService = this.GetService<IDispatcherService>();
            IsServerStopped = true;
            _server.StatusChanged += OnServerStatusChanged;
            _server.SessionStatusChanged += OnServerSessionStatusChanged;
            _server.ClientMessageRecieved += OnServerSessionMessageRecieved;

            // defaults
            ServerPort = 2100;
        }

        public async Task RunServerAsync()
        {
            var asyncCommand = this.GetAsyncCommand(x => x.RunServerAsync());
            var endPoint = new IPEndPoint(IPAddress.Any, ServerPort);
            await _server.RunServerLifecycleAsync(endPoint, asyncCommand.CancellationTokenSource.Token).ConfigureAwait(false);
        }

        private void OnServerStatusChanged(object sender, ServerStatusChangedEventArgs e)
        {
            if (e.Exception.IsNotIntended())
            {
                MessageBoxService.ShowMessage(e.Exception.Message, "Ошибка работы сервера");
            }
            IsServerStopped = !e.IsRunning;
            WriteMessage(e.IsRunning ? "Сервер запущен" : "Сервер остановлен");
        }

        private void OnServerSessionStatusChanged(object sender, SessionStatusChangedEventArgs e)
        {
            if (sender is not Session session)
            {
                throw new ArgumentException();
            }

            var message = "Клиент подключился";
            if (!e.IsConnected)
            {
                message = e.Exception.IsNotIntended() ? $"Клиент отключился ({e.Exception.Message})" : "Клиент отключился";
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

        public void Dispose()
        {
            _server.StatusChanged -= OnServerStatusChanged;
            _server.SessionStatusChanged -= OnServerSessionStatusChanged;
            _server.ClientMessageRecieved -= OnServerSessionMessageRecieved;
            _server.Dispose();
        }
    }
}
