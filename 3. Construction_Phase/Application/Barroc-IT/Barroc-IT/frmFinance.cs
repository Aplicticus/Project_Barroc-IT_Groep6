using System;
using System.Windows.Forms;

namespace Barroc_IT
{
    public partial class frmFinance : Form
    {
        private DatabaseHandler handler;
        private frmLogin loginForm;

        //private int selectedCustomer = 0;
        //private bool closing = false;
        public frmFinance(DatabaseHandler handler, frmLogin loginForm)
        {
            InitializeComponent();
            this.handler = handler;
            this.loginForm = loginForm;
        }

        

       

        private void CloseToLogin()
        {
            //closing = true;
            loginForm.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            CloseToLogin();
        }

        private void btnFinanceSelectCustomer_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 1;
        }

        private void btnEditFields_Click(object sender, EventArgs e)
        {

        }

        private void btnAppointmentAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnCusAddCustomer_Click(object sender, EventArgs e)
        {

        }


    }
}
