using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using HalconDotNet;
using ImageRecognitionTestTask.Lifetime;

namespace ImageRecognitionTestTask.Server
{
    /// <summary>
    /// Сессия сервера. Символизирует подключение к определённому клиенту.
    /// Во время инициализации, сессия ожидает что клиент сразу же пришлёт своё имя.
    /// Далее сессия всегда ждёт сообщение от клиента. При получении сообщения, сессия обрабатывает сообщение клиента и отправляет назад ответ
    /// </summary>
    public class Session : LifetimeObjectBase
    {
        /// <summary>
        /// Сообщение от клиента было получено
        /// </summary>
        public event EventHandler<ClientMessageRecievedEventArgs> ClientMessageRecieved;
        /// <summary>
        /// Получен путь до валидной картинки
        /// </summary>
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
            var writeBuffer = _encoding.GetBytes(responseMessage);
            await stream.WriteAsync(writeBuffer, token).ConfigureAwait(false);
            return true;
        }

        protected override void End()
        {
            _client?.Dispose();
        }

        /// <summary>
        /// Обрабатывает входящие сообщения от клиента
        /// </summary>
        /// <param name="clientMessage">Сообщение клиента</param>
        /// <returns>Ответ сервера который отправится клиенту</returns>
        private string HandleClientMessage(string clientMessage)
        {
            var responseMessage = $"Сообщение '{clientMessage}' не является путём к валидному изображению";
            if (TryCountObjectInImage(clientMessage, out var objectCount))
            {
                var imagePathRecieved = new ImagePathRecievedEventArgs(clientMessage, objectCount);
                ImagePathRecieved?.Invoke(this, imagePathRecieved);
                responseMessage = objectCount > 50 ? "OK" : "NG";
            }
            var messageRecievedArgs = new ClientMessageRecievedEventArgs(clientMessage, responseMessage);
            ClientMessageRecieved?.Invoke(this, messageRecievedArgs);
            return responseMessage;
        }

        /// <summary>
        /// Пытается посчитать количесво предметов на изображении с помощью Halcon
        /// </summary>
        /// <param name="path">Путь к изображения</param>
        /// <param name="objectCount">Количество изображений на картинке</param>
        /// <returns>Получилось ли считать валидное изображение по пути</returns>
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
            var region = image.GrayErosionShape(15d, 15d, "octagon")
                    .Threshold(110d, 255d)
                    .DilationCircle(9d)
                    .ErosionCircle(5d)
                    .Connection();
            objectCount = region.CountObj();
            return true;
        }
    }
}