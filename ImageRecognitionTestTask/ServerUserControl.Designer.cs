namespace ImageRecognitionTestTask
{
    partial class ServerUserControl
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
            hSmartWindowControl1 = new HalconDotNet.HSmartWindowControl();
            StopServerButton = new DevExpress.XtraEditors.SimpleButton();
            LogEdit = new DevExpress.XtraEditors.MemoEdit();
            PortEdit = new DevExpress.XtraEditors.SpinEdit();
            RunServerButton = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LogEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PortEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(labelControl1);
            layoutControl1.Controls.Add(hSmartWindowControl1);
            layoutControl1.Controls.Add(StopServerButton);
            layoutControl1.Controls.Add(LogEdit);
            layoutControl1.Controls.Add(PortEdit);
            layoutControl1.Controls.Add(RunServerButton);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2755, 74, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(611, 423);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // hSmartWindowControl1
            // 
            hSmartWindowControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            hSmartWindowControl1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            hSmartWindowControl1.HDoubleClickToFitContent = true;
            hSmartWindowControl1.HDrawingObjectsModifier = HalconDotNet.HSmartWindowControl.DrawingObjectsModifier.None;
            hSmartWindowControl1.HImagePart = new System.Drawing.Rectangle(185, 84, 268, 310);
            hSmartWindowControl1.HKeepAspectRatio = true;
            hSmartWindowControl1.HMoveContent = true;
            hSmartWindowControl1.HZoomContent = HalconDotNet.HSmartWindowControl.ZoomContent.WheelForwardZoomsIn;
            hSmartWindowControl1.Location = new System.Drawing.Point(12, 81);
            hSmartWindowControl1.Margin = new System.Windows.Forms.Padding(0);
            hSmartWindowControl1.Name = "hSmartWindowControl1";
            hSmartWindowControl1.Size = new System.Drawing.Size(214, 330);
            hSmartWindowControl1.TabIndex = 8;
            hSmartWindowControl1.WindowSize = new System.Drawing.Size(214, 330);
            // 
            // StopServerButton
            // 
            StopServerButton.Location = new System.Drawing.Point(108, 38);
            StopServerButton.Name = "StopServerButton";
            StopServerButton.Size = new System.Drawing.Size(491, 22);
            StopServerButton.StyleController = layoutControl1;
            StopServerButton.TabIndex = 7;
            StopServerButton.Text = "Остановить";
            // 
            // LogEdit
            // 
            LogEdit.Location = new System.Drawing.Point(230, 64);
            LogEdit.Name = "LogEdit";
            LogEdit.Size = new System.Drawing.Size(369, 347);
            LogEdit.StyleController = layoutControl1;
            LogEdit.TabIndex = 6;
            // 
            // PortEdit
            // 
            PortEdit.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            PortEdit.Location = new System.Drawing.Point(12, 34);
            PortEdit.Name = "PortEdit";
            PortEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            PortEdit.Properties.MaskSettings.Set("mask", "d");
            PortEdit.Properties.MaxValue = new decimal(new int[] { 65535, 0, 0, 0 });
            PortEdit.Size = new System.Drawing.Size(92, 20);
            PortEdit.StyleController = layoutControl1;
            PortEdit.TabIndex = 5;
            // 
            // RunServerButton
            // 
            RunServerButton.Location = new System.Drawing.Point(108, 12);
            RunServerButton.Name = "RunServerButton";
            RunServerButton.Size = new System.Drawing.Size(491, 22);
            RunServerButton.StyleController = layoutControl1;
            RunServerButton.TabIndex = 4;
            RunServerButton.Text = "Запуск";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4, layoutControlItem5, layoutControlItem6 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(611, 423);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            layoutControlItem1.Control = RunServerButton;
            layoutControlItem1.Location = new System.Drawing.Point(96, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(495, 26);
            layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            layoutControlItem2.Control = PortEdit;
            layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(96, 52);
            layoutControlItem2.Text = "Порт";
            layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem2.TextSize = new System.Drawing.Size(25, 13);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = LogEdit;
            layoutControlItem3.Location = new System.Drawing.Point(218, 52);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(373, 351);
            layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = StopServerButton;
            layoutControlItem4.Location = new System.Drawing.Point(96, 26);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new System.Drawing.Size(495, 26);
            layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = hSmartWindowControl1;
            layoutControlItem5.Location = new System.Drawing.Point(0, 69);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new System.Drawing.Size(218, 334);
            layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem5.TextVisible = false;
            // 
            // labelControl1
            // 
            labelControl1.Location = new System.Drawing.Point(12, 64);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(214, 13);
            labelControl1.StyleController = layoutControl1;
            labelControl1.TabIndex = 9;
            labelControl1.Text = "labelControl1";
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.Control = labelControl1;
            layoutControlItem6.Location = new System.Drawing.Point(0, 52);
            layoutControlItem6.MinSize = new System.Drawing.Size(67, 17);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.Size = new System.Drawing.Size(218, 17);
            layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem6.TextVisible = false;
            // 
            // ServerUserControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(layoutControl1);
            Name = "ServerUserControl";
            Size = new System.Drawing.Size(611, 423);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LogEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)PortEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton RunServerButton;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SpinEdit PortEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.MemoEdit LogEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton StopServerButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private HalconDotNet.HSmartWindowControl hSmartWindowControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}
