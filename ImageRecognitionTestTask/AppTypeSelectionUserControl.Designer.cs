namespace ImageRecognitionTestTask
{
    partial class AppTypeSelectionUserControl
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
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition4 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition5 = new DevExpress.XtraLayout.RowDefinition();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            ServerButton = new DevExpress.XtraEditors.SimpleButton();
            ClientButton = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            simpleLabelItem1 = new DevExpress.XtraLayout.SimpleLabelItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)simpleLabelItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(ServerButton);
            layoutControl1.Controls.Add(ClientButton);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2978, 168, 735, 582);
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(567, 405);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // ServerButton
            // 
            ServerButton.Location = new System.Drawing.Point(235, 213);
            ServerButton.Name = "ServerButton";
            ServerButton.Size = new System.Drawing.Size(96, 22);
            ServerButton.StyleController = layoutControl1;
            ServerButton.TabIndex = 5;
            ServerButton.Text = "Сервер";
            ServerButton.Click += SelectServerButton_Click;
            // 
            // ClientButton
            // 
            ClientButton.Location = new System.Drawing.Point(233, 187);
            ClientButton.MaximumSize = new System.Drawing.Size(100, 0);
            ClientButton.Name = "ClientButton";
            ClientButton.Size = new System.Drawing.Size(100, 22);
            ClientButton.StyleController = layoutControl1;
            ClientButton.TabIndex = 4;
            ClientButton.Text = "Клиент";
            ClientButton.Click += SelectClientButton_Click;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { simpleLabelItem1, layoutControlItem1, layoutControlItem2 });
            Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            Root.Name = "Root";
            columnDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition1.Width = 100D;
            Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] { columnDefinition1 });
            rowDefinition1.Height = 45D;
            rowDefinition1.SizeType = System.Windows.Forms.SizeType.Percent;
            rowDefinition2.Height = 17D;
            rowDefinition2.SizeType = System.Windows.Forms.SizeType.AutoSize;
            rowDefinition3.Height = 26D;
            rowDefinition3.SizeType = System.Windows.Forms.SizeType.AutoSize;
            rowDefinition4.Height = 26D;
            rowDefinition4.SizeType = System.Windows.Forms.SizeType.AutoSize;
            rowDefinition5.Height = 45D;
            rowDefinition5.SizeType = System.Windows.Forms.SizeType.Percent;
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition1, rowDefinition2, rowDefinition3, rowDefinition4, rowDefinition5 });
            Root.Size = new System.Drawing.Size(567, 405);
            Root.TextVisible = false;
            // 
            // simpleLabelItem1
            // 
            simpleLabelItem1.AllowHotTrack = false;
            simpleLabelItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            simpleLabelItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            simpleLabelItem1.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            simpleLabelItem1.Location = new System.Drawing.Point(0, 158);
            simpleLabelItem1.Name = "simpleLabelItem1";
            simpleLabelItem1.OptionsTableLayoutItem.RowIndex = 1;
            simpleLabelItem1.Size = new System.Drawing.Size(547, 17);
            simpleLabelItem1.Text = "Выберите режим";
            simpleLabelItem1.TextSize = new System.Drawing.Size(85, 13);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            layoutControlItem1.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            layoutControlItem1.Control = ClientButton;
            layoutControlItem1.Location = new System.Drawing.Point(0, 175);
            layoutControlItem1.MaxSize = new System.Drawing.Size(0, 26);
            layoutControlItem1.MinSize = new System.Drawing.Size(78, 26);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem1.Size = new System.Drawing.Size(547, 26);
            layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            layoutControlItem2.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            layoutControlItem2.Control = ServerButton;
            layoutControlItem2.Location = new System.Drawing.Point(0, 201);
            layoutControlItem2.MaxSize = new System.Drawing.Size(100, 26);
            layoutControlItem2.MinSize = new System.Drawing.Size(78, 26);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.OptionsTableLayoutItem.RowIndex = 3;
            layoutControlItem2.Size = new System.Drawing.Size(547, 26);
            layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem2.TextVisible = false;
            // 
            // AppTypeSelectionUserControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "AppTypeSelectionUserControl";
            Size = new System.Drawing.Size(567, 405);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)simpleLabelItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton ServerButton;
        private DevExpress.XtraEditors.SimpleButton ClientButton;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}
