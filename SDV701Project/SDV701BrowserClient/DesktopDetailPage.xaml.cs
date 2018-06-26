using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SDV701BrowserClient
{
    /// <summary>
    /// Details about a desktop computer and ordering form.
    /// </summary>
    public sealed partial class DesktopDetailPage : Page
    {
        private ComputerModel model;

        public DesktopDetailPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if(e.Parameter != null)
            {
                model = (ComputerModel)e.Parameter;
                setDetails();
            }
        }

        private async Task setDetails()
        {
            try
            {
                // Ensure that the information being presented is current
                bool loadedModelIsCurrent = model.modifiedDate == (await ServiceClient.GetModifiedDateAsync(model.name));
                if (!loadedModelIsCurrent)
                    model = await ServiceClient.GetComputerModelAsync(model.name);
            }
            catch (HttpRequestException)
            {
                showConnectionError();
            }

            lblName.Text = $"{model.manufacturer} Desktop: {model.name}";
            lblPrice.Text = $"Price: {model.price.ToString("C2")}";
            lblStock.Text = $"Number Available: {model.quantity}";
            lblOperatingSystem.Text = $"Operating System: {model.operatingSystem}";
            lblMemory.Text = $"RAM: {model.memory} Gigabytes";
            lblStorage.Text = $"Storage: {model.storage} Gigabytes";
            lblProcessorFamily.Text = $"Processor: {model.processorFamily}";
            lblGraphicsFamily.Text = $"Graphics: {model.graphicsFamily}";
            lblTowerSize.Text = $"Tower Size: {model.towerForm}";
            lblPowerSupply.Text = $"Power Supply: {model.powerSupply}";
        }

        private void showMessage(string message)
        {
            // Remove existing behaviour for OK press.
            removeMessageGridEventHandlers();
            // Show the message.
            lblMessageGridText.Text = message;
            messageGrid.Visibility = Visibility.Visible;
        }

        private void removeMessageGridEventHandlers()
        {
            btnMessageGridOK.Click -= btnMessageGridOK_Click;
            btnMessageGridOK.Click -= btnMessageGridOK_ClickClose;
        }

        private void showConnectionError()
        {
            App.reportConnectionLost();
            showMessage("Could not establish a connection to the data server. You will be returned to the front page.");
            btnMessageGridOK.Click += btnMessageGridOK_ClickClose;
        }

        private void showConfirmationDialogue()
        {
            short orderQuantity = Convert.ToInt16(tbOrderQuantity.Text);
            lblConfirmationGridText.Text = $"Create order for {orderQuantity} {model.name} models? The total of this order will be {model.price * orderQuantity:C2}";
            confirmationGrid.Visibility = Visibility.Visible;
        }

        private async void createOrder()
        {
            PurchaseOrder order = new PurchaseOrder()
            {
                product = model,
                customerName = tbOrderName.Text,
                customerStreetAddress = tbOrderAddress.Text,
                customerCity = tbOrderCity.Text,
                customerPostCode = tbOrderPostCode.Text,
                productPrice = model.price,
                quantity = Convert.ToInt16(tbOrderQuantity.Text)
            };
            string result = await ServiceClient.PostPurchaseOrder(order);
            switch (result)
            {
                case "SUCCESS":
                    showMessage("Your order was successfully created. You will be returned to the main page.");
                    btnMessageGridOK.Click += btnMessageGridOK_ClickClose;
                    break;
                case "COUNT ERROR":
                    showMessage("There was an error processing your order.");
                    btnMessageGridOK.Click += btnMessageGridOK_Click;
                    break;
                case "STOCK ERROR":
                    model.quantity = (short)(await ServiceClient.GetComputerModelStockQuantityAsync(model.name));
                    showMessage("Sorry, there is not enough stock on hand to complete your order.");
                    btnMessageGridOK.Click += btnMessageGridOK_Click;
                    break;
                default:
                    showMessage("An unexpected behaviour was encountered.");
                    btnMessageGridOK.Click += btnMessageGridOK_Click;
                    break;
            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            App.BackPress();
        }

        private bool orderDetailsAreValid()
        {
            bool result = true;
            // Make sure text entries are not too long or empty
            List<Tuple<TextBox, int>> valuesToCheck = new List<Tuple<TextBox, int>>()
            {
                new Tuple<TextBox, int>(tbOrderName, 60),
                new Tuple<TextBox, int>(tbOrderAddress, 60),
                new Tuple<TextBox, int>(tbOrderCity, 20),
                new Tuple<TextBox, int>(tbOrderPostCode, 5),
            };
            foreach (Tuple<TextBox, int> t in valuesToCheck)
            {
                TextBox textBox = t.Item1;
                int enforcedLength = t.Item2;
                if (textBox.Text.Length > enforcedLength || string.IsNullOrWhiteSpace(textBox.Text))
                {
                    result = false;
                    textBox.Background = new SolidColorBrush(Colors.Red);
                }
                else
                    textBox.Background = new SolidColorBrush(Colors.White);
            }

            // Make sure stock requested is a number and is not greater than stock available
            try
            {
                // Attempt conversion
                short requestedQuantity = Convert.ToInt16(tbOrderQuantity.Text);
                // Check value is not too high or too low.
                if (requestedQuantity > model.quantity || requestedQuantity < 1)
                    throw new Exception();
                // If no errors return background to white.
                tbOrderQuantity.Background = new SolidColorBrush(Colors.White);
            }
            catch (Exception ex)
            {
                result = false;
                tbOrderQuantity.Background = new SolidColorBrush(Colors.Red);
            }
            return result;
        }

        private async void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (await ServiceClient.GetComputerModelExistsAsync(model.name))
                {
                    if (await ServiceClient.GetModifiedDateAsync(model.name) == model.modifiedDate)
                    {
                        if (orderDetailsAreValid())
                            showConfirmationDialogue();
                        else
                        {
                            showMessage("Please enter valid order information.");
                            btnMessageGridOK.Click += btnMessageGridOK_Click;
                        }
                    }
                    else
                    {
                        showMessage("The details for this product have been modified. Please review the information and resubmit your order.");
                        btnMessageGridOK.Click += btnMessageGridOK_Click;
                        setDetails();
                    }
                }
                else
                {
                    showMessage("The selected item no longer exists. You will be returned to the front page.");
                    btnMessageGridOK.Click += btnMessageGridOK_ClickReturn;
                }
            }
            catch (HttpRequestException)
            {
                showConnectionError();
            }
        }

        private void btnMessageGridOK_Click(object sender, RoutedEventArgs e)
        {
            messageGrid.Visibility = Visibility.Collapsed;
            setDetails();
        }

        private void btnMessageGridOK_ClickReturn(object sender, RoutedEventArgs e)
        {
            messageGrid.Visibility = Visibility.Collapsed;
            App.BackPress();
        }

        private void btnMessageGridOK_ClickClose(object sender, RoutedEventArgs e)
        {
            messageGrid.Visibility = Visibility.Collapsed;
            this.Frame.Navigate(typeof(MainPage));
        }

        private void btnConfirmationGridOK_Click(object sender, RoutedEventArgs e)
        {
            confirmationGrid.Visibility = Visibility.Collapsed;
            createOrder();
        }

        private void btnConfirmationGridCancel_Click(object sender, RoutedEventArgs e)
        {
            confirmationGrid.Visibility = Visibility.Collapsed;
        }
        
    }
}
