using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace ImageRecognitionTestTask
{
    public partial class MainForm : XtraForm
    {
        public MainForm()
        {
            InitializeComponent();

            var appSelection = new AppTypeSelectionUserControl();
            appSelection.ClientSelected += AppTypeSelectionUserControl_ClientSelected;
            appSelection.ServerSelected += AppTypeSelectionUserControl_ServerSelected;
            SetMainUserControl(appSelection);
        }

        private void AppTypeSelectionUserControl_ServerSelected(object sender, EventArgs e)
        {
            SetMainUserControl(new ServerUserControl());
        }

        private void AppTypeSelectionUserControl_ClientSelected(object sender, EventArgs e)
        {
            SetMainUserControl(new ClientUserControl());
        }

        private void SetMainUserControl(Control control)
        {
            control.Dock = DockStyle.Fill;
            Controls.Clear();
            Controls.Add(control);
            DocumentManager.ClientControl = control;
        }
    }
}