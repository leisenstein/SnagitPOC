namespace SnagitPOC
{
    partial class Main
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
            this.txtUrl1 = new System.Windows.Forms.TextBox();
            this.lblUrl1 = new System.Windows.Forms.Label();
            this.lblOutput1 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.btnCapture1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUrl1
            // 
            this.txtUrl1.Location = new System.Drawing.Point(123, 20);
            this.txtUrl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUrl1.Name = "txtUrl1";
            this.txtUrl1.Size = new System.Drawing.Size(547, 22);
            this.txtUrl1.TabIndex = 0;
            // 
            // lblUrl1
            // 
            this.lblUrl1.AutoSize = true;
            this.lblUrl1.Location = new System.Drawing.Point(16, 23);
            this.lblUrl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUrl1.Name = "lblUrl1";
            this.lblUrl1.Size = new System.Drawing.Size(56, 17);
            this.lblUrl1.TabIndex = 1;
            this.lblUrl1.Text = "URL 1: ";
            // 
            // lblOutput1
            // 
            this.lblOutput1.AutoSize = true;
            this.lblOutput1.Location = new System.Drawing.Point(723, 23);
            this.lblOutput1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutput1.Name = "lblOutput1";
            this.lblOutput1.Size = new System.Drawing.Size(97, 17);
            this.lblOutput1.TabIndex = 7;
            this.lblOutput1.Text = "Output File 1: ";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(829, 20);
            this.textBox6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(389, 22);
            this.textBox6.TabIndex = 6;
            // 
            // btnCapture1
            // 
            this.btnCapture1.Location = new System.Drawing.Point(1244, 17);
            this.btnCapture1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCapture1.Name = "btnCapture1";
            this.btnCapture1.Size = new System.Drawing.Size(100, 28);
            this.btnCapture1.TabIndex = 12;
            this.btnCapture1.Text = "Capture";
            this.btnCapture1.UseVisualStyleBackColor = true;
            this.btnCapture1.Click += new System.EventHandler(this.btnCapture1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 78);
            this.Controls.Add(this.btnCapture1);
            this.Controls.Add(this.lblOutput1);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.lblUrl1);
            this.Controls.Add(this.txtUrl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl1;
        private System.Windows.Forms.Label lblUrl1;
        private System.Windows.Forms.Label lblOutput1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button btnCapture1;
    }
}

