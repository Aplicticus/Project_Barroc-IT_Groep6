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
        private DatabaseHandler handler;
        public frmDevelopment(DatabaseHandler handler)
        {
            InitializeComponent();
            cBoxSearch.SelectedIndex = 0;
            this.handler = handler;
        }

        private void btnDevSelectCustomer_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 1;
        }
    }
}
