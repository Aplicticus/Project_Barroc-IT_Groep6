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
        

        private int selectedCustomer;
        private int selectedProject;
        private bool closing = false;

        // Form Constructor
        public frmDevelopment(DatabaseHandler handler, frmLogin loginForm)
        {
            InitializeComponent();
            cBoxCustomerSearch.SelectedIndex = 0;

            this.handler = handler;
            this.loginForm = loginForm;
            
        }      

        #region "Events"
        private void btnDevSelectCustomer_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 1;
            dgvCustomers.Rows.Clear();
            DataTable customers = LoadCustomers();

            AddItemsToDataGridView(customers, dgvCustomers);
        }

        private void btnCreateProject_Click(object sender, EventArgs e)
        {
            if (AddProject() == true)
            {
                MessageBox.Show("Project succesfully added!");
            }
            else
            {
                MessageBox.Show("There is a problem with adding a project!");
            }
        }

        private void btnAddProjectCustomer_Click(object sender, EventArgs e)
        {
            DataTable dtCustomerResult = LoadCustomers(selectedCustomer);

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
                LoadProjectDetails(selectedProject);

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
            DataTable projects = LoadProjects(selectedCustomer);

            AddItemsToDataGridView(projects, dgvProjects);
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

                DataTable resultOfSearch = SearchText(selectedItem, txtCustomerSearch.Text);
                AddItemsToDataGridView(resultOfSearch, dgvCustomers);
            }
            else
            {
                DataTable customers = LoadCustomers();
                AddItemsToDataGridView(customers, dgvCustomers);
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
                selectedCustomer = int.Parse(dgvCustomers.Rows[e.RowIndex].Cells["cViewButton"].Value.ToString());
                DataTable customerDetails = LoadCustomers(selectedCustomer);

                LoadCustomerDetails(customerDetails);
                LoadAppointmentDetails(selectedCustomer);
                tbContr.SelectedIndex = 2;
            }
        }

        private void dgvProjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvProjects.Columns["cProjectViewButton"].Index)
            {
                selectedProject = int.Parse(dgvProjects.Rows[e.RowIndex].Cells["cProjectViewButton"].Value.ToString());
                //LoadAppointmentDetails();
                DataTable projectDetails = LoadProjectDetails(selectedCustomer);
                DataTable projectCustomerDetails = LoadCustomers(selectedCustomer);

                foreach (DataRow dr in projectDetails.Rows)
                {                    
                    DateTime projectDeadline = new DateTime();
                    projectDeadline = DateTime.Parse(dr["DEADLINE"].ToString());

                    txtProjectName.Text = dr["NAME"].ToString();
                    dtpDeadlineViewProject.Value = projectDeadline;
                    txtProjectSubject.Text = dr["SUBJECT"].ToString();
                    txtProjectValue.Text = dr["VALUE"].ToString();
                }
                foreach (DataRow drCus in projectCustomerDetails.Rows)
                {
                    txtProjectCompanyName.Text = drCus["COMPANYNAME"].ToString();
                }
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
        private DataTable LoadCustomers()
        {
            string sqlQuery = "SELECT * FROM tbl_Customers";
            SqlDataAdapter DA = new SqlDataAdapter(sqlQuery, handler.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];

            return DT;
        }

        private DataTable LoadCustomers(int customerID)
        {
            string sqlQueryCustomer = "SELECT * FROM tbl_Customers WHERE CUSTOMER_ID ='" + customerID + "'";
            SqlDataAdapter daCustomer = new SqlDataAdapter(sqlQueryCustomer, handler.GetConnection());
            DataSet dSetCustomer = new DataSet();
            daCustomer.Fill(dSetCustomer);
            DataTable DT = dSetCustomer.Tables[0];

            return DT;
        }
        private void LoadCustomerDetails(DataTable table)
        {
            DataRow row = table.Rows[0];

            txtCompanyName.Text = row["COMPANYNAME"].ToString();
            txtAddress1.Text = row["ADDRESS1"].ToString();
            txtPostalCode1.Text = row["POSTALCODE1"].ToString();
            txtPhoneNumber1.Text = row["PHONE_NR1"].ToString();
            txtFaxNumber.Text = row["FAXNUMBER"].ToString();
            txtEmail.Text = row["EMAIL"].ToString();
            txtContactPerson.Text = row["CONTACTPERSON"].ToString();

            txtMaintenance.Text = row["MAINT_CONTR"].ToString();
            txtOpenProject.Text = row["OPEN_PROJ"].ToString();
            txtHardware.Text = row["HARDWARE"].ToString();
            txtSoftware.Text = row["SOFTWARE"].ToString();
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
        private DataTable LoadProjects(int customerID)
        {
            string sqlQueryProjects = "SELECT * FROM tbl_Projects WHERE CUSTOMER_ID ='" + customerID + "'";
            SqlDataAdapter DA = new SqlDataAdapter(sqlQueryProjects, handler.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];

            return DT;
        }

        private DataTable LoadProjectDetails(int projectID)
        {
            string sqlQueryPro = "SELECT * FROM tbl_Projects WHERE PROJECT_ID ='" + selectedProject + "'";

            SqlDataAdapter daProject = new SqlDataAdapter(sqlQueryPro, handler.GetConnection());
            DataSet dsProject = new DataSet();

            daProject.Fill(dsProject);
            DataTable dtProject = dsProject.Tables[0];

            return dtProject;
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
        private DataTable LoadAppointments(int customerID)
        {
            string sqlQuery = "SELECT * FROM tbl_Appointments WHERE CUSTOMER_ID ='" + selectedCustomer + "'";

            SqlDataAdapter DA = new SqlDataAdapter(sqlQuery, handler.GetConnection());
            DataSet DS = new DataSet();

            DA.Fill(DS);

            DataTable DT = DS.Tables[0];

            return DT;
        }
        private void LoadAppointmentDetails(int customerID)
        {
            dtpDevAppointment.Text = "";
            txtInternalContact.Text = "";

            DataTable dtAppointmentResults = LoadAppointments(customerID);
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

        private void AddItemsToDataGridView(DataTable table, DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            foreach (DataRow dr in table.Rows)
            {
                dataGridView.Rows.Add(dr.ItemArray);
            }
        }

        private DataTable SearchText(Choice choice, string searchString)
        {
            string selectedChoice = "";
            switch (choice)
            {
                case Choice.Company:
                    selectedChoice = "COMPANYNAME";
                    break;
                case Choice.Email:
                    selectedChoice = "EMAIL";
                    break;
                case Choice.Initials:
                    selectedChoice = "INITIALS";
                    break;
                default:
                    selectedChoice = "";
                    break;
            }

            string sqlQuery = "SELECT * FROM tbl_Customers WHERE " + selectedChoice + " LIKE '%" + searchString + "%'";
            SqlDataAdapter DA = new SqlDataAdapter(sqlQuery, handler.GetConnection());
            
            DataSet DS = new DataSet();
            DA.Fill(DS);

            DataTable DT = DS.Tables[0];
            return DT;
        }

        private void CloseToLogin()
        {
            closing = true;
            loginForm.Show();
            this.Close();
        }
    }
}
