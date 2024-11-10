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
            stackPanel1 = new DevExpress.Utils.Layout.StackPanel();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            SelectClientButton = new DevExpress.XtraEditors.SimpleButton();
            SelectServerButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).BeginInit();
            stackPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // stackPanel1
            // 
            stackPanel1.Controls.Add(labelControl1);
            stackPanel1.Controls.Add(SelectClientButton);
            stackPanel1.Controls.Add(SelectServerButton);
            stackPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            stackPanel1.LayoutDirection = DevExpress.Utils.Layout.StackPanelLayoutDirection.TopDown;
            stackPanel1.Location = new System.Drawing.Point(0, 0);
            stackPanel1.Name = "stackPanel1";
            stackPanel1.Size = new System.Drawing.Size(150, 150);
            stackPanel1.TabIndex = 1;
            stackPanel1.UseSkinIndents = true;
            // 
            // labelControl1
            // 
            labelControl1.Location = new System.Drawing.Point(7, 12);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(136, 13);
            labelControl1.TabIndex = 2;
            labelControl1.Text = "Выберите тип приложения";
            // 
            // SelectClientButton
            // 
            SelectClientButton.Location = new System.Drawing.Point(47, 29);
            SelectClientButton.Name = "SelectClientButton";
            SelectClientButton.Size = new System.Drawing.Size(56, 22);
            SelectClientButton.TabIndex = 1;
            SelectClientButton.Text = "Клиент";
            SelectClientButton.Click += SelectClientButton_Click;
            // 
            // SelectServerButton
            // 
            SelectServerButton.Location = new System.Drawing.Point(45, 55);
            SelectServerButton.Name = "SelectServerButton";
            SelectServerButton.Size = new System.Drawing.Size(60, 23);
            SelectServerButton.TabIndex = 0;
            SelectServerButton.Text = "Сервер";
            SelectServerButton.Click += SelectServerButton_Click;
            // 
            // AppTypeSelectionUserControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(stackPanel1);
            Name = "AppTypeSelectionUserControl";
            ((System.ComponentModel.ISupportInitialize)stackPanel1).EndInit();
            stackPanel1.ResumeLayout(false);
            stackPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton SelectClientButton;
        private DevExpress.XtraEditors.SimpleButton SelectServerButton;
    }
}
