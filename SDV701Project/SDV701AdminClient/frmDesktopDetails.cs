using System;
using System.Threading.Tasks;

namespace SDV701AdminClient
{
    /// <date>2018/06/25</date>
    /// <author>Tim Gentry</author>
    /// <summary>
    /// A form for editing the details of desktop computers.
    /// </summary>
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
            nudPowerSupply.Value = model.powerSupply;

            cbTowerForm.DataSource = prexistingFieldData.TowerForms;
            cbTowerForm.Text = model.towerForm;
        }

        protected async override Task pushData()
        {
            await base.pushData();
            model.powerSupply = Convert.ToInt16(nudPowerSupply.Value);
            model.towerForm = cbTowerForm.Text;
        }

    }
}
