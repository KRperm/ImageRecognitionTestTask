using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM.Services;
using ImageRecognitionTestTask.Client;
using ImageRecognitionTestTask.Lifetime;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageRecognitionTestTask.ViewModels
{
    public class ClientViewModel
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
        protected IDispatcherService DispatcherService { get; }

        private AppClient _client;

        public ClientViewModel()
        {
            MessageBoxService = this.GetService<IMessageBoxService>();
            DispatcherService = this.GetService<IDispatcherService>();
            // defaults
            ClientName = "По умолчанию";
            ServerAddress = IPAddress.Loopback;
            ServerPort = 2100;
        }

        public async Task ConnectAsync()
        {
            var asyncCommand = this.GetAsyncCommand(x => x.ConnectAsync());
            var endPoint = new IPEndPoint(ServerAddress, ServerPort);
            using (_client = new AppClient(endPoint, ClientName, Encoding.UTF8))
            {
                _client.StatusChanged += OnStatusChanged;
                _client.MessageRecieved += OnServerMessageRecieved;
                await _client.RunLifetimeAsync(asyncCommand.CancellationTokenSource.Token).ConfigureAwait(false);
                _client.StatusChanged -= OnStatusChanged;
                _client.MessageRecieved -= OnServerMessageRecieved;
            }
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
            if (_client is null || _client.CurrentStatus != LifetimeObjectBase.Status.Running)
            {
                return;
            }
            var connectAsyncCommand = this.GetAsyncCommand(x => x.ConnectAsync());
            var sendAsyncCommand = this.GetAsyncCommand(x => x.SendMessageAsync());
            using var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(connectAsyncCommand.CancellationTokenSource.Token, sendAsyncCommand.CancellationTokenSource.Token);

            try
            {
                await _client.SendMessageAsync(Message, linkedTokenSource.Token).ConfigureAwait(false);
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

        private void OnStatusChanged(object sender, LifetimeObjectStatusChangedEventArgs e)
        {
            if (e.Exception.IsNotIntended())
            {
                MessageBoxService.ShowMessage(e.Exception.TryGetIOExceptionMessage(), "Ошибка соединения");
            }
            DispatcherService.BeginInvoke(() =>
            {
                Status = e.NewStatus switch
                {
                    LifetimeObjectBase.Status.StartingUp => ConnectionStatus.AwaitingConnection,
                    LifetimeObjectBase.Status.Running => ConnectionStatus.Connected,
                    LifetimeObjectBase.Status.Finished => ConnectionStatus.Disconnected,
                    _ => throw new NotImplementedException(),
                };
            });   
        }

        private void OnServerMessageRecieved(object sender, ServerMessageRecievedEventArgs e)
        {
            DispatcherService.BeginInvoke(() => ServerResponse = e.Message);
        }
    }
}
