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
    public partial class frmDesktopDetails
    {
        public static readonly frmDesktopDetails Instance = new frmDesktopDetails();

        private frmDesktopDetails()
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

        protected virtual async Task setDetails()
        {
            await base.setDetails();
            nudPowerSupply.Value = model.PowerSupply;

            cbTowerForm.DataSource = prexistingFieldData.TowerForms;
            cbTowerForm.Text = model.TowerForm;
        }

        protected async override Task pushData()
        {
            await base.pushData();
            model.PowerSupply = Convert.ToInt16(nudPowerSupply.Value);
            model.TowerForm = cbTowerForm.Text;
        }

    }
}
