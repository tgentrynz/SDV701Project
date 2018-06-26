using System;
using System.Windows.Forms;

namespace SDV701AdminClient
{
    /// <date>2018/06/25</date>
    /// <author>Tim Gentry</author>
    /// <summary>
    /// Doalog box for selecting a type of computer.
    /// </summary>
    public partial class frmModelTypeDialog : Form
    {
        private static frmModelTypeDialog instance = new frmModelTypeDialog();

        private frmModelTypeDialog()
        {
            InitializeComponent();
        }

        private void init()
        {
            cbOptions.SelectedIndex = 0;
        }

        public static string Run()
        {
            string result = null;
            instance.init();
            instance.ShowDialog();
            
            if(instance.DialogResult == DialogResult.OK)
            {
                result = ((string)instance.cbOptions.SelectedItem).ToLower();
            }
            return result;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
