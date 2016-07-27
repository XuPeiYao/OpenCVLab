namespace OpenCVLab {
    partial class WebcamForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.CaptureButton = new System.Windows.Forms.Button();
            this.CapturePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CapturePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CaptureButton
            // 
            this.CaptureButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CaptureButton.Location = new System.Drawing.Point(0, 203);
            this.CaptureButton.Name = "CaptureButton";
            this.CaptureButton.Size = new System.Drawing.Size(311, 23);
            this.CaptureButton.TabIndex = 0;
            this.CaptureButton.Text = "擷取";
            this.CaptureButton.UseVisualStyleBackColor = true;
            this.CaptureButton.Click += new System.EventHandler(this.CaptureButton_Click);
            // 
            // CapturePictureBox
            // 
            this.CapturePictureBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.CapturePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CapturePictureBox.Location = new System.Drawing.Point(0, 0);
            this.CapturePictureBox.Name = "CapturePictureBox";
            this.CapturePictureBox.Size = new System.Drawing.Size(311, 203);
            this.CapturePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CapturePictureBox.TabIndex = 1;
            this.CapturePictureBox.TabStop = false;
            // 
            // WebcamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 226);
            this.Controls.Add(this.CapturePictureBox);
            this.Controls.Add(this.CaptureButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "WebcamForm";
            this.Text = "網路攝影機影像擷取";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WebcamForm_FormClosing);
            this.Load += new System.EventHandler(this.WebcamForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CapturePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CaptureButton;
        private System.Windows.Forms.PictureBox CapturePictureBox;
    }
}