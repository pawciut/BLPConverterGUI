namespace BLPConverterGUI
{
    partial class ManForm
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
            this.lbBLPPath = new System.Windows.Forms.Label();
            this.txtBLPConverterPath = new System.Windows.Forms.TextBox();
            this.btnBLTConverterPathBrowse = new System.Windows.Forms.Button();
            this.lbSource = new System.Windows.Forms.Label();
            this.lvSources = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSelectSourceFolder = new System.Windows.Forms.Button();
            this.btnSelectSourceFile = new System.Windows.Forms.Button();
            this.btnClearSources = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbConvertingStatus = new System.Windows.Forms.Label();
            this.lbConvertingCount = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnOutputPathBrowser = new System.Windows.Forms.Button();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.lbOutput = new System.Windows.Forms.Label();
            this.chbCustomOutput = new System.Windows.Forms.CheckBox();
            this.lbSourcesCount = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbBLPPath
            // 
            this.lbBLPPath.AutoSize = true;
            this.lbBLPPath.Location = new System.Drawing.Point(12, 9);
            this.lbBLPPath.Name = "lbBLPPath";
            this.lbBLPPath.Size = new System.Drawing.Size(100, 13);
            this.lbBLPPath.TabIndex = 0;
            this.lbBLPPath.Text = "BLPConverter path:";
            // 
            // txtBLPConverterPath
            // 
            this.txtBLPConverterPath.Enabled = false;
            this.txtBLPConverterPath.Location = new System.Drawing.Point(118, 6);
            this.txtBLPConverterPath.Name = "txtBLPConverterPath";
            this.txtBLPConverterPath.ReadOnly = true;
            this.txtBLPConverterPath.Size = new System.Drawing.Size(592, 20);
            this.txtBLPConverterPath.TabIndex = 1;
            // 
            // btnBLTConverterPathBrowse
            // 
            this.btnBLTConverterPathBrowse.Location = new System.Drawing.Point(716, 4);
            this.btnBLTConverterPathBrowse.Name = "btnBLTConverterPathBrowse";
            this.btnBLTConverterPathBrowse.Size = new System.Drawing.Size(29, 23);
            this.btnBLTConverterPathBrowse.TabIndex = 2;
            this.btnBLTConverterPathBrowse.Text = "...";
            this.btnBLTConverterPathBrowse.UseVisualStyleBackColor = true;
            this.btnBLTConverterPathBrowse.Click += new System.EventHandler(this.btnBLTConverterPathBrowse_Click);
            // 
            // lbSource
            // 
            this.lbSource.AutoSize = true;
            this.lbSource.Location = new System.Drawing.Point(12, 184);
            this.lbSource.Name = "lbSource";
            this.lbSource.Size = new System.Drawing.Size(49, 13);
            this.lbSource.TabIndex = 3;
            this.lbSource.Text = "Sources:";
            // 
            // lvSources
            // 
            this.lvSources.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSources.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvSources.HideSelection = false;
            this.lvSources.Location = new System.Drawing.Point(12, 208);
            this.lvSources.Name = "lvSources";
            this.lvSources.Size = new System.Drawing.Size(727, 306);
            this.lvSources.TabIndex = 4;
            this.lvSources.UseCompatibleStateImageBehavior = false;
            this.lvSources.View = System.Windows.Forms.View.Details;
            this.lvSources.VirtualMode = true;
            this.lvSources.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvSources_RetrieveVirtualItem);
            this.lvSources.SearchForVirtualItem += new System.Windows.Forms.SearchForVirtualItemEventHandler(this.lvSources_SearchForVirtualItem);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File";
            this.columnHeader1.Width = 400;
            // 
            // btnSelectSourceFolder
            // 
            this.btnSelectSourceFolder.Location = new System.Drawing.Point(67, 179);
            this.btnSelectSourceFolder.Name = "btnSelectSourceFolder";
            this.btnSelectSourceFolder.Size = new System.Drawing.Size(75, 23);
            this.btnSelectSourceFolder.TabIndex = 5;
            this.btnSelectSourceFolder.Text = "SelectFolder";
            this.btnSelectSourceFolder.UseVisualStyleBackColor = true;
            this.btnSelectSourceFolder.Click += new System.EventHandler(this.btnSelectSourceFolder_Click);
            // 
            // btnSelectSourceFile
            // 
            this.btnSelectSourceFile.Location = new System.Drawing.Point(148, 179);
            this.btnSelectSourceFile.Name = "btnSelectSourceFile";
            this.btnSelectSourceFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectSourceFile.TabIndex = 6;
            this.btnSelectSourceFile.Text = "Select file";
            this.btnSelectSourceFile.UseVisualStyleBackColor = true;
            this.btnSelectSourceFile.Click += new System.EventHandler(this.btnSelectSourceFile_Click);
            // 
            // btnClearSources
            // 
            this.btnClearSources.Location = new System.Drawing.Point(229, 179);
            this.btnClearSources.Name = "btnClearSources";
            this.btnClearSources.Size = new System.Drawing.Size(62, 23);
            this.btnClearSources.TabIndex = 7;
            this.btnClearSources.Text = "Clear";
            this.btnClearSources.UseVisualStyleBackColor = true;
            this.btnClearSources.Click += new System.EventHandler(this.btnClearSources_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(118, 59);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(592, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // lbConvertingStatus
            // 
            this.lbConvertingStatus.AutoSize = true;
            this.lbConvertingStatus.Location = new System.Drawing.Point(124, 43);
            this.lbConvertingStatus.Name = "lbConvertingStatus";
            this.lbConvertingStatus.Size = new System.Drawing.Size(77, 13);
            this.lbConvertingStatus.TabIndex = 9;
            this.lbConvertingStatus.Text = "Converting file ";
            // 
            // lbConvertingCount
            // 
            this.lbConvertingCount.AutoSize = true;
            this.lbConvertingCount.Location = new System.Drawing.Point(686, 85);
            this.lbConvertingCount.Name = "lbConvertingCount";
            this.lbConvertingCount.Size = new System.Drawing.Size(24, 13);
            this.lbConvertingCount.TabIndex = 10;
            this.lbConvertingCount.Text = "0/1";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(669, 174);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 11;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnOutputPathBrowser
            // 
            this.btnOutputPathBrowser.Location = new System.Drawing.Point(716, 131);
            this.btnOutputPathBrowser.Name = "btnOutputPathBrowser";
            this.btnOutputPathBrowser.Size = new System.Drawing.Size(29, 23);
            this.btnOutputPathBrowser.TabIndex = 14;
            this.btnOutputPathBrowser.Text = "...";
            this.btnOutputPathBrowser.UseVisualStyleBackColor = true;
            this.btnOutputPathBrowser.Click += new System.EventHandler(this.btnOutputPathBrowser_Click);
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Enabled = false;
            this.txtOutputPath.Location = new System.Drawing.Point(118, 133);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.ReadOnly = true;
            this.txtOutputPath.Size = new System.Drawing.Size(592, 20);
            this.txtOutputPath.TabIndex = 13;
            // 
            // lbOutput
            // 
            this.lbOutput.AutoSize = true;
            this.lbOutput.Location = new System.Drawing.Point(12, 136);
            this.lbOutput.Name = "lbOutput";
            this.lbOutput.Size = new System.Drawing.Size(85, 13);
            this.lbOutput.TabIndex = 12;
            this.lbOutput.Text = "Output directory:";
            // 
            // chbCustomOutput
            // 
            this.chbCustomOutput.AutoSize = true;
            this.chbCustomOutput.Location = new System.Drawing.Point(15, 101);
            this.chbCustomOutput.Name = "chbCustomOutput";
            this.chbCustomOutput.Size = new System.Drawing.Size(137, 17);
            this.chbCustomOutput.TabIndex = 15;
            this.chbCustomOutput.Text = "Custom output directory";
            this.chbCustomOutput.UseVisualStyleBackColor = true;
            this.chbCustomOutput.CheckedChanged += new System.EventHandler(this.chbCustomOutput_CheckedChanged);
            // 
            // lbSourcesCount
            // 
            this.lbSourcesCount.AutoSize = true;
            this.lbSourcesCount.Location = new System.Drawing.Point(297, 184);
            this.lbSourcesCount.Name = "lbSourcesCount";
            this.lbSourcesCount.Size = new System.Drawing.Size(13, 13);
            this.lbSourcesCount.TabIndex = 16;
            this.lbSourcesCount.Text = "0";
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(338, 179);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ManForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 526);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lbSourcesCount);
            this.Controls.Add(this.chbCustomOutput);
            this.Controls.Add(this.btnOutputPathBrowser);
            this.Controls.Add(this.txtOutputPath);
            this.Controls.Add(this.lbOutput);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.lbConvertingCount);
            this.Controls.Add(this.lbConvertingStatus);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnClearSources);
            this.Controls.Add(this.btnSelectSourceFile);
            this.Controls.Add(this.btnSelectSourceFolder);
            this.Controls.Add(this.lvSources);
            this.Controls.Add(this.lbSource);
            this.Controls.Add(this.btnBLTConverterPathBrowse);
            this.Controls.Add(this.txtBLPConverterPath);
            this.Controls.Add(this.lbBLPPath);
            this.Name = "ManForm";
            this.Text = "BLPConverter GUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbBLPPath;
        private System.Windows.Forms.TextBox txtBLPConverterPath;
        private System.Windows.Forms.Button btnBLTConverterPathBrowse;
        private System.Windows.Forms.Label lbSource;
        private System.Windows.Forms.ListView lvSources;
        private System.Windows.Forms.Button btnSelectSourceFolder;
        private System.Windows.Forms.Button btnSelectSourceFile;
        private System.Windows.Forms.Button btnClearSources;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbConvertingStatus;
        private System.Windows.Forms.Label lbConvertingCount;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnOutputPathBrowser;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Label lbOutput;
        private System.Windows.Forms.CheckBox chbCustomOutput;
        private System.Windows.Forms.Label lbSourcesCount;
        private System.Windows.Forms.Button btnCancel;
    }
}

