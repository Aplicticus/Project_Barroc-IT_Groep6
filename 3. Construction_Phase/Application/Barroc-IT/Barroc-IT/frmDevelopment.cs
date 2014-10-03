using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barroc_IT
{
    public partial class frmDevelopment : Form
    {

        public frmDevelopment()
        {
            InitializeComponent();
            cBoxSearch.SelectedIndex = 0;
        }

        private void btnDevSelectCustomer_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 1;
        }

    }
}
