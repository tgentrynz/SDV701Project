using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDV701AdminClient
{
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
            nudScreenSize.Value = model.ScreenSize;
            nudBatteryLife.Value = model.BatteryLife;
            chbFullSizeKeyboard.Checked = model.FullsizeKeyboard;
            chbWebCamera.Checked = model.Webcamera;
        }

        protected async override Task pushData()
        {
            await base.pushData();
            model.ScreenSize = Convert.ToByte(nudScreenSize.Value);
            model.BatteryLife = Convert.ToByte(nudBatteryLife.Value);
            model.Webcamera = chbWebCamera.Checked;
            model.FullsizeKeyboard = chbFullSizeKeyboard.Checked;
        }
    }
}
