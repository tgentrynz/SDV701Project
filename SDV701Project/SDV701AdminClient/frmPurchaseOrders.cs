using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDV701AdminClient
{
    public partial class frmPurchaseOrders : Form
    {
        public static readonly frmPurchaseOrders Instance = new frmPurchaseOrders();

        private List<PurchaseOrder> orders;

        private frmPurchaseOrders()
        {
            InitializeComponent();
        }

        public static void Run()
        {
            Instance.refreshOrders();
            Instance.ShowDialog();
        }

        private void lbOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbOrders.SelectedItem != null)
                updateDetails((PurchaseOrder)lbOrders.SelectedItem);
        }

        private void updateDetails(PurchaseOrder order)
        {
            bool b = order != null;
            gbOrderDetails.Text = b ? order.OrderNumber.ToString("D10") : "";
            lblCustomerName.Text = b ? order.CustomerName : "";
            lblCustomerStreetAddress.Text = b ? order.CustomerStreetAddress : "";
            lblCustomerCity.Text = b ? order.CustomerCity : "";
            lblCustomerPostCode.Text = b ? order.CustomerPostCode : "";

            lblManufacturerName.Text = b ? "???" : "";
            lblProductName.Text = b ? (order.Product != null ? order.Product.Name: "ITEM REMOVED") : "";

            btnViewDetails.Enabled = b ? order.Product != null : false;
        }

        private async Task refreshOrders()
        {
            lbOrders.DataSource = null;
            updateDetails(null);
            if (Program.Connected)
            {
                try
                {
                    orders = await ServiceClient.GetPurchaseOrdersAsync();

                    if (orders.Count > 0)
                    {
                        lbOrders.DataSource = orders;
                    }
                    
                }
                catch (HttpRequestException ex)
                {
                    orders = new List<PurchaseOrder>();
                    showConnectionError();
                    DialogResult = DialogResult.Abort;
                }
                finally
                {
                    Decimal orderTotal = 0M;
                    foreach (PurchaseOrder order in orders)
                    {
                        orderTotal += (order.ProductPrice * order.Quantity);
                        Console.WriteLine(orderTotal);
                    }
                    lblTotal.Text = $"Total Value: " + orderTotal.ToString("C2");
                }
            }
            else
                DialogResult = DialogResult.Abort;
        }

        private void showConnectionError()
        {
            Program.reportConnectionLost();
            MessageBox.Show("Connection to the data server has been lost.");
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            btnRemove.Enabled = false;
            PurchaseOrder order = (PurchaseOrder)lbOrders.SelectedItem;
            if (order != null)
            {
                
                if (MessageBox.Show($"Do you really want to remove order {order.OrderNumber}?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        string result = await ServiceClient.DeletePurchaseOrderAsync(order.OrderNumber);
                        switch (result.ToString())
                        {
                            case "SUCCESS":
                                MessageBox.Show($"Order {order.OrderNumber} was removed.");
                                break;
                            case "COUNT ERROR":
                                MessageBox.Show("Many rows were removed.");
                                break;
                            default:
                                MessageBox.Show("An unexpected behaviour was encountered.");
                                break;
                        }
                    }
                    catch (HttpRequestException)
                    {
                        showConnectionError();
                        DialogResult = DialogResult.Abort;
                    }
                }
                
            }
            await refreshOrders();
            btnRemove.Enabled = true;
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            PurchaseOrder order = (PurchaseOrder)lbOrders.SelectedItem;
            if (order != null)
            {
                if (order.Product != null)
                {
                    order.Product.showDetails();
                    refreshOrders();
                }
                    
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            await refreshOrders();
            btnRefresh.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
