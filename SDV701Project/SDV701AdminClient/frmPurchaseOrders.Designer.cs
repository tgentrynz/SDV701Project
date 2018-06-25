namespace SDV701AdminClient
{
    partial class frmPurchaseOrders
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
            this.lbOrders = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.gbOrderDetails = new System.Windows.Forms.GroupBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblManufacturerName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCustomerPostCode = new System.Windows.Forms.Label();
            this.lblCustomerCity = new System.Windows.Forms.Label();
            this.lblCustomerStreetAddress = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbOrderDetails.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbOrders
            // 
            this.lbOrders.FormattingEnabled = true;
            this.lbOrders.Items.AddRange(new object[] {
            "0000000001\t23/06/2018\tJohn Doe\t\tTC-780-UR12\t1\t$799.99\t\t$799.99"});
            this.lbOrders.Location = new System.Drawing.Point(12, 38);
            this.lbOrders.Name = "lbOrders";
            this.lbOrders.Size = new System.Drawing.Size(610, 199);
            this.lbOrders.TabIndex = 0;
            this.lbOrders.SelectedIndexChanged += new System.EventHandler(this.lbOrders_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Orders";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(556, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number                   Date                        Customer                  Pr" +
    "oduct                   Quantity    Price                       Total";
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(221, 240);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(401, 23);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Total Value: 1111111";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gbOrderDetails
            // 
            this.gbOrderDetails.Controls.Add(this.lblQuantity);
            this.gbOrderDetails.Controls.Add(this.label11);
            this.gbOrderDetails.Controls.Add(this.lblProductName);
            this.gbOrderDetails.Controls.Add(this.label9);
            this.gbOrderDetails.Controls.Add(this.lblManufacturerName);
            this.gbOrderDetails.Controls.Add(this.label7);
            this.gbOrderDetails.Controls.Add(this.groupBox1);
            this.gbOrderDetails.Controls.Add(this.btnRemove);
            this.gbOrderDetails.Controls.Add(this.btnViewDetails);
            this.gbOrderDetails.Location = new System.Drawing.Point(12, 252);
            this.gbOrderDetails.Name = "gbOrderDetails";
            this.gbOrderDetails.Size = new System.Drawing.Size(378, 111);
            this.gbOrderDetails.TabIndex = 4;
            this.gbOrderDetails.TabStop = false;
            this.gbOrderDetails.Text = "Order: 0000000000";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(278, 32);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(46, 13);
            this.lblQuantity.TabIndex = 8;
            this.lblQuantity.Text = "Quantity";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(268, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Quantity Ordered:";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(163, 66);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(95, 13);
            this.lblProductName.TabIndex = 6;
            this.lblProductName.Text = "Model Name Code";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(161, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Product Model:";
            // 
            // lblManufacturerName
            // 
            this.lblManufacturerName.AutoSize = true;
            this.lblManufacturerName.Location = new System.Drawing.Point(163, 32);
            this.lblManufacturerName.Name = "lblManufacturerName";
            this.lblManufacturerName.Size = new System.Drawing.Size(66, 13);
            this.lblManufacturerName.TabIndex = 4;
            this.lblManufacturerName.Text = "Brand Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(161, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Product Brand:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCustomerPostCode);
            this.groupBox1.Controls.Add(this.lblCustomerCity);
            this.groupBox1.Controls.Add(this.lblCustomerStreetAddress);
            this.groupBox1.Controls.Add(this.lblCustomerName);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(148, 85);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Details";
            // 
            // lblCustomerPostCode
            // 
            this.lblCustomerPostCode.AutoSize = true;
            this.lblCustomerPostCode.Location = new System.Drawing.Point(6, 60);
            this.lblCustomerPostCode.Name = "lblCustomerPostCode";
            this.lblCustomerPostCode.Size = new System.Drawing.Size(103, 13);
            this.lblCustomerPostCode.TabIndex = 3;
            this.lblCustomerPostCode.Text = "Customer Post Code";
            // 
            // lblCustomerCity
            // 
            this.lblCustomerCity.AutoSize = true;
            this.lblCustomerCity.Location = new System.Drawing.Point(6, 47);
            this.lblCustomerCity.Name = "lblCustomerCity";
            this.lblCustomerCity.Size = new System.Drawing.Size(71, 13);
            this.lblCustomerCity.TabIndex = 2;
            this.lblCustomerCity.Text = "Customer City";
            // 
            // lblCustomerStreetAddress
            // 
            this.lblCustomerStreetAddress.AutoSize = true;
            this.lblCustomerStreetAddress.Location = new System.Drawing.Point(6, 34);
            this.lblCustomerStreetAddress.Name = "lblCustomerStreetAddress";
            this.lblCustomerStreetAddress.Size = new System.Drawing.Size(123, 13);
            this.lblCustomerStreetAddress.TabIndex = 1;
            this.lblCustomerStreetAddress.Text = "Customer Street Address";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(6, 21);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(82, 13);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(271, 52);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(101, 23);
            this.btnRemove.TabIndex = 0;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Location = new System.Drawing.Point(271, 81);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(101, 23);
            this.btnViewDetails.TabIndex = 1;
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(416, 305);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(101, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(416, 333);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmPurchaseOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 366);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbOrderDetails);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbOrders);
            this.Name = "frmPurchaseOrders";
            this.Text = "Orders";
            this.gbOrderDetails.ResumeLayout(false);
            this.gbOrderDetails.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbOrders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.GroupBox gbOrderDetails;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCustomerPostCode;
        private System.Windows.Forms.Label lblCustomerCity;
        private System.Windows.Forms.Label lblCustomerStreetAddress;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblManufacturerName;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label label9;
    }
}