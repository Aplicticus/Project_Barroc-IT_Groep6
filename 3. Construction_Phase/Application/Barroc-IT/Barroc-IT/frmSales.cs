using System;
using System.Data;
using System.Data.SqlClient;
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
            LoadCustomers();  
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
            addCustomer();
            tbContr.SelectedIndex = 1;
            dgvUserInfo.Rows.Clear();
            LoadCustomers(); 
        }

        // Loads
        private void LoadCustomers()
        {
            dgvUserInfo.Rows.Clear();
            string selectCustomers = sqlhandler.GetQuery(Query.loadCustomers);
            DataTable customers = dthandler.ExecuteQuery(selectCustomers);
            AddItemsToDataGridView(customers, dgvUserInfo, "cCustomerID");
        }

        private bool addCustomer()
        {
            string sqlQuery = sqlhandler.GetQuery(Query.addCustomer);
            SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection());            
            cmd.Parameters.Add(new SqlParameter("@CompanyName", txtCusAddCompanyName.Text));
            cmd.Parameters.Add(new SqlParameter("@Address1", txtCusAddAddress1.Text));
            cmd.Parameters.Add(new SqlParameter("@PostalCode1", txtCusAddPostalCode1.Text));
            cmd.Parameters.Add(new SqlParameter("@Residence1", txtCusAddResidence1.Text));
            cmd.Parameters.Add(new SqlParameter("@Address2", txtCusAddAddress2.Text));
            cmd.Parameters.Add(new SqlParameter("@PostalCode2", txtCusAddPostalCode2.Text));
            cmd.Parameters.Add(new SqlParameter("@Residence2", txtCusAddResidence2.Text));
            cmd.Parameters.Add(new SqlParameter("@ContactPerson", txtCusAddContactperson .Text));
            cmd.Parameters.Add(new SqlParameter("@Initials", txtCusAddInitials.Text));
            cmd.Parameters.Add(new SqlParameter("@PhoneNr1", txtCusAddPhoneNumber1.Text));
            cmd.Parameters.Add(new SqlParameter("@PhoneNr2", txtCusAddPhoneNumber2.Text));
            cmd.Parameters.Add(new SqlParameter("@FaxNumber", txtCusAddFaxNumber.Text));
            cmd.Parameters.Add(new SqlParameter("@Email", txtCusAddEmail.Text));
            cmd.Parameters.Add(new SqlParameter("@Prospect", cbCusAddProspect.SelectedIndex.ToString()));
                       
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
                selectedCustomer = int.Parse(dgvUserInfo.Rows[e.RowIndex].Cells["cCustomerID"].Value.ToString());
                ReloadCustomers();
                tbContr.SelectedIndex = 2;
            }
        }

        private void ReloadCustomers()
        {
            string sqlCustomers = sqlhandler.GetQuery(Query.loadCustomerDetails);
            SqlParameter[] collection = { new SqlParameter("customerID", selectedCustomer) };
            DataTable customerDetails = dthandler.ExecuteQuery(sqlCustomers, collection);
            LoadCustomerDetails(customerDetails);
        }

        private void LoadCustomerDetails(DataTable CusTable)
        {
            DataRow CusRow = CusTable.Rows[0];
            txtCusCompanyName.Text = CusRow["COMPANYNAME"].ToString();
            txtCusAddress1.Text = CusRow["ADDRESS1"].ToString();
            txtCusPostalCode1.Text = CusRow["POSTALCODE1"].ToString();
            txtCusPhoneNumber1.Text = CusRow["PHONE_NR1"].ToString();
            txtCusFaxNumber.Text = CusRow["FAXNUMBER"].ToString();
            txtCusEmail.Text = CusRow["EMAIL"].ToString();
            txtCusContactPerson.Text = CusRow["CONTACTPERSON"].ToString();
            cBoxCusProspect.Text = CusRow["PROSPECT"].ToString();
            txtCusOfferStatus.Text = CusRow["OFFER_STAT"].ToString();
            DateTime dateOfAction = DateTime.Parse(CusRow["DATE_OF_ACTION"].ToString());
            dtpCusSalesDateOfAction.Value = dateOfAction;
            DateTime lastContactDate = DateTime.Parse(CusRow["LAST_CONTACT_DATE"].ToString());
            dtpCusSalesLastContactDate.Value = lastContactDate;
            DateTime nextAction = DateTime.Parse(CusRow["NEXT_ACTION"].ToString());
            dtpCusSalesNextAction.Value = nextAction;


            RecoverComboBoxes();

        }

        private void RecoverComboBoxes()
        {
            if (cBoxCusProspect.Text == "True" || cBoxCusProspect.Text == "1")
            {
                cBoxCusProspect.Text = "Yes";
            }
            else if (cBoxCusProspect.Text == "False" || cBoxCusProspect.Text == "0")
            {
                cBoxCusProspect.Text = "No";
        }

            if (txtCusOfferStatus.Text == "True" || txtCusOfferStatus.Text == "1")
            {
                txtCusOfferStatus.Text = "Yes";
            }
            else
            {
                txtCusOfferStatus.Text = "No";
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
