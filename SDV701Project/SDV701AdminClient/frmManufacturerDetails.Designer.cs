namespace SDV701AdminClient
{
    partial class frmManufacturerDetails
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
            this.gbManufacturerDetails = new System.Windows.Forms.GroupBox();
            this.lblManufacturerCountry = new System.Windows.Forms.Label();
            this.lblManufacturerName = new System.Windows.Forms.Label();
            this.lblComputers = new System.Windows.Forms.Label();
            this.lbModels = new System.Windows.Forms.ListBox();
            this.lblFields = new System.Windows.Forms.Label();
            this.gbComputerDetails = new System.Windows.Forms.GroupBox();
            this.btnRemoveComputer = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.lblComputerSystem = new System.Windows.Forms.Label();
            this.lblComputerType = new System.Windows.Forms.Label();
            this.btnAddComputer = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbManufacturerDetails.SuspendLayout();
            this.gbComputerDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbManufacturerDetails
            // 
            this.gbManufacturerDetails.Controls.Add(this.lblManufacturerCountry);
            this.gbManufacturerDetails.Controls.Add(this.lblManufacturerName);
            this.gbManufacturerDetails.Location = new System.Drawing.Point(12, 12);
            this.gbManufacturerDetails.Name = "gbManufacturerDetails";
            this.gbManufacturerDetails.Size = new System.Drawing.Size(260, 49);
            this.gbManufacturerDetails.TabIndex = 0;
            this.gbManufacturerDetails.TabStop = false;
            this.gbManufacturerDetails.Text = "Manufacturer: ";
            // 
            // lblManufacturerCountry
            // 
            this.lblManufacturerCountry.AutoSize = true;
            this.lblManufacturerCountry.Location = new System.Drawing.Point(6, 29);
            this.lblManufacturerCountry.Name = "lblManufacturerCountry";
            this.lblManufacturerCountry.Size = new System.Drawing.Size(49, 13);
            this.lblManufacturerCountry.TabIndex = 2;
            this.lblManufacturerCountry.Text = "Country: ";
            // 
            // lblManufacturerName
            // 
            this.lblManufacturerName.AutoSize = true;
            this.lblManufacturerName.Location = new System.Drawing.Point(6, 16);
            this.lblManufacturerName.Name = "lblManufacturerName";
            this.lblManufacturerName.Size = new System.Drawing.Size(41, 13);
            this.lblManufacturerName.TabIndex = 1;
            this.lblManufacturerName.Text = "Name: ";
            // 
            // lblComputers
            // 
            this.lblComputers.AutoSize = true;
            this.lblComputers.Location = new System.Drawing.Point(13, 68);
            this.lblComputers.Name = "lblComputers";
            this.lblComputers.Size = new System.Drawing.Size(57, 13);
            this.lblComputers.TabIndex = 1;
            this.lblComputers.Text = "Computers";
            // 
            // lbModels
            // 
            this.lbModels.FormattingEnabled = true;
            this.lbModels.Location = new System.Drawing.Point(12, 109);
            this.lbModels.Name = "lbModels";
            this.lbModels.Size = new System.Drawing.Size(260, 95);
            this.lbModels.TabIndex = 2;
            this.lbModels.SelectedIndexChanged += new System.EventHandler(this.lbModels_SelectedIndexChanged);
            this.lbModels.DoubleClick += new System.EventHandler(this.editModel_Click);
            // 
            // lblFields
            // 
            this.lblFields.AutoSize = true;
            this.lblFields.Location = new System.Drawing.Point(16, 90);
            this.lblFields.Name = "lblFields";
            this.lblFields.Size = new System.Drawing.Size(231, 13);
            this.lblFields.TabIndex = 3;
            this.lblFields.Text = "Model                     Price                       Quantity";
            // 
            // gbComputerDetails
            // 
            this.gbComputerDetails.Controls.Add(this.btnRemoveComputer);
            this.gbComputerDetails.Controls.Add(this.btnViewDetails);
            this.gbComputerDetails.Controls.Add(this.lblComputerSystem);
            this.gbComputerDetails.Controls.Add(this.lblComputerType);
            this.gbComputerDetails.Location = new System.Drawing.Point(12, 211);
            this.gbComputerDetails.Name = "gbComputerDetails";
            this.gbComputerDetails.Size = new System.Drawing.Size(135, 121);
            this.gbComputerDetails.TabIndex = 4;
            this.gbComputerDetails.TabStop = false;
            this.gbComputerDetails.Text = "TC-780-UR12";
            // 
            // btnRemoveComputer
            // 
            this.btnRemoveComputer.Location = new System.Drawing.Point(6, 89);
            this.btnRemoveComputer.Name = "btnRemoveComputer";
            this.btnRemoveComputer.Size = new System.Drawing.Size(123, 24);
            this.btnRemoveComputer.TabIndex = 3;
            this.btnRemoveComputer.Text = "Remove";
            this.btnRemoveComputer.UseVisualStyleBackColor = true;
            this.btnRemoveComputer.Click += new System.EventHandler(this.btnRemoveComputer_Click);
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Location = new System.Drawing.Point(6, 59);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(123, 24);
            this.btnViewDetails.TabIndex = 2;
            this.btnViewDetails.Text = "Edit Details";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += new System.EventHandler(this.editModel_Click);
            // 
            // lblComputerSystem
            // 
            this.lblComputerSystem.AutoSize = true;
            this.lblComputerSystem.Location = new System.Drawing.Point(6, 29);
            this.lblComputerSystem.Name = "lblComputerSystem";
            this.lblComputerSystem.Size = new System.Drawing.Size(44, 13);
            this.lblComputerSystem.TabIndex = 1;
            this.lblComputerSystem.Text = "System:";
            // 
            // lblComputerType
            // 
            this.lblComputerType.AutoSize = true;
            this.lblComputerType.Location = new System.Drawing.Point(6, 16);
            this.lblComputerType.Name = "lblComputerType";
            this.lblComputerType.Size = new System.Drawing.Size(37, 13);
            this.lblComputerType.TabIndex = 0;
            this.lblComputerType.Text = "Type: ";
            // 
            // btnAddComputer
            // 
            this.btnAddComputer.Location = new System.Drawing.Point(149, 217);
            this.btnAddComputer.Name = "btnAddComputer";
            this.btnAddComputer.Size = new System.Drawing.Size(123, 23);
            this.btnAddComputer.TabIndex = 5;
            this.btnAddComputer.Text = "Add New Model";
            this.btnAddComputer.UseVisualStyleBackColor = true;
            this.btnAddComputer.Click += new System.EventHandler(this.btnAddComputer_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(149, 301);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmManufacturerDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 336);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddComputer);
            this.Controls.Add(this.gbComputerDetails);
            this.Controls.Add(this.lblFields);
            this.Controls.Add(this.lbModels);
            this.Controls.Add(this.lblComputers);
            this.Controls.Add(this.gbManufacturerDetails);
            this.Name = "frmManufacturerDetails";
            this.Text = "frmManufacturerDetails";
            this.gbManufacturerDetails.ResumeLayout(false);
            this.gbManufacturerDetails.PerformLayout();
            this.gbComputerDetails.ResumeLayout(false);
            this.gbComputerDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbManufacturerDetails;
        private System.Windows.Forms.Label lblManufacturerCountry;
        private System.Windows.Forms.Label lblManufacturerName;
        private System.Windows.Forms.Label lblComputers;
        private System.Windows.Forms.ListBox lbModels;
        private System.Windows.Forms.Label lblFields;
        private System.Windows.Forms.GroupBox gbComputerDetails;
        private System.Windows.Forms.Button btnRemoveComputer;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Label lblComputerSystem;
        private System.Windows.Forms.Label lblComputerType;
        private System.Windows.Forms.Button btnAddComputer;
        private System.Windows.Forms.Button btnClose;
    }
}