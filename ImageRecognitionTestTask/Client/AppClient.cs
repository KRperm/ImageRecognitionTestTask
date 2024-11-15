using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImageRecognitionTestTask.Client
{
    public class AppClient : IDisposable
    {
        public enum Status { Disconnected, Connected, AwaitingConnection }

        public event EventHandler<ClientStatusChangedEventArgs> StatusChanged;
        public event EventHandler<ServerMessageRecievedEventArgs> MessageRecieved;

        public Encoding Encoding { get; set; } = Encoding.UTF8;
        private TcpClient _client;

        public async Task RunClientLifecycleAsync(IPEndPoint endPoint, string clientName, CancellationToken token)
        {
            if (_client is not null)
            {
                return;
            }

            Exception exception = null;
            try
            {
                _client = new TcpClient();
                var awaitingArgs = new ClientStatusChangedEventArgs(Status.AwaitingConnection);
                StatusChanged?.Invoke(this, awaitingArgs);
                await _client.ConnectAsync(endPoint, token).ConfigureAwait(false);
                await SendMessageAsync(clientName, token).ConfigureAwait(false);
                var connectedArgs = new ClientStatusChangedEventArgs(Status.Connected);
                StatusChanged?.Invoke(this, connectedArgs);

                // Переодическое получение данных
                while (!token.IsCancellationRequested)
                {
                    var stream = _client.GetStream();
                    var readBuffer = new byte[_client.ReceiveBufferSize];
                    var readSize = await stream.ReadAsync(readBuffer, token).ConfigureAwait(false);
                    if (readSize == 0)
                    {
                        break;
                    }
                    var serverMessage = Encoding.GetString(readBuffer, 0, readSize);
                    var messageArgs = new ServerMessageRecievedEventArgs(serverMessage);
                    MessageRecieved?.Invoke(this, messageArgs);
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
                // disconnected
                _client.Dispose();
                _client = null;
                var disconnectedArgs = new ClientStatusChangedEventArgs(Status.Disconnected, exception);
                StatusChanged?.Invoke(this, disconnectedArgs);
            }
        }

        public async Task SendMessageAsync(string message, CancellationToken token)
        {
            if (_client is null || !_client.Connected)
            {
                return;
            }
            var stream = _client.GetStream();
            var writeBuffer = Encoding.GetBytes(message);
            await stream.WriteAsync(writeBuffer, token).ConfigureAwait(false);
        }

        public void Dispose()
        {
            _client?.Dispose();
            _client?.Close();
        }
    }
}
