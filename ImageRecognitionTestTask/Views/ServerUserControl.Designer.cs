using ImageRecognitionTestTask.Database;

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
            PictureEdit = new DevExpress.XtraEditors.PictureEdit();
            ObjectCountLabel = new DevExpress.XtraEditors.LabelControl();
            ImagesList = new DevExpress.XtraEditors.ListBoxControl();
            StopServerButton = new DevExpress.XtraEditors.SimpleButton();
            LogEdit = new DevExpress.XtraEditors.MemoEdit();
            PortEdit = new DevExpress.XtraEditors.SpinEdit();
            RunServerButton = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ImagesList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LogEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PortEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabbedControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitterItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(PictureEdit);
            layoutControl1.Controls.Add(ObjectCountLabel);
            layoutControl1.Controls.Add(ImagesList);
            layoutControl1.Controls.Add(StopServerButton);
            layoutControl1.Controls.Add(LogEdit);
            layoutControl1.Controls.Add(PortEdit);
            layoutControl1.Controls.Add(RunServerButton);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2500, 282, 650, 400);
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(611, 423);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // PictureEdit
            // 
            PictureEdit.Location = new System.Drawing.Point(155, 104);
            PictureEdit.Name = "PictureEdit";
            PictureEdit.Properties.NullText = "Изображение не найдено";
            PictureEdit.Properties.ReadOnly = true;
            PictureEdit.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            PictureEdit.Properties.ShowMenu = false;
            PictureEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            PictureEdit.Size = new System.Drawing.Size(432, 295);
            PictureEdit.StyleController = layoutControl1;
            PictureEdit.TabIndex = 8;
            // 
            // ObjectCountLabel
            // 
            ObjectCountLabel.Location = new System.Drawing.Point(155, 87);
            ObjectCountLabel.Name = "ObjectCountLabel";
            ObjectCountLabel.Size = new System.Drawing.Size(432, 13);
            ObjectCountLabel.StyleController = layoutControl1;
            ObjectCountLabel.TabIndex = 7;
            ObjectCountLabel.Text = "labelControl1";
            // 
            // ImagesList
            // 
            ImagesList.DataSource = typeof(ImageRecord);
            ImagesList.DisplayMember = "Path";
            ImagesList.Location = new System.Drawing.Point(24, 87);
            ImagesList.Name = "ImagesList";
            ImagesList.Size = new System.Drawing.Size(117, 312);
            ImagesList.StyleController = layoutControl1;
            ImagesList.TabIndex = 5;
            ImagesList.ValueMember = "Id";
            // 
            // StopServerButton
            // 
            StopServerButton.Location = new System.Drawing.Point(165, 19);
            StopServerButton.Name = "StopServerButton";
            StopServerButton.Size = new System.Drawing.Size(77, 22);
            StopServerButton.StyleController = layoutControl1;
            StopServerButton.TabIndex = 3;
            StopServerButton.Text = "Остановить";
            // 
            // LogEdit
            // 
            LogEdit.Location = new System.Drawing.Point(24, 87);
            LogEdit.Name = "LogEdit";
            LogEdit.Properties.ReadOnly = true;
            LogEdit.Size = new System.Drawing.Size(563, 312);
            LogEdit.StyleController = layoutControl1;
            LogEdit.TabIndex = 1;
            // 
            // PortEdit
            // 
            PortEdit.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            PortEdit.Location = new System.Drawing.Point(12, 28);
            PortEdit.Name = "PortEdit";
            PortEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            PortEdit.Properties.MaskSettings.Set("mask", "d");
            PortEdit.Properties.MaxValue = new decimal(new int[] { 65535, 0, 0, 0 });
            PortEdit.Size = new System.Drawing.Size(94, 20);
            PortEdit.StyleController = layoutControl1;
            PortEdit.TabIndex = 0;
            // 
            // RunServerButton
            // 
            RunServerButton.Location = new System.Drawing.Point(110, 19);
            RunServerButton.Name = "RunServerButton";
            RunServerButton.Size = new System.Drawing.Size(51, 22);
            RunServerButton.StyleController = layoutControl1;
            RunServerButton.TabIndex = 2;
            RunServerButton.Text = "Запуск";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem2, tabbedControlGroup1, layoutControlItem4, layoutControlItem1, emptySpaceItem1 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(611, 423);
            Root.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            layoutControlItem2.Control = PortEdit;
            layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            layoutControlItem2.MaxSize = new System.Drawing.Size(98, 40);
            layoutControlItem2.MinSize = new System.Drawing.Size(98, 40);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(98, 40);
            layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem2.Text = "Порт";
            layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem2.TextSize = new System.Drawing.Size(25, 13);
            // 
            // tabbedControlGroup1
            // 
            tabbedControlGroup1.Location = new System.Drawing.Point(0, 40);
            tabbedControlGroup1.Name = "tabbedControlGroup1";
            tabbedControlGroup1.SelectedTabPage = layoutControlGroup1;
            tabbedControlGroup1.Size = new System.Drawing.Size(591, 363);
            tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlGroup2, layoutControlGroup1 });
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { splitterItem1, layoutControlItem6, layoutControlItem7, layoutControlItem5 });
            layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            layoutControlGroup1.Name = "layoutControlGroup1";
            layoutControlGroup1.Size = new System.Drawing.Size(567, 316);
            layoutControlGroup1.Text = "Изображения";
            // 
            // splitterItem1
            // 
            splitterItem1.AllowHotTrack = true;
            splitterItem1.Location = new System.Drawing.Point(121, 0);
            splitterItem1.Name = "splitterItem1";
            splitterItem1.Size = new System.Drawing.Size(10, 316);
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.Control = ImagesList;
            layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.Size = new System.Drawing.Size(121, 316);
            layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            layoutControlItem7.Control = ObjectCountLabel;
            layoutControlItem7.Location = new System.Drawing.Point(131, 0);
            layoutControlItem7.MaxSize = new System.Drawing.Size(0, 17);
            layoutControlItem7.MinSize = new System.Drawing.Size(67, 17);
            layoutControlItem7.Name = "layoutControlItem7";
            layoutControlItem7.Size = new System.Drawing.Size(436, 17);
            layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = PictureEdit;
            layoutControlItem5.Location = new System.Drawing.Point(131, 17);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new System.Drawing.Size(436, 299);
            layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem5.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem3 });
            layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            layoutControlGroup2.Name = "layoutControlGroup2";
            layoutControlGroup2.Size = new System.Drawing.Size(567, 316);
            layoutControlGroup2.Text = "Логи";
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = LogEdit;
            layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(567, 316);
            layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            layoutControlItem4.Control = StopServerButton;
            layoutControlItem4.Location = new System.Drawing.Point(153, 0);
            layoutControlItem4.MaxSize = new System.Drawing.Size(81, 40);
            layoutControlItem4.MinSize = new System.Drawing.Size(81, 40);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new System.Drawing.Size(81, 40);
            layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            layoutControlItem1.Control = RunServerButton;
            layoutControlItem1.Location = new System.Drawing.Point(98, 0);
            layoutControlItem1.MaxSize = new System.Drawing.Size(55, 40);
            layoutControlItem1.MinSize = new System.Drawing.Size(55, 40);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(55, 40);
            layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.AllowHotTrack = false;
            emptySpaceItem1.Location = new System.Drawing.Point(234, 0);
            emptySpaceItem1.MaxSize = new System.Drawing.Size(0, 40);
            emptySpaceItem1.MinSize = new System.Drawing.Size(10, 40);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new System.Drawing.Size(357, 40);
            emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
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
            ((System.ComponentModel.ISupportInitialize)PictureEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ImagesList).EndInit();
            ((System.ComponentModel.ISupportInitialize)LogEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)PortEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabbedControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitterItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
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
        private DevExpress.XtraEditors.SimpleButton StopServerButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.ListBoxControl ImagesList;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.LabelControl ObjectCountLabel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.PictureEdit PictureEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}
