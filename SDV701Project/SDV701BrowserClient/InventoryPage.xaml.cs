using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class InventoryPage : Page
    {
        private ComputerManufacturer manufacturer;
        private Dictionary<string, Type> detailPages = new Dictionary<string, Type>()
        {
            { "desktop", typeof(DesktopDetailPage)},
            { "laptop", typeof(LaptopDetailPage)}
        };

        public InventoryPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            // Clean up existing data
            lbModels.ItemsSource = null;
            refreshModelDetails(null);

            if (e.Parameter != null)
            {
                try
                {
                    await loadManufacturer((int)(e.Parameter));
                }
                catch(HttpRequestException ex)
                {
                    showConnectionError();
                }
            }
            else
            {
                showMessage("There was a navigation error.");
            }
        }

        private async Task loadManufacturer(int manufacturerCode)
        {
            manufacturer = await ServiceClient.GetManufacturerAsync(manufacturerCode);
            if (manufacturer != null)
                refreshManufacturerDetails();
            else
            {
                showMessage("The selected manufacturer has been removed. You will be returned to the front page.");
                btnMessageGridOK.Click += btnMessageGridOK_ClickClose;
            }
        }

        private void refreshManufacturerDetails()
        {
            lblBrand.Text = $"Brand: {manufacturer.Name}";
            lblCountry.Text = $"Country: {manufacturer.Country}";

            
            lbModels.ItemsSource = manufacturer.Models;
        }

        private void refreshModelDetails(ComputerModel model)
        {
            Console.WriteLine("Entered");
            bool b = model != null;
            lblModel.Text = $"Selected product: { (b? model.Name: "")}";
            lblType.Text = $"Computer Type: { (b? model.type: "")}";
            lblSystem.Text = $"Operating System: { (b? model.OperatingSystem: "")}";
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            App.BackPress();
        }

        private void showMessage(string message)
        {
            // Remove existing behaviour for OK press.
            removeMessageGridEventHandlers();
            // Show the message.
            lblMessageGridText.Text = message;
            messageGrid.Visibility = Visibility.Visible;
        }

        private void showConnectionError()
        {
            App.reportConnectionLost();
            showMessage("Could not establish a connection to the data server. You will be returned to the front page.");
            btnMessageGridOK.Click += btnMessageGridOK_ClickClose;
        }

        private async Task viewModel()
        {
            if (lbModels.SelectedItem != null)
            {
                try
                {
                    ComputerModel model = (ComputerModel)lbModels.SelectedItem;
                    bool itemExists = await ServiceClient.GetComputerModelExistsAsync(model.Name);
                    if (itemExists)
                    {
                        // Navigate to form
                        if (detailPages.ContainsKey(model.type))
                        {
                            this.Frame.Navigate(detailPages[model.type], model);
                        }
                    }
                    else
                    {
                        showMessage("The selected item no longer exists.");
                        btnMessageGridOK.Click += btnMessageGridOK_ClickRefresh;
                    }
                }
                catch (HttpRequestException ex)
                {
                    showConnectionError();
                }
            }
        }

        private void lbModels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refreshModelDetails((ComputerModel)lbModels.SelectedItem);
        }

        private void lbModels_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            viewModel();
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            viewModel();
        }
  

        private void btnMessageGridOK_ClickClose(object sender, RoutedEventArgs e)
        {
            messageGrid.Visibility = Visibility.Collapsed;
            this.Frame.Navigate(typeof(MainPage));
        }

        private void btnMessageGridOK_ClickRefresh(object sender, RoutedEventArgs e)
        {
            messageGrid.Visibility = Visibility.Collapsed;
            loadManufacturer(manufacturer.Code);
        }

        private void removeMessageGridEventHandlers()
        {
            btnMessageGridOK.Click -= btnMessageGridOK_ClickClose;
            btnMessageGridOK.Click -= btnMessageGridOK_ClickRefresh;
        }


    }
}
