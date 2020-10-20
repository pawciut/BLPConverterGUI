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
            // ManForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

