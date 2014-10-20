using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Barroc_IT
{
    public partial class frmFinance : Form
    {
        // Properties
        private DatabaseHandler handler;
        private frmLogin loginForm;
        private DataTableHandler dthandler;
        private int selectedProject;
        private int selectedCustomer;
        private int selectedInvoice;
        private bool closing = false;
        // Form Load
        public frmFinance(DatabaseHandler handler, frmLogin loginForm, DataTableHandler dthandler)
        {
            InitializeComponent();
            this.handler = handler;
            this.loginForm = loginForm;
            this.dthandler = dthandler;
        }

        // Click Events
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
            dgvCustomers.Rows.Clear();
            DataTable customers = dthandler.LoadCustomers();
            AddItemsToDataGridView(customers, dgvCustomers, "cProjectID");
        }
        private void btnViewProjects_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 3;
            LoadProjects();            
            }
        private void btnViewInvoices_Click(object sender, EventArgs e)
            {
                selectedProject = int.Parse(dgvProjects.Rows[e.RowIndex].Cells["finProCustomerID"].Value.ToString());
                DataTable customerDetails = dthandler.LoadCustomers(selectedCustomer);
                DataTable projectDetails = dthandler.LoadProjectDetails(selectedProject, selectedCustomer);

                LoadProjectDetails(customerDetails, projectDetails);
                tbContr.SelectedIndex = 4;
            }
        }

        private void LoadProjectDetails(DataTable CusTable, DataTable ProTable)
        {
            DataRow CusRow = CusTable.Rows[0];

            txtProjectCompanyName.Text = CusRow["COMPANYNAME"].ToString();

            DataRow ProRow = ProTable.Rows[0];

            DateTime projectDeadline = new DateTime();
            projectDeadline = DateTime.Parse(ProRow["DEADLINE"].ToString());
            txtProjectName.Text = ProRow["NAME"].ToString();
            dtpDeadlineViewProject.Value = projectDeadline;
            txtProjectSubject.Text = ProRow["SUBJECT"].ToString();
            txtProjectValue.Text = ProRow["VALUE"].ToString();
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
                UpdateCustomer(selectedCustomer);
                dthandler.LoadCustomers(selectedCustomer);                
                txtFinAccountID.ReadOnly = true;
                txtFinBalance.ReadOnly = true;
                txtFinLimit.ReadOnly = true;
                txtFinLegderID.ReadOnly = true;
                txtFinBTWCode.ReadOnly = true;
                cbFinBKR.Enabled = false;
                btnEditFields.Text = "Edit Fields";


        }

        private void btnViewProjects_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 3;
            dgvProjects.Rows.Clear();
            DataTable projects = dthandler.LoadProjects(selectedCustomer);

            AddItemsToDataGridView(projects, dgvProjects, "finProView");


        }
        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 7;
        }
        private void btnCreateInvoice_Click(object sender, EventArgs e)
        {
            if (AddInvoice() == true)
            {
                tbContr.SelectedIndex = 5;
                LoadInvoices();
                MessageBox.Show("Invoice succesfully added!");
            }
            else
            {
                MessageBox.Show("There is a problem with adding a invoice!");
            }
        }

        // Datagridview CellContentClicks
        private void dgvUserInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCustomers.Columns["finCusView"].Index)
            {
                selectedCustomer = int.Parse(dgvCustomers.Rows[e.RowIndex].Cells["cCustomerID"].Value.ToString());                
                DataTable customerDetails = dthandler.LoadCustomers(selectedCustomer);                
                LoadCustomerDetails(customerDetails);
                tbContr.SelectedIndex = 2;
            }
        }
        private void dgvProjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvProjects.Columns["finProView"].Index)
            {
                selectedProject = int.Parse(dgvProjects.Rows[e.RowIndex].Cells["cProjectID"].Value.ToString());
                //DataTable customerDetails = dthandler.LoadCustomers(selectedCustomer);
                DataTable projectDetails = dthandler.LoadProjectDetails(selectedCustomer, selectedProject);
                LoadProjectDetails(projectDetails);
                tbContr.SelectedIndex = 4;
            }
        }
        private void dgvInvoices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvInvoices.Columns["finInvView"].Index)
            {        
                selectedInvoice = int.Parse(dgvInvoices.Rows[e.RowIndex].Cells["cInvoiceID"].Value.ToString());                
                DataTable invoiceDetails = dthandler.LoadInvoiceDetails(selectedCustomer, selectedProject, selectedInvoice);
                LoadInvoiceDetails(invoiceDetails);
                tbContr.SelectedIndex = 6;
            }   
        }                
       
        // Methods
        
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
        private void btnAddInvoiceCancel_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 4;
        }
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
        private void LoadInvoices()
        {
            dgvInvoices.Rows.Clear();
            DataTable invoices = dthandler.LoadInvoices(selectedProject);
            AddItemsToDataGridView(invoices, dgvInvoices, "finInvView");
        }
        private void LoadProjects()
        {
            dgvProjects.Rows.Clear();
            DataTable projects = dthandler.LoadProjects(selectedCustomer);
            AddItemsToDataGridView(projects, dgvProjects, "finProView");
        }
        private void CloseToLogin()
        {
            closing = true;
            loginForm.ClearTextBoxes();
            loginForm.Show();
            this.Close();
        }
        private bool UpdateCustomer(int customerID)
        {
            // Have to convert Boolean of cbFinBKR to 0 or 1 to update...

            string sqlQuery = "UPDATE tbl_Customers SET ACC_ID=@AccountID, BALANCE=@Balance, LIMIT=@Limit, LEDGER_ID=@LedgerID, BTW_CODE=@BTWcode, BKR=@Bkr WHERE CUSTOMER_ID=@CustomerID";
            SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection());

            cmd.Parameters.Add(new SqlParameter("AccountID", txtFinAccountID.Text));
            cmd.Parameters.Add(new SqlParameter("Balance", txtFinBalance.Text));
            cmd.Parameters.Add(new SqlParameter("Limit", txtFinLimit.Text));
            cmd.Parameters.Add(new SqlParameter("LedgerID", txtFinLegderID.Text));
            cmd.Parameters.Add(new SqlParameter("BTWcode", txtFinBTWCode.Text));
            cmd.Parameters.Add(new SqlParameter("Bkr", cbFinBKR.Text));
            cmd.Parameters.Add(new SqlParameter("customerID", customerID));

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

        // Load Details
        private void LoadCustomerDetails(DataTable CusTable)
        {
            DataRow CusRow = CusTable.Rows[0];

            txtCompanyName.Text = CusRow["COMPANYNAME"].ToString();
            txtAddress1.Text = CusRow["ADDRESS1"].ToString();
            txtPostalCode1.Text = CusRow["POSTALCODE1"].ToString();
            txtPhoneNumber1.Text = CusRow["PHONE_NR1"].ToString();
            txtFaxNumber.Text = CusRow["FAXNUMBER"].ToString();
            txtEmail.Text = CusRow["EMAIL"].ToString();
            txtContactPerson.Text = CusRow["CONTACTPERSON"].ToString();
            txtFinAccountID.Text = CusRow["ACC_ID"].ToString();
            txtFinBalance.Text = CusRow["BALANCE"].ToString();
            txtFinLimit.Text = CusRow["LIMIT"].ToString();
            txtFinLegderID.Text = CusRow["LEDGER_ID"].ToString();
            txtFinBTWCode.Text = CusRow["BTW_CODE"].ToString();
            cbFinBKR.Text = CusRow["BKR"].ToString();


            //txtFinInvoices.Text =  ( Add Count of invoices from current project/Customer )
       
            //txtFinSales.Text = ( add count of sales from current project / cutomer)
        }
        private void LoadProjectDetails(DataTable DT)
        {
            DataRow DR = DT.Rows[0];
            txtProjectCompanyName.Text = DR["COMPANYNAME"].ToString();
            DateTime projectDeadline = new DateTime();
            projectDeadline = DateTime.Parse(DR["DEADLINE"].ToString());
            txtProjectName.Text = DR["NAME"].ToString();
            dtpDeadlineViewProject.Value = projectDeadline;
            txtProjectSubject.Text = DR["SUBJECT"].ToString();
            txtProjectValue.Text = DR["VALUE"].ToString();
        }
        private void LoadInvoiceDetails(DataTable InvTable)
        {
            DataRow InvRow = InvTable.Rows[0];
            txtInvoiceCompanyName.Text = InvRow["COMPANYNAME"].ToString();
            txtInvoiceSubject.Text = InvRow["SUBJECT"].ToString();
            decimal nudInvoiceValue = decimal.Parse(InvRow["INVOICE_VALUE"].ToString());
            nudSelectedInvoiceValue.Value = nudInvoiceValue;
            DateTime InvoiceExpireDate = new DateTime();
            InvoiceExpireDate = DateTime.Parse(InvRow["INVOICE_END_DATE"].ToString());
            dtpSelectedInvoiceExpireDate.Value = InvoiceExpireDate;
            DateTime InvoiceSendDate = new DateTime();
            InvoiceSendDate = DateTime.Parse(InvRow["INVOICE_SEND"].ToString());
            dtpSelectedInvoiceSendDate.Value = InvoiceSendDate;
        }

        // Back button
        private void btnBackClick(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = tbContr.SelectedIndex - 1;
        }

        // Form Closing method
        private void frmFinance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closing)
            {
                CloseToLogin();
            }
        }

    }
}
