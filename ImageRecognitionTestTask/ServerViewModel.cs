using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ImageRecognitionTestTask.ServerViewModel;

namespace ImageRecognitionTestTask
{
    public class ServerViewModel : IDisposable
    {
        public virtual bool IsServerRunning { get; set; }
        public virtual int ServerPort { get; set; }

        protected Encoding Encoding { get; }
        protected IMessageBoxService MessageBoxService { get; }

        private TcpListener _listener;
        private readonly ConcurrentDictionary<Guid, Session> _sessions;

        public ServerViewModel()
        {
            _sessions = [];
            Encoding = Encoding.UTF8;
            MessageBoxService = this.GetService<IMessageBoxService>();
            IsServerRunning = false;

            // defaults
            ServerPort = 2100;
        }

        public async Task RunServerAsync()
        {
            if (_listener is not null)
            {
                return;
            }

            var asyncCommand = this.GetAsyncCommand(x => x.RunServerAsync());
            var token = asyncCommand.CancellationTokenSource.Token;

            try
            {
                _listener = new TcpListener(IPAddress.Any, ServerPort);
                _listener.Start();
                IsServerRunning = true;
                while (!token.IsCancellationRequested)
                {
                    var client = await _listener.AcceptTcpClientAsync(token);
                    var session = new Session()
                    {
                        Id = Guid.NewGuid(),
                        Client = client,
                        TokenSource = new CancellationTokenSource(),
                    };
                    _sessions[session.Id] = session;

                    var messageObject = new ClientMessage() { Name = session.Id.ToString()[..5], Message = "Клиент подключён" };
                    Messenger.Default.Send(messageObject);

                    _ = DoSessionRoutineAsync(session);
                }
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(ex.Message, "Ошибка");
            }
            finally
            {
                IsServerRunning = false;
                _listener.Stop();
                _listener.Dispose();
                _listener = null;
            }
        }

        private async Task DoSessionRoutineAsync(Session session)
        {
            try
            {
                while (!session.Token.IsCancellationRequested && session.Client.Connected)
                {
                    var stream = session.Client.GetStream();

                    var inputBuffer = new byte[1024];
                    var inputSize = await stream.ReadAsync(inputBuffer, session.Token);
                    var clientMessage = Encoding.GetString(inputBuffer, 0, inputSize);
                    var messageObject = new ClientMessage() { Name = session.Id.ToString()[..5], Message = clientMessage };
                    Messenger.Default.Send(messageObject);

                    var response = React(clientMessage);
                    var outputBuffer = Encoding.GetBytes(response);
                    await stream.WriteAsync(outputBuffer, session.Token);
                }
            }
            catch(Exception ex)
            {
                var message = $"Клиент отключён - {ex.Message}";
                var messageObject = new ClientMessage() { Name = session.Id.ToString()[..5], Message = message };
                Messenger.Default.Send(messageObject);
            }
            finally
            {
                _sessions.TryRemove(session.Id, out _);
                session.Dispose();
            }
        }

        private string React(string clientMessage)
        {
            if (File.Exists(clientMessage))
            {
                using var stream = File.OpenRead(clientMessage);
            }

            return $"SERVER ECHO: {clientMessage}";
        }

        public void Dispose()
        {
            _listener.Stop();
            _listener.Dispose();
            foreach (var session in _sessions.Values)
            {
                session.Dispose();
            }
            _sessions.Clear();
        }

        private class Session : IDisposable
        {
            public Guid Id { get; set; }
            public TcpClient Client { get; set; }
            public CancellationTokenSource TokenSource { get; set; }
            public CancellationToken Token => TokenSource?.Token ?? default;

            public void Dispose()
            {
                Client?.Close();
                Client?.Dispose();
                TokenSource?.Cancel();
                TokenSource?.Dispose();
            }
        }

        public class ClientMessage
        {
            public string Name { get; set; }
            public string Message { get; set; }

            public override string ToString()
            {
                return $"{Name}: {Message}";
            }
        }
    }
}
