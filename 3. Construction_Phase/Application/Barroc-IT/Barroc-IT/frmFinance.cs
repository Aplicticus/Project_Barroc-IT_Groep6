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
        private DataTableHandler dthandler;
        private int selectedProject;
        private int selectedCustomer;
        private int selectedInvoice = 0;

        //private int selectedCustomer = 0;
        private bool closing = false;
        public frmFinance(DatabaseHandler handler, frmLogin loginForm, DataTableHandler dthandler)
        {
            InitializeComponent();
            this.handler = handler;
            this.loginForm = loginForm;
            this.dthandler = dthandler;
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
            tbContr.SelectedIndex = 1;
            dgvCustomers.Rows.Clear();
            DataTable customers = dthandler.LoadCustomers();

            AddItemsToDataGridView(customers, dgvCustomers, "cProjectID");
        }

        private void btnViewProjects_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 3;
            dgvProjects.Rows.Clear();
            DataTable projects = dthandler.LoadProjects(selectedCustomer);

            AddItemsToDataGridView(projects, dgvProjects, "finProView");


        }

        private void btnViewInvoices_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 5;
            dgvProjects.Rows.Clear();
            DataTable invoices = dthandler.LoadInvoices(selectedProject);

            AddItemsToDataGridView(invoices, dgvInvoices, "finInvView");
        }





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



        private void dgvProjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvProjects.Columns["finProView"].Index)
            {
                selectedProject = int.Parse(dgvProjects.Rows[e.RowIndex].Cells["finProCustomerID"].Value.ToString());
                DataTable customerDetails = dthandler.LoadCustomers(selectedCustomer);
                DataTable projectDetails = dthandler.LoadProjectDetails(selectedProject, selectedCustomer);

                LoadProjectDetails(customerDetails, projectDetails);
                tbContr.SelectedIndex = 4;
            }
        }

        private void dgvInvoices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvInvoices.Columns["finInvView"].Index)
            {
                selectedInvoice = int.Parse(dgvInvoices.Rows[e.RowIndex].Cells["finInvProjectID"].Value.ToString());
                DataTable customerDetails = dthandler.LoadCustomers(selectedCustomer);
                DataTable projectDetails = dthandler.LoadProjects(selectedCustomer);
                DataTable invoiceDetails = dthandler.LoadInvoices(selectedProject);

                LoadInvoiceDetails(customerDetails, projectDetails, invoiceDetails);
                tbContr.SelectedIndex = 6;
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

        private void LoadInvoiceDetails(DataTable CusTable, DataTable ProTable, DataTable InvTable)
        {
            DataRow CusRow = CusTable.Rows[0];

            txtInvoiceCompanyName.Text = CusRow["COMPANYNAME"].ToString();

            DataRow ProRow = ProTable.Rows[0];

            txtInvoiceSubject.Text = ProRow["SUBJECT"].ToString();
            decimal nudInvoiceValue = decimal.Parse(ProRow["VALUE"].ToString());
            nudInvoiceInvoiceValue.Value = nudInvoiceValue;

         

            DataRow InvRow = InvTable.Rows[0];

            DateTime InvoiceExpireDate = new DateTime();
            InvoiceExpireDate = DateTime.Parse(InvRow["INVOICE_END_DATE"].ToString());
            dtpFinInvoiceExpDate.Value = InvoiceExpireDate;

            DateTime InvoiceSendDate = new DateTime();
            InvoiceSendDate = DateTime.Parse(InvRow["INVOICE_SEND"].ToString());
            dtptxtInvoiceInvoiceSendDate.Value = InvoiceSendDate;
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
                btnEditFields.Text = "Edit Fields";
            }


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
                tbContr.SelectedIndex = 5;
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

       
    }
}
