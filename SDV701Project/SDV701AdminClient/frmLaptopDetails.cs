using System;
using System.Threading.Tasks;

namespace SDV701AdminClient
{
    /// <date>2018/06/25</date>
    /// <author>Tim Gentry</author>
    /// <summary>
    /// A form for editing the details of laptop computers.
    /// </summary>
    public partial class frmLaptopDetails
    {
        public static readonly frmLaptopDetails Instance = new frmLaptopDetails();

        private frmLaptopDetails()
        {
            InitializeComponent();
        }

        public static void Run(ComputerModel model, bool editing)
        {
            Instance.model = model;
            Instance.setDetails();
            Instance.setButtons(editing);
            Instance.ShowDialog();
        }

        protected override async Task setDetails()
        {
            await base.setDetails();
            nudScreenSize.Value = model.screenSize;
            nudBatteryLife.Value = model.batteryLife;
            chbFullSizeKeyboard.Checked = model.fullsizeKeyboard;
            chbWebCamera.Checked = model.webcamera;
        }

        protected async override Task pushData()
        {
            await base.pushData();
            model.screenSize = Convert.ToByte(nudScreenSize.Value);
            model.batteryLife = Convert.ToByte(nudBatteryLife.Value);
            model.webcamera = chbWebCamera.Checked;
            model.fullsizeKeyboard = chbFullSizeKeyboard.Checked;
        }
    }
}
