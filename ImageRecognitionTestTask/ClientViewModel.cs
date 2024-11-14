using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        protected IMessageBoxService MessageBoxService { get; }
        protected Encoding Encoding { get; set; }

        private TcpClient _client;

        public ClientViewModel()
        {
            MessageBoxService = this.GetService<IMessageBoxService>();
            Encoding = Encoding.UTF8;

            // defaults
            ServerAddress = IPAddress.Loopback;
            ServerPort = 2100;
        }

        public async Task ConnectAsync()
        {
            if (_client is not null)
            {
                _client.Close();
                _client.Dispose();
                _client = null;
            }
            var asyncCommand = this.GetAsyncCommand(x => x.ConnectAsync());

            try
            {
                _client = new TcpClient();
                Status = ConnectionStatus.Connecting;
                var endPoint = new IPEndPoint(ServerAddress, ServerPort);
                await _client.ConnectAsync(endPoint, asyncCommand.CancellationTokenSource.Token);
                if (asyncCommand.IsCancellationRequested)
                {
                    Status = ConnectionStatus.Disconnected;
                    return;
                }
                
                Status = _client.Connected ? ConnectionStatus.Connected : ConnectionStatus.Disconnected;
            }
            catch (OperationCanceledException) 
            {
                Status = ConnectionStatus.Disconnected;
            }
            catch (Exception ex)
            {
                Status = ConnectionStatus.Disconnected;
                MessageBoxService.ShowMessage(ex.Message, "Ошибка");
            }
        }

        public bool CanConnectAsync()
        {
            return Status != ConnectionStatus.Connected && ServerAddress != null;
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
            if (_client is null || !_client.Connected)
            {
                return;
            }
            var asyncCommand = this.GetAsyncCommand(x => x.SendMessageAsync());
            try
            {
                var stream = _client.GetStream();
                var outputBuffer = Encoding.GetBytes(Message);
                await stream.WriteAsync(outputBuffer, asyncCommand.CancellationTokenSource.Token);

                var inputBuffer = new byte[1024];
                var size = await stream.ReadAsync(inputBuffer, asyncCommand.CancellationTokenSource.Token);

                ServerResponse = Encoding.GetString(inputBuffer, 0, size);
            }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(ex.Message, "Ошибка");
            }
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
            _client.Close();
            _client.Dispose();
        }
    }
}
