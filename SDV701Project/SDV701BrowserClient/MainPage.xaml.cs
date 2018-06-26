using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SDV701BrowserClient
{
    /// <summary>
    /// Home page for the app. Provides a list of manufacturers.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Dictionary<int, string> loadedManufacturers;

        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(200, 100));
            ApplicationView.PreferredLaunchViewSize = new Size(480, 800);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            // Stop user from being able to navigate back to an error frame the led here.
            ((Frame)Window.Current.Content).BackStack.Clear();

            // Load data from server
            setInputAllowed(false);
            refreshManufacturers();
        }

        private async Task refreshManufacturers()
        {
            bool connected = App.Connected ? true : await App.establishConnectionAsync();
            try
            {
                if (connected)
                {
                    loadedManufacturers = await ServiceClient.getManufacturersNamesAsync();
                    lbManufacturers.ItemsSource = loadedManufacturers.Values;
                    setInputAllowed(true);
                }
                else
                    throw new HttpRequestException();
            }
            catch(HttpRequestException ex)
            {
                showConnectionError();
            }
            catch(Exception ex)
            {
                showMessage("An unexpected error occured.");
            }
        }

        private void searchManufacturers(string searchString)
        {
            lbManufacturers.ItemsSource = (from man in loadedManufacturers where man.Value.Contains(searchString) select man.Value).ToList();
        }

        private void showMessage(string message)
        {
            messageGrid.Visibility = Visibility.Visible;
            lblMessageGridText.Text = message;

            setInputAllowed(false);
        }

        private void viewManufacturerProducts()
        {
            this.Frame.Navigate(typeof(InventoryPage), (from man in loadedManufacturers where man.Value == (string)lbManufacturers.SelectedItem select man.Key).ToList().First());
        }

        private void showConnectionError()
        {
            showMessage("Could not establish a connection to the data server. Press OK to reattempt connection.");
        }

        private void setInputAllowed(bool allow)
        {
            btnView.IsEnabled = allow;
            lbManufacturers.IsEnabled = allow;
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            if (lbManufacturers.SelectedItem != null)
                viewManufacturerProducts();
        }

        private void lbManufacturers_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (lbManufacturers.SelectedItem != null)
                viewManufacturerProducts();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchManufacturers(tbSearch.Text);
        }

        private void btnMessageGridOK_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
            messageGrid.Visibility = Visibility.Collapsed;
            refreshManufacturers();
        }

    }
}
