namespace SDV701AdminClient
{
    partial class frmDesktopDetails : frmModelDetails
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
            this.cbTowerForm = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.nudPowerSupply = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMemory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPowerSupply)).BeginInit();
            this.SuspendLayout();
            // 
            // cbTowerForm
            // 
            this.cbTowerForm.FormattingEnabled = true;
            this.cbTowerForm.Location = new System.Drawing.Point(11, 237);
            this.cbTowerForm.MaxLength = 20;
            this.cbTowerForm.Name = "cbTowerForm";
            this.cbTowerForm.Size = new System.Drawing.Size(121, 21);
            this.cbTowerForm.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 221);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Tower Size";
            // 
            // nudPowerSupply
            // 
            this.nudPowerSupply.Location = new System.Drawing.Point(152, 198);
            this.nudPowerSupply.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.nudPowerSupply.Name = "nudPowerSupply";
            this.nudPowerSupply.Size = new System.Drawing.Size(120, 20);
            this.nudPowerSupply.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(156, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Power (Watts)";
            // 
            // frmDesktopDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 336);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.nudPowerSupply);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbTowerForm);
            this.Name = "frmDesktopDetails";
            this.Text = "frmDesktopDetails";
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
            this.Controls.SetChildIndex(this.cbTowerForm, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.nudPowerSupply, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMemory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPowerSupply)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTowerForm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudPowerSupply;
        private System.Windows.Forms.Label label10;
    }
}