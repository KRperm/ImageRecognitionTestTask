using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.IO;
using HalconDotNet;

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
                    var responseMessage = HandleSessionMessage(sessionMessage);

                    var messageRecievedArgs = new SessionMessageRecievedEventArgs(session.Id, session.ClientName, sessionMessage, responseMessage);
                    SessionMessageRecieved?.Invoke(this, messageRecievedArgs);

                    var writeBuffer = Encoding.GetBytes(responseMessage);
                    await stream.WriteAsync(writeBuffer, token);
                }
            }
            catch (IOException ioEx)
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
            if (TryDetectObjects(sessionMessage, out var region))
            {
                using var appContext = new ApplicationContext();
                
                var objectCount = region.CountObj();
                var record = new ImageRecord
                {
                    ObjectCount = region.CountObj(),
                    Path = sessionMessage,
                };
                appContext.Images.Add(record);
                appContext.SaveChanges();

                return objectCount == 50 ? "OK" : "NG";
            }

            return $"SERVER ECHO: {sessionMessage}";
        }

        private bool TryDetectObjects(string path, out HRegion region)
        {
            region = null;
            HImage image;
            try
            {
                image = new HImage(path);
            }
            catch
            {
                return false;
            }
            region = image.GrayErosionShape(20d, 20d, "octagon")
                    .Threshold(90d, 255d)
                    .ErosionCircle(3d)
                    .DilationCircle(5d)
                    .Connection();
            return true;
        }

        public void Dispose()
        {
            _listener?.Stop();
            _listener?.Dispose();
            _listener = null;
        }
    }
}
