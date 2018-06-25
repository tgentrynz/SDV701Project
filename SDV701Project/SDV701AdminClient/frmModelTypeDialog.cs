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
