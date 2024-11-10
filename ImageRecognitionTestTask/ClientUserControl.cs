using DevExpress.Utils.CommonDialogs.Internal;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraEditors;
using DevExpress.XtraSpreadsheet.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageRecognitionTestTask
{
    public partial class ClientUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        private TcpClient _client;

        public ClientUserControl()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            var uri = new Uri(ConnectTextEdit.Text);
            var ip = IPAddress.Parse(uri.Host);
            var endPoint = new IPEndPoint(ip, uri.Port);
            _client = new TcpClient();
            _client.Connect(endPoint);

            MessagePanel.Enabled = true;
        }

        public void SelectPathButton_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog
            {
                Filter = "Изображения (png, jpg, bmp)|*.png;*.jpg;*.bmp"
            };

            var dialogResult = fileDialog.ShowDialog();
            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                MessageTextEdit.Text = fileDialog.FileName;
            }
        }

        private void SendMessageButton_Click(object sender, EventArgs e)
        {

        }
    }
}
