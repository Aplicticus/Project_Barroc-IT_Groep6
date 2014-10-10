using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Barroc_IT
{
    public partial class frmDevelopment : Form

    {        
        // ..........
        private DatabaseHandler handler;
        private int selectedCustomer;
        private int selectedProject;
        private frmLogin loginForm;
        private bool closing = false;
        public frmDevelopment(DatabaseHandler handler, frmLogin loginForm)
        {
            InitializeComponent();
            cBoxCustomerSearch.SelectedIndex = 0;
            this.handler = handler;            
            this.loginForm = loginForm;
        }

        // Getters
        private void GetCustomers()
        {
            string sqlQuery = "SELECT * FROM tbl_Customers ";
            SqlDataAdapter DA = new SqlDataAdapter(sqlQuery, handler.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];

            foreach (DataRow dr in DT.Rows)
            {
                dgvUserInfo.Rows.Add(dr.ItemArray);
            }
        }
        private void GetProjects()
        {
            DataTable dtProjectResult = LoadProject(selectedCustomer);
            foreach (DataRow dr in dtProjectResult.Rows)
            {
                dgvProjects.Rows.Add(dr.ItemArray);
            }
        }

        // Loads
        private void LoadCustomerDetails()
        {
            DataTable dtCustomerResult = LoadCustomers(selectedCustomer);
            DataRow drCustomer = dtCustomerResult.Rows[0];
            txtCompanyName.Text = drCustomer["COMPANYNAME"].ToString();
            txtAddress1.Text = drCustomer["ADDRESS1"].ToString();
            txtPostalCode1.Text = drCustomer["POSTALCODE1"].ToString();
            txtPhoneNumber1.Text = drCustomer["PHONE_NR1"].ToString();
            txtFaxNumber.Text = drCustomer["FAXNUMBER"].ToString();
            txtEmail.Text = drCustomer["EMAIL"].ToString();
            txtContactPerson.Text = drCustomer["CONTACTPERSON"].ToString();
            txtMaintenance.Text = drCustomer["MAINT_CONTR"].ToString();
            txtOpenProject.Text = drCustomer["OPEN_PROJ"].ToString();
            txtHardware.Text = drCustomer["HARDWARE"].ToString();
            txtSoftware.Text = drCustomer["SOFTWARE"].ToString();
        }
        private void LoadAppointmentDetails()
        {
            txtAppointments.Text = "";
            txtInternalContact.Text = "";
            DataTable dtAppointmentResults = LoadAppointments(selectedCustomer);
            foreach (DataRow DR in dtAppointmentResults.Rows)
            {
                txtAppointments.Text = DR["APPOIN_DATE"].ToString();
                txtInternalContact.Text = DR["INT_CONTACT"].ToString();
            }
        }
        private void LoadProjectDetails()
        {
            DataTable dtCustomerResult = LoadCustomers(selectedCustomer);
            foreach (DataRow dr in dtCustomerResult.Rows)
            {
                txtProjectCustomerID.Text = dr["COMPANYNAME"].ToString();
            }

            DataTable dtProjectResult = LoadProjectDetails(selectedProject);
            foreach (DataRow dr in dtProjectResult.Rows)
            {
                DateTime projectDeadline = new DateTime();
                projectDeadline = DateTime.Parse(dr["DEADLINE"].ToString());
                txtProjectName.Text = dr["NAME"].ToString();
                dtpDeadlineViewProject.Value = projectDeadline;
                txtProjectSubject.Text = dr["SUBJECT"].ToString();
                txtProjectValue.Text = dr["VALUE"].ToString();
            }
        }

        // Click events
        private void btnDevSelectCustomer_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 1;
            dgvUserInfo.Rows.Clear();
            GetCustomers();
        }
        // Adds
        private void btnProjectAdd_Click(object sender, EventArgs e)
        {
            AddDevProject();
        }
        private void btnAddProject_Click(object sender, EventArgs e)
        {
            DataTable dtCustomerResult = LoadCustomers(selectedCustomer);
            foreach (DataRow dr in dtCustomerResult.Rows)
            {
                txtProjectAddCompanyName.Text = dr["COMPANYNAME"].ToString();
            }
            tbContr.SelectedIndex = 5;
        }
        // Edits
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
                UpdateDevProjectFields();
                LoadProjectDetails();
                tbContr.SelectedIndex = 4;
                txtProjectName.ReadOnly = true;
                txtProjectSubject.ReadOnly = true;
                txtProjectValue.ReadOnly = true;
                btnEditProject.Text = "Edit Fields";
            }
        }
        // Views
        private void btnViewProjects_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 3;
            dgvProjects.Rows.Clear();
            GetProjects();
        }
        // Search
        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            if (txtCustomerSearch.Text.Length > 0)
            {
                if (cBoxCustomerSearch.SelectedItem.ToString() == "Company Name")
                {
                    SearchCompanyName();
                }
            }
            else
            {
                SearchDisplayDefault();
            }
        }
        // Logout
        private void btnLogout_Click(object sender, EventArgs e)
        {
            CloseToLogin();
        }
        // Updaters
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
                UpdateDevCustomersFields();
                UpdateDevAppointmentFields();                 

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
        // Datagridview Clicks
        private void dgvUserInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvUserInfo.Columns["cViewButton"].Index)
            {
                selectedCustomer = int.Parse(dgvUserInfo.Rows[e.RowIndex].Cells["cViewButton"].Value.ToString());
                LoadCustomerDetails();
                LoadAppointmentDetails();
                tbContr.SelectedIndex = 2;
            }
        }
        private void dgvProjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvProjects.Columns["cProjectViewButton"].Index)
            {
                selectedProject = int.Parse(dgvProjects.Rows[e.RowIndex].Cells["cProjectViewButton"].Value.ToString());
                //LoadAppointmentDetails();
                LoadProjectDetails();
                tbContr.SelectedIndex = 4;
            }
        }
        // Close formDev
        private void frmDevelopment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closing)
            {
                CloseToLogin();
                closing = true;
            }
        }

        // Methods
        public DataTable LoadCustomers(int customerID)
        {
            string sqlQueryCustomer = "SELECT * FROM tbl_Customers WHERE CUSTOMER_ID ='" + customerID + "'";
            SqlDataAdapter daCustomer = new SqlDataAdapter(sqlQueryCustomer, handler.GetConnection());
            DataSet dSetCustomer = new DataSet();
            daCustomer.Fill(dSetCustomer);
            DataTable DT = dSetCustomer.Tables[0];

            return DT;
        }

        public DataTable LoadProject(int customerID)
        {
            string sqlQueryProjects = "SELECT * FROM tbl_Projects WHERE CUSTOMER_ID ='" + customerID + "'";
            SqlDataAdapter DA = new SqlDataAdapter(sqlQueryProjects, handler.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];

            return DT;
        }

        public DataTable LoadAppointments(int customerID)
        {
            string sqlQuery = "SELECT * FROM tbl_Appointments WHERE CUSTOMER_ID ='" + selectedCustomer + "'";
            SqlDataAdapter DA = new SqlDataAdapter(sqlQuery, handler.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];
            return DT;
        }

        public DataTable LoadProjectDetails(int ProjectID)
        {
            string sqlQueryPro = "SELECT * FROM tbl_Projects WHERE PROJECT_ID ='" + selectedProject + "'";
            SqlDataAdapter daProject = new SqlDataAdapter(sqlQueryPro, handler.GetConnection());
            DataSet dsProject = new DataSet();
            daProject.Fill(dsProject);
            DataTable dtProject = dsProject.Tables[0];            
            return dtProject;
        }

        public void AddDevProject()
        {
            string sqlQuery = "INSERT INTO tbl_Projects (CUSTOMER_ID, NAME, DEADLINE, SUBJECT, VALUE) VALUES (@SelectedCustomer, @Name, @Deadline, @Subject, @Value)";
            SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection());
            cmd.Parameters.Add(new SqlParameter("@SelectedCustomer", selectedCustomer));
            cmd.Parameters.Add(new SqlParameter("@Name", txtProjectAddName.Text));
            cmd.Parameters.Add(new SqlParameter("@Deadline", dtProjectAddDeadline.Value));
            cmd.Parameters.Add(new SqlParameter("@Subject", txtProjectAddSubject.Text));
            cmd.Parameters.Add(new SqlParameter("@Value", numProjectAddValue.Value));
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void UpdateDevCustomersFields()
        {
            string sqlQueryCustomers = "UPDATE tbl_Customers SET MAINT_CONTR=@MaintenanceContract, OPEN_PROJ=@OpenProjects, HARDWARE=@Hardware, SOFTWARE=@Software WHERE CUSTOMER_ID=@SelectedCustomer";
            SqlCommand cmd = new SqlCommand(sqlQueryCustomers, handler.GetConnection());
            cmd.Parameters.Add(new SqlParameter("MaintenanceContract", txtMaintenance.Text));
            cmd.Parameters.Add(new SqlParameter("OpenProjects", txtOpenProject.Text));
            cmd.Parameters.Add(new SqlParameter("Hardware", txtHardware.Text));
            cmd.Parameters.Add(new SqlParameter("Software", txtSoftware.Text));
            cmd.Parameters.Add(new SqlParameter("SelectedCustomer", selectedCustomer));
            handler.OpenConnection();
            cmd.ExecuteNonQuery();
            handler.CloseConnection();
        }         
  
        public void UpdateDevAppointmentFields()
        {
            string sqlQueryAppointments = "UPDATE tbl_Appointments SET INT_CONTACT=@InternalContact WHERE CUSTOMER_ID=@SelectedCustomer";
            SqlCommand cmdApo = new SqlCommand(sqlQueryAppointments, handler.GetConnection());
            cmdApo.Parameters.Add(new SqlParameter("InternalContact", txtInternalContact.Text));
            cmdApo.Parameters.Add(new SqlParameter("SelectedCustomer", selectedCustomer));
            cmdApo.Connection.Open();
            cmdApo.ExecuteNonQuery();
            cmdApo.Connection.Close();
        }

        public void UpdateDevProjectFields()
        {
            string sqlQuery = "UPDATE tbl_Projects SET NAME=@ProjectName, DEADLINE=@Deadline, SUBJECT=@Subject, VALUE=@Value WHERE PROJECT_ID=@SelectedProject";
                SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection());
                cmd.Parameters.Add(new SqlParameter("ProjectName", txtProjectName.Text));
                cmd.Parameters.Add(new SqlParameter("Deadline", dtpDeadlineViewProject.Value.Date));
                cmd.Parameters.Add(new SqlParameter("Subject", txtProjectSubject.Text));
                cmd.Parameters.Add(new SqlParameter("Value", txtProjectValue.Text));
                cmd.Parameters.Add(new SqlParameter("SelectedProject", selectedProject));
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
        }

        public void SearchCompanyName()
        {
            string sqlQuery = "SELECT * FROM tbl_Customers WHERE COMPANYNAME='" + txtCustomerSearch.Text + "'";
                    SqlDataAdapter DA = new SqlDataAdapter(sqlQuery, handler.GetConnection());
                    DataSet DS = new DataSet();
                    DA.Fill(DS);
                    DataTable DT = DS.Tables[0];
                    dgvUserInfo.Rows.Clear();
                    foreach (DataRow dr in DT.Rows)
                    {
                        dgvUserInfo.Rows.Add(dr.ItemArray);
                    }
        }

        public void SearchDisplayDefault()
        {
            string sqlQuery = "SELECT * FROM tbl_Customers";
            SqlDataAdapter DA = new SqlDataAdapter(sqlQuery, handler.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];
            dgvUserInfo.Rows.Clear();
            foreach (DataRow dr in DT.Rows)
            {
                dgvUserInfo.Rows.Add(dr.ItemArray);
            }
        }

        private void CloseToLogin()
        {
            closing = true;
            loginForm.Show();
            this.Close();
        }        
    }
}
