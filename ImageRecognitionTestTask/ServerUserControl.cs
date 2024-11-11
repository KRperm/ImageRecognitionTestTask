using DevExpress.Utils.MVVM;

namespace ImageRecognitionTestTask
{
    public partial class ServerUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public ServerUserControl()
        {
            InitializeComponent();
            var mvvmContext = new MVVMContext
            {
                ContainerControl = this,
                ViewModelType = typeof(ServerViewModel),
            };
            var fluent = mvvmContext.OfType<ServerViewModel>();
            fluent.BindCommand(StartServerButton, x => x.StartServerAsync());
            fluent.SetBinding(PortEdit, e => e.Value, x => x.Port);
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
