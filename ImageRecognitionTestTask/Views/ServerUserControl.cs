using DevExpress.Mvvm;
using DevExpress.Utils.MVVM;
using ImageRecognitionTestTask.ViewModels;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using HalconDotNet;
using ImageRecognitionTestTask.Database;

namespace ImageRecognitionTestTask
{
    public partial class ServerUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public ServerUserControl()
        {
            InitializeComponent();
            Messenger.Default.Register<string>(this, OnMessage);

            var mvvmContext = new MVVMContext
            {
                ContainerControl = this,
                ViewModelType = typeof(ServerViewModel),
            };
            var fluent = mvvmContext.OfType<ServerViewModel>();
            fluent.BindCommand(RunServerButton, x => x.RunServerAsync());
            fluent.BindCancelCommand(StopServerButton, x => x.RunServerAsync());
            fluent.SetBinding(PortEdit, e => e.Value, x => x.ServerPort);
            fluent.SetBinding(PortEdit, e => e.Enabled, x => x.IsServerStopped);
            fluent.SetBinding(ImagesList, e => e.DataSource, x => x.ImageDataSource);
            fluent.SetBinding(ImagesList, e => e.SelectedValue, x => x.SelectedImageId);
            fluent.SetBinding(PictureEdit, e => e.Image, x => x.SelectedImage);
            fluent.SetBinding(ObjectCountLabel, e => e.Text, x => x.SelectedImageObjectCount, modelState => $"Количество деталей: {modelState}");
        }

        private void OnMessage(string message)
        {
            LogEdit.Text += $"{message}{Environment.NewLine}";
            LogEdit.SelectionStart = LogEdit.Text.Length;
            LogEdit.ScrollToCaret();
        }

        private void OnDisposing()
        {
            var mvvmContext = MVVMContext.FromControl(this);
            if (mvvmContext is null)
            {
                return;
            }
            var viewModel = mvvmContext.GetViewModel<ServerViewModel>();
            viewModel.Dispose();
            mvvmContext.Dispose();
        }
    }
}
