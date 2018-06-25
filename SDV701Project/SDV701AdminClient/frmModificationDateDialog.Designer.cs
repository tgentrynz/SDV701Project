namespace SDV701AdminClient
{
    partial class frmModificationDateDialog
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
            this.btnIgnore = new System.Windows.Forms.Button();
            this.btnRetry = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnIgnore
            // 
            this.btnIgnore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIgnore.Location = new System.Drawing.Point(12, 85);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(235, 23);
            this.btnIgnore.TabIndex = 0;
            this.btnIgnore.Text = "Force Update";
            this.btnIgnore.UseVisualStyleBackColor = true;
            this.btnIgnore.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            // 
            // btnRetry
            // 
            this.btnRetry.Location = new System.Drawing.Point(12, 56);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(235, 23);
            this.btnRetry.TabIndex = 1;
            this.btnRetry.Text = "Refresh Form";
            this.btnRetry.UseVisualStyleBackColor = true;
            this.btnRetry.Click += new System.EventHandler(this.button2_Click);
            this.btnRetry.DialogResult = System.Windows.Forms.DialogResult.Retry;
            // 
            // btnAbort
            // 
            this.btnAbort.Location = new System.Drawing.Point(12, 114);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(235, 23);
            this.btnAbort.TabIndex = 2;
            this.btnAbort.Text = "Close Form";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.DialogResult = System.Windows.Forms.DialogResult.Abort;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 44);
            this.label1.TabIndex = 3;
            this.label1.Text = "The information stored in the database is more recent than what was loaded on thi" +
    "s form.\r\nDo you still want to push changes?";
            // 
            // frmModificationDateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 141);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnRetry);
            this.Controls.Add(this.btnIgnore);
            this.Name = "frmModificationDateDialog";
            this.Text = "frmModificationDateDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIgnore;
        private System.Windows.Forms.Button btnRetry;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Label label1;
    }
}