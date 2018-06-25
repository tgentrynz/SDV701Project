namespace SDV701AdminClient
{
    partial class frmLaptopDetails : frmModelDetails
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
            this.nudScreenSize = new System.Windows.Forms.NumericUpDown();
            this.nudBatteryLife = new System.Windows.Forms.NumericUpDown();
            this.chbFullSizeKeyboard = new System.Windows.Forms.CheckBox();
            this.chbWebCamera = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMemory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScreenSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBatteryLife)).BeginInit();
            this.SuspendLayout();
            // 
            // nudScreenSize
            // 
            this.nudScreenSize.Location = new System.Drawing.Point(152, 197);
            this.nudScreenSize.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudScreenSize.Name = "nudScreenSize";
            this.nudScreenSize.Size = new System.Drawing.Size(120, 20);
            this.nudScreenSize.TabIndex = 19;
            // 
            // nudBatteryLife
            // 
            this.nudBatteryLife.Location = new System.Drawing.Point(11, 242);
            this.nudBatteryLife.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudBatteryLife.Name = "nudBatteryLife";
            this.nudBatteryLife.Size = new System.Drawing.Size(120, 20);
            this.nudBatteryLife.TabIndex = 20;
            // 
            // chbFullSizeKeyboard
            // 
            this.chbFullSizeKeyboard.AutoSize = true;
            this.chbFullSizeKeyboard.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbFullSizeKeyboard.Location = new System.Drawing.Point(159, 222);
            this.chbFullSizeKeyboard.Name = "chbFullSizeKeyboard";
            this.chbFullSizeKeyboard.Size = new System.Drawing.Size(113, 17);
            this.chbFullSizeKeyboard.TabIndex = 21;
            this.chbFullSizeKeyboard.Text = "Full Size Keyboard";
            this.chbFullSizeKeyboard.UseVisualStyleBackColor = true;
            // 
            // chbWebCamera
            // 
            this.chbWebCamera.AutoSize = true;
            this.chbWebCamera.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbWebCamera.Location = new System.Drawing.Point(184, 245);
            this.chbWebCamera.Name = "chbWebCamera";
            this.chbWebCamera.Size = new System.Drawing.Size(88, 17);
            this.chbWebCamera.TabIndex = 22;
            this.chbWebCamera.Text = "Web Camera";
            this.chbWebCamera.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(156, 181);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Screen Size";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 226);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Battery Life (Hours)";
            // 
            // frmLaptopDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 336);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chbWebCamera);
            this.Controls.Add(this.chbFullSizeKeyboard);
            this.Controls.Add(this.nudBatteryLife);
            this.Controls.Add(this.nudScreenSize);
            this.Name = "frmLaptopDetails";
            this.Text = "frmLaptopDetails";
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.nudPrice, 0);
            this.Controls.SetChildIndex(this.nudQuantity, 0);
            this.Controls.SetChildIndex(this.cbOperatingSystem, 0);
            this.Controls.SetChildIndex(this.nudMemory, 0);
            this.Controls.SetChildIndex(this.cbProcessorFamily, 0);
            this.Controls.SetChildIndex(this.nudStorage, 0);
            this.Controls.SetChildIndex(this.cbGraphicsFamily, 0);
            this.Controls.SetChildIndex(this.lblModification, 0);
            this.Controls.SetChildIndex(this.nudScreenSize, 0);
            this.Controls.SetChildIndex(this.nudBatteryLife, 0);
            this.Controls.SetChildIndex(this.chbFullSizeKeyboard, 0);
            this.Controls.SetChildIndex(this.chbWebCamera, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMemory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScreenSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBatteryLife)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudScreenSize;
        private System.Windows.Forms.NumericUpDown nudBatteryLife;
        private System.Windows.Forms.CheckBox chbFullSizeKeyboard;
        private System.Windows.Forms.CheckBox chbWebCamera;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}