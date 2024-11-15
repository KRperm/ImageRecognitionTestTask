using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using ImageRecognitionTestTask.Client;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageRecognitionTestTask.ViewModels
{
    public class ClientViewModel : IDisposable
    {
        public enum ConnectionStatus { Disconnected, Connected, AwaitingConnection };

        [BindableProperty(OnPropertyChangedMethodName = nameof(NotifyStatusChanged))]
        public virtual ConnectionStatus Status { get; set; }
        [BindableProperty(OnPropertyChangedMethodName = nameof(NotifyMessageChanged))]
        public virtual string Message { get; set; }

        [BindableProperty(OnPropertyChangedMethodName = nameof(NotifyClientNameChanged))]
        public virtual string ClientName { get; set; }

        [BindableProperty(OnPropertyChangedMethodName = nameof(NotifyServerAddressChanged))]
        public virtual IPAddress ServerAddress { get; set; }
        public virtual int ServerPort { get; set; }
        public virtual string ServerResponse { get; set; }

        protected IMessageBoxService MessageBoxService { get; }

        private readonly AppClient _client = new();

        public ClientViewModel()
        {
            MessageBoxService = this.GetService<IMessageBoxService>();
            _client.StatusChanged += OnStatusChanged;
            _client.MessageRecieved += OnClientMessageRecieved;

            // defaults
            ClientName = "По умолчанию";
            ServerAddress = IPAddress.Loopback;
            ServerPort = 2100;
        }

        public async Task ConnectAsync()
        {
            var asyncCommand = this.GetAsyncCommand(x => x.ConnectAsync());
            var endPoint = new IPEndPoint(ServerAddress, ServerPort);
            await _client.RunClientLifecycleAsync(endPoint, ClientName, asyncCommand.CancellationTokenSource.Token);
        }

        public bool CanConnectAsync()
        {
            return ServerAddress != null && !string.IsNullOrEmpty(ClientName);
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
            var connectAsyncCommand = this.GetAsyncCommand(x => x.ConnectAsync());
            var sendAsyncCommand = this.GetAsyncCommand(x => x.SendMessageAsync());
            using var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(connectAsyncCommand.CancellationTokenSource.Token, sendAsyncCommand.CancellationTokenSource.Token);

            try
            {
                await _client.SendMessageAsync(Message, linkedTokenSource.Token);
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                MessageBoxService.ShowMessage(ex.Message, "Ошибка отправки сообщения");
            }
        }

        public bool CanSendMessageAsync()
        {
            return Status == ConnectionStatus.Connected && !string.IsNullOrEmpty(Message);
        }

        protected void NotifyServerAddressChanged()
        {
            this.RaiseCanExecuteChanged(x => x.ConnectAsync());
        }

        protected void NotifyClientNameChanged()
        {
            this.RaiseCanExecuteChanged(x => x.ConnectAsync());
        }

        protected void NotifyStatusChanged()
        {
            this.RaiseCanExecuteChanged(x => x.ConnectAsync());
            this.RaiseCanExecuteChanged(x => x.SetFilePathMessage());
            this.RaiseCanExecuteChanged(x => x.SendMessageAsync());
        }

        protected void NotifyMessageChanged()
        {
            this.RaiseCanExecuteChanged(x => x.SendMessageAsync());
        }

        private void OnStatusChanged(object sender, ClientStatusChangedEventArgs e)
        {
            if (e.Exception.IsNotIntended())
            {
                MessageBoxService.ShowMessage(e.Exception.Message, "Ошибка соединения");
            }
            Status = e.NewStatus switch
            {
                AppClient.Status.Disconnected => ConnectionStatus.Disconnected,
                AppClient.Status.Connected => ConnectionStatus.Connected,
                AppClient.Status.AwaitingConnection => ConnectionStatus.AwaitingConnection,
                _ => throw new NotImplementedException(),
            };
        }

        private void OnClientMessageRecieved(object sender, ServerMessageRecievedEventArgs e)
        {
            ServerResponse = e.Message;
        }

        public void Dispose()
        {
            _client.StatusChanged -= OnStatusChanged;
            _client.MessageRecieved -= OnClientMessageRecieved;
            _client.Dispose();
        }
    }
}
