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
            tablePanel2 = new DevExpress.Utils.Layout.TablePanel();
            ConnectButton = new DevExpress.XtraEditors.SimpleButton();
            ConnectTextEdit = new DevExpress.XtraEditors.TextEdit();
            MessagePanel = new DevExpress.Utils.Layout.TablePanel();
            SendMessageButton = new DevExpress.XtraEditors.SimpleButton();
            SelectPathButton = new DevExpress.XtraEditors.SimpleButton();
            MessageTextEdit = new DevExpress.XtraEditors.TextEdit();
            ResponseLabel = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).BeginInit();
            stackPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tablePanel2).BeginInit();
            tablePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ConnectTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MessagePanel).BeginInit();
            MessagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MessageTextEdit.Properties).BeginInit();
            SuspendLayout();
            // 
            // stackPanel1
            // 
            stackPanel1.AutoSize = true;
            stackPanel1.Controls.Add(tablePanel2);
            stackPanel1.Controls.Add(MessagePanel);
            stackPanel1.Controls.Add(ResponseLabel);
            stackPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            stackPanel1.LayoutDirection = DevExpress.Utils.Layout.StackPanelLayoutDirection.TopDown;
            stackPanel1.Location = new System.Drawing.Point(0, 0);
            stackPanel1.Name = "stackPanel1";
            stackPanel1.Size = new System.Drawing.Size(475, 276);
            stackPanel1.TabIndex = 0;
            stackPanel1.UseSkinIndents = true;
            // 
            // tablePanel2
            // 
            tablePanel2.AutoSize = true;
            tablePanel2.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 200F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 70F) });
            tablePanel2.Controls.Add(ConnectButton);
            tablePanel2.Controls.Add(ConnectTextEdit);
            tablePanel2.Location = new System.Drawing.Point(57, 12);
            tablePanel2.Name = "tablePanel2";
            tablePanel2.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F) });
            tablePanel2.Size = new System.Drawing.Size(361, 48);
            tablePanel2.TabIndex = 4;
            tablePanel2.UseSkinIndents = true;
            // 
            // ConnectButton
            // 
            tablePanel2.SetColumn(ConnectButton, 1);
            ConnectButton.Location = new System.Drawing.Point(264, 12);
            ConnectButton.Name = "ConnectButton";
            tablePanel2.SetRow(ConnectButton, 0);
            ConnectButton.Size = new System.Drawing.Size(84, 23);
            ConnectButton.TabIndex = 1;
            ConnectButton.Text = "Подключиться";
            ConnectButton.Click += ConnectButton_Click;
            // 
            // ConnectTextEdit
            // 
            tablePanel2.SetColumn(ConnectTextEdit, 0);
            ConnectTextEdit.Location = new System.Drawing.Point(13, 13);
            ConnectTextEdit.Name = "ConnectTextEdit";
            tablePanel2.SetRow(ConnectTextEdit, 0);
            ConnectTextEdit.Size = new System.Drawing.Size(247, 20);
            ConnectTextEdit.TabIndex = 0;
            // 
            // MessagePanel
            // 
            MessagePanel.AutoSize = true;
            MessagePanel.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 5F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 55F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 50F) });
            MessagePanel.Controls.Add(SendMessageButton);
            MessagePanel.Controls.Add(SelectPathButton);
            MessagePanel.Controls.Add(MessageTextEdit);
            MessagePanel.Enabled = false;
            MessagePanel.Location = new System.Drawing.Point(26, 64);
            MessagePanel.Name = "MessagePanel";
            MessagePanel.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F) });
            MessagePanel.Size = new System.Drawing.Size(423, 47);
            MessagePanel.TabIndex = 3;
            MessagePanel.UseSkinIndents = true;
            // 
            // SendMessageButton
            // 
            MessagePanel.SetColumn(SendMessageButton, 2);
            SendMessageButton.Location = new System.Drawing.Point(333, 12);
            SendMessageButton.Name = "SendMessageButton";
            MessagePanel.SetRow(SendMessageButton, 0);
            SendMessageButton.Size = new System.Drawing.Size(77, 22);
            SendMessageButton.TabIndex = 2;
            SendMessageButton.Text = "Отправить";
            SendMessageButton.Click += SendMessageButton_Click;
            // 
            // SelectPathButton
            // 
            MessagePanel.SetColumn(SelectPathButton, 1);
            SelectPathButton.Location = new System.Drawing.Point(238, 12);
            SelectPathButton.Name = "SelectPathButton";
            MessagePanel.SetRow(SelectPathButton, 0);
            SelectPathButton.Size = new System.Drawing.Size(91, 22);
            SelectPathButton.TabIndex = 1;
            SelectPathButton.Text = "Найти файл";
            SelectPathButton.Click += SelectPathButton_Click;
            // 
            // MessageTextEdit
            // 
            MessagePanel.SetColumn(MessageTextEdit, 0);
            MessageTextEdit.Location = new System.Drawing.Point(13, 13);
            MessageTextEdit.Name = "MessageTextEdit";
            MessagePanel.SetRow(MessageTextEdit, 0);
            MessageTextEdit.Size = new System.Drawing.Size(221, 20);
            MessageTextEdit.TabIndex = 0;
            // 
            // ResponseLabel
            // 
            ResponseLabel.Location = new System.Drawing.Point(199, 115);
            ResponseLabel.Name = "ResponseLabel";
            ResponseLabel.Size = new System.Drawing.Size(76, 13);
            ResponseLabel.TabIndex = 2;
            ResponseLabel.Text = "Ответ сервера";
            // 
            // ClientUserControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(stackPanel1);
            Name = "ClientUserControl";
            Size = new System.Drawing.Size(475, 276);
            ((System.ComponentModel.ISupportInitialize)stackPanel1).EndInit();
            stackPanel1.ResumeLayout(false);
            stackPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tablePanel2).EndInit();
            tablePanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ConnectTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)MessagePanel).EndInit();
            MessagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MessageTextEdit.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.Utils.Layout.StackPanel ConnectionPanel;
        private DevExpress.XtraEditors.LabelControl ResponseLabel;
        private DevExpress.Utils.Layout.TablePanel tablePanel2;
        private DevExpress.XtraEditors.SimpleButton ConnectButton;
        private DevExpress.XtraEditors.TextEdit ConnectTextEdit;
        private DevExpress.Utils.Layout.TablePanel MessagePanel;
        private DevExpress.XtraEditors.SimpleButton SendMessageButton;
        private DevExpress.XtraEditors.SimpleButton SelectPathButton;
        private DevExpress.XtraEditors.TextEdit MessageTextEdit;
    }
}
