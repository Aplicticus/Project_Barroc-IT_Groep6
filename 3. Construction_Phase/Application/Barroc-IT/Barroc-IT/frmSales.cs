using System;
using System.Windows.Forms;

namespace Barroc_IT
{
    public partial class frmSales : Form
    {
        private DatabaseHandler handler;
        private frmLogin loginForm;

        private int selectedCustomer = 0;

        private bool closing = false;
        public frmSales(DatabaseHandler handler, frmLogin loginForm)
        {
            InitializeComponent();
            this.handler = handler;
            this.loginForm = loginForm;
        }

        private void btnSalesSelectCustomer_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 1;
        }

        private void frmSales_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closing)
            {
                CloseToLogin();
                closing = true;
            }
        }

        private void CloseToLogin()
        {
            closing = true;
            loginForm.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            CloseToLogin();
        }

        private void dgvUserInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvUserInfo.Columns["cViewButton"].Index)
            {
                selectedCustomer = int.Parse(dgvUserInfo.Rows[e.RowIndex].Cells["cViewButton"].Value.ToString());
                //LoadCustomerDetails();
                //LoadAppointmentDetails();
                tbContr.SelectedIndex = 2;
            }
        }

    }
}
