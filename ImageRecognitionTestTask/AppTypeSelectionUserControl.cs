using DevExpress.Utils.MVVM.Services;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageRecognitionTestTask
{
    public partial class AppTypeSelectionUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public event EventHandler ClientSelected;
        public event EventHandler ServerSelected;

        public AppTypeSelectionUserControl()
        {
            InitializeComponent();
        }

        private void SelectClientButton_Click(object sender, EventArgs e)
        {
            ClientSelected?.Invoke(this, EventArgs.Empty);
        }

        private void SelectServerButton_Click(object sender, EventArgs e)
        {
            ServerSelected?.Invoke(this, EventArgs.Empty);
        }
    }
}
