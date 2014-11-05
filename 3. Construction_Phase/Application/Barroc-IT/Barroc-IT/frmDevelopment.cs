using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Barroc_IT
{
    public partial class frmDevelopment : Form
    {
        // Add check functions
        #region Properties
        private DatabaseHandler handler;
        private frmLogin loginForm;
        private DataTableHandler dthandler;
        private SqlQueryHandler sqlhandler;
        private int selectedCustomer;
        private int selectedProject;        
        private bool closing = false;
        #endregion

        #region Constructor
        public frmDevelopment(DatabaseHandler handler, frmLogin loginForm, DataTableHandler dthandler, SqlQueryHandler sqlhandler)
        {
            InitializeComponent();
            cBoxCustomerSearch.SelectedIndex = 0;
            cBoxProjectSearch.SelectedIndex = 0;
            this.handler = handler;
            this.loginForm = loginForm;
            this.dthandler = dthandler;
            this.sqlhandler = sqlhandler;
        }
        #endregion

        #region Click Events
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
            string sql = sqlhandler.GetQuery(Query.loadCustomerDetails);
            SqlParameter[] collection = { new SqlParameter("customerID", selectedCustomer) };
            DataTable dtCustomerResult = dthandler.ExecuteQuery(sql, collection);
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
                string sql = sqlhandler.GetQuery(Query.updateFinProjectInfo);
                SqlParameter[] collection = { new SqlParameter("customerID", selectedCustomer) };
                dthandler.ExecuteQuery(sql, collection);
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
                DataTable resultOfSearch = dthandler.SearchText(selectedItem, txtCustomerSearch.Text, selectedCustomer);
                dthandler.AddItemsToDataGridView(resultOfSearch, dgvCustomers, "cCustomerID");
            }
            else
            {
                string selectCustomers = "SELECT * FROM tbl_Customers";
                DataTable customers = dthandler.ExecuteQuery(selectCustomers);
                dthandler.AddItemsToDataGridView(customers, dgvCustomers, "cCustomerID");
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
        private void btnProjectSearch_Click(object sender, EventArgs e)
        {
            if (txtProjectSearch.Text.Length > 0)
            {
                SearchChoice selectedItem;
                switch (cBoxProjectSearch.SelectedItem.ToString())
                {
                    case "Project Name":
                        selectedItem = SearchChoice.ProjectName;
                        break;
                    case "Subject":
                        selectedItem = SearchChoice.ProjectSubject;
                        break;
                    default:
                        selectedItem = SearchChoice.ProjectName;
                        break;
                }
                DataTable resultOfSearch = dthandler.SearchText(selectedItem, txtProjectSearch.Text, selectedCustomer);
                dthandler.AddItemsToDataGridView(resultOfSearch, dgvProjects, "cProjectID");
            }
            else
            {
                string selectCustomers = sqlhandler.GetQuery(Query.loadProjects);
                SqlParameter[] collection = { new SqlParameter("customerID", selectedCustomer) };
                DataTable customers = dthandler.ExecuteQuery(selectCustomers, collection);
                dthandler.AddItemsToDataGridView(customers, dgvProjects, "cProjectID");
            }
        }        
        // Cell Content Clicks
        private void dgvUserInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCustomers.Columns["cViewButton"].Index)
            {
                selectedCustomer = int.Parse(dgvCustomers.Rows[e.RowIndex].Cells["cCustomerID"].Value.ToString());
                string sqlCustomer = sqlhandler.GetQuery(Query.loadCustomers);
                DataTable customerDetails = dthandler.ExecuteQuery(sqlCustomer);

                string sqlAppointments = sqlhandler.GetQuery(Query.loadAppointments);
                SqlParameter[] collection = { new SqlParameter("customerID", selectedCustomer) };
                DataTable appointmentDetails = dthandler.ExecuteQuery(sqlAppointments, collection);

                string sqlCountProjects = sqlhandler.GetQuery(Query.countProjects);
                collection = new SqlParameter[]{ new SqlParameter("customerID", selectedCustomer) };
                DataTable projectCount = dthandler.ExecuteQuery(sqlCountProjects, collection);
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
                string sqlCustomer = sqlhandler.GetQuery(Query.loadCustomers);
                DataTable customerDetails = dthandler.ExecuteQuery(sqlCustomer);

                string sqlProject = sqlhandler.GetQuery(Query.loadProjectDetails);
                SqlParameter[] collection = { new SqlParameter("customerID", selectedCustomer), new SqlParameter("projectID", selectedProject) };

                DataTable projectDetails = dthandler.ExecuteQuery(sqlProject,collection);                
                LoadProjectDetails(customerDetails, projectDetails);
                tbContr.SelectedIndex = 4;                
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
            dthandler.AddItemsToDataGridView(projects, dgvProjects, "finProView");
        }       
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
        #endregion

        #region Updaters / Editers
        private bool UpdateCustomer(int customerID)
        {
            string sqlQueryCustomers = sqlhandler.GetQuery(Query.updateDevCustomerInfo);
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
            string sqlQuery = sqlhandler.GetQuery(Query.updateDevProjectInfo);
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
            string sqlQuery = sqlhandler.GetQuery(Query.updateDevAppointmentInfo);
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
        #endregion
        
        #region Methods
        private bool AddProject()
        {
            string sqlQuery = sqlhandler.GetQuery(Query.addProject);
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
        #endregion
        
        #region Form closing
        private void frmDevelopment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closing)
            {
                CloseToLogin();
                closing = true;
            }
        }
        #endregion

        #region CloseToLogin
        private void CloseToLogin()
        {
            closing = true;
            loginForm.ClearTextBoxes();
            loginForm.Show();
            this.Close();
        }
        #endregion
    }
}
