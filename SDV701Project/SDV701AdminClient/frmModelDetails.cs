using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDV701AdminClient
{
    /// <date>2018/06/25</date>
    /// <author>Tim Gentry</author>
    /// <summary>
    /// Base form for editing computer models.
    /// </summary>
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
            newModel = String.IsNullOrEmpty(model.name);
            Console.WriteLine("Model name: " + model.name + newModel.ToString());
            tbName.Enabled = newModel;
            try
            {
                // Ensure information presented is the most recent version
                bool loadedModelIsCurrent = model.modifiedDate == (await ServiceClient.GetModifiedDateAsync(model.name));
                if (!loadedModelIsCurrent)
                {
                    Console.WriteLine("Refreshing model.");
                    ComputerModel retrievedModel = await ServiceClient.GetComputerModelAsync(model.name);
                    if (retrievedModel != null)
                        model = retrievedModel;
                }
                
                // Load preexisting field data from database
                prexistingFieldData = await ServiceClient.GetModelDetailPrexistingFieldDataAsync();

                this.Text = $"{(newModel ? "New " : "")}{model.manufacturer} {model.type}";

                tbName.Text = model.name;
                nudPrice.Value = model.price;
                nudQuantity.Value = model.quantity;
                cbOperatingSystem.DataSource = prexistingFieldData.OperatingSystems;
                cbOperatingSystem.Text = model.operatingSystem;
                nudMemory.Value = model.memory;
                cbProcessorFamily.DataSource = prexistingFieldData.ProcessorFamilies;
                cbProcessorFamily.Text = model.processorFamily;
                nudStorage.Value = model.storage;
                cbGraphicsFamily.DataSource = prexistingFieldData.GraphicsFamilies;
                cbGraphicsFamily.Text = model.graphicsFamily;
                lblModification.Text = $"Modified: {model.modifiedDate.ToLocalTime().ToLongDateString()} {model.modifiedDate.ToLocalTime().ToLongTimeString()}";
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
            if (newModel)
                    model.name = tbName.Text;

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
            model.quantity = Convert.ToInt16(nudQuantity.Value);

            model.price = nudPrice.Value;
            model.operatingSystem = cbOperatingSystem.Text;
            model.processorFamily = cbProcessorFamily.Text;
            model.graphicsFamily = cbGraphicsFamily.Text;
            model.memory = Convert.ToByte(nudMemory.Value);
        }

        private async Task<int> getChangesToStock()
        {
            try
            {
                int currentStock = await ServiceClient.GetComputerModelStockQuantityAsync(model.name);
                int stockDifference = currentStock - model.quantity;

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
                    // Handle loaded date mismatch with stored date
                    DateTime storedModificationDate = await ServiceClient.GetModifiedDateAsync(model.name);

                    if (model.modifiedDate < storedModificationDate)
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
                    // Push the changes if still rquired
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
