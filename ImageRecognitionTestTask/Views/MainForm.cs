﻿using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;

namespace ImageRecognitionTestTask
{
    public partial class MainForm : XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
            MVVMContext.RegisterFlyoutMessageBoxService();
        }
    }
}