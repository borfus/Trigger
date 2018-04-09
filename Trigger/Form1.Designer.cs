namespace Trigger
{
    partial class Form1
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
            this.btnEnabled = new System.Windows.Forms.Button();
            this.lblFiring = new System.Windows.Forms.Label();
            this.prgFiring = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btnEnabled
            // 
            this.btnEnabled.Location = new System.Drawing.Point(12, 12);
            this.btnEnabled.Name = "btnEnabled";
            this.btnEnabled.Size = new System.Drawing.Size(95, 27);
            this.btnEnabled.TabIndex = 0;
            this.btnEnabled.TabStop = false;
            this.btnEnabled.Text = "Enable";
            this.btnEnabled.UseVisualStyleBackColor = true;
            this.btnEnabled.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnEnable_MouseClick);
            // 
            // lblFiring
            // 
            this.lblFiring.AutoSize = true;
            this.lblFiring.Location = new System.Drawing.Point(120, 19);
            this.lblFiring.Name = "lblFiring";
            this.lblFiring.Size = new System.Drawing.Size(38, 13);
            this.lblFiring.TabIndex = 1;
            this.lblFiring.Text = "Firing: ";
            // 
            // prgFiring
            // 
            this.prgFiring.ForeColor = System.Drawing.Color.Red;
            this.prgFiring.Location = new System.Drawing.Point(164, 12);
            this.prgFiring.Name = "prgFiring";
            this.prgFiring.Size = new System.Drawing.Size(38, 27);
            this.prgFiring.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgFiring.TabIndex = 2;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 51);
            this.Controls.Add(this.prgFiring);
            this.Controls.Add(this.lblFiring);
            this.Controls.Add(this.btnEnabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Trigger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnabled;
        private System.Windows.Forms.Label lblFiring;
        private System.Windows.Forms.ProgressBar prgFiring;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

