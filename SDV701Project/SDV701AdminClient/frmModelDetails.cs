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
    public partial class frmModelDetails : Form
    {
        protected ComputerModel model;
        protected bool newModel;
        protected ModelDetailPrexistingFieldData prexistingFieldData;

        public frmModelDetails()
        {
            InitializeComponent();
        }
        
        protected virtual async Task setDetails()
        {
            newModel = String.IsNullOrEmpty(model.Name);
            tbName.Enabled = newModel;
            try
            {
                // Ensure information presented is the most recent version
                bool loadedModelIsCurrent = model.ModifiedDate == (await ServiceClient.GetModifiedDateAsync(model.Name));
                if (!loadedModelIsCurrent)
                    model = await ServiceClient.GetComputerModelAsync(model.Name);
                
                // Load preexisting field data from database
                prexistingFieldData = await ServiceClient.GetModelDetailPrexistingFieldDataAsync();

                this.Text = $"{(newModel ? "New " : "")}{model.Manufacturer} {model.Type}";

                tbName.Text = model.Name;
                nudPrice.Value = model.Price;
                nudQuantity.Value = model.Quantity;
                cbOperatingSystem.DataSource = prexistingFieldData.OperatingSystems;
                cbOperatingSystem.Text = model.OperatingSystem;
                nudMemory.Value = model.Memory;
                cbProcessorFamily.DataSource = prexistingFieldData.ProcessorFamilies;
                cbProcessorFamily.Text = model.ProcessorFamily;
                nudStorage.Value = model.Storage;
                cbGraphicsFamily.DataSource = prexistingFieldData.GraphicsFamilies;
                cbGraphicsFamily.Text = model.GraphicsFamily;
                lblModification.Text = $"Modified: {model.ModifiedDate.ToLocalTime().ToLongDateString()} {model.ModifiedDate.ToLocalTime().ToLongTimeString()}";
            }
            catch (HttpRequestException ex)
            {
                showConnectionError();
                DialogResult = DialogResult.Abort;
            }
        }

        protected void setButtons(bool editing)
        {
            if (editing)
            {
                btnOK.Enabled = true;
                btnOK.Visible = true;
                btnOK.Text = "OK";
                btnCancel.Text = "Cancel";
            }
            else
            {
                btnOK.Enabled = false;
                btnOK.Visible = false;
                btnOK.Text = "Error";
                btnCancel.Text = "Close";
            }

            List<Type> typesToModify = new List<Type>() { typeof(NumericUpDown), typeof(TextBox), typeof(ComboBox), typeof(CheckBox) };
            foreach (Control c in Controls)
            {
                if (c != tbName)
                {
                    Type controlType = c.GetType();   
                    if (typesToModify.Contains(controlType))
                    {
                        c.Enabled = editing;
                    }
                }
            }
        }

        protected async virtual Task pushData()
        {
            // Store name if this is a new model.
            if(newModel)
                model.Name = tbName.Text;

            // Handle any purchases made while data was being editied.
            if (!newModel)
            {
                int quantityDifference = await getChangesToStock();
                if (quantityDifference != 0)
                {
                    DialogResult dr = MessageBox.Show("The available stock has changed since the information was loaded.\nThis is probably due to recent purchase orders being submitted.\nThe value submitted will be updated to reflect both these new purchases and any changes you have made.");
                    decimal newQuantity = nudQuantity.Value + quantityDifference;
                    if (newQuantity < 0)
                    {
                        dr = MessageBox.Show("Warning!\nThe quanity you have entered less the quantities required for recent purchase orders is less than 0.\nThis means you do not have enough stock on hand to meet these orders.");
                    }
                    nudQuantity.Value = newQuantity;
                }
            }
            model.Quantity = Convert.ToInt16(nudQuantity.Value);

            model.Price = nudPrice.Value;
            model.OperatingSystem = cbOperatingSystem.Text;
            model.ProcessorFamily = cbProcessorFamily.Text;
            model.GraphicsFamily = cbGraphicsFamily.Text;
            model.Memory = Convert.ToByte(nudMemory.Value);
        }

        private async Task<int> getChangesToStock()
        {
            try
            {
                int currentStock = await ServiceClient.GetComputerModelStockQuantityAsync(model.Name);
                int stockDifference = currentStock - model.Quantity;

                return stockDifference;
            }
            catch(HttpRequestException ex)
            {
                showConnectionError();
                DialogResult = DialogResult.Abort;
                return 0;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbName.Text))
            {
                await pushData();
                bool pushChanges = true;

                btnOK.Enabled = false;
                try
                {
                    DateTime storedModificationDate = await ServiceClient.GetModifiedDateAsync(model.Name);

                    if (model.ModifiedDate < storedModificationDate)
                    {
                        DialogResult warnUser = new frmModificationDateDialog().ShowDialog();
                        switch (warnUser)
                        {
                            case DialogResult.Retry:
                                setDetails();
                                pushChanges = false;
                                break;
                            case DialogResult.Abort:
                                pushChanges = false;
                                DialogResult = DialogResult.Cancel;
                                break;
                            case DialogResult.Ignore:
                                pushChanges = true;
                                break;
                            default:
                                System.Media.SystemSounds.Asterisk.Play();
                                break;
                        }
                    }
                    if (pushChanges)
                    {
                        try
                        {
                            string result;
                            if (newModel)
                                result = (await ServiceClient.PostComputerModelAsync(model));
                            else
                                result = (await ServiceClient.PutComputerModelAsync(model));

                            switch (result)
                            {
                                case "SUCCESS":
                                    MessageBox.Show($"Computer Model successfully {(newModel ? "created" : "updated")}.");
                                    DialogResult = DialogResult.OK;
                                    break;
                                case "COUNT ERROR":
                                    MessageBox.Show("There was an error when entering the data.");
                                    break;
                                case "KEY ERROR":
                                    MessageBox.Show("A model with that name already exists.");
                                    break;
                                default:
                                    MessageBox.Show(result);
                                    MessageBox.Show("An unexpected behaviour was encountered.");
                                    DialogResult = DialogResult.OK;
                                    break;
                            }
                            
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An unexpected error occured while transmitting data.");
                        }
                    }
                }
                catch (HttpRequestException ex)
                {
                    showConnectionError();
                }
                btnOK.Enabled = true;
            }
            else
                MessageBox.Show("A model requires a model name.");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void showConnectionError()
        {
            Program.reportConnectionLost();
            MessageBox.Show("Connection to the data server has been lost.");
        }
    }
}
