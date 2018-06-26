using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDV701AdminClient
{
    static class Program
    {
        private static bool connected = false;
        public static bool Connected => connected;
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ComputerModel.loadForm.Add("desktop", new ComputerModel.loadEditFormDelegate(frmDesktopDetails.Run));
            ComputerModel.loadForm.Add("laptop", new ComputerModel.loadEditFormDelegate(frmLaptopDetails.Run));

            Application.Run(frmManufacturers.Instance);
        }

        public static async Task<bool> establishConnectionAsync()
        {
            connected = await ServiceClient.getConnectionTestAsync();
            return connected;
        }
        
        public static void reportConnectionLost()
        {
            connected = false;
        }
    }
}
