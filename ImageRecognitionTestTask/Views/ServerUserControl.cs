﻿using DevExpress.Mvvm;
using DevExpress.Utils.MVVM;
using ImageRecognitionTestTask.ViewModels;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using HalconDotNet;

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
            fluent.SetBinding(ImagesList, e => e.SelectedValue, x => x.SelectedImageId);
            fluent.SetTrigger(x => x.SelectedImageId, id => {
                using var context = new ApplicationContext();
                var record = context.Images.Single(r => r.Id == id);
                var image = new HImage(record.Path);
                ObjectCountLabel.Text = $"Количество деталей: {record.ObjectCount}";
                HSmartWindowControl.HalconWindow.DispImage(image);
            });

            // This line of code is generated by Data Source Configuration Wizard
            // Instantiate a new DBContext
            ImageRecognitionTestTask.ApplicationContext dbContext = new ImageRecognitionTestTask.ApplicationContext();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.Images.LoadAsync().ContinueWith(loadTask =>
            {
                // Bind data to control when loading complete
                ImagesBindingSource.DataSource = dbContext.Images.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
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
            mvvmContext.Dispose();
        }
    }
}
