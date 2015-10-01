using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Management;
using System.Globalization;


namespace BackupWiz
{
    public partial class FormB : Form
    {

        TreeNode Trn = new TreeNode();
        IList<string> DirList = new List<string>();
        public FormB()
        {
            InitializeComponent();
        }




        private void FormB_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            FileSync Fs = new FileSync();
            foreach (string s in DirList)
            {
                Fs.Backup(s);
            }

            
        }

        private void browser1_SelectedFolderChanged(object sender, FileBrowser.SelectedFolderChangedEventArgs e)
        {


             //PopulateFiles(e.Node);
            //Trn = e.Node;
            //string path = e.Node.


            //string n = e.Node.Text;
            //Trn = e.Node.Parent;
            //if (Trn != null)
            //{
            //    foreach (TreeNode aNode in Trn.Nodes)
            //    {
            //        if (aNode.Checked)
            //        {
            //            if (!DirList.Contains(e.Path))
            //                DirList.Add(e.Path);
            //        }

            //    }
            //}
            
        }


        private void browser1_AfterCheck(object sender, FileBrowser.SelectedFolderChangedEventArgs e)
        {
            if (!DirList.Contains(e.Path))
                DirList.Add(e.Path);

        }


        //List View Management

        protected void InitListView()
        {
            //init ListView control
            ListView1.Clear();		//clear control
            //create column header for ListView
            ListView1.Columns.Add("Name", 150, System.Windows.Forms.HorizontalAlignment.Left);
            ListView1.Columns.Add("Size", 75, System.Windows.Forms.HorizontalAlignment.Right);
            ListView1.Columns.Add("Created", 140, System.Windows.Forms.HorizontalAlignment.Left);
            ListView1.Columns.Add("Modified", 140, System.Windows.Forms.HorizontalAlignment.Left);

        }


        	protected string GetPathName(string stringPath)
		{
			//Get Name of folder
			string[] stringSplit = stringPath.Split('\\');
			int _maxIndex = stringSplit.Length;
			return stringSplit[_maxIndex-1];
		}

		protected void PopulateFiles(TreeNode nodeCurrent)
		{
			//Populate listview with files
			string[] lvData =  new string[4];
			
			//clear list
			InitListView();

			if (nodeCurrent.SelectedImageIndex != 0) 
			{
				//check path
				if(Directory.Exists((string) getFullPath(nodeCurrent.FullPath)) == false)
				{
					MessageBox.Show("Directory or path " + nodeCurrent.ToString() + " does not exist.");
				}
				else
				{
					try
					{
						string[] stringFiles = Directory.GetFiles(getFullPath(nodeCurrent.FullPath));
						string stringFileName = "";
						DateTime dtCreateDate, dtModifyDate;
						Int64 lFileSize = 0;

						//loop throught all files
						foreach (string stringFile in stringFiles)
						{
							stringFileName = stringFile;
							FileInfo objFileSize = new FileInfo(stringFileName);
							lFileSize = objFileSize.Length;
							dtCreateDate = objFileSize.CreationTime; //GetCreationTime(stringFileName);
							dtModifyDate = objFileSize.LastWriteTime; //GetLastWriteTime(stringFileName);

							//create listview data
							lvData[0] = GetPathName(stringFileName);
							lvData[1] = formatSize(lFileSize);
							
							//check if file is in local current day light saving time
							if (TimeZone.CurrentTimeZone.IsDaylightSavingTime(dtCreateDate) == false)
							{
								//not in day light saving time adjust time
								lvData[2] = formatDate(dtCreateDate.AddHours(1));
							}
							else
							{
								//is in day light saving time adjust time
								lvData[2] = formatDate(dtCreateDate);
							}

							//check if file is in local current day light saving time
							if (TimeZone.CurrentTimeZone.IsDaylightSavingTime(dtModifyDate) == false)
							{
								//not in day light saving time adjust time
								lvData[3] = formatDate(dtModifyDate.AddHours(1));
							}
							else							
							{
								//not in day light saving time adjust time
								lvData[3] = formatDate(dtModifyDate);
							}


							//Create actual list item
							ListViewItem lvItem = new ListViewItem(lvData,0);
							ListView1.Items.Add(lvItem);

							
						}
					}
					catch (IOException e)
					{
						MessageBox.Show("Error: Drive not ready or directory does not exist.");
					}
					catch (UnauthorizedAccessException e)
					{
						MessageBox.Show("Error: Drive or directory access denided.");
					}
					catch (Exception e)
					{
						MessageBox.Show("Error: " + e);
					}
				}
			}
		}

		protected string getFullPath(string stringPath)
		{
			//Get Full path
			string stringParse = "";
			//remove My Computer from path.
			stringParse = stringPath.Replace("My Computer\\", "");

			return stringParse;
		}
		
		protected ManagementObjectCollection getDrives()
		{
			//get drive collection
			ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * From Win32_LogicalDisk ");
			ManagementObjectCollection queryCollection = query.Get();
			
			return queryCollection;
		}

		protected string formatDate(DateTime dtDate)
		{
			//Get date and time in short format
			string stringDate = "";

			stringDate = dtDate.ToShortDateString().ToString() + " " + dtDate.ToShortTimeString().ToString();

			return stringDate;
		}

		protected string formatSize(Int64 lSize)
		{
			//Format number to KB
			string stringSize = "";
			NumberFormatInfo myNfi = new NumberFormatInfo();

			Int64 lKBSize = 0;

			if (lSize < 1024 ) 
			{
				if (lSize == 0) 
				{
					//zero byte
					stringSize = "0";
				}
				else 
				{
					//less than 1K but not zero byte
					stringSize = "1";
				}
			}
			else 
			{
				//convert to KB
				lKBSize = lSize / 1024;
				//format number with default format
				stringSize = lKBSize.ToString("n",myNfi);
				//remove decimal
				stringSize = stringSize.Replace(".00", "");
			}

			return stringSize + " KB";

		}


 
    }
}
