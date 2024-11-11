using DevExpress.Utils.MVVM;
using System.Net;

namespace ImageRecognitionTestTask
{
    public partial class ClientUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public ClientUserControl()
        {
            InitializeComponent();
            var mvvmContext = new MVVMContext
            {
                ContainerControl = this,
                ViewModelType = typeof(ClientViewModel),
            };
            var fluent = mvvmContext.OfType<ClientViewModel>();
            fluent.BindCommand(ConnectButton, x => x.ConnectAsync());
            fluent.BindCommand(SendMessageButton, x => x.SendMessageAsync());
            fluent.BindCommand(FindFileButton, x => x.SetFilePathMessage());
            fluent.SetBinding(ServerStatusLabel, e => e.Text, x => x.Status,
                modelState =>
                {
                    return modelState switch
                    {
                        ClientViewModel.ConnectionStatus.Disconnected => "Отключено",
                        ClientViewModel.ConnectionStatus.Connected => "ОК",
                        ClientViewModel.ConnectionStatus.Connecting => "Соединяю",
                        _ => "Неизвестный статус",
                    };
                });
            fluent.SetBinding(ServerResponseLabel, e => e.Text, x => x.ServerResponse);
            fluent.SetBinding(MessageEdit, e => e.Text, x => x.Message);
            fluent.SetBinding(MessageEdit, e => e.Enabled, x => x.Status, modelState => modelState == ClientViewModel.ConnectionStatus.Connected);
            fluent.SetBinding(IpEdit, e => e.Text, x => x.ServerAddress, 
                modelState => modelState?.ToString(),
                editState => IPAddress.TryParse(editState, out var address) ? address : null);
            fluent.SetBinding(IpEdit, e => e.Enabled, x => x.Status, modelState => modelState == ClientViewModel.ConnectionStatus.Disconnected);
            fluent.SetBinding(PortEdit, e => e.Value, x => x.ServerPort);
            fluent.SetBinding(PortEdit, e => e.Enabled, x => x.Status, modelState => modelState == ClientViewModel.ConnectionStatus.Disconnected);
        }

        private void OnDisposing()
        {
            var mvvmContext = MVVMContext.FromControl(this);
            if (mvvmContext is null)
            {
                return;
            }
            var viewModel = mvvmContext.GetViewModel<ClientViewModel>();
            viewModel.Dispose();
            mvvmContext.Dispose();
        }
    }
}
