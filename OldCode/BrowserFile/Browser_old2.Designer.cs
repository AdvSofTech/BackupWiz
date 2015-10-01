namespace FileBrowser
{
    partial class Browser_old2
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
            this.btnOK = new System.Windows.Forms.Button();
            this.folderView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(706, 384);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "button1";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // folderView
            // 
            this.folderView.Location = new System.Drawing.Point(132, 133);
            this.folderView.Name = "folderView";
            this.folderView.Size = new System.Drawing.Size(118, 97);
            this.folderView.TabIndex = 4;
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 419);
            this.Controls.Add(this.folderView);
            this.Controls.Add(this.btnOK);
            this.Name = "Browser";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        //private FileBrowser.BrowserTreeView folderView;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TreeView folderView;
    }
}

