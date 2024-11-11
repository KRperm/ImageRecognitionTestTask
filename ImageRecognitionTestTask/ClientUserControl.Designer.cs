namespace ImageRecognitionTestTask
{
    partial class ClientUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                OnDisposing();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition2 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition3 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition4 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition5 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition6 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition4 = new DevExpress.XtraLayout.RowDefinition();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            PortEdit = new DevExpress.XtraEditors.SpinEdit();
            ServerResponseLabel = new DevExpress.XtraEditors.LabelControl();
            MessageEdit = new DevExpress.XtraEditors.TextEdit();
            ConnectButton = new DevExpress.XtraEditors.SimpleButton();
            FindFileButton = new DevExpress.XtraEditors.SimpleButton();
            IpEdit = new DevExpress.XtraEditors.TextEdit();
            ServerStatusLabel = new DevExpress.XtraEditors.LabelControl();
            SendMessageButton = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PortEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MessageEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IpEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem9).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(PortEdit);
            layoutControl1.Controls.Add(ServerResponseLabel);
            layoutControl1.Controls.Add(MessageEdit);
            layoutControl1.Controls.Add(ConnectButton);
            layoutControl1.Controls.Add(FindFileButton);
            layoutControl1.Controls.Add(IpEdit);
            layoutControl1.Controls.Add(ServerStatusLabel);
            layoutControl1.Controls.Add(SendMessageButton);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(3104, 218, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(776, 425);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // PortEdit
            // 
            PortEdit.EditValue = new decimal(new int[] { 2100, 0, 0, 0 });
            PortEdit.Location = new System.Drawing.Point(390, 28);
            PortEdit.Name = "PortEdit";
            PortEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            PortEdit.Properties.MaskSettings.Set("mask", "d");
            PortEdit.Properties.MaxValue = new decimal(new int[] { 65535, 0, 0, 0 });
            PortEdit.Size = new System.Drawing.Size(96, 20);
            PortEdit.StyleController = layoutControl1;
            PortEdit.TabIndex = 7;
            // 
            // ServerResponseLabel
            // 
            ServerResponseLabel.Location = new System.Drawing.Point(430, 92);
            ServerResponseLabel.Name = "ServerResponseLabel";
            ServerResponseLabel.Size = new System.Drawing.Size(32, 13);
            ServerResponseLabel.StyleController = layoutControl1;
            ServerResponseLabel.TabIndex = 1;
            ServerResponseLabel.Text = "Ответ";
            // 
            // MessageEdit
            // 
            MessageEdit.Location = new System.Drawing.Point(222, 68);
            MessageEdit.Name = "MessageEdit";
            MessageEdit.Size = new System.Drawing.Size(164, 20);
            MessageEdit.StyleController = layoutControl1;
            MessageEdit.TabIndex = 4;
            // 
            // ConnectButton
            // 
            ConnectButton.Location = new System.Drawing.Point(490, 12);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new System.Drawing.Size(96, 22);
            ConnectButton.StyleController = layoutControl1;
            ConnectButton.TabIndex = 3;
            ConnectButton.Text = "Подключиться";
            // 
            // FindFileButton
            // 
            FindFileButton.Location = new System.Drawing.Point(390, 52);
            FindFileButton.Name = "FindFileButton";
            FindFileButton.Size = new System.Drawing.Size(96, 22);
            FindFileButton.StyleController = layoutControl1;
            FindFileButton.TabIndex = 5;
            FindFileButton.Text = "Найти файл";
            // 
            // IpEdit
            // 
            IpEdit.EditValue = "";
            IpEdit.Location = new System.Drawing.Point(222, 28);
            IpEdit.Name = "IpEdit";
            IpEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.RegExpMaskManager));
            IpEdit.Properties.MaskSettings.Set("MaskManagerSignature", "isOptimistic=False");
            IpEdit.Properties.MaskSettings.Set("mask", "(([01]?[0-9]?[0-9])|(2[0-4][0-9])|(25[0-5]))\\.(([01]?[0-9]?[0-9])|(2[0-4][0-9])|(25[0-5]))\\.(([01]?[0-9]?[0-9])|(2[0-4][0-9])|(25[0-5]))\\.(([01]?[0-9]?[0-9])|(2[0-4][0-9])|(25[0-5]))");
            IpEdit.Size = new System.Drawing.Size(164, 20);
            IpEdit.StyleController = layoutControl1;
            IpEdit.TabIndex = 0;
            // 
            // ServerStatusLabel
            // 
            ServerStatusLabel.Location = new System.Drawing.Point(590, 12);
            ServerStatusLabel.Name = "ServerStatusLabel";
            ServerStatusLabel.Size = new System.Drawing.Size(80, 13);
            ServerStatusLabel.StyleController = layoutControl1;
            ServerStatusLabel.TabIndex = 1;
            ServerStatusLabel.Text = "Статус сервера";
            // 
            // SendMessageButton
            // 
            SendMessageButton.Location = new System.Drawing.Point(490, 52);
            SendMessageButton.Name = "SendMessageButton";
            SendMessageButton.Size = new System.Drawing.Size(96, 22);
            SendMessageButton.StyleController = layoutControl1;
            SendMessageButton.TabIndex = 6;
            SendMessageButton.Text = "Отправить";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem4, layoutControlItem7, layoutControlItem6, layoutControlItem5, layoutControlItem2, layoutControlItem3, layoutControlItem8, layoutControlItem9 });
            Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            Root.Name = "Root";
            columnDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition1.Width = 25D;
            columnDefinition2.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition2.Width = 20D;
            columnDefinition3.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition3.Width = 100D;
            columnDefinition4.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition4.Width = 100D;
            columnDefinition5.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition5.Width = 10D;
            columnDefinition6.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition6.Width = 25D;
            Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] { columnDefinition1, columnDefinition2, columnDefinition3, columnDefinition4, columnDefinition5, columnDefinition6 });
            rowDefinition1.Height = 40D;
            rowDefinition1.SizeType = System.Windows.Forms.SizeType.AutoSize;
            rowDefinition2.Height = 40D;
            rowDefinition2.SizeType = System.Windows.Forms.SizeType.AutoSize;
            rowDefinition3.Height = 17D;
            rowDefinition3.SizeType = System.Windows.Forms.SizeType.AutoSize;
            rowDefinition4.Height = 100D;
            rowDefinition4.SizeType = System.Windows.Forms.SizeType.Percent;
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition1, rowDefinition2, rowDefinition3, rowDefinition4 });
            Root.Size = new System.Drawing.Size(892, 408);
            Root.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = IpEdit;
            layoutControlItem4.Location = new System.Drawing.Point(210, 0);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.OptionsTableLayoutItem.ColumnIndex = 1;
            layoutControlItem4.Size = new System.Drawing.Size(168, 40);
            layoutControlItem4.Text = "Ip";
            layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem4.TextSize = new System.Drawing.Size(58, 13);
            // 
            // layoutControlItem7
            // 
            layoutControlItem7.Control = MessageEdit;
            layoutControlItem7.Location = new System.Drawing.Point(210, 40);
            layoutControlItem7.Name = "layoutControlItem7";
            layoutControlItem7.OptionsTableLayoutItem.ColumnIndex = 1;
            layoutControlItem7.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem7.Size = new System.Drawing.Size(168, 40);
            layoutControlItem7.Text = "Сообщение";
            layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem7.TextSize = new System.Drawing.Size(58, 13);
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            layoutControlItem6.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            layoutControlItem6.Control = ServerResponseLabel;
            layoutControlItem6.Location = new System.Drawing.Point(210, 80);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.OptionsTableLayoutItem.ColumnIndex = 1;
            layoutControlItem6.OptionsTableLayoutItem.ColumnSpan = 4;
            layoutControlItem6.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem6.Size = new System.Drawing.Size(452, 17);
            layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = FindFileButton;
            layoutControlItem5.Location = new System.Drawing.Point(378, 40);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.OptionsTableLayoutItem.ColumnIndex = 2;
            layoutControlItem5.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem5.Size = new System.Drawing.Size(100, 40);
            layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = SendMessageButton;
            layoutControlItem2.Location = new System.Drawing.Point(478, 40);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.OptionsTableLayoutItem.ColumnIndex = 3;
            layoutControlItem2.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem2.Size = new System.Drawing.Size(100, 40);
            layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = ServerStatusLabel;
            layoutControlItem3.Location = new System.Drawing.Point(578, 0);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.OptionsTableLayoutItem.ColumnIndex = 4;
            layoutControlItem3.Size = new System.Drawing.Size(84, 40);
            layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            layoutControlItem8.Control = ConnectButton;
            layoutControlItem8.Location = new System.Drawing.Point(478, 0);
            layoutControlItem8.Name = "layoutControlItem8";
            layoutControlItem8.OptionsTableLayoutItem.ColumnIndex = 3;
            layoutControlItem8.Size = new System.Drawing.Size(100, 40);
            layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            layoutControlItem9.Control = PortEdit;
            layoutControlItem9.Location = new System.Drawing.Point(378, 0);
            layoutControlItem9.Name = "layoutControlItem9";
            layoutControlItem9.OptionsTableLayoutItem.ColumnIndex = 2;
            layoutControlItem9.Size = new System.Drawing.Size(100, 40);
            layoutControlItem9.Text = "Порт";
            layoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem9.TextSize = new System.Drawing.Size(58, 13);
            // 
            // ClientUserControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "ClientUserControl";
            Size = new System.Drawing.Size(776, 425);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PortEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)MessageEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)IpEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem9).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DevExpress.Utils.Layout.StackPanel ConnectionPanel;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton FindFileButton;
        private DevExpress.XtraEditors.TextEdit IpEdit;
        private DevExpress.XtraEditors.LabelControl ServerStatusLabel;
        private DevExpress.XtraEditors.SimpleButton SendMessageButton;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit MessageEdit;
        private DevExpress.XtraEditors.SimpleButton ConnectButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.LabelControl ServerResponseLabel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SpinEdit PortEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
    }
}
