using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.IO;
using DevExpress.Pdf.Native.BouncyCastle.Utilities.IO;

namespace ImageRecognitionTestTask.Server
{
    public partial class AppServer : IDisposable
    {
        public event EventHandler<ServerStatusChangedEventArgs> StatusChanged;
        public event EventHandler<SessionStatusChangedEventArgs> SessionStatusChanged;
        public event EventHandler<SessionMessageRecievedEventArgs> SessionMessageRecieved;

        public Encoding Encoding { get; set; } = Encoding.UTF8;

        private TcpListener _listener;

        public async Task RunServerLifecycleAsync(IPEndPoint endPoint, CancellationToken token)
        {
            if (_listener is not null)
            {
                return;
            }

            Exception exception = null;
            try
            {
                _listener = new TcpListener(endPoint);
                _listener.Start();
                var connectedArgs = new ServerStatusChangedEventArgs(true);
                StatusChanged?.Invoke(this, connectedArgs);
                while (!token.IsCancellationRequested)
                {
                    var client = await _listener.AcceptTcpClientAsync(token);

                    // Получаем имя клиента
                    var clientStream = client.GetStream();
                    var readNameBuffer = new byte[client.ReceiveBufferSize];
                    var readSize = await clientStream.ReadAsync(readNameBuffer, token);
                    var clientName = Encoding.GetString(readNameBuffer, 0, readSize);

                    var session = new Session 
                    {
                        Id = Guid.NewGuid(),
                        ClientName = clientName,
                        Client = client,
                    };
                    var sessionConnectedArgs = new SessionStatusChangedEventArgs(session.Id, session.ClientName, true);
                    SessionStatusChanged?.Invoke(this, sessionConnectedArgs);
                    _ = RunSessionLifecycleAsync(session, token);
                }
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            finally
            {
                // disconnect
                _listener.Stop();
                _listener.Dispose();
                _listener = null;
                var disconnectedArgs = new ServerStatusChangedEventArgs(false, exception);
                StatusChanged?.Invoke(this, disconnectedArgs);
            }
        }

        private async Task RunSessionLifecycleAsync(Session session, CancellationToken token)
        {
            Exception exception = null;
            try
            {
                while (!token.IsCancellationRequested)
                {
                    var stream = session.Client.GetStream();

                    var readBuffer = new byte[session.Client.ReceiveBufferSize];
                    var readSize = await stream.ReadAsync(readBuffer, token);
                    if (readSize == 0)
                    {
                        break;
                    }
                    var sessionMessage = Encoding.GetString(readBuffer, 0, readSize);
                    var messageRecievedArgs = new SessionMessageRecievedEventArgs(session.Id, session.ClientName, sessionMessage);
                    SessionMessageRecieved?.Invoke(this, messageRecievedArgs);

                    var responseMessage = HandleSessionMessage(sessionMessage);
                    var writeBuffer = Encoding.GetBytes(responseMessage);
                    await stream.WriteAsync(writeBuffer, token);
                }
            }
            catch(IOException ioEx)
            {
                exception = ioEx.InnerException;
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            finally
            {
                // close session
                session.Client.Dispose();
                var disconnectedArgs = new SessionStatusChangedEventArgs(session.Id, session.ClientName, false, exception);
                SessionStatusChanged?.Invoke(this, disconnectedArgs);
            }
        }

        private string HandleSessionMessage(string sessionMessage)
        {
            if (File.Exists(sessionMessage))
            {
                using var stream = File.OpenRead(sessionMessage);
            }

            return $"SERVER ECHO: {sessionMessage}";
        }

        public void Dispose()
        {
            _listener?.Stop();
            _listener?.Dispose();
            _listener = null;
        }
    }
}
