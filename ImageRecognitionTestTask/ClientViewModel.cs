using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageRecognitionTestTask
{
    public class ClientViewModel : IDisposable
    {
        public enum ConnectionStatus { Disconnected, Connecting, Connected };

        [BindableProperty(OnPropertyChangedMethodName = nameof(NotifyStatusChanged))]
        public virtual ConnectionStatus Status { get; set; }
        public virtual string Message { get; set; }

        [BindableProperty(OnPropertyChangedMethodName = nameof(NotifyServerAddressChanged))]
        public virtual IPAddress ServerAddress { get; set; }
        public virtual int ServerPort { get; set; }
        public virtual string ServerResponse { get; set; }


        private TcpClient _client;

        public async Task ConnectAsync()
        {
            var asyncCommand = this.GetAsyncCommand(x => x.ConnectAsync());

            _client = new TcpClient();
            Status = ConnectionStatus.Connecting;
            var endPoint = new IPEndPoint(ServerAddress, ServerPort);
            await _client.ConnectAsync(endPoint);
            if (asyncCommand.IsCancellationRequested)
            {
                Status = ConnectionStatus.Disconnected;
                return;
            }
            Status = _client.Connected ? ConnectionStatus.Connected : ConnectionStatus.Disconnected;
        }

        public bool CanConnectAsync()
        {
            return Status == ConnectionStatus.Disconnected && ServerAddress != null;
        }

        public void SetFilePathMessage()
        {
            var fileDialog = new OpenFileDialog
            {
                Filter = "Изображения (png, jpg, bmp)|*.png;*.jpg;*.bmp"
            };

            var dialogResult = fileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                Message = fileDialog.FileName;
            }
        }

        public bool CanSetFilePathMessage()
        {
            return Status == ConnectionStatus.Connected;
        }

        public async Task SendMessageAsync()
        {
            await using var stream = _client.GetStream();

            var outputBuffer = Encoding.ASCII.GetBytes(Message);
            await stream.WriteAsync(outputBuffer);

            var inputBuffer = new byte[1024];
            var size = await stream.ReadAsync(inputBuffer);

            ServerResponse = Encoding.ASCII.GetString(inputBuffer, 0, size);
        }

        public bool CanSendMessageAsync()
        {
            return Status == ConnectionStatus.Connected;
        }

        protected void NotifyServerAddressChanged()
        {
            this.RaiseCanExecuteChanged(x => x.ConnectAsync());
        }

        protected void NotifyStatusChanged()
        {
            this.RaiseCanExecuteChanged(x => x.ConnectAsync());
            this.RaiseCanExecuteChanged(x => x.SetFilePathMessage());
            this.RaiseCanExecuteChanged(x => x.SendMessageAsync());
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
