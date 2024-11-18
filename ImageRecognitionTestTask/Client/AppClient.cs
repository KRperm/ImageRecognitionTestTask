using DevExpress.Pdf.Native.BouncyCastle.Utilities.IO;
using ImageRecognitionTestTask.Lifetime;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImageRecognitionTestTask.Client
{
    public class AppClient : LifetimeObjectBase
    {
        public event EventHandler<ServerMessageRecievedEventArgs> MessageRecieved;

        private TcpClient _client;
        private readonly IPEndPoint _endPoint;
        private readonly string _clientName;
        private readonly Encoding _encoding;

        public AppClient(IPEndPoint endPoint, string clientName, Encoding encoding)
        {
            _endPoint = endPoint;
            _clientName = clientName;
            _encoding = encoding;
        }

        public async Task SendMessageAsync(string message, CancellationToken token)
        {
            if (_client is null || !_client.Connected)
            {
                return;
            }
            var stream = _client.GetStream();
            var writeBuffer = _encoding.GetBytes(message);
            await stream.WriteAsync(writeBuffer, token).ConfigureAwait(false);
        }

        protected override async Task StartAsync(CancellationToken token)
        {
            _client = new TcpClient();
            await _client.ConnectAsync(_endPoint, token).ConfigureAwait(false);
            await SendMessageAsync(_clientName, token).ConfigureAwait(false);
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
            var serverMessage = _encoding.GetString(readBuffer, 0, readSize);
            var messageArgs = new ServerMessageRecievedEventArgs(serverMessage);
            MessageRecieved?.Invoke(this, messageArgs);
            return true;
        }

        protected override void End()
        {
            _client?.Close();
            _client?.Dispose();
        }
    }
}
