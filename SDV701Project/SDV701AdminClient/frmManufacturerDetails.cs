using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDV701AdminClient
{
    /// <date>2018/06/25</date>
    /// <author>Tim Gentry</author>
    /// <summary>
    /// A form for view details about a manufacturer and selecting computers by that manufacturer.
    /// </summary>
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

        private async Task setDetails(int manufacturerCode)
        {
            // Check if a new manufacturer is being added.
            bool newManufacturer = true;
            int currentIndex = 0;

            if (manufacturer != null)
                newManufacturer = manufacturer.code != manufacturerCode;

            if (!newManufacturer)
                currentIndex = lbModels.SelectedIndex;

            // Empty existing data
            lbModels.DataSource = null;
            setInputAllowed(false);

            // Attempt to laod data from server.
            if (Program.Connected)
            {
                try
                {
                    manufacturer = await ServiceClient.GetManufacturerAsync(manufacturerCode);
                    setManufacturerDetails();

                    if (manufacturer.models.Count > 0)
                    {
                        lbModels.DataSource = manufacturer.models;
                        lbModels.SelectedIndex = (currentIndex < manufacturer.models.Count ? currentIndex : 0);
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
            this.Text = manufacturer.name;
            lblManufacturerName.Text = manufacturer.name;
            lblManufacturerCountry.Text = manufacturer.country;
            gbManufacturerDetails.Text = $"Manufacturer: {manufacturer.code.ToString("D5")}";
        }

        private void setComputerDetails()
        {
            ComputerModel model = (ComputerModel)lbModels.SelectedItem;
            bool b = (model != null);
            gbComputerDetails.Text = b ? model.name : "";
            lblComputerType.Text = $"Type: {(b ? model.type : "")}";
            lblComputerSystem.Text = $" System: {(b ? model.operatingSystem: "")}";
        }

        private void editComputerModel(ComputerModel model)
        {
            if (model != null)
            {
                model.editDetails();
                setDetails(manufacturer.code);
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
                editComputerModel(new ComputerModel(type, manufacturer.name));
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
                // get confirmation from user
                if (MessageBox.Show($"Do you really want to delete model: {model.name}?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        // Notify server of deletion.
                        string result = await ServiceClient.DeleteComputerModelAsync(model.name);
                        switch (result.ToString())
                        {
                            case "SUCCESS":
                                MessageBox.Show($"The model: {model.name} was removed.");
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
                    setDetails(manufacturer.code);
                }
            }
            btnRemoveComputer.Enabled = true;
        }

    }
}
