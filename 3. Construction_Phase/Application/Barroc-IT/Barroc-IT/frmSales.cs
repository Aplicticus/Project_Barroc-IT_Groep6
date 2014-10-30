using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Barroc_IT
{
    public partial class frmSales : Form
    {
        // Properties, Instances
        private DatabaseHandler handler;
        private frmLogin loginForm;
        private SqlQueryHandler sqlhandler;
        private DataTableHandler dthandler;

        private int selectedCustomer = 0;
        private bool closing = false;
        public frmSales(DatabaseHandler handler, frmLogin loginForm, DataTableHandler dthandler, SqlQueryHandler sqlhandler)
        {
            InitializeComponent();
            this.handler = handler;
            this.loginForm = loginForm;
            this.dthandler = dthandler;
            this.sqlhandler = sqlhandler;
        }

        // Click Events
        private void btnSalesSelectCustomer_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 1;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = tbContr.SelectedIndex - 1;
        }
        private void btnSalesHome_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 0;
        }
        private void btnSalesAddCustomer_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 6;
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult confirmationLogout = MessageBox.Show("Are you sure you want to log out?", "Confirm log out", MessageBoxButtons.YesNo);
            if (confirmationLogout == DialogResult.Yes)
            {
                CloseToLogin();
            }
        }
        private void btnViewAppointments_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 3;
        }
        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 5;
        }
        private void btnAppointmentAdd_Click(object sender, EventArgs e)
        {

        }
        private void btnAddInvoiceCancel_Click(object sender, EventArgs e)
        {

        }
        private void btnCusAddCustomer_Click(object sender, EventArgs e)
        {

        }
        private void btnEditFields_Click(object sender, EventArgs e)
        {

        }
        private void btnAppointmentSearch_Click(object sender, EventArgs e)
        {

        }

        // Cell Content Clicks
        private void dgvUserInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvUserInfo.Columns["cViewButton"].Index)
            {
                selectedCustomer = int.Parse(dgvUserInfo.Rows[e.RowIndex].Cells["cViewButton"].Value.ToString());
                tbContr.SelectedIndex = 2;
            }
        }
        private void dgvAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvAppointments.Columns["cAppointmentViewButton"].Index)
            {
                selectedCustomer = int.Parse(dgvAppointments.Rows[e.RowIndex].Cells["cAppointmentViewButton"].Value.ToString());
                tbContr.SelectedIndex = 4;
            }
        }

        // Methods
        private void AddItemsToDataGridView(DataTable table, DataGridView dataGridView, string idColumnName)
        {
            dataGridView.Rows.Clear();
            table.Columns.Add(idColumnName);
            table.Columns[idColumnName].SetOrdinal(0);
            foreach (DataRow dr in table.Rows)
            {
                dataGridView.Rows.Add(dr.ItemArray);
            }
        }

        // Close To Login
        private void CloseToLogin()
        {
            closing = true;
            loginForm.ClearTextBoxes();
            loginForm.Show();
            this.Close();
        }

        // Form Closing
        private void frmSales_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closing)
            {
                CloseToLogin();
                closing = true;
            }
        }
    }
}
