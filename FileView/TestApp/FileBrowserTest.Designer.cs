namespace TestApp
{
    partial class FileBrowserTest
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.helpInfoLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.seperator1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.currentDirInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.fileBrowser1 = new FileBrowser.Browser();
            this.shellBrowser = new ShellDll.ShellBrowser();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpInfoLabel,
            this.seperator1,
            this.currentDirInfo});
            this.statusStrip.Location = new System.Drawing.Point(0, 477);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(406, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // helpInfoLabel
            // 
            this.helpInfoLabel.Name = "helpInfoLabel";
            this.helpInfoLabel.Size = new System.Drawing.Size(387, 17);
            this.helpInfoLabel.Spring = true;
            this.helpInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // seperator1
            // 
            this.seperator1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.seperator1.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.seperator1.Name = "seperator1";
            this.seperator1.Size = new System.Drawing.Size(4, 17);
            // 
            // currentDirInfo
            // 
            this.currentDirInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.currentDirInfo.Name = "currentDirInfo";
            this.currentDirInfo.Size = new System.Drawing.Size(0, 17);
            this.currentDirInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fileBrowser1
            // 
            this.fileBrowser1.AllowDrop = true;
            this.fileBrowser1.Dock = System.Windows.Forms.DockStyle.Left;
            this.fileBrowser1.Location = new System.Drawing.Point(0, 0);
            this.fileBrowser1.MinimumSize = new System.Drawing.Size(300, 200);
            this.fileBrowser1.Name = "fileBrowser1";
            this.fileBrowser1.SelectedNode = null;
            this.fileBrowser1.ShellBrowser = this.shellBrowser;
            this.fileBrowser1.Size = new System.Drawing.Size(300, 477);
            this.fileBrowser1.TabIndex = 2;
            this.fileBrowser1.ContextMenuMouseHover += new FileBrowser.ContextMenuMouseHoverEventHandler(this.fileBrowser_ContextMenuMouseHover);
            this.fileBrowser1.SelectedFolderChanged += new FileBrowser.SelectedFolderChangedEventHandler(this.fileBrowser_SelectedFolderChanged);
            // 
            // FileBrowserTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 499);
            this.Controls.Add(this.fileBrowser1);
            this.Controls.Add(this.statusStrip);
            this.Name = "FileBrowserTest";
            this.Text = "FileBrowser Test";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel helpInfoLabel;
        private System.Windows.Forms.ToolStripStatusLabel currentDirInfo;
        private System.Windows.Forms.ToolStripStatusLabel seperator1;
        private ShellDll.ShellBrowser shellBrowser;
        private FileBrowser.Browser fileBrowser1;
    }
}

