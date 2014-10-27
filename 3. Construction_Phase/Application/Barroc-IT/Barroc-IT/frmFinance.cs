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
        private SqlQueryHandler sqlhandler;
        private int selectedProject;
        private int selectedCustomer;
        private int selectedInvoice;
        private bool closing = false;

        // Form Load
        public frmFinance(DatabaseHandler handler, frmLogin loginForm, DataTableHandler dthandler, SqlQueryHandler sqlhandler)
        {
            InitializeComponent();
            this.handler = handler;
            this.loginForm = loginForm;
            this.dthandler = dthandler;
            this.sqlhandler = sqlhandler;
            cBoxCustomerSearch.SelectedIndex = 0;
            cBoxProjectSearch.SelectedIndex = 0;
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
            LoadCustomers();                    
        }
        private void btnViewProjects_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 3;
            LoadProjects();            
        }
        private void btnViewInvoices_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 5;
            LoadInvoices();            
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
                string sql = sqlhandler.GetQuery("loadCustomerDetails", selectedCustomer);
                DataTable customerDetails = dthandler.SqlQueryToDataTable(sql, selectedCustomer);                 
                txtFinAccountID.ReadOnly = true;
                txtFinBalance.ReadOnly = true;
                txtFinLimit.ReadOnly = true;
                txtFinLegderID.ReadOnly = true;
                txtFinBTWCode.ReadOnly = true;
                cbFinBKR.Enabled = false;
                BKRRecover();
            }
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
        private void btnAddInvoiceCancel_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 4;
        }
        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            if (txtCustomerSearch.Text.Length > 0)
            {
                Choice selectedItem;
                switch (cBoxCustomerSearch.SelectedItem.ToString())
                {
                    case "Company Name":
                        selectedItem = Choice.CompanyName;
                        break;
                    case "E-Mail":
                        selectedItem = Choice.Email;
                        break;
                    case "Initials":
                        selectedItem = Choice.Initials;
                        break;
                    default:
                        selectedItem = Choice.CompanyName;
                        break;
                }
                DataTable resultOfSearch = dthandler.SearchText(selectedItem, txtCustomerSearch.Text);

                AddItemsToDataGridView(resultOfSearch, dgvCustomers, "cCustomerID");
            }
        }
        private void btnProjectSearch_Click(object sender, EventArgs e)
        {
            // Add search function for projects 
        }
        private void btnBackClick(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadProjects();
            LoadInvoices();
            tbContr.SelectedIndex = tbContr.SelectedIndex - 1;
        }

        // Datagridview CellContentClicks
        private void dgvUserInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCustomers.Columns["finCusView"].Index)
            {
                selectedCustomer = int.Parse(dgvCustomers.Rows[e.RowIndex].Cells["cCustomerID"].Value.ToString());
                ReloadCustomers();
                tbContr.SelectedIndex = 2;
                int temp = 0;
                if (txtFinProjects.Text != temp.ToString())
                {
                    btnViewProjects.Enabled = true;
                }
                else
                {
                    btnViewProjects.Enabled = false;
                }   
            }           
        }
        private void dgvProjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvProjects.Columns["finProView"].Index)
            {
                selectedProject = int.Parse(dgvProjects.Rows[e.RowIndex].Cells["cProjectID"].Value.ToString());
                ReloadProjects();
                tbContr.SelectedIndex = 4;
                string temp = "";
                if (txtProjectValue.Text != temp)
                {
                    btnViewInvoices.Enabled = true;
                }
                else
                {
                    btnViewInvoices.Enabled = false;
                }
            }
        }
        private void dgvInvoices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvInvoices.Columns["finInvView"].Index)
            {        
                selectedInvoice = int.Parse(dgvInvoices.Rows[e.RowIndex].Cells["cInvoiceID"].Value.ToString());
                ReloadInvoices();
                tbContr.SelectedIndex = 6;
            }   
        } 

        // Methods       
        private bool AddInvoice()
        {
            string sqlQuery = sqlhandler.SetQuery("addInvoice");
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
       
        // Loads
        private void LoadCustomers()
        {
            dgvCustomers.Rows.Clear();

            string selectCustomers = sqlhandler.GetQuery("loadCustomers");
            DataTable customers = dthandler.SqlQueryToDataTable(selectCustomers);
            AddItemsToDataGridView(customers, dgvCustomers, "cProjectID");
        }
        private void LoadProjects()
        {
            dgvProjects.Rows.Clear();
            string sql = sqlhandler.GetQuery("loadProjects", selectedCustomer);
            DataTable projects = dthandler.SqlQueryToDataTableProject(sql, selectedCustomer);
            AddItemsToDataGridView(projects, dgvProjects, "finProView");
        }
        private void LoadInvoices()
        {
            dgvInvoices.Rows.Clear();
            string sql = sqlhandler.GetQuery("loadInvoices", selectedProject);
            DataTable invoices = dthandler.SqlQueryToDataTable(sql, selectedProject);
            AddItemsToDataGridView(invoices, dgvInvoices, "finInvView");
        }

        // First Loads / Reloads
        private void ReloadCustomers()
        {
            string sqlCustomers = sqlhandler.GetQuery("loadCustomerDetails", selectedCustomer);
            DataTable customerDetails = dthandler.SqlQueryToDataTable(sqlCustomers, selectedCustomer);
            string sqlInvoice = sqlhandler.GetQuery("countInvoices", selectedCustomer);
            DataTable invoiceCount = dthandler.SqlQueryToDataTable(sqlInvoice, selectedCustomer);
            string sqlSales = sqlhandler.GetQuery("countSales", selectedCustomer);
            DataTable salesCount = dthandler.SqlQueryToDataTable(sqlSales, selectedCustomer);
            string sqlProject = sqlhandler.GetQuery("countProjects", selectedCustomer);
            DataTable projectCount = dthandler.SqlQueryToDataTable(sqlProject, selectedCustomer);
            LoadCustomerDetails(customerDetails, invoiceCount, projectCount, salesCount);            
            BKRRecover();
        }
        private void ReloadProjects()
        {            
            string sqlProject = sqlhandler.GetQuery("loadProjectDetails", selectedCustomer, selectedProject);
            DataTable projectDetails = dthandler.SqlQueryToDataTable(sqlProject, selectedCustomer, selectedProject);
            string sqlValues = sqlhandler.GetQuery("countValues", selectedCustomer);
            DataTable valueDetails = dthandler.SqlQueryToDataTable(sqlValues, selectedProject);
            LoadProjectDetails(projectDetails, valueDetails);
        }
        private void ReloadInvoices()
        {
            string sql = sqlhandler.GetQuery("loadInvoiceDetails", selectedCustomer, selectedProject, selectedInvoice);
            DataTable invoiceDetails = dthandler.SqlQueryToDataTable(sql, selectedCustomer, selectedProject, selectedInvoice);
            LoadInvoiceDetails(invoiceDetails);            
        }

        // Go to Login
        private void CloseToLogin()
        {
            closing = true;
            loginForm.ClearTextBoxes();
            loginForm.Show();
            this.Close();
        }

        //BKR field recover ( yes / no ) 
        private void BKRRecover()
        {
            if (cbFinBKR.Text == "True" || cbFinBKR.Text == "1")
            {
                cbFinBKR.Text = "Yes";
            }
            else if (cbFinBKR.Text == "False" || cbFinBKR.Text == "0")
            {
                cbFinBKR.Text = "No";
            }
            btnEditFields.Text = "Edit Fields";
        }

        // Updaters / Editers
        private bool UpdateCustomer(int customerID)
        {
            // Have to convert Boolean of cbFinBKR to 0 or 1 to update...

            string sqlQuery = sqlhandler.UpdateQuery("updateFinCustomersInfo");
            SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection());
            if (cbFinBKR.Text == "Yes")
            {
                cbFinBKR.Text = "1";
            }
            else if (cbFinBKR.Text == "No")
            {
                cbFinBKR.Text = "0";
            }
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
        private void LoadCustomerDetails(DataTable CusTable, DataTable InvCount, DataTable ProCount, DataTable SalCount)
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
            DataRow InvRow = InvCount.Rows[0];
            txtFinInvoices.Text = InvRow[0].ToString();
            DataRow ProRow = ProCount.Rows[0];
            txtFinProjects.Text = ProRow[0].ToString();
            DataRow InvVal = SalCount.Rows[0];
            txtFinSales.Text = InvVal[0].ToString();
        }
        private void LoadProjectDetails(DataTable DT, DataTable DTVal)
        {
            DataRow DR = DT.Rows[0];
            txtProjectCompanyName.Text = DR["COMPANYNAME"].ToString();
            DateTime projectDeadline = new DateTime();
            projectDeadline = DateTime.Parse(DR["DEADLINE"].ToString());
            txtProjectName.Text = DR["NAME"].ToString();
            dtpDeadlineViewProject.Value = projectDeadline;
            txtProjectSubject.Text = DR["SUBJECT"].ToString();
            DataRow DRVal = DTVal.Rows[0];
            txtProjectValue.Text = DRVal[0].ToString();
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

        //Form Closing method
        private void frmFinance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closing)
            {
                CloseToLogin();
            }
        }        
      }
}
