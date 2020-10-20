using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLPConverterGUI
{
    public partial class ManForm : Form
    {
        FolderBrowserDialog sourceFolderBrowserDialog;

        public ManForm()
        {
            InitializeComponent();

            //Defaults
            txtBLPConverterPath.Text = @"C:\Repos\WOW2D\Tools\BLPConverter_8-4\BLPConverter.exe";
            //initial source directory
            sourceFolderBrowserDialog = new FolderBrowserDialog();
            sourceFolderBrowserDialog.SelectedPath = @"C:\Repos\WOW2D\Tools\cascview_en\x64\Work";

            lbConvertingStatus.Text = String.Empty;
            lbConvertingCount.Text = String.Empty;
        }

        private void btnBLTConverterPathBrowse_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = File.Exists(txtBLPConverterPath.Text) ? txtBLPConverterPath.Text : "c:\\";
                openFileDialog.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    txtBLPConverterPath.Text = filePath;
                }
            }
        }

        private void btnSelectSourceFolder_Click(object sender, EventArgs e)
        {
            // Show the FolderBrowserDialog.
            string folderPath = string.Empty;

            if (sourceFolderBrowserDialog == null)
                sourceFolderBrowserDialog = new FolderBrowserDialog();


            if (sourceFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                folderPath = sourceFolderBrowserDialog.SelectedPath;

                //Recursively
                AddSourceFiles(folderPath, true);
            }
        }

        /// <summary>
        /// add all files from directory
        /// </summary>
        /// <param name="path">directory path</param>
        /// <param name="searchChildDirectories">add files from child directiorys</param>
        void AddSourceFiles(string path, bool searchChildDirectories)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            var blpFiles = directoryInfo.EnumerateFiles("*.blp");
            //add files from directory
            for (int i = 0; i < blpFiles.Count(); ++i)
            {
                AddSourceFile(blpFiles.ElementAt(i).FullName);
            }
            //add child directory files
            var childDirectories = directoryInfo.EnumerateDirectories();
            for (int i = 0; i < childDirectories.Count(); ++i)
            {
                AddSourceFiles(childDirectories.ElementAt(i).FullName, searchChildDirectories);
            }
        }

        private void btnClearSources_Click(object sender, EventArgs e)
        {
            lvSources.Items.Clear();
        }

        private void btnSelectSourceFile_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            string[] filePaths;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = (sourceFolderBrowserDialog != null && Directory.Exists(sourceFolderBrowserDialog.SelectedPath)) ? sourceFolderBrowserDialog.SelectedPath : "c:\\";
                openFileDialog.Filter = "blp files (*.blp)|*.blp|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePaths = openFileDialog.FileNames;
                    foreach (var filePath in filePaths)
                        AddSourceFile(filePath);
                }
            }
        }

        /// <summary>
        /// add single source file
        /// </summary>
        /// <param name="filePath"></param>
        void AddSourceFile(string filePath)
        {
            var asList = lvSources.Items.Cast<ListViewItem>();
            if (!asList.Any(lvi => lvi.Text.ToLower() == filePath.ToLower()))
            {
                var item = new ListViewItem(filePath);
                lvSources.Items.Add(item);
            }
        }
    }
}
