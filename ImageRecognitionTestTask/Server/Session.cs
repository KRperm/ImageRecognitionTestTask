using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using HalconDotNet;
using ImageRecognitionTestTask.Lifetime;

namespace ImageRecognitionTestTask.Server
{
    public class Session : LifetimeObjectBase
    {
        public event EventHandler<ClientMessageRecievedEventArgs> ClientMessageRecieved;
        public event EventHandler<ImagePathRecievedEventArgs> ImagePathRecieved;

        public Guid Id { get; init; } = Guid.NewGuid();
        public string ClientName { get; private set; }

        private readonly TcpClient _client;
        private readonly Encoding _encoding;

        public Session(TcpClient client, Encoding encoding)
        {
            _client = client;
            _encoding = encoding;
        }

        protected override async Task StartAsync(CancellationToken token)
        {
            var stream = _client.GetStream();
            // Получаем имя клиента
            var readNameBuffer = new byte[_client.ReceiveBufferSize];
            var nameSize = await stream.ReadAsync(readNameBuffer, token).ConfigureAwait(false);
            ClientName = _encoding.GetString(readNameBuffer, 0, nameSize);
        }

        protected override async Task<bool> RunAsync(CancellationToken token)
        {
            var stream = _client.GetStream();

            var readBuffer = new byte[_client.ReceiveBufferSize];
            var readSize = await stream.ReadAsync(readBuffer, token).ConfigureAwait(false);
            if (readSize == 0)
            {
                return false;
            }
            var clientMessage = _encoding.GetString(readBuffer, 0, readSize);
            var responseMessage = HandleClientMessage(clientMessage);

            var messageRecievedArgs = new ClientMessageRecievedEventArgs(clientMessage, responseMessage);
            ClientMessageRecieved?.Invoke(this, messageRecievedArgs);
            var writeBuffer = _encoding.GetBytes(responseMessage);
            await stream.WriteAsync(writeBuffer, token).ConfigureAwait(false);
            return true;
        }

        protected override void End()
        {
            _client?.Dispose();
        }

        private string HandleClientMessage(string clientMessage)
        {
            if (TryCountObjectInImage(clientMessage, out var objectCount))
            {
                var imagePathRecieved = new ImagePathRecievedEventArgs(clientMessage, objectCount);
                ImagePathRecieved?.Invoke(this, imagePathRecieved);
                return objectCount > 50 ? "OK" : "NG";
            }
            return $"Сообщение '{clientMessage}' не является путём к валидному изображению";
        }

        private bool TryCountObjectInImage(string path, out int objectCount)
        {
            objectCount = 0;
            HImage image;
            try
            {
                image = new HImage(path);
            }
            catch
            {
                // TODO: логи
                return false;
            }
            var region = image.GrayErosionShape(20d, 20d, "octagon")
                    .Threshold(90d, 255d)
                    .ErosionCircle(3d)
                    .DilationCircle(5d)
                    .Connection();
            objectCount = region.CountObj();
            return true;
        }
    }
}