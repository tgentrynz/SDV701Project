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
    public partial class frmManufacturers : Form
    {
        private static frmManufacturers instance;
        public static frmManufacturers Instance
        {
            get
            {
                if (instance == null)
                    instance = new frmManufacturers();
                return instance;
            }
        }
        private Dictionary<int, string> loadedManufacturers;

        private frmManufacturers()
        {
            InitializeComponent();
            setInputAllowed(false);
            refreshConnection();
        }

        private async Task refreshConnection()
        {
            setInputAllowed(false);
            showConnectButton(false);
            lbManufacturers.DataSource = null;

            bool connected = await Program.establishConnectionAsync();

            if (connected)
            {
                try
                {
                    if (connected)
                    {                        
                        loadedManufacturers = await ServiceClient.getManufacturersNamesAsync();
                        lbManufacturers.DataSource = loadedManufacturers.Values.ToList();
                        setInputAllowed(true);
                    }
                }
                catch (HttpRequestException ex)
                {
                    showConnectionError();
                }
            }
            else
            {
                showConnectionError();
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            frmManufacturerDetails.Run((from g in loadedManufacturers where g.Value == lbManufacturers.SelectedItem.ToString() select g.Key).First());
            refreshConnection();
        }

        private void btnViewOrders_Click(object sender, EventArgs e)
        {
            frmPurchaseOrders.Run();
            refreshConnection();
        }

        private void showConnectionError()
        {
            showConnectButton(true);
            MessageBox.Show("Could not establish connection to the data server.");
        }

        private void setInputAllowed(bool allow)
        {
            lbManufacturers.Enabled = allow;
            btnViewDetails.Enabled = allow;
            btnViewOrders.Enabled = allow;
        }
        
        private void showConnectButton(bool show)
        {
            btnConnect.Enabled = show;
            btnConnect.Visible = show;
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            setInputAllowed(false);
            btnConnect.Enabled = false;
            await refreshConnection();    
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
