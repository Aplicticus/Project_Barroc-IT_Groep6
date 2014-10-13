using System;
using System.Windows.Forms;

namespace Barroc_IT
{
    public partial class frmFinance : Form
    {
        private DatabaseHandler handler;
        private frmLogin loginForm;

        //private int selectedCustomer = 0;
        private bool closing = false;
        public frmFinance(DatabaseHandler handler, frmLogin loginForm)
        {
            InitializeComponent();
            this.handler = handler;
            this.loginForm = loginForm;
        }

        private void CloseToLogin()
        {
            closing = true;
            loginForm.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult confirmationLogout = MessageBox.Show("Are you sure you want to log out?", "Confirm log out", MessageBoxButtons.YesNo);
            if (confirmationLogout == DialogResult.Yes)
            {
                CloseToLogin();
            }
        }

        private void btnFinanceSelectCustomer_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 1;
        }

        private void frmFinance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closing)
            {
                CloseToLogin();
            }
        }
    }
}
