namespace LiveSplit.OBSVlc
{
    partial class OBSVlcSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblVideoPath = new System.Windows.Forms.Label();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtVideoPath = new System.Windows.Forms.TextBox();
            this.lblRunStartsAt = new System.Windows.Forms.Label();
            this.txtOffset = new System.Windows.Forms.TextBox();
            this.lblSourceName = new System.Windows.Forms.Label();
            this.txtObsUrl = new System.Windows.Forms.TextBox();
            this.lblObsPassword = new System.Windows.Forms.Label();
            this.txtSourceName = new System.Windows.Forms.TextBox();
            this.lblObsUrl = new System.Windows.Forms.Label();
            this.txtObsPassword = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.Controls.Add(this.lblVideoPath, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSelectFile, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtVideoPath, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblRunStartsAt, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtOffset, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblSourceName, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtObsUrl, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblObsPassword, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtSourceName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblObsUrl, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtObsPassword, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(462, 144);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblVideoPath
            // 
            this.lblVideoPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVideoPath.AutoSize = true;
            this.lblVideoPath.Location = new System.Drawing.Point(3, 8);
            this.lblVideoPath.Name = "lblVideoPath";
            this.lblVideoPath.Size = new System.Drawing.Size(83, 13);
            this.lblVideoPath.TabIndex = 0;
            this.lblVideoPath.Text = "Video Path:";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFile.Location = new System.Drawing.Point(384, 3);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFile.TabIndex = 1;
            this.btnSelectFile.Text = "Browse...";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // txtVideoPath
            // 
            this.txtVideoPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVideoPath.Location = new System.Drawing.Point(92, 4);
            this.txtVideoPath.Name = "txtVideoPath";
            this.txtVideoPath.Size = new System.Drawing.Size(286, 20);
            this.txtVideoPath.TabIndex = 0;
            // 
            // lblRunStartsAt
            // 
            this.lblRunStartsAt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRunStartsAt.AutoSize = true;
            this.lblRunStartsAt.Location = new System.Drawing.Point(3, 37);
            this.lblRunStartsAt.Name = "lblRunStartsAt";
            this.lblRunStartsAt.Size = new System.Drawing.Size(83, 13);
            this.lblRunStartsAt.TabIndex = 6;
            this.lblRunStartsAt.Text = "Run Starts At:";
            // 
            // txtOffset
            // 
            this.txtOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtOffset, 2);
            this.txtOffset.Location = new System.Drawing.Point(92, 33);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.Size = new System.Drawing.Size(367, 20);
            this.txtOffset.TabIndex = 2;
            this.txtOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSourceName
            // 
            this.lblSourceName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSourceName.AutoSize = true;
            this.lblSourceName.Location = new System.Drawing.Point(3, 66);
            this.lblSourceName.Name = "lblSourceName";
            this.lblSourceName.Size = new System.Drawing.Size(83, 13);
            this.lblSourceName.TabIndex = 7;
            this.lblSourceName.Text = "Source Name:";
            // 
            // txtObsUrl
            // 
            this.txtObsUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtObsUrl, 2);
            this.txtObsUrl.Location = new System.Drawing.Point(92, 91);
            this.txtObsUrl.Name = "txtObsUrl";
            this.txtObsUrl.Size = new System.Drawing.Size(367, 20);
            this.txtObsUrl.TabIndex = 4;
            this.txtObsUrl.Text = "ws://127.0.0.1:4455";
            this.txtObsUrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblObsPassword
            // 
            this.lblObsPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblObsPassword.AutoSize = true;
            this.lblObsPassword.Location = new System.Drawing.Point(3, 124);
            this.lblObsPassword.Name = "lblObsPassword";
            this.lblObsPassword.Size = new System.Drawing.Size(83, 13);
            this.lblObsPassword.TabIndex = 9;
            this.lblObsPassword.Text = "OBS Password:";
            // 
            // txtSourceName
            // 
            this.txtSourceName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtSourceName, 2);
            this.txtSourceName.Location = new System.Drawing.Point(92, 62);
            this.txtSourceName.Name = "txtSourceName";
            this.txtSourceName.Size = new System.Drawing.Size(367, 20);
            this.txtSourceName.TabIndex = 10;
            this.txtSourceName.Text = "PB Video";
            this.txtSourceName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblObsUrl
            // 
            this.lblObsUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblObsUrl.AutoSize = true;
            this.lblObsUrl.Location = new System.Drawing.Point(3, 95);
            this.lblObsUrl.Name = "lblObsUrl";
            this.lblObsUrl.Size = new System.Drawing.Size(83, 13);
            this.lblObsUrl.TabIndex = 8;
            this.lblObsUrl.Text = "OBS URL:";
            // 
            // txtObsPassword
            // 
            this.txtObsPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtObsPassword, 2);
            this.txtObsPassword.Location = new System.Drawing.Point(92, 120);
            this.txtObsPassword.Name = "txtObsPassword";
            this.txtObsPassword.PasswordChar = '*';
            this.txtObsPassword.Size = new System.Drawing.Size(367, 20);
            this.txtObsPassword.TabIndex = 11;
            this.txtObsPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // OBSVlcSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OBSVlcSettings";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.Size = new System.Drawing.Size(476, 158);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblVideoPath;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label lblRunStartsAt;
        private System.Windows.Forms.TextBox txtOffset;
        public System.Windows.Forms.TextBox txtVideoPath;
        private System.Windows.Forms.Label lblSourceName;
        private System.Windows.Forms.Label lblObsUrl;
        private System.Windows.Forms.Label lblObsPassword;
        private System.Windows.Forms.TextBox txtObsUrl;
        private System.Windows.Forms.TextBox txtSourceName;
        private System.Windows.Forms.TextBox txtObsPassword;
    }
}
