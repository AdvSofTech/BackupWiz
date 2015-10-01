using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FileBrowser;
using ShellDll;
using System.Runtime.InteropServices;
using System.IO;

namespace TestApp
{
    public partial class FileBrowserTest : Form
    {
        public FileBrowserTest()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            fileBrowser1.StartUpDirectory = SpecialFolders.Other;
            fileBrowser1.StartUpDirectoryOther = "c:\\users\\max\\cookies"; Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
        }

        private void fileBrowser_ContextMenuMouseHover(object sender, ContextMenuMouseHoverEventArgs e)
        {
            helpInfoLabel.Text = e.ContextMenuItemInfo;
        }

        private void fileBrowser_SelectedFolderChanged(object sender, SelectedFolderChangedEventArgs e)
        {
            Icon icon = ShellImageList.GetIcon(e.Node.ImageIndex, true);

            if (icon != null)
            {
                currentDirInfo.Image = icon.ToBitmap();
                this.Icon = icon;
            }
            else
            {
                currentDirInfo.Image = null;
                this.Icon = null;
            }

            currentDirInfo.Text = e.Node.Text;
            this.Text = e.Node.Text;
        }
    }
}