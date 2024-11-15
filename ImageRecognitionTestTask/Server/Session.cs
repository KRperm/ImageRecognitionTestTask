using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using HalconDotNet;
using DevExpress.Xpo;

namespace ImageRecognitionTestTask.Server
{
    public class Session
    {
        public event EventHandler<SessionStatusChangedEventArgs> StatusChanged;
        public event EventHandler<ClientMessageRecievedEventArgs> ClientMessageRecieved;

        public Guid Id { get; init; } = Guid.NewGuid();
        public string ClientName { get; private set; }
        public Encoding Encoding { get; set; }

        private readonly TcpClient _client;


        public Session(TcpClient client, Encoding encoding)
        {
            _client = client;
            Encoding = encoding;
        }

        public async Task RunSessionLifecycleAsync(CancellationToken token)
        {
            Exception exception = null;
            try
            {
                var stream = _client.GetStream();

                // Получаем имя клиента
                var readNameBuffer = new byte[_client.ReceiveBufferSize];
                var nameSize = await stream.ReadAsync(readNameBuffer, token).ConfigureAwait(false);
                ClientName = Encoding.GetString(readNameBuffer, 0, nameSize);

                var sessionConnectedArgs = new SessionStatusChangedEventArgs(true);
                StatusChanged?.Invoke(this, sessionConnectedArgs);

                while (!token.IsCancellationRequested)
                {
                    var readBuffer = new byte[_client.ReceiveBufferSize];
                    var readSize = await stream.ReadAsync(readBuffer, token).ConfigureAwait(false);
                    if (readSize == 0)
                    {
                        break;
                    }
                    var sessionMessage = Encoding.GetString(readBuffer, 0, readSize);
                    var responseMessage = HandleClientMessage(sessionMessage);

                    var messageRecievedArgs = new ClientMessageRecievedEventArgs(sessionMessage, responseMessage);
                    ClientMessageRecieved?.Invoke(this, messageRecievedArgs);

                    var writeBuffer = Encoding.GetBytes(responseMessage);
                    await stream.WriteAsync(writeBuffer, token).ConfigureAwait(false);
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
                _client.Dispose();
                var disconnectedArgs = new SessionStatusChangedEventArgs(false, exception);
                StatusChanged?.Invoke(this, disconnectedArgs);
            }
        }

        private string HandleClientMessage(string clientMessage)
        {
            if (TryDetectObjects(clientMessage, out var region))
            {
                using var appContext = new ApplicationContext();

                var objectCount = region.CountObj();
                var record = new ImageRecord
                {
                    ObjectCount = region.CountObj(),
                    Path = clientMessage,
                };
                appContext.Images.Add(record);
                appContext.SaveChanges();

                return objectCount == 50 ? "OK" : "NG";
            }

            return $"SERVER ECHO: {clientMessage}";
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
    }
}