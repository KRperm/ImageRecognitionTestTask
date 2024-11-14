namespace ImageRecognitionTestTask
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DocumentManager = new DevExpress.XtraBars.Docking2010.DocumentManager(components);
            windowsuiView1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView(components);
            tileContainer1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.TileContainer(components);
            document1Tile = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile(components);
            document1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(components);
            document2Tile = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile(components);
            document2 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(components);
            ((System.ComponentModel.ISupportInitialize)DocumentManager).BeginInit();
            ((System.ComponentModel.ISupportInitialize)windowsuiView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tileContainer1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)document1Tile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)document1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)document2Tile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)document2).BeginInit();
            SuspendLayout();
            // 
            // DocumentManager
            // 
            DocumentManager.ContainerControl = this;
            DocumentManager.View = windowsuiView1;
            DocumentManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] { windowsuiView1 });
            // 
            // windowsuiView1
            // 
            windowsuiView1.AllowCaptionDragMove = DevExpress.Utils.DefaultBoolean.False;
            windowsuiView1.Caption = "Режимы приложения";
            windowsuiView1.ContentContainers.AddRange(new DevExpress.XtraBars.Docking2010.Views.WindowsUI.IContentContainer[] { tileContainer1 });
            windowsuiView1.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] { document1, document2 });
            windowsuiView1.SearchPanelProperties.Enabled = false;
            windowsuiView1.TileContainerProperties.AllowDrag = false;
            windowsuiView1.TileContainerProperties.AllowDragTilesBetweenGroups = false;
            windowsuiView1.TileContainerProperties.AllowGroupHighlighting = true;
            windowsuiView1.TileContainerProperties.ItemTextShowMode = DevExpress.XtraEditors.TileItemContentShowMode.Always;
            windowsuiView1.TileContainerProperties.ShowContextActionBarOnActivating = true;
            windowsuiView1.TileContainerProperties.ShowText = true;
            windowsuiView1.TileContainerProperties.VerticalContentAlignment = DevExpress.Utils.VertAlignment.Center;
            windowsuiView1.TileProperties.AllowCheck = false;
            windowsuiView1.TileProperties.ItemSize = DevExpress.XtraEditors.TileItemSize.Small;
            windowsuiView1.TileProperties.TextShowMode = DevExpress.XtraEditors.TileItemContentShowMode.Always;
            windowsuiView1.Tiles.AddRange(new DevExpress.XtraBars.Docking2010.Views.WindowsUI.BaseTile[] { document1Tile, document2Tile });
            // 
            // tileContainer1
            // 
            tileContainer1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.WindowsUI.BaseTile[] { document1Tile, document2Tile });
            tileContainer1.Name = "tileContainer1";
            tileContainer1.Properties.LayoutMode = DevExpress.XtraEditors.TileControlLayoutMode.Adaptive;
            // 
            // document1Tile
            // 
            document1Tile.Document = document1;
            tileItemElement1.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 13F);
            tileItemElement1.Appearance.Normal.Options.UseFont = true;
            tileItemElement1.Text = "Клиент";
            tileItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            document1Tile.Elements.Add(tileItemElement1);
            document1Tile.Group = "Режимы";
            document1Tile.Name = "document1Tile";
            document1Tile.Properties.ItemSize = DevExpress.XtraEditors.TileItemSize.Small;
            document1Tile.Properties.TextShowMode = DevExpress.XtraEditors.TileItemContentShowMode.Default;
            // 
            // document1
            // 
            document1.Caption = "Клиент";
            document1.ControlName = "document1";
            document1.ControlType = typeof(ClientUserControl);
            document1.Footer = "Клиент";
            document1.Header = "Клиент";
            // 
            // document2Tile
            // 
            document2Tile.Document = document2;
            tileItemElement2.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 13F);
            tileItemElement2.Appearance.Normal.Options.UseFont = true;
            tileItemElement2.Text = "Сервер";
            tileItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            document2Tile.Elements.Add(tileItemElement2);
            document2Tile.Group = "Режимы";
            document2Tile.Name = "document2Tile";
            document2Tile.Properties.AllowCheck = DevExpress.Utils.DefaultBoolean.False;
            document2Tile.Properties.TextShowMode = DevExpress.XtraEditors.TileItemContentShowMode.Default;
            // 
            // document2
            // 
            document2.Caption = "Сервер";
            document2.ControlName = "document2";
            document2.ControlType = typeof(ServerUserControl);
            document2.Header = "Сервер";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(882, 420);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)DocumentManager).EndInit();
            ((System.ComponentModel.ISupportInitialize)windowsuiView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tileContainer1).EndInit();
            ((System.ComponentModel.ISupportInitialize)document1Tile).EndInit();
            ((System.ComponentModel.ISupportInitialize)document1).EndInit();
            ((System.ComponentModel.ISupportInitialize)document2Tile).EndInit();
            ((System.ComponentModel.ISupportInitialize)document2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraBars.Docking2010.DocumentManager DocumentManager;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView windowsuiView1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document document1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document document2;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.TileContainer tileContainer1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile document1Tile;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile document2Tile;
    }
}