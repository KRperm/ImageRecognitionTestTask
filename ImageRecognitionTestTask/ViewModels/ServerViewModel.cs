using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using ImageRecognitionTestTask.Server;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ImageRecognitionTestTask.ViewModels
{
    public class ServerViewModel : IDisposable
    {
        public virtual bool IsServerStopped { get; set; }
        public virtual int ServerPort { get; set; }

        protected IMessageBoxService MessageBoxService { get; }
        private readonly AppServer _server = new();


        public ServerViewModel()
        {
            MessageBoxService = this.GetService<IMessageBoxService>();
            IsServerStopped = true;
            _server.StatusChanged += OnServerStatusChanged;
            _server.SessionStatusChanged += OnServerSessionStatusChanged;
            _server.SessionMessageRecieved += OnServerSessionMessageRecieved;

            // defaults
            ServerPort = 2100;
        }

        public async Task RunServerAsync()
        {
            var asyncCommand = this.GetAsyncCommand(x => x.RunServerAsync());
            var endPoint = new IPEndPoint(IPAddress.Any, ServerPort);
            await _server.RunServerLifecycleAsync(endPoint, asyncCommand.CancellationTokenSource.Token);
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
            var message = "Клиент подключился";
            if (!e.IsConnected)
            {
                message = e.Exception.IsNotIntended() ? $"Клиент отключился ({e.Exception.Message})" : "Клиент отключился";
            }
            WriteMessage(e.SessionId, e.ClientName, message);
        }

        private void OnServerSessionMessageRecieved(object sender, SessionMessageRecievedEventArgs e)
        {
            WriteMessage(e.SessionId, e.ClientName, $"Сообщение '{e.Message}'");
        }

        private void WriteMessage(string message)
        {
            var timeString = DateTime.Now.ToLongTimeString();
            Messenger.Default.Send($"{timeString}> {message}");
        }

        private void WriteMessage(Guid sessionId, string clientName, string message)
        {
            var timeString = DateTime.Now.ToLongTimeString();
            var idString = $"[id сессии {sessionId.ToString()[..8]}...]";
            Messenger.Default.Send($"{timeString} {clientName} {idString}> {message}");
        }

        public void Dispose()
        {
            _server.StatusChanged -= OnServerStatusChanged;
            _server.SessionStatusChanged -= OnServerSessionStatusChanged;
            _server.SessionMessageRecieved -= OnServerSessionMessageRecieved;
            _server.Dispose();
        }
    }
}
