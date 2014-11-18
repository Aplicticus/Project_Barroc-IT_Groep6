using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Barroc_IT
{   
    public partial class frmFinance : Form
    {
        #region Properties
        private DatabaseHandler handler;
        private frmLogin loginForm;
        private DataTableHandler dthandler;
        private SqlQueryHandler sqlhandler;
        private int selectedProject;
        private int selectedCustomer;
        private int selectedInvoice;
        private bool closing = false;
        #endregion

        #region Constructor
        public frmFinance(DatabaseHandler handler, frmLogin loginForm, DataTableHandler dthandler, SqlQueryHandler sqlhandler)
        {
            InitializeComponent();
            this.handler = handler;
            this.loginForm = loginForm;
            this.dthandler = dthandler;
            this.sqlhandler = sqlhandler;
            cBoxCustomerSearch.SelectedIndex = 0;
            cBoxProjectSearch.SelectedIndex = 0;
            cBoxSearchInvoice.SelectedIndex = 0;
            dtpFinInvoiceExpDate.MinDate = DateTime.Now.Date;
            dtpFinInvoiceExpDate.Value = dtpFinInvoiceExpDate.MinDate;
            dtpFinInvoiceSentDate.MinDate = DateTime.Now.Date; ;
            dtpFinInvoiceSentDate.Value = dtpFinInvoiceSentDate.MinDate;
        }
        #endregion

        #region Click Events
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult confirmationLogout = MessageBox.Show("Are you sure you want to log out?", "Confirm log out", MessageBoxButtons.YesNo);
            if (confirmationLogout == DialogResult.Yes)
            {
                CloseToLogin();
            }
        }
        private void btnFinanceHome_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 0;
        }
        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            UpdatePayment(selectedProject, selectedInvoice, true);
            ReloadInvoices();
            if (txtInvoicePaid.Text == "Yes")
            {
                btnConfirmPayment.Enabled = false;
            }
            else
            {
                btnConfirmPayment.Enabled = true;
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
                nudFinLimit.Enabled = true;
                nudFinLimit.ReadOnly = false;
                txtFinLedgerID.ReadOnly = false;
                txtFinBTWCode.ReadOnly = false;
                cbFinBKR.Enabled = true;
                DisableAllButtons();
                btnEditFields.Text = "Save Changes";
            }
            else if (btnEditFields.Text == "Save Changes")
            {
                int CheckForInt;
                if (txtFinAccountID.Text.Length > 0 && txtFinAccountID.Text.Length < 17)
                {
                    if (nudFinLimit.Value > 0)
                    {                        
                        if (txtFinLedgerID.Text.Length > 0 && txtFinLedgerID.Text.Length < 10 && int.TryParse(txtFinLedgerID.Text, out CheckForInt))
                    {
                            if (txtFinBTWCode.Text.Length > 0 && txtFinBTWCode.Text.Length < 10 && int.TryParse(txtFinBTWCode.Text, out CheckForInt))
                        {
                                if (cbFinBKR.Text == "Yes" || cbFinBKR.Text == "No")
                            {
                                SetBKR();
                                UpdateCustomer(selectedCustomer);
                                    txtFinAccountID.ReadOnly = true;
                                    nudFinLimit.Enabled = false;
                                    nudFinLimit.ReadOnly = true;
                                    txtFinLedgerID.ReadOnly = true;
                                    txtFinBTWCode.ReadOnly = true;
                                    cbFinBKR.Enabled = false;
                                    EnableAllButtons();
                                    GetBKR();
                                    btnEditFields.Text = "Edit Fields";
                            }
                            else
                            {
                                    MessageBox.Show("The BKR field can only have (Yes/No)");
                                    cbFinBKR.ResetText();
                                }                                
                            }
                            else
                            {
                                MessageBox.Show("The BTWcode field is empty or not a number! please enter numbers.");
                                txtFinBTWCode.ResetText();
                            }
                        }
                        else
                        {
                            MessageBox.Show("The ledgerID field is empty or not a number! please enter numbers.");
                            txtFinLedgerID.ResetText();
                        }
                    }
                    else
                    {
                        MessageBox.Show("The Limit field is empty or 0! please enter a value.");
                        nudFinLimit.ResetText();
                    }
                }
                else
                {
                    MessageBox.Show("The Account Number field is empty or too long! please enter a correct account number.");
                }
            }
        }        
        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 7;
        }
        private void btnInvoiceSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchInvoice.Text.Length > 0)
            {
                SearchChoice selectedItem;
                switch (cBoxSearchInvoice.SelectedItem.ToString())
                {
                    case "Company Name":
                        selectedItem = SearchChoice.InvoiceCompanyName;
                        break;
                    case "Project Name":
                        selectedItem = SearchChoice.InvoiceProjectName;
                        break;
                    case "Value":
                        selectedItem = SearchChoice.InvoiceValue;
                        break;
                    default:
                        selectedItem = SearchChoice.InvoiceCompanyName;
                        break;
                }
                DataTable resultOfSearch = dthandler.SearchText(selectedItem, txtSearchInvoice.Text, selectedCustomer, selectedProject);
                dthandler.AddItemsToDataGridView(resultOfSearch, dgvInvoices, "cInvoiceID");
            }
            else
            {
                LoadInvoices();
            }
        }
        private void btnCreateInvoice_Click(object sender, EventArgs e)
        {
            numFinInvoiceAddValue.ResetText();
            if (numFinInvoiceAddValue.Value > 0)
            {
            if (AddInvoice() == true)
            {                
                tbContr.SelectedIndex = 5;
                LoadInvoices();
                ReloadProjects();
                MessageBox.Show("Invoice succesfully added!");
            }
            else
            {
                MessageBox.Show("There is a problem with adding a invoice!");
            }            
        }
            else
            {
                MessageBox.Show("The Invoice Value field is empty or 0! please enter a value.");
                numFinInvoiceAddValue.ResetText();
            }

                       
        }
        private void btnAddInvoiceCancel_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 4;
            ////////
        }
        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            if (txtCustomerSearch.Text.Length > 0)
            {
                SearchChoice selectedItem;
                switch (cBoxCustomerSearch.SelectedItem.ToString())
                {
                    case "Company Name":
                        selectedItem = SearchChoice.CompanyName;
                        break;
                    case "E-Mail":
                        selectedItem = SearchChoice.Email;
                        break;
                    case "Initials":
                        selectedItem = SearchChoice.Initials;
                        break;
                    default:
                        selectedItem = SearchChoice.CompanyName;
                        break;
                }
                DataTable resultOfSearch = dthandler.SearchText(selectedItem, txtCustomerSearch.Text, selectedCustomer,0);

                dthandler.AddItemsToDataGridView(resultOfSearch, dgvCustomers, "cCustomerID");
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
            int temp = 0;
            if (txtProjectInvoices.Text != temp.ToString())
            {
                btnViewInvoices.Enabled = true;
            }
            else
            {
                btnViewInvoices.Enabled = false;
            }
            tbContr.SelectedIndex = tbContr.SelectedIndex - 1;
        }
        // Datagridview CellContentClicks
        private void dgvUserInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCustomers.Columns["finCusView"].Index)
            {
                selectedCustomer = int.Parse(dgvCustomers.Rows[e.RowIndex].Cells["cCustomerID"].Value.ToString());
                UpdateBalance();
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
                int temp = 0;
                if (txtProjectInvoices.Text != temp.ToString())
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
                GetBKR();
                tbContr.SelectedIndex = 6;
                if (txtInvoicePaid.Text == "Yes")
                {
                    btnConfirmPayment.Enabled = false;
                }
                else
                {
                    btnConfirmPayment.Enabled = true;
                }
            }   
        }
        #endregion

        #region Loaders
        private void LoadCustomers()
        {
            dgvCustomers.Rows.Clear();
            string selectCustomers = sqlhandler.GetQuery(Query.loadCustomers);
            DataTable customers = dthandler.ExecuteQuery(selectCustomers);
            dthandler.AddItemsToDataGridView(customers, dgvCustomers, "cProjectID");
        }
        private void LoadProjects()
        {
            dgvProjects.Rows.Clear();
            string sql = sqlhandler.GetQuery(Query.loadProjects);
            SqlParameter[] collection = { new SqlParameter("customerID", selectedCustomer) };  
            DataTable projects = dthandler.ExecuteQuery(sql, collection);
            dthandler.AddItemsToDataGridView(projects, dgvProjects, "cProjectID");
        }
        private void LoadInvoices()
        {
            dgvInvoices.Rows.Clear();
            string sql = sqlhandler.GetQuery(Query.loadInvoices);
            SqlParameter[] collection = { new SqlParameter("customerID", selectedCustomer), new SqlParameter("projectID", selectedProject) };  
            DataTable invoices = dthandler.ExecuteQuery(sql, collection);
            dthandler.AddItemsToDataGridView(invoices, dgvInvoices, "cInvoiceID");
        }
        // Load Details
        private void LoadCustomerDetails(DataTable dtCustomers, DataTable dtProjectsCount, DataTable dtSalesCount)
        {
            DataRow tbl_Customers_Rows = dtCustomers.Rows[0];
            DataRow tbl_Projects_Rows = dtProjectsCount.Rows[0];
            DataRow tbl_Invoices_Sales_Rows_Count = dtSalesCount.Rows[0];
            txtCompanyName.Text = tbl_Customers_Rows["COMPANYNAME"].ToString();
            txtAddress1.Text = tbl_Customers_Rows["ADDRESS1"].ToString();
            txtPostalCode1.Text = tbl_Customers_Rows["POSTALCODE1"].ToString();
            txtPhoneNumber1.Text = tbl_Customers_Rows["PHONE_NR1"].ToString();
            txtFaxNumber.Text = tbl_Customers_Rows["FAXNUMBER"].ToString();
            txtEmail.Text = tbl_Customers_Rows["EMAIL"].ToString();
            txtContactPerson.Text = tbl_Customers_Rows["CONTACTPERSON"].ToString();
            txtFinAccountID.Text = tbl_Customers_Rows["ACC_ID"].ToString();
            txtFinBalance.Text = tbl_Customers_Rows["BALANCE"].ToString();
            nudFinLimit.Text = tbl_Customers_Rows["LIMIT"].ToString();
            txtFinLedgerID.Text = tbl_Customers_Rows["LEDGER_ID"].ToString();
            txtFinBTWCode.Text = tbl_Customers_Rows["BTW_CODE"].ToString();
            cbFinBKR.Text = tbl_Customers_Rows["BKR"].ToString();
            txtFinProjects.Text = tbl_Projects_Rows[0].ToString();
            txtFinSales.Text = tbl_Invoices_Sales_Rows_Count[0].ToString();
        }
        private void LoadProjectDetails(DataTable dtCustomers, DataTable dtInvoicesCount)
        {
            DataRow tbl_Customers_Rows = dtCustomers.Rows[0];
            DataRow tbl_Invoices_Rows_Count = dtInvoicesCount.Rows[0];
            txtProjectCompanyName.Text = tbl_Customers_Rows["COMPANYNAME"].ToString();
            DateTime projectDeadline = DateTime.Parse(tbl_Customers_Rows["DEADLINE"].ToString());
            txtProjectName.Text = tbl_Customers_Rows["NAME"].ToString();
            dtpDeadlineViewProject.Value = projectDeadline;
            txtProjectSubject.Text = tbl_Customers_Rows["SUBJECT"].ToString();
            txtProjectValue.Text = tbl_Customers_Rows["VALUE"].ToString();
            txtProjectInvoices.Text = tbl_Invoices_Rows_Count[0].ToString();
        }
        private void LoadInvoiceDetails(DataTable dtInvoice)
        {
            DataRow tbl_Invoice_Rows = dtInvoice.Rows[0];
            txtInvoiceCompanyName.Text = tbl_Invoice_Rows["COMPANYNAME"].ToString();
            txtInvoiceSubject.Text = tbl_Invoice_Rows["SUBJECT"].ToString();
            txtInvoicePaid.Text = tbl_Invoice_Rows["PAID"].ToString();
            decimal nudInvoiceValue = decimal.Parse(tbl_Invoice_Rows["INVOICE_VALUE"].ToString());
            nudSelectedInvoiceValue.Value = nudInvoiceValue;
            DateTime InvoiceExpireDate = DateTime.Parse(tbl_Invoice_Rows["INVOICE_END_DATE"].ToString());
            dtpSelectedInvoiceExpireDate.Value = InvoiceExpireDate;
            DateTime InvoiceSendDate = DateTime.Parse(tbl_Invoice_Rows["INVOICE_SEND"].ToString());
            dtpSelectedInvoiceSendDate.Value = InvoiceSendDate;
        }

        #endregion

        #region Reloads
        private void ReloadCustomers()
        {
            string sqlCustomers = sqlhandler.GetQuery(Query.loadCustomerDetails);
            SqlParameter[] collection = { new SqlParameter("customerID", selectedCustomer) }; 
            DataTable dtCustomers = dthandler.ExecuteQuery(sqlCustomers, collection);
            
            string sqlProjects = sqlhandler.GetQuery(Query.countProjects);
            collection = new SqlParameter[] { new SqlParameter("customerID", selectedCustomer) };
            DataTable dtProjectsCount = dthandler.ExecuteQuery(sqlProjects, collection);

            string sqlInvoices = sqlhandler.GetQuery(Query.countPaidInvoices);
            collection = new SqlParameter[] { new SqlParameter("customerID", selectedCustomer)};
            DataTable dtPaidInvoicesCount = dthandler.ExecuteQuery(sqlInvoices, collection);  

            LoadCustomerDetails(dtCustomers, dtProjectsCount, dtPaidInvoicesCount);            
            GetBKR();
        }
        private void ReloadProjects()
        {            
            string sqlProject = sqlhandler.GetQuery(Query.loadProjectDetails);
            SqlParameter[] collection = new SqlParameter[] { new SqlParameter("customerID", selectedCustomer), new SqlParameter("projectID", selectedProject) };           
            DataTable projectDetails = dthandler.ExecuteQuery(sqlProject, collection);

            string sqlValues = sqlhandler.GetQuery(Query.countOpenInvoices);
            collection = new SqlParameter[] { new SqlParameter("customerID", selectedCustomer), new SqlParameter("projectID", selectedProject) };
            DataTable valueDetails = dthandler.ExecuteQuery(sqlValues, collection);
            LoadProjectDetails(projectDetails, valueDetails);
        }
        private void ReloadInvoices()
        {
            string sql = sqlhandler.GetQuery(Query.loadInvoiceDetails);
            SqlParameter[] collection = { new SqlParameter("customerID", selectedCustomer), new SqlParameter("projectID", selectedProject), new SqlParameter("invoiceID", selectedInvoice) };
            DataTable invoiceDetails = dthandler.ExecuteQuery(sql, collection);
            LoadInvoiceDetails(invoiceDetails); 
        }
        #endregion

        #region Methods
        private bool AddInvoice()
        {
            string sqlQuery = sqlhandler.GetQuery(Query.addInvoice);
            SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection());
            cmd.Parameters.Add(new SqlParameter("@SelectedProject", selectedProject));
            cmd.Parameters.Add(new SqlParameter("@InvoiceVal", numFinInvoiceAddValue.Value));
            cmd.Parameters.Add(new SqlParameter("@InvoiceEndDate", dtpFinInvoiceExpDate.Value));
            cmd.Parameters.Add(new SqlParameter("@InvoiceSend", dtpFinInvoiceSentDate.Value));
            cmd.Parameters.Add(new SqlParameter("@Paid", false));
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
        private void DisableAllButtons()
        {
            btnViewProjects.Enabled = false;
            btnCustomerBack.Enabled = false;
            btnLogout.Enabled = false;
            btnFinanceSelectCustomer.Enabled = false;
            btnFinanceHome.Enabled = false;
            btnViewInvoices.Enabled = false;
            btnAddInvoice.Enabled = false;
            btnProjectBack.Enabled = false;
            this.ControlBox = false;
        }
        private void EnableAllButtons()
        {
            btnCustomerBack.Enabled = true;
            btnLogout.Enabled = true;
            btnFinanceSelectCustomer.Enabled = true;
            btnFinanceHome.Enabled = true;
            int temp = 0;
            if (txtFinProjects.Text != temp.ToString() )
            {
                btnViewProjects.Enabled = true;
            }
            else 
            {
                btnViewProjects.Enabled = false;
            }
            btnViewInvoices.Enabled = true;
            btnAddInvoice.Enabled = true;
            btnProjectBack.Enabled = true;
            this.ControlBox = true;
        }

        #endregion

        #region Get & Set BKR ( yes / no, true / false )
        private void GetBKR()
        {
            if (cbFinBKR.Text == "True" || cbFinBKR.Text == "1")
            {
                cbFinBKR.Text = "Yes";
            }
            else if (cbFinBKR.Text == "False" || cbFinBKR.Text == "0")
            {
                cbFinBKR.Text = "No";
            }            
            else if (txtInvoicePaid.Text == "True" || txtInvoicePaid.Text == "1")
            {
                txtInvoicePaid.Text = "Yes";
        }
            else if (txtInvoicePaid.Text == "False" || txtInvoicePaid.Text == "0")
            {
                txtInvoicePaid.Text = "No";
            }
        }
        private void SetBKR()
        {
            if (cbFinBKR.Text == "Yes")
            {
                cbFinBKR.Text = "True";
            }
            else if (cbFinBKR.Text == "No")
            {
                cbFinBKR.Text = "False";
            }
        }
        #endregion

        #region Updaters / Editers
        private bool UpdatePayment(int projectID, int invoiceID, bool paid)
        {
            string sqlQuery = sqlhandler.GetQuery(Query.updateFinPayment);
            SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection()); 
            cmd.Parameters.Add(new SqlParameter("projectID", projectID));
            cmd.Parameters.Add(new SqlParameter("invoiceID", selectedInvoice));
            cmd.Parameters.Add(new SqlParameter("Paid", paid));
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
        private void UpdateBalance()
        {
            string countInvoicesQuery = sqlhandler.GetQuery(Query.countInvoices);
            SqlParameter[] collection = { new SqlParameter("customerID", selectedCustomer) }; 
            DataTable dtCountInvoices = dthandler.ExecuteQuery(countInvoicesQuery, collection);
            DataRow drCountInvoices = dtCountInvoices.Rows[0];
            string sqlQuery = sqlhandler.GetQuery(Query.copyCountInvoicesToBalance);
            SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection());
            cmd.Parameters.Add(new SqlParameter("Balance", drCountInvoices[0]));
            cmd.Parameters.Add(new SqlParameter("customerID", selectedCustomer));
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        private bool UpdateCustomer(int customerID)
        {
            string sqlQuery = sqlhandler.GetQuery(Query.updateFinCustomersInfo);
            SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection());            
            cmd.Parameters.Add(new SqlParameter("AccountID", txtFinAccountID.Text));
            cmd.Parameters.Add(new SqlParameter("Limit", nudFinLimit.Value));
            cmd.Parameters.Add(new SqlParameter("LedgerID", txtFinLedgerID.Text));
            cmd.Parameters.Add(new SqlParameter("BTWcode", txtFinBTWCode.Text));
            cmd.Parameters.Add(new SqlParameter("Bkr", bool.Parse(cbFinBKR.Text)));
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
        #endregion

        #region GoToLogin
        private void CloseToLogin()
        {
            closing = true;
            loginForm.ClearTextBoxes();
            loginForm.Show();
            loginForm.CenterScreen();
            this.Close();
        }
        #endregion

        #region Form Closing
        //Form Closing method
        private void frmFinance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closing)
            {
                CloseToLogin();
            }
        }
        #endregion


    }
}
