using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLPConverterGUI
{
    public partial class ManForm : Form
    {
        /// <summary>
        /// suffix to search output from BLPConverter process to determin result of conversion
        /// </summary>
        const string BLPConverter_DoneSuffix = "...done!";
        const string Status_Converting = "Converting...";
        const string Status_Finished = "Complete";

        FolderBrowserDialog sourceFolderBrowserDialog;
        FolderBrowserDialog outputFolderBrowserDialog;
        bool customOutputToggleVisible;
        int currentProgressCount = 0;
        Control control;
        List<string> errors = new List<string>();
        List<string> sourceList = new List<string>();

        int beforeAddingSourceDir = 0;
        int sourceToBeAddedCount = 0;

        bool importInProgress = false;
        bool cancel = false;

        public ManForm()
        {
            InitializeComponent();

            control = this;

            //Defaults
            txtBLPConverterPath.Text = @"C:\Repos\WOW2D\Tools\BLPConverter_8-4\BLPConverter.exe";
            //initial source directory
            sourceFolderBrowserDialog = new FolderBrowserDialog();
            sourceFolderBrowserDialog.SelectedPath = @"C:\Repos\WOW2D\Tools\cascview_en\x64\Work";

            outputFolderBrowserDialog = new FolderBrowserDialog();

            lbConvertingStatus.Text = String.Empty;
            lbConvertingCount.Text = String.Empty;

            lbSourcesCount.Text = String.Empty;

            ToggleProgressBar(false);
            ToggleCustomOutput(false);
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
        private void btnClearSources_Click(object sender, EventArgs e)
        {
            //lvSources.Items.Clear();
            lvSources.VirtualListSize = 0;
            sourceList.Clear();
            lbSourcesCount.Text = lvSources.Items.Count.ToString();
        }


        /// <summary>
        /// add all files from directory
        /// </summary>
        /// <param name="path">directory path</param>
        /// <param name="searchChildDirectories">add files from child directiorys</param>
        async void AddSourceFiles(string path, bool searchChildDirectories)
        {
            btnCancel.Enabled = true;
            var sourceFilesToBeAdded = Directory.GetFiles(path, "*.blp", SearchOption.AllDirectories);
            beforeAddingSourceDir = lvSources.Items.Count;
            sourceToBeAddedCount = sourceFilesToBeAdded.Length;
            importInProgress = true;

            lvSources.BeginUpdate();

            //add files
            for (int i = 0; i < sourceFilesToBeAdded.Count(); ++i)
            {
                if (!cancel)
                    await AddSourceFile(sourceFilesToBeAdded[i]);
            }

            control.BeginInvoke((MethodInvoker)delegate ()
            {
                lbSourcesCount.Text = lvSources.Items.Count.ToString();
                beforeAddingSourceDir = 0;
                sourceToBeAddedCount = 0;
            });
            
            lvSources.EndUpdate();
            cancel = false;
            btnCancel.Enabled = false;
            importInProgress = false;
        }


        private async void btnSelectSourceFile_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = true;
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
                    importInProgress = true;
                    //Get the path of specified file
                    filePaths = openFileDialog.FileNames;

                    beforeAddingSourceDir = lvSources.Items.Count;
                    sourceToBeAddedCount = filePaths.Length;

                    foreach (var filePath in filePaths)
                        await AddSourceFile(filePath);

                    lbSourcesCount.Text = lvSources.Items.Count.ToString();
                    beforeAddingSourceDir = 0;
                    sourceToBeAddedCount = 0;
                    cancel = false;
                    btnCancel.Enabled = false;
                    importInProgress = false;
                }
            }
        }

        /// <summary>
        /// add single source file
        /// </summary>
        /// <param name="filePath"></param>
        Task AddSourceFile(string filePath)
        {
            return Task.Run(() =>
            {
                if (cancel)
                    return;

                if (!sourceList.Any(source => source.ToLower() == filePath.ToLower()))
                {
                    sourceList.Add(filePath);
                    control.BeginInvoke((MethodInvoker)delegate ()
                    {
                        lvSources.VirtualListSize++;
                        lbSourcesCount.Text = $"{(lvSources.Items.Count - beforeAddingSourceDir)} / {sourceToBeAddedCount}";
                    });
                }
            });
        }

        void ToggleCustomOutput(bool visible)
        {
            lbOutput.Visible = visible;
            txtOutputPath.Visible = visible;
            btnOutputPathBrowser.Visible = visible;
        }

        private void chbCustomOutput_CheckedChanged(object sender, EventArgs e)
        {
            ToggleCustomOutput(customOutputToggleVisible = !customOutputToggleVisible);
        }

        private async void btnConvert_Click(object sender, EventArgs e)
        {
            if (IsSettingsValid())
            {
                SetupProgess(sourceList.Count);
                ToggleProgressBar(true);
                UpdateUI(false);

                var sources = sourceList;
                List<string> outputs = new List<string>();

                if (customOutputToggleVisible)
                {
                    //Convert all to specified directory
                    UpdateProgress("Preparing output paths");
                    foreach (var sourcePath in sources)
                    {
                        var outputFileName = Path.ChangeExtension(Path.GetFileName(sourcePath), "png");
                        var outputPath = Path.Combine(txtOutputPath.Text, outputFileName);
                        outputs.Add(outputPath);
                    }
                }
                else
                {
                    //by default, empty outputs means same location as source with appropriate file extension
                }

                UpdateProgress(Status_Converting);

                await ConvertAll(sources, outputs);

                UpdateProgress(Status_Finished);
                UpdateUI(true);
                MessageBox.Show("Complete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        async Task ConvertAll(List<string> sources, List<string> outputs)
        {
            List<Task> allTasks = new List<Task>();
            //Convert all in same directory as source
            for (int i = 0; i < sources.Count; ++i)
            {
                var sourcePath = sources[i];
                //If there are no outputs that means that the default output file will be put in the same location as source
                var outputPath = outputs.Any() ? outputs[i] : String.Empty;
                var result = Task.Run<ConversionResult>(() => Convert(sourcePath, outputPath));
                allTasks.Add(result);
            }
            await Task.WhenAll(allTasks);
        }



        private void SetupProgess(int count)
        {
            currentProgressCount = 0;
            lbConvertingStatus.Text = null;
            lbConvertingCount.Text = $"{currentProgressCount}/{count}";

            progressBar1.Value = 0;
            progressBar1.Step = 1;
            progressBar1.Maximum = count;
        }

        void UpdateProgress(string statusText)
        {
            lbConvertingStatus.Text = statusText;
        }
        void UpdateProgress(bool success)
        {
            if (success)
            {
                ++currentProgressCount;
                lbConvertingCount.Text = $"{currentProgressCount}/{sourceList.Count}";
                progressBar1.PerformStep();
            }
        }

        void UpdateUI(bool enabled)
        {
            btnSelectSourceFile.Enabled = enabled;
            btnSelectSourceFolder.Enabled = enabled;
            btnClearSources.Enabled = enabled;
            btnConvert.Enabled = enabled;
            btnBLTConverterPathBrowse.Enabled = enabled;
            btnOutputPathBrowser.Enabled = enabled;
            chbCustomOutput.Enabled = enabled;
        }

        Task<ConversionResult> ConvertAsync(string filePath, string outputFilePath)
        {
            var result = Task.Run<ConversionResult>(() => Convert(filePath, outputFilePath));
            return result;
        }

        ConversionResult Convert(string filePath, string outputFilePath)
        {
            ConversionResult result = new ConversionResult();
            result.sourcePath = filePath;

            var arguments = String.IsNullOrEmpty(outputFilePath) ? $"{filePath}" : $"\"{filePath}\" \"{outputFilePath}\"";

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = txtBLPConverterPath.Text,
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                //analize output of BLP Converter
                if (line.EndsWith(BLPConverter_DoneSuffix))
                {
                    result.success = true;
                    break;
                }
            }
            //For debugging purposue
            //Thread.Sleep(2000);
            control.BeginInvoke((MethodInvoker)delegate ()
            {
                UpdateProgress(result.success);
            });
            return result;
        }

        bool IsSettingsValid()
        {
            if (!File.Exists(txtBLPConverterPath.Text))
            {
                MessageBox.Show("BLPConverter path is invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (sourceList.Count <= 0)
            {
                MessageBox.Show("No source files to convert", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (customOutputToggleVisible && !Directory.Exists(txtOutputPath.Text))
            {
                MessageBox.Show("Output path is invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        void ToggleProgressBar(bool visible)
        {
            lbConvertingStatus.Visible = visible;
            lbConvertingCount.Visible = visible;
            progressBar1.Visible = visible;
        }

        private void btnOutputPathBrowser_Click(object sender, EventArgs e)
        {
            // Show the FolderBrowserDialog.
            string folderPath = string.Empty;

            if (outputFolderBrowserDialog == null)
                outputFolderBrowserDialog = new FolderBrowserDialog();


            if (outputFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                folderPath = outputFolderBrowserDialog.SelectedPath;
                txtOutputPath.Text = folderPath;
            }
        }

        private void lvSources_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            //check to see if the requested item is currently in the cache
            //if (myCache != null && e.ItemIndex >= firstItem && e.ItemIndex < firstItem + myCache.Length)
            //{
            //    //A cache hit, so get the ListViewItem from the cache instead of making a new one.
            //    e.Item = myCache[e.ItemIndex - firstItem];
            //}
            //else
            {
                //A cache miss, so create a new ListViewItem and pass it back.
                e.Item = new ListViewItem(sourceList[e.ItemIndex]);
            }
        }

        private void lvSources_SearchForVirtualItem(object sender, SearchForVirtualItemEventArgs e)
        {
            //We've gotten a search request.
            //In this example, finding the item is easy since it's
            //just the square of its index.  We'll take the square root
            //and round.
            double x = 0;
            if (Double.TryParse(e.Text, out x)) //check if this is a valid search
            {
                x = Math.Sqrt(x);
                x = Math.Round(x);
                e.Index = (int)x;
            }
            //If e.Index is not set, the search returns null.
            //Note that this only handles simple searches over the entire
            //list, ignoring any other settings.  Handling Direction, StartIndex,
            //and the other properties of SearchForVirtualItemEventArgs is up
            //to this handler.
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancel = true;
        }
    }
}
