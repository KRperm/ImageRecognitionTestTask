﻿using DevExpress.Mvvm;
using DevExpress.Utils.MVVM;
using ImageRecognitionTestTask.ViewModels;
using System;

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
        }

        private void OnMessage(string message)
        {
            LogEdit.Text += $"{message}{Environment.NewLine}";
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