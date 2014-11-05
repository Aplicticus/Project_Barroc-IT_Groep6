using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Barroc_IT
{
    public partial class frmDevelopment : Form
    {
        // Add check functions
        // 1: Add Project (done)
        // 2: Update Project (done)
        // 3: Update CustomerDevInfo 

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
            if (txtProjectAddName.Text.Length > 0)
            {
                if (dtProjectAddDeadline.Value > dtProjectAddDeadline.MinDate)
                {
                    if (txtProjectAddSubject.Text.Length > 0)
                    {
                        if(numProjectAddValue.Value > 0)
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
                        else
                        {
                            MessageBox.Show("Invalid Value! Please check the value.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The Subject field is empty! Please fill in.");
                    }
                }
                else
                {
                    MessageBox.Show("The date is invalid. Please check the date.");
                }
            }
            else
            {
                MessageBox.Show("The Project Name field is empty! Please fill in.");
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
            txtProjectAddName.ResetText();
            txtProjectAddSubject.ResetText();
            nudProjectValue.ResetText();
        }
        private void btnEditProject_Click(object sender, EventArgs e)
        {
            if (btnEditProject.Text == "Edit Fields")
            {
                txtProjectName.ReadOnly = false;
                dtpDeadlineViewProject.Enabled = true;
                txtProjectSubject.ReadOnly = false;
                nudProjectValue.ReadOnly = false;
                btnEditProject.Text = "Save Changes";
            }
            else if (btnEditProject.Text == "Save Changes")
            {
                if (txtProjectName.Text.Length > 0)
                {
                    if (dtProjectAddDeadline.Value > dtProjectAddDeadline.MinDate)
                    {
                        if (txtProjectSubject.Text.Length > 0)
                        {
                            if (nudProjectValue.Value > 0)
                            {
                                UpdateProject(selectedProject);
                                txtProjectName.ReadOnly = true;
                                txtProjectSubject.ReadOnly = true;
                                nudProjectValue.ReadOnly = true;
                                btnEditProject.Text = "Edit Fields";
                            }
                            else
                            {
                                MessageBox.Show("The Value field is empty or 0. Please fill in.");
                                nudProjectValue.ResetText();
                            }
                        }
                        else
                        {
                            MessageBox.Show("The Subject field is empty! Please fill in.");
                            txtProjectSubject.ResetText();
                        }                        
                    }
                    else
                    {
                        MessageBox.Show("The Date field is filled incorrect. Please check the date.");
                        dtProjectAddDeadline.ResetText();
                    }
                }
                else
                {
                    MessageBox.Show("The Project Name field is empty! Please fill in.");
                    txtProjectName.ResetText();
                }                              
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

                string sqlCountOpenProjects = sqlhandler.GetQuery(Query.countProjectsTable);
                collection = new SqlParameter[] { new SqlParameter("customerID", selectedCustomer), new SqlParameter("Completed", false)};
                DataTable countOpenProjectsTable = dthandler.ExecuteQuery(sqlCountOpenProjects, collection);

                string sqlCountClosedProjects = sqlhandler.GetQuery(Query.countProjectsTable);
                collection = new SqlParameter[] { new SqlParameter("customerID", selectedCustomer), new SqlParameter("Completed", true) };
                DataTable countClosedProjectsTable = dthandler.ExecuteQuery(sqlCountClosedProjects, collection);

                LoadCustomerDetails(customerDetails, appointmentDetails, projectCount, countOpenProjectsTable, countClosedProjectsTable);

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
                if (txtProjectCompleted.Text == "True")
                {
                    btnArchiveProject.Enabled = false;
                    btnEditProject.Enabled = false;
                }
                else
                {
                    btnArchiveProject.Enabled = true;
                    btnEditProject.Enabled = true;
                }
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
            dthandler.AddItemsToDataGridView(customers, dgvCustomers, "cCustomerID");
        }
        private void LoadProjects()
        {
            dgvProjects.Rows.Clear();
            string sql = sqlhandler.GetQuery(Query.loadProjects);
            SqlParameter[] collection = { new SqlParameter("customerID", selectedCustomer) };
            DataTable projects = dthandler.ExecuteQuery(sql, collection);
            dthandler.AddItemsToDataGridView(projects, dgvProjects, "cProjectID");
        }
        private void LoadCustomerDetails(DataTable CusTable, DataTable ApoTable, DataTable CountProTable, DataTable CountOpenProjectsTable, DataTable CountClosedProjectsTable)
        {
            DataRow CusRow = CusTable.Rows[0];
            DataRow ApoRow = ApoTable.Rows[0];
            DataRow CountPro = CountProTable.Rows[0];
            DataRow CountOpenProjectsRow = CountOpenProjectsTable.Rows[0];
            DataRow CountClosedProjectsRow = CountClosedProjectsTable.Rows[0];
            txtCompanyName.Text = CusRow["COMPANYNAME"].ToString();
            txtAddress1.Text = CusRow["ADDRESS1"].ToString();
            txtPostalCode1.Text = CusRow["POSTALCODE1"].ToString();
            txtPhoneNumber1.Text = CusRow["PHONE_NR1"].ToString();
            txtFaxNumber.Text = CusRow["FAXNUMBER"].ToString();
            txtEmail.Text = CusRow["EMAIL"].ToString();
            txtContactPerson.Text = CusRow["CONTACTPERSON"].ToString();
            txtApplications.Text = CusRow["APPLICATIONS"].ToString();
            txtMaintenance.Text = CusRow["MAINT_CONTR"].ToString();            
            txtHardware.Text = CusRow["HARDWARE"].ToString();
            txtSoftware.Text = CusRow["SOFTWARE"].ToString();            
            txtInternalContact.Text = ApoRow["INT_CONTACT"].ToString();
            DateTime devAppointment = new DateTime();
            devAppointment = DateTime.Parse(ApoRow["APPOIN_DATE"].ToString());
            dtpDevAppointment.Value = devAppointment;            
            txtDevProjects.Text = CountPro[0].ToString();
            txtOpenProjects.Text = CountOpenProjectsRow[0].ToString();
            txtClosedProjects.Text = CountClosedProjectsRow[0].ToString();
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
            nudProjectValue.Text = ProRow["VALUE"].ToString();
            txtProjectCompleted.Text = ProRow["COMPLETED"].ToString();
        }
        #endregion

        #region Updaters / Editers
        private bool UpdateCustomer(int customerID)
        {
            string sqlQueryCustomers = sqlhandler.GetQuery(Query.updateDevCustomerInfo);
            SqlCommand cmd = new SqlCommand(sqlQueryCustomers, handler.GetConnection());
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
            cmd.Parameters.Add(new SqlParameter("Value", nudProjectValue.Value));
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
            cmd.Parameters.Add(new SqlParameter("@Completed", false));
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

        private bool ArchiveProject(int projectID)
        {
            string sqlQuery = sqlhandler.GetQuery(Query.archiveProject);

            SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection());
            cmd.Parameters.Add(new SqlParameter("@Completed", true));
            cmd.Parameters.Add(new SqlParameter("@projectID", projectID));
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

        private void btnArchiveProject_Click(object sender, EventArgs e)
        {
            if (ArchiveProject(selectedProject))
            {
                MessageBox.Show("Project succesfully completed!");
                tbContr.SelectedIndex = 3;
                LoadProjects();
            }
        }
    }
}
