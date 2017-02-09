namespace FastSerial
{
    partial class Info
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Info));
            this.progressBarload = new System.Windows.Forms.ProgressBar();
            this.buttonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBarload
            // 
            this.progressBarload.ForeColor = System.Drawing.SystemColors.GrayText;
            this.progressBarload.Location = new System.Drawing.Point(164, 401);
            this.progressBarload.Maximum = 1000;
            this.progressBarload.Name = "progressBarload";
            this.progressBarload.Size = new System.Drawing.Size(331, 18);
            this.progressBarload.Step = 100;
            this.progressBarload.TabIndex = 0;
            this.progressBarload.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOk.Location = new System.Drawing.Point(530, 401);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = false;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(662, 464);
            this.ControlBox = false;
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.progressBarload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Info";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Info";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarload;
        private System.Windows.Forms.Button buttonOk;
    }
}