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
        public ManForm()
        {
            InitializeComponent();

            //Defaults
            txtBLPConverterPath.Text = @"C:\Repos\WOW2D\Tools\BLPConverter_8-4\BLPConverter.exe";
        }

        private void btnBLTConverterPathBrowse_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = File.Exists(txtBLPConverterPath.Text)? txtBLPConverterPath.Text : "c:\\";
                openFileDialog.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    txtBLPConverterPath.Text = filePath;
                }
            }
        }
    }
}
