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
    public partial class frmManufacturerDetails : Form
    {
        public static readonly frmManufacturerDetails Instance = new frmManufacturerDetails();

        private ComputerManufacturer manufacturer;
        
        private frmManufacturerDetails()
        {
            InitializeComponent();
        }

        public static void Run(int manufacturer)
        {
            Instance.setDetails(manufacturer);
            Instance.ShowDialog();
        }

        private async void setDetails(int manufacturerCode)
        {
            bool newManufacturer = true;
            int currentIndex = 0;

            if (manufacturer != null)
                newManufacturer = manufacturer.Code != manufacturerCode;

            if (!newManufacturer)
                currentIndex = lbModels.SelectedIndex;

            lbModels.DataSource = null;
            setInputAllowed(false);

            if (Program.Connected)
            {
                try
                {
                    manufacturer = await ServiceClient.GetManufacturerAsync(manufacturerCode);
                    setManufacturerDetails();

                    if (manufacturer.Models.Count > 0)
                    {
                        lbModels.DataSource = manufacturer.Models;
                        lbModels.SelectedIndex = (currentIndex < manufacturer.Models.Count ? currentIndex : 0);
                    }

                    setComputerDetails();

                    setInputAllowed(true);
                }
                catch (HttpRequestException ex)
                {
                    showConnectionError();
                    setInputAllowed(false);
                    DialogResult = DialogResult.Abort;
                }
            }
            else
                DialogResult = DialogResult.Abort;
        }

        private void setManufacturerDetails()
        {
            this.Text = manufacturer.Name;
            lblManufacturerName.Text = manufacturer.Name;
            lblManufacturerCountry.Text = manufacturer.Country;
            gbManufacturerDetails.Text = $"Manufacturer: {manufacturer.Code.ToString("D5")}";
        }

        private void setComputerDetails()
        {
            ComputerModel model = (ComputerModel)lbModels.SelectedItem;
            bool b = (model != null);
            gbComputerDetails.Text = b ? model.Name : "";
            lblComputerType.Text = b ? model.Type : "";
            lblComputerSystem.Text = b ? model.OperatingSystem: "";
        }

        private void editComputerModel(ComputerModel model)
        {
            if (model != null)
            {
                model.editDetails();
                setDetails(manufacturer.Code);
            }
        }

        private void lbModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            setComputerDetails();
        }

        private void btnAddComputer_Click(object sender, EventArgs e)
        {

            string type = frmModelTypeDialog.Run();
            if (type != null)
                editComputerModel(new ComputerModel(type, manufacturer.Name));
        }

        private void editModel_Click(object sender, EventArgs e)
        {
            editComputerModel((ComputerModel)lbModels.SelectedItem);
        }

        private void showConnectionError()
        {
            Program.reportConnectionLost();
            MessageBox.Show("Connection to the data server has been lost.");
        }

        private void setInputAllowed(bool allow)
        {
            lbModels.Enabled = allow;
            btnAddComputer.Enabled = allow;
            btnViewDetails.Enabled = allow;
            btnRemoveComputer.Enabled = allow;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private async void btnRemoveComputer_Click(object sender, EventArgs e)
        {
            btnRemoveComputer.Enabled = false;
            ComputerModel model = (ComputerModel)lbModels.SelectedItem;
            if (model != null)
            {
                if (MessageBox.Show($"Do you really want to delete model: {model.Name}?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        string result = await ServiceClient.DeleteComputerModelAsync(model.Name);
                        switch (result.ToString())
                        {
                            case "SUCCESS":
                                MessageBox.Show($"The model: {model.Name} was removed.");
                                break;
                            case "COUNT ERROR":
                                MessageBox.Show("Many rows were removed.");
                                break;
                            default:
                                MessageBox.Show("An unexpected behaviour was encountered.");
                                break;
                        }
                    }
                    catch (HttpRequestException) { }
                    setDetails(manufacturer.Code);
                }
            }
            btnRemoveComputer.Enabled = true;
        }

    }
}
