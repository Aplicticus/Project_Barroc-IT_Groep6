using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Barroc_IT
{
    public enum Choice
    {
        Company = 0,
        Email = 1,
        Initials = 2
    }

    public partial class frmDevelopment : Form
    {
        // Variables
        private DatabaseHandler handler;
        private frmLogin loginForm;
        private DataTableHandler dthandler;
        private int selectedCustomer;
        private int selectedProject;        
        private bool closing = false;

        // Form Constructor
        public frmDevelopment(DatabaseHandler handler, frmLogin loginForm, DataTableHandler dthandler)
        {
            InitializeComponent();
            cBoxCustomerSearch.SelectedIndex = 0;
            this.handler = handler;
            this.loginForm = loginForm;
            this.dthandler = dthandler;
        }      

        #region "Events"
        private void btnDevSelectCustomer_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 1;
            dgvCustomers.Rows.Clear();
            DataTable customers = dthandler.LoadCustomers();

            AddItemsToDataGridView(customers, dgvCustomers, "cProjectID");
        }

        private void btnCreateProject_Click(object sender, EventArgs e)
        {
            if (AddProject() == true)
            {
                MessageBox.Show("Project succesfully added!");
                tbContr.SelectedIndex = 4;
            }
            else
            {
                MessageBox.Show("There is a problem with adding a project!");
            }
        }

        private void btnAddProjectCustomer_Click(object sender, EventArgs e)
        {
            DataTable dtCustomerResult = dthandler.LoadCustomers(selectedCustomer);

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
                dthandler.LoadProjects(selectedProject);

                txtProjectName.ReadOnly = true;
                txtProjectSubject.ReadOnly = true;
                txtProjectValue.ReadOnly = true;

                btnEditProject.Text = "Edit Fields";
            }
        }

        private void btnViewProjects_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 3;
            dgvProjects.Rows.Clear();
            DataTable projects = dthandler.LoadProjects(selectedCustomer);            

            AddItemsToDataGridView(projects, dgvProjects, "cProjectID");
        }

        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            if (txtCustomerSearch.Text.Length > 0)
            {
                Choice selectedItem;
                switch(cBoxCustomerSearch.SelectedItem.ToString())
                {
                    case "Company Name":
                        selectedItem = Choice.Company;
                        break;
                    case "E-Mail":
                        selectedItem = Choice.Email;
                        break;
                    case "Initials":
                        selectedItem = Choice.Initials;
                        break;
                    default:
                        selectedItem = Choice.Company;
                        break;
                }
                DataTable resultOfSearch = dthandler.SearchText(selectedItem, txtCustomerSearch.Text);
                AddItemsToDataGridView(resultOfSearch, dgvCustomers, "cCustomerID");
            }
            else
            {
                DataTable customers = dthandler.LoadCustomers();
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
                
                //Set fields taht could be changed to readOnly
                txtMaintenance.ReadOnly = true;
                txtOpenProject.ReadOnly = true;
                txtApplications.ReadOnly = true;
                txtHardware.ReadOnly = true;
                txtSoftware.ReadOnly = true;
                txtInternalContact.ReadOnly = true;
                btnEditFields.Text = "Edit Fields";
            }
        }

        private void dgvUserInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCustomers.Columns["cViewButton"].Index)
            {
                selectedCustomer = int.Parse(dgvCustomers.Rows[e.RowIndex].Cells["cCustomerID"].Value.ToString());               
                DataTable customerDetails = dthandler.LoadCustomers(selectedCustomer);
                DataTable appointmentDetails = dthandler.LoadAppointments(selectedCustomer);

                LoadCustomerDetails(customerDetails, appointmentDetails);
                tbContr.SelectedIndex = 2;
            }
        }

        private void dgvProjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvProjects.Columns["cProjectViewButton"].Index)
            {
                selectedProject = int.Parse(dgvProjects.Rows[e.RowIndex].Cells["cProjectID"].Value.ToString());
                DataTable customerDetails = dthandler.LoadCustomers(selectedCustomer);
                DataTable projectDetails = dthandler.LoadProjectDetails(selectedCustomer, selectedProject);
                
                LoadProjectDetails(customerDetails, projectDetails);
                tbContr.SelectedIndex = 4;                
            }
        }

        private void frmDevelopment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closing)
            {
                CloseToLogin();
                closing = true;
            }
        }
        #endregion

        #region "Customer Methods"
        private void LoadCustomerDetails(DataTable CusTable, DataTable ApoTable)
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
        }

        private bool UpdateCustomer(int customerID)
        {
            string sqlQueryCustomers = "UPDATE tbl_Customers SET MAINT_CONTR=@MaintenanceContract, OPEN_PROJ=@OpenProjects, HARDWARE=@Hardware, SOFTWARE=@Software WHERE CUSTOMER_ID=@customerID";
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
        #endregion

        #region "Project Methods"     
 
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

        private bool AddProject()
        {
            string sqlQuery = "INSERT INTO tbl_Projects (CUSTOMER_ID, NAME, DEADLINE, SUBJECT, VALUE) VALUES (@SelectedCustomer, @Name, @Deadline, @Subject, @Value)";
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

        private bool UpdateProject(int projectID)
        {
            string sqlQuery = "UPDATE tbl_Projects SET NAME=@ProjectName, DEADLINE=@Deadline, SUBJECT=@Subject, VALUE=@Value WHERE PROJECT_ID=@ProjectID";
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
        #endregion

        #region "Appointment Methods"
       
        private void LoadAppointmentDetails(int customerID)
        {    
            DataTable dtAppointmentResults = dthandler.LoadAppointments(customerID);
            foreach (DataRow DR in dtAppointmentResults.Rows)
            {
                DateTime projectAppointment = new DateTime();
                projectAppointment = DateTime.Parse(DR["APPOIN_DATE"].ToString());

                dtpDevAppointment.Value = projectAppointment;
                txtInternalContact.Text = DR["INT_CONTACT"].ToString();
            }
        }

        private bool UpdateAppointment(int customerID)
        {
            string sqlQuery = "UPDATE tbl_Appointments SET INT_CONTACT=@InternalContact WHERE CUSTOMER_ID=@customerID";
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

        private void CloseToLogin()
        {
            closing = true;
            loginForm.ClearTextBoxes();
            loginForm.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = tbContr.SelectedIndex - 1;
        }
    }
}
