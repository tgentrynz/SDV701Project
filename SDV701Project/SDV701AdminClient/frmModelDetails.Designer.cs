namespace SDV701AdminClient
{
    partial class frmModelDetails
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.cbOperatingSystem = new System.Windows.Forms.ComboBox();
            this.nudMemory = new System.Windows.Forms.NumericUpDown();
            this.cbProcessorFamily = new System.Windows.Forms.ComboBox();
            this.nudStorage = new System.Windows.Forms.NumericUpDown();
            this.cbGraphicsFamily = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblModification = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMemory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStorage)).BeginInit();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(11, 24);
            this.tbName.MaxLength = 60;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(261, 20);
            this.tbName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Model Name";
            // 
            // nudPrice
            // 
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Location = new System.Drawing.Point(11, 63);
            this.nudPrice.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(120, 20);
            this.nudPrice.TabIndex = 2;
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(152, 63);
            this.nudQuantity.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(120, 20);
            this.nudQuantity.TabIndex = 3;
            // 
            // cbOperatingSystem
            // 
            this.cbOperatingSystem.FormattingEnabled = true;
            this.cbOperatingSystem.Location = new System.Drawing.Point(11, 116);
            this.cbOperatingSystem.MaxLength = 20;
            this.cbOperatingSystem.Name = "cbOperatingSystem";
            this.cbOperatingSystem.Size = new System.Drawing.Size(121, 21);
            this.cbOperatingSystem.TabIndex = 4;
            // 
            // nudMemory
            // 
            this.nudMemory.Location = new System.Drawing.Point(152, 117);
            this.nudMemory.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudMemory.Name = "nudMemory";
            this.nudMemory.Size = new System.Drawing.Size(120, 20);
            this.nudMemory.TabIndex = 5;
            // 
            // cbProcessorFamily
            // 
            this.cbProcessorFamily.FormattingEnabled = true;
            this.cbProcessorFamily.Location = new System.Drawing.Point(11, 156);
            this.cbProcessorFamily.MaxLength = 20;
            this.cbProcessorFamily.Name = "cbProcessorFamily";
            this.cbProcessorFamily.Size = new System.Drawing.Size(121, 21);
            this.cbProcessorFamily.TabIndex = 6;
            // 
            // nudStorage
            // 
            this.nudStorage.Location = new System.Drawing.Point(152, 158);
            this.nudStorage.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudStorage.Name = "nudStorage";
            this.nudStorage.Size = new System.Drawing.Size(120, 20);
            this.nudStorage.TabIndex = 7;
            // 
            // cbGraphicsFamily
            // 
            this.cbGraphicsFamily.FormattingEnabled = true;
            this.cbGraphicsFamily.Location = new System.Drawing.Point(11, 197);
            this.cbGraphicsFamily.MaxLength = 20;
            this.cbGraphicsFamily.Name = "cbGraphicsFamily";
            this.cbGraphicsFamily.Size = new System.Drawing.Size(121, 21);
            this.cbGraphicsFamily.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Quantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Operating System";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(156, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "RAM (Gigabytes)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Processor Family";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(156, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Storage (Gigabytes)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Graphics Family";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(116, 301);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(197, 301);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblModification
            // 
            this.lblModification.Location = new System.Drawing.Point(12, 285);
            this.lblModification.Name = "lblModification";
            this.lblModification.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblModification.Size = new System.Drawing.Size(260, 13);
            this.lblModification.TabIndex = 18;
            this.lblModification.Text = "Modified:";
            this.lblModification.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmModelDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 336);
            this.Controls.Add(this.lblModification);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbGraphicsFamily);
            this.Controls.Add(this.nudStorage);
            this.Controls.Add(this.cbProcessorFamily);
            this.Controls.Add(this.nudMemory);
            this.Controls.Add(this.cbOperatingSystem);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbName);
            this.Name = "frmModelDetails";
            this.Text = "frmModelDetails";
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMemory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStorage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        protected System.Windows.Forms.Label lblModification;
        protected System.Windows.Forms.Button btnOK;
        protected System.Windows.Forms.Button btnCancel;
        protected System.Windows.Forms.TextBox tbName;
        protected System.Windows.Forms.NumericUpDown nudPrice;
        protected System.Windows.Forms.NumericUpDown nudQuantity;
        protected System.Windows.Forms.ComboBox cbOperatingSystem;
        protected System.Windows.Forms.NumericUpDown nudMemory;
        protected System.Windows.Forms.ComboBox cbProcessorFamily;
        protected System.Windows.Forms.ComboBox cbGraphicsFamily;
        protected System.Windows.Forms.NumericUpDown nudStorage;
    }
}