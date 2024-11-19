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
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            NameEdit = new DevExpress.XtraEditors.TextEdit();
            CancelSendMessageButton = new DevExpress.XtraEditors.SimpleButton();
            DisconnectButton = new DevExpress.XtraEditors.SimpleButton();
            PortEdit = new DevExpress.XtraEditors.SpinEdit();
            ServerResponseLabel = new DevExpress.XtraEditors.LabelControl();
            MessageEdit = new DevExpress.XtraEditors.TextEdit();
            ConnectButton = new DevExpress.XtraEditors.SimpleButton();
            FindFileButton = new DevExpress.XtraEditors.SimpleButton();
            IpEdit = new DevExpress.XtraEditors.TextEdit();
            ServerStatusLabel = new DevExpress.XtraEditors.LabelControl();
            SendMessageButton = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NameEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PortEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MessageEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IpEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitterItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator1).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(NameEdit);
            layoutControl1.Controls.Add(CancelSendMessageButton);
            layoutControl1.Controls.Add(DisconnectButton);
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
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2836, 408, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(650, 325);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // NameEdit
            // 
            NameEdit.Location = new System.Drawing.Point(12, 28);
            NameEdit.Name = "NameEdit";
            NameEdit.Size = new System.Drawing.Size(293, 20);
            NameEdit.StyleController = layoutControl1;
            NameEdit.TabIndex = 0;
            // 
            // CancelSendMessageButton
            // 
            CancelSendMessageButton.Location = new System.Drawing.Point(476, 78);
            CancelSendMessageButton.Name = "CancelSendMessageButton";
            CancelSendMessageButton.Size = new System.Drawing.Size(162, 22);
            CancelSendMessageButton.StyleController = layoutControl1;
            CancelSendMessageButton.TabIndex = 9;
            CancelSendMessageButton.Text = "Отменить отправку";
            // 
            // DisconnectButton
            // 
            DisconnectButton.Location = new System.Drawing.Point(160, 132);
            DisconnectButton.Name = "DisconnectButton";
            DisconnectButton.Size = new System.Drawing.Size(145, 22);
            DisconnectButton.StyleController = layoutControl1;
            DisconnectButton.TabIndex = 7;
            DisconnectButton.Text = "Отключиться";
            // 
            // PortEdit
            // 
            PortEdit.EditValue = new decimal(new int[] { 2100, 0, 0, 0 });
            PortEdit.Location = new System.Drawing.Point(12, 108);
            PortEdit.Name = "PortEdit";
            PortEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            PortEdit.Properties.MaskSettings.Set("mask", "d");
            PortEdit.Properties.MaxValue = new decimal(new int[] { 65535, 0, 0, 0 });
            PortEdit.Size = new System.Drawing.Size(293, 20);
            PortEdit.StyleController = layoutControl1;
            PortEdit.TabIndex = 4;
            // 
            // ServerResponseLabel
            // 
            ServerResponseLabel.Appearance.Options.UseTextOptions = true;
            ServerResponseLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            ServerResponseLabel.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            ServerResponseLabel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            ServerResponseLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            ServerResponseLabel.Location = new System.Drawing.Point(320, 104);
            ServerResponseLabel.Name = "ServerResponseLabel";
            ServerResponseLabel.Size = new System.Drawing.Size(318, 209);
            ServerResponseLabel.StyleController = layoutControl1;
            ServerResponseLabel.TabIndex = 1;
            ServerResponseLabel.Text = "Ответ";
            // 
            // MessageEdit
            // 
            MessageEdit.Location = new System.Drawing.Point(320, 28);
            MessageEdit.Name = "MessageEdit";
            MessageEdit.Size = new System.Drawing.Size(318, 20);
            MessageEdit.StyleController = layoutControl1;
            MessageEdit.TabIndex = 2;
            // 
            // ConnectButton
            // 
            ConnectButton.Location = new System.Drawing.Point(12, 132);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new System.Drawing.Size(144, 22);
            ConnectButton.StyleController = layoutControl1;
            ConnectButton.TabIndex = 6;
            ConnectButton.Text = "Подключиться";
            // 
            // FindFileButton
            // 
            FindFileButton.Location = new System.Drawing.Point(320, 52);
            FindFileButton.Name = "FindFileButton";
            FindFileButton.Size = new System.Drawing.Size(318, 22);
            FindFileButton.StyleController = layoutControl1;
            FindFileButton.TabIndex = 5;
            FindFileButton.Text = "Найти файл";
            // 
            // IpEdit
            // 
            IpEdit.EditValue = "";
            IpEdit.Location = new System.Drawing.Point(12, 68);
            IpEdit.Name = "IpEdit";
            IpEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.RegExpMaskManager));
            IpEdit.Properties.MaskSettings.Set("MaskManagerSignature", "isOptimistic=False");
            IpEdit.Properties.MaskSettings.Set("mask", "(([01]?[0-9]?[0-9])|(2[0-4][0-9])|(25[0-5]))\\.(([01]?[0-9]?[0-9])|(2[0-4][0-9])|(25[0-5]))\\.(([01]?[0-9]?[0-9])|(2[0-4][0-9])|(25[0-5]))\\.(([01]?[0-9]?[0-9])|(2[0-4][0-9])|(25[0-5]))");
            IpEdit.Size = new System.Drawing.Size(293, 20);
            IpEdit.StyleController = layoutControl1;
            IpEdit.TabIndex = 3;
            // 
            // ServerStatusLabel
            // 
            ServerStatusLabel.Appearance.Options.UseTextOptions = true;
            ServerStatusLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            ServerStatusLabel.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            ServerStatusLabel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            ServerStatusLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            ServerStatusLabel.Location = new System.Drawing.Point(12, 158);
            ServerStatusLabel.Name = "ServerStatusLabel";
            ServerStatusLabel.Size = new System.Drawing.Size(293, 155);
            ServerStatusLabel.StyleController = layoutControl1;
            ServerStatusLabel.TabIndex = 1;
            ServerStatusLabel.Text = "Статус сервера";
            // 
            // SendMessageButton
            // 
            SendMessageButton.Location = new System.Drawing.Point(320, 78);
            SendMessageButton.Name = "SendMessageButton";
            SendMessageButton.Size = new System.Drawing.Size(152, 22);
            SendMessageButton.StyleController = layoutControl1;
            SendMessageButton.TabIndex = 8;
            SendMessageButton.Text = "Отправить";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem11, layoutControlItem7, layoutControlItem4, layoutControlItem9, layoutControlItem8, layoutControlItem1, layoutControlItem3, layoutControlItem6, layoutControlItem2, layoutControlItem10, layoutControlItem5, splitterItem1, simpleSeparator1 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(650, 325);
            Root.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            layoutControlItem11.Control = NameEdit;
            layoutControlItem11.Location = new System.Drawing.Point(0, 0);
            layoutControlItem11.MaxSize = new System.Drawing.Size(0, 40);
            layoutControlItem11.MinSize = new System.Drawing.Size(62, 40);
            layoutControlItem11.Name = "layoutControlItem11";
            layoutControlItem11.OptionsTableLayoutItem.ColumnSpan = 2;
            layoutControlItem11.Size = new System.Drawing.Size(297, 40);
            layoutControlItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem11.Text = "Ваше имя";
            layoutControlItem11.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem11.TextSize = new System.Drawing.Size(58, 13);
            // 
            // layoutControlItem7
            // 
            layoutControlItem7.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            layoutControlItem7.Control = MessageEdit;
            layoutControlItem7.Location = new System.Drawing.Point(308, 0);
            layoutControlItem7.MaxSize = new System.Drawing.Size(0, 40);
            layoutControlItem7.MinSize = new System.Drawing.Size(62, 40);
            layoutControlItem7.Name = "layoutControlItem7";
            layoutControlItem7.OptionsTableLayoutItem.ColumnIndex = 2;
            layoutControlItem7.OptionsTableLayoutItem.ColumnSpan = 2;
            layoutControlItem7.OptionsTableLayoutItem.RowSpan = 2;
            layoutControlItem7.Size = new System.Drawing.Size(322, 40);
            layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem7.Text = "Сообщение";
            layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem7.TextSize = new System.Drawing.Size(58, 13);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            layoutControlItem4.Control = IpEdit;
            layoutControlItem4.Location = new System.Drawing.Point(0, 40);
            layoutControlItem4.MaxSize = new System.Drawing.Size(0, 40);
            layoutControlItem4.MinSize = new System.Drawing.Size(62, 40);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.OptionsTableLayoutItem.ColumnSpan = 2;
            layoutControlItem4.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem4.Size = new System.Drawing.Size(297, 40);
            layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem4.Text = "Ip";
            layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem4.TextSize = new System.Drawing.Size(58, 13);
            // 
            // layoutControlItem9
            // 
            layoutControlItem9.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            layoutControlItem9.Control = PortEdit;
            layoutControlItem9.Location = new System.Drawing.Point(0, 80);
            layoutControlItem9.MaxSize = new System.Drawing.Size(0, 40);
            layoutControlItem9.MinSize = new System.Drawing.Size(62, 40);
            layoutControlItem9.Name = "layoutControlItem9";
            layoutControlItem9.OptionsTableLayoutItem.ColumnSpan = 2;
            layoutControlItem9.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem9.Size = new System.Drawing.Size(297, 40);
            layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem9.Text = "Порт";
            layoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem9.TextSize = new System.Drawing.Size(58, 13);
            // 
            // layoutControlItem8
            // 
            layoutControlItem8.Control = ConnectButton;
            layoutControlItem8.Location = new System.Drawing.Point(0, 120);
            layoutControlItem8.MaxSize = new System.Drawing.Size(0, 26);
            layoutControlItem8.MinSize = new System.Drawing.Size(87, 26);
            layoutControlItem8.Name = "layoutControlItem8";
            layoutControlItem8.OptionsTableLayoutItem.RowIndex = 3;
            layoutControlItem8.Size = new System.Drawing.Size(148, 26);
            layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = DisconnectButton;
            layoutControlItem1.Location = new System.Drawing.Point(148, 120);
            layoutControlItem1.MaxSize = new System.Drawing.Size(0, 26);
            layoutControlItem1.MinSize = new System.Drawing.Size(81, 26);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.OptionsTableLayoutItem.ColumnIndex = 1;
            layoutControlItem1.OptionsTableLayoutItem.RowIndex = 3;
            layoutControlItem1.Size = new System.Drawing.Size(149, 26);
            layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = ServerStatusLabel;
            layoutControlItem3.Location = new System.Drawing.Point(0, 146);
            layoutControlItem3.MinSize = new System.Drawing.Size(84, 17);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.OptionsTableLayoutItem.ColumnSpan = 2;
            layoutControlItem3.OptionsTableLayoutItem.RowIndex = 4;
            layoutControlItem3.Size = new System.Drawing.Size(297, 159);
            layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.Control = ServerResponseLabel;
            layoutControlItem6.Location = new System.Drawing.Point(308, 92);
            layoutControlItem6.MinSize = new System.Drawing.Size(36, 17);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.OptionsTableLayoutItem.ColumnIndex = 2;
            layoutControlItem6.OptionsTableLayoutItem.ColumnSpan = 2;
            layoutControlItem6.OptionsTableLayoutItem.RowIndex = 4;
            layoutControlItem6.Size = new System.Drawing.Size(322, 213);
            layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = SendMessageButton;
            layoutControlItem2.Location = new System.Drawing.Point(308, 66);
            layoutControlItem2.MaxSize = new System.Drawing.Size(0, 26);
            layoutControlItem2.MinSize = new System.Drawing.Size(67, 26);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.OptionsTableLayoutItem.ColumnIndex = 2;
            layoutControlItem2.OptionsTableLayoutItem.RowIndex = 3;
            layoutControlItem2.Size = new System.Drawing.Size(156, 26);
            layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            layoutControlItem10.Control = CancelSendMessageButton;
            layoutControlItem10.Location = new System.Drawing.Point(464, 66);
            layoutControlItem10.MaxSize = new System.Drawing.Size(0, 26);
            layoutControlItem10.MinSize = new System.Drawing.Size(112, 26);
            layoutControlItem10.Name = "layoutControlItem10";
            layoutControlItem10.OptionsTableLayoutItem.ColumnIndex = 3;
            layoutControlItem10.OptionsTableLayoutItem.RowIndex = 3;
            layoutControlItem10.Size = new System.Drawing.Size(166, 26);
            layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem10.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = FindFileButton;
            layoutControlItem5.Location = new System.Drawing.Point(308, 40);
            layoutControlItem5.MaxSize = new System.Drawing.Size(0, 26);
            layoutControlItem5.MinSize = new System.Drawing.Size(71, 26);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.OptionsTableLayoutItem.ColumnIndex = 2;
            layoutControlItem5.OptionsTableLayoutItem.ColumnSpan = 2;
            layoutControlItem5.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem5.Size = new System.Drawing.Size(322, 26);
            layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem5.TextVisible = false;
            // 
            // splitterItem1
            // 
            splitterItem1.AllowHotTrack = true;
            splitterItem1.Location = new System.Drawing.Point(297, 0);
            splitterItem1.Name = "splitterItem1";
            splitterItem1.Size = new System.Drawing.Size(10, 305);
            // 
            // simpleSeparator1
            // 
            simpleSeparator1.AllowHotTrack = false;
            simpleSeparator1.Location = new System.Drawing.Point(307, 0);
            simpleSeparator1.Name = "simpleSeparator1";
            simpleSeparator1.Size = new System.Drawing.Size(1, 305);
            // 
            // ClientUserControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "ClientUserControl";
            Size = new System.Drawing.Size(650, 325);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NameEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)PortEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)MessageEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)IpEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem11).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem9).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem10).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitterItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator1).EndInit();
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
        private DevExpress.XtraEditors.LabelControl ServerResponseLabel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private DevExpress.XtraEditors.SpinEdit PortEdit;
        private DevExpress.XtraEditors.SimpleButton DisconnectButton;
        private DevExpress.XtraEditors.SimpleButton CancelSendMessageButton;
        private DevExpress.XtraEditors.TextEdit NameEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
    }
}
