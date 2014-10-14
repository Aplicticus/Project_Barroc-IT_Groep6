using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Barroc_IT
{
    public partial class frmFinance : Form
    {
        private DatabaseHandler handler;
        private frmLogin loginForm;
        private int selectedProject;

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
            loginForm.ClearTextBoxes();
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
            //tbContr.SelectedIndex = 1;
            tbContr.SelectedIndex = 2;
        }

        private void frmFinance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closing)
            {
                CloseToLogin();
            }
        }

        private void btnEditFields_Click(object sender, EventArgs e)
        {
            if (btnEditFields.Text == "Edit Fields")
            {
                txtFinAccountID.ReadOnly = false;
                txtFinBalance.ReadOnly = false;
                txtFinLimit.ReadOnly = false;
                txtFinLegderID.ReadOnly = false;
                txtFinBTWCode.ReadOnly = false;
                cbFinBKR.Enabled = true;

                btnEditFields.Text = "Save Changes";
            }
            else if (btnEditFields.Text == "Save Changes")
            {
                // Update query to SQL for update fin details of the customer

                txtFinAccountID.ReadOnly = true;
                txtFinBalance.ReadOnly = true;
                txtFinLimit.ReadOnly = true;
                txtFinLegderID.ReadOnly = true;
                txtFinBTWCode.ReadOnly = true;
                cbFinBKR.Enabled = false;
            }


        }

        private void btnViewProjects_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 3;
        }

        private void btnInvoicesBack_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 5;
        }

        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 7;
        }

        private void btnCreateInvoice_Click(object sender, EventArgs e)
        {
            if (AddInvoice() == true)
            {
                MessageBox.Show("Invoice succesfully added!");
            }
            else
            {
                MessageBox.Show("There is a problem with adding a invoice!");
            }
        }

        private bool AddInvoice()
        {
            string sqlQuery = "INSERT INTO tbl_Invoices (PROJECT_ID, INVOICE_VALUE, INVOICE_END_DATE, INVOICE_SEND) VALUES (@SelectedProject, @InvoiceVal, @InvoiceEndDate, @InvoiceSend)";
            SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection());

            cmd.Parameters.Add(new SqlParameter("@SelectedProject", selectedProject));
            cmd.Parameters.Add(new SqlParameter("@InvoiceVal", numFinInvoiceAddValue.Value));
            cmd.Parameters.Add(new SqlParameter("@InvoiceEndDate", dtpFinInvoiceExpDate.Value));
            cmd.Parameters.Add(new SqlParameter("@InvoiceSend", dtpFinInvoiceSentDate.Value));

            cmd.Connection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnAddInvoiceBack_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 4;
        }


    }
}
