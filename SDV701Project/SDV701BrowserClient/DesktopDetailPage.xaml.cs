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
    /// An empty page that can be used on its own or navigated to within a Frame.
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
                bool loadedModelIsCurrent = model.ModifiedDate == (await ServiceClient.GetModifiedDateAsync(model.Name));
                if (!loadedModelIsCurrent)
                    model = await ServiceClient.GetComputerModelAsync(model.Name);
            }
            catch (HttpRequestException)
            {
                showConnectionError();
            }

            lblName.Text = $"{model.Manufacturer} Desktop: {model.Name}";
            lblPrice.Text = $"Price: {model.Price.ToString("C2")}";
            lblStock.Text = $"Number Available: {model.Quantity}";
            lblOperatingSystem.Text = $"Operating System: {model.OperatingSystem}";
            lblMemory.Text = $"RAM: {model.Memory} Gigabytes";
            lblStorage.Text = $"Storage: {model.Storage} Gigabytes";
            lblProcessorFamily.Text = $"Processor: {model.ProcessorFamily}";
            lblGraphicsFamily.Text = $"Graphics: {model.GraphicsFamily}";
            lblTowerSize.Text = $"Tower Size: {model.TowerForm}";
            lblPowerSupply.Text = $"Power Supply: {model.PowerSupply}";
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
            lblConfirmationGridText.Text = $"Create order for {orderQuantity} {model.Name} models? The total of this order will be {model.Price * orderQuantity:C2}";
            confirmationGrid.Visibility = Visibility.Visible;
        }

        private async void createOrder()
        {
            PurchaseOrder order = new PurchaseOrder()
            {
                Product = model,
                CustomerName = tbOrderName.Text,
                CustomerStreetAddress = tbOrderAddress.Text,
                CustomerCity = tbOrderCity.Text,
                CustomerPostCode = tbOrderPostCode.Text,
                ProductPrice = model.Price,
                Quantity = Convert.ToInt16(tbOrderQuantity.Text)
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
                    model.Quantity = (short)(await ServiceClient.GetComputerModelStockQuantityAsync(model.Name));
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
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
                return;
            if (rootFrame.CanGoBack)
                rootFrame.GoBack();
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
                // Check value is not too high.
                if (requestedQuantity > model.Quantity)
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
                if (await ServiceClient.GetComputerModelExistsAsync(model.Name))
                {
                    if (await ServiceClient.GetModifiedDateAsync(model.Name) == model.ModifiedDate)
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
