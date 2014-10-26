using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Barroc_IT
{
    public partial class frmDevelopment : Form
    {
        // Properties, Instances
        private DatabaseHandler handler;
        private frmLogin loginForm;
        private DataTableHandler dthandler;
        private SqlQueryHandler sqlhandler;
        private int selectedCustomer;
        private int selectedProject;        
        private bool closing = false;

        // Form Constructor
        public frmDevelopment(DatabaseHandler handler, frmLogin loginForm, DataTableHandler dthandler, SqlQueryHandler sqlhandler)
        {
            InitializeComponent();
            cBoxCustomerSearch.SelectedIndex = 0;
            this.handler = handler;
            this.loginForm = loginForm;
            this.dthandler = dthandler;
            this.sqlhandler = sqlhandler;
        }      

        // Click Events
        private void btnDevSelectCustomer_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 1;
            LoadCustomers();
        }
        private void btnCreateProject_Click(object sender, EventArgs e)
        {
            if (AddProject() == true)
            {
                MessageBox.Show("Project succesfully added!");
                LoadProjects();
                tbContr.SelectedIndex = 3;
            }
            else
            {
                MessageBox.Show("There is a problem with adding a project!");
            }
        }
        private void btnAddProjectCustomer_Click(object sender, EventArgs e)
        {
            string loadCustomerDetails = sqlhandler.GetQuery("loadCustomerDetails", selectedCustomer);
            DataTable dtCustomerResult = dthandler.SqlQueryToDataTable(loadCustomerDetails, selectedCustomer);
            foreach (DataRow dr in dtCustomerResult.Rows)
            {
                txtProjectAddCompanyName.Text = dr["COMPANYNAME"].ToString();
                break;
            }
            tbContr.SelectedIndex = 5;
        }
        private void btnEditProject_Click(object sender, EventArgs e)
        {
            if (btnEditProject.Text == "Edit Fields")
            {
                txtProjectName.ReadOnly = false;
                dtpDeadlineViewProject.Enabled = true;
                txtProjectSubject.ReadOnly = false;
                txtProjectValue.ReadOnly = false;
                btnEditProject.Text = "Save Changes";
            }
            else if (btnEditProject.Text == "Save Changes")
            {
                UpdateProject(selectedProject);
                string sql = sqlhandler.UpdateQuery("updateFinProjectInfo", selectedCustomer);
                dthandler.SqlQueryToDataTableProject(sql, selectedCustomer);
                txtProjectName.ReadOnly = true;
                txtProjectSubject.ReadOnly = true;
                txtProjectValue.ReadOnly = true;
                btnEditProject.Text = "Edit Fields";
            }
        }
        private void btnViewProjects_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 3;           
            LoadProjects();
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
            else
            {
                string selectCustomers = "SELECT * FROM tbl_Customers";
                DataTable customers = dthandler.SqlQueryToDataTable(selectCustomers);
                AddItemsToDataGridView(customers, dgvCustomers, "cCustomerID");
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult confirmationLogout = MessageBox.Show("Are you sure you want to log out?", "Confirm log out", MessageBoxButtons.YesNo);
            if (confirmationLogout == DialogResult.Yes)
            {
                CloseToLogin();
            }
        }
        private void btnEditFields_Click(object sender, EventArgs e)
        {
            if (btnEditFields.Text == "Edit Fields")
            {
                //Change fields readonly so they can be edited
                txtMaintenance.ReadOnly = false;
                txtOpenProject.ReadOnly = false;
                txtApplications.ReadOnly = false;
                txtHardware.ReadOnly = false;
                txtSoftware.ReadOnly = false;
                txtInternalContact.ReadOnly = false;
                btnEditFields.Text = "Save Changes";
            }
            else if (btnEditFields.Text == "Save Changes")
            {
                if (UpdateCustomer(selectedCustomer) == true && UpdateAppointment(selectedCustomer))
                {
                    MessageBox.Show("Succesfully saved changes!");
                }
                else
                {
                    MessageBox.Show("There was an error saving changes!");
                }
                //Set fields that could be changed to readOnly
                txtMaintenance.ReadOnly = true;
                txtOpenProject.ReadOnly = true;
                txtApplications.ReadOnly = true;
                txtHardware.ReadOnly = true;
                txtSoftware.ReadOnly = true;
                txtInternalContact.ReadOnly = true;
                btnEditFields.Text = "Edit Fields";
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = tbContr.SelectedIndex - 1;
            LoadCustomers();
            LoadProjects();
        }
        private void btnAddInvoiceCancel_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 2;
        }
        
        // Cell Content Clicks
        private void dgvUserInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCustomers.Columns["cViewButton"].Index)
            {
                selectedCustomer = int.Parse(dgvCustomers.Rows[e.RowIndex].Cells["cCustomerID"].Value.ToString());
                string sqlCustomer = sqlhandler.GetQuery("loadCustomers");
                DataTable customerDetails = dthandler.SqlQueryToDataTable(sqlCustomer, selectedCustomer);
                string sqlAppointments = sqlhandler.GetQuery("loadAppointments", selectedCustomer);
                DataTable appointmentDetails = dthandler.SqlQueryToDataTable(sqlAppointments, selectedCustomer);
                string sqlCountProjects = sqlhandler.GetQuery("countProjects", selectedCustomer);
                DataTable projectCount = dthandler.SqlQueryToDataTable(sqlCountProjects, selectedCustomer);
                LoadCustomerDetails(customerDetails, appointmentDetails, projectCount);
                tbContr.SelectedIndex = 2;
                int temp = 0;
                if (txtDevProjects.Text != temp.ToString())
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
            if (e.ColumnIndex == dgvProjects.Columns["cProjectViewButton"].Index)
            {
                selectedProject = int.Parse(dgvProjects.Rows[e.RowIndex].Cells["cProjectID"].Value.ToString());
                string sqlCustomer = sqlhandler.GetQuery("loadCustomers");
                DataTable customerDetails = dthandler.SqlQueryToDataTable(sqlCustomer, selectedCustomer);
                string sqlProject = sqlhandler.GetQuery("loadProjects", selectedProject);
                DataTable projectDetails = dthandler.SqlQueryToDataTable(sqlProject, selectedCustomer, selectedProject);
                
                LoadProjectDetails(customerDetails, projectDetails);
                tbContr.SelectedIndex = 4;                
            }
        }

        // Loads
        private void LoadCustomerDetails(DataTable CusTable, DataTable ApoTable, DataTable CountProTable)
        {
            DataRow CusRow = CusTable.Rows[0];
            txtCompanyName.Text = CusRow["COMPANYNAME"].ToString();
            txtAddress1.Text = CusRow["ADDRESS1"].ToString();
            txtPostalCode1.Text = CusRow["POSTALCODE1"].ToString();
            txtPhoneNumber1.Text = CusRow["PHONE_NR1"].ToString();
            txtFaxNumber.Text = CusRow["FAXNUMBER"].ToString();
            txtEmail.Text = CusRow["EMAIL"].ToString();
            txtContactPerson.Text = CusRow["CONTACTPERSON"].ToString();
            txtApplications.Text = CusRow["APPLICATIONS"].ToString();
            txtMaintenance.Text = CusRow["MAINT_CONTR"].ToString();
            txtOpenProject.Text = CusRow["OPEN_PROJ"].ToString();
            txtHardware.Text = CusRow["HARDWARE"].ToString();
            txtSoftware.Text = CusRow["SOFTWARE"].ToString();
            DataRow ApoRow = ApoTable.Rows[0];
            txtInternalContact.Text = ApoRow["INT_CONTACT"].ToString();
            DateTime devAppointment = new DateTime();
            devAppointment = DateTime.Parse(ApoRow["APPOIN_DATE"].ToString());
            dtpDevAppointment.Value = devAppointment;
            DataRow CountPro = CountProTable.Rows[0];
            txtDevProjects.Text = CountPro[0].ToString();
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

        // Updaters / Editers
        private bool UpdateCustomer(int customerID)
        {
            string sqlQueryCustomers = sqlhandler.UpdateQuery("updateDevCustomerInfo", selectedCustomer);
            SqlCommand cmd = new SqlCommand(sqlQueryCustomers, handler.GetConnection());
            cmd.Parameters.Add(new SqlParameter("MaintenanceContract", txtMaintenance.Text));
            cmd.Parameters.Add(new SqlParameter("OpenProjects", txtOpenProject.Text));
            cmd.Parameters.Add(new SqlParameter("Hardware", txtHardware.Text));
            cmd.Parameters.Add(new SqlParameter("Software", txtSoftware.Text));
            cmd.Parameters.Add(new SqlParameter("customerID", customerID));
            handler.OpenConnection();
            int rowsAffected = cmd.ExecuteNonQuery();
            handler.CloseConnection();
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool UpdateProject(int projectID)
        {
            string sqlQuery = sqlhandler.UpdateQueryProject("updateDevProjectInfo", selectedProject);
            SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection());
            cmd.Parameters.Add(new SqlParameter("ProjectName", txtProjectName.Text));
            cmd.Parameters.Add(new SqlParameter("Deadline", dtpDeadlineViewProject.Value.Date));
            cmd.Parameters.Add(new SqlParameter("Subject", txtProjectSubject.Text));
            cmd.Parameters.Add(new SqlParameter("Value", txtProjectValue.Text));
            cmd.Parameters.Add(new SqlParameter("ProjectID", projectID));
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
        private bool UpdateAppointment(int customerID)
        {
            string sqlQuery = sqlhandler.UpdateQuery("updateDevAppointmentInfo", selectedCustomer);
            SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection());
            cmd.Parameters.Add(new SqlParameter("InternalContact", txtInternalContact.Text));
            cmd.Parameters.Add(new SqlParameter("customerID", customerID));
            handler.OpenConnection();
            int rowsAffected = cmd.ExecuteNonQuery();
            handler.CloseConnection();

            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Inserts
        private bool AddProject()
        {
            string sqlQuery = sqlhandler.SetQuery("addProject");
            SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection());
            cmd.Parameters.Add(new SqlParameter("@SelectedCustomer", selectedCustomer));
            cmd.Parameters.Add(new SqlParameter("@Name", txtProjectAddName.Text));
            cmd.Parameters.Add(new SqlParameter("@Deadline", dtProjectAddDeadline.Value));
            cmd.Parameters.Add(new SqlParameter("@Subject", txtProjectAddSubject.Text));
            cmd.Parameters.Add(new SqlParameter("@Value", numProjectAddValue.Value));
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

        // Form closing
        private void frmDevelopment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closing)
            {
                CloseToLogin();
                closing = true;
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
    }
}
