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
    public partial class frmSales : Form
    {
       
        public frmSales()
        {
            InitializeComponent();
        }


        // Click events
        private void btnRegister_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 1;
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 0;
        }
        private void btnUserInfo_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 2;
          //  DGVUserInfo.ReadOnly = true;
        }
        private void btnDeactivatedUsers_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 3;
            DGVDeactivatedUsers.ReadOnly = true;
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btnAdminConfirmRegister_Click(object sender, EventArgs e)
        {

        }

      

        
        
    }
}
