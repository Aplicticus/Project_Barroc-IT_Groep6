using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Barroc_IT
{
    public partial class frmDevelopment : Form
    {
        private DatabaseHandler handler;
        private int selectedCustomer;
        private int selectedProject;
        public frmDevelopment(DatabaseHandler handler)
        {
            InitializeComponent();
            cBoxCustomerSearch.SelectedIndex = 0;
            this.handler = handler;
        }
        private void btnDevSelectCustomer_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 1;
            dgvUserInfo.Rows.Clear();
            GetCustomers();
        }
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
            string sqlQueryProjects = "SELECT * FROM tbl_Projects WHERE CUSTOMER_ID ='" + selectedCustomer + "'";
            SqlDataAdapter DA = new SqlDataAdapter(sqlQueryProjects, handler.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];

            foreach (DataRow dr in DT.Rows)
            {
                dgvProjects.Rows.Add(dr.ItemArray);
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
                //sqlQuerys
                string sqlQueryCustomers = "UPDATE tbl_Customers SET MAINT_CONTR=@MaintenanceContract, OPEN_PROJ=@OpenProjects, HARDWARE=@Hardware, SOFTWARE=@Software WHERE CUSTOMER_ID=@SelectedCustomer";
                string sqlQueryAppointments = "UPDATE tbl_Appointments SET INT_CONTACT=@InternalContact WHERE CUSTOMER_ID=@SelectedCustomer";

                //Create sqlcommands
                SqlCommand cmd = new SqlCommand(sqlQueryCustomers, handler.GetConnection());
                SqlCommand cmdApo = new SqlCommand(sqlQueryAppointments, handler.GetConnection());

                //Add parameters
                cmd.Parameters.Add(new SqlParameter("MaintenanceContract", txtMaintenance.Text));
                cmd.Parameters.Add(new SqlParameter("OpenProjects", txtOpenProject.Text));
                cmd.Parameters.Add(new SqlParameter("Hardware", txtHardware.Text));
                cmd.Parameters.Add(new SqlParameter("Software", txtSoftware.Text));
                cmd.Parameters.Add(new SqlParameter("SelectedCustomer", selectedCustomer));
                cmdApo.Parameters.Add(new SqlParameter("InternalContact", txtInternalContact.Text));
                cmdApo.Parameters.Add(new SqlParameter("SelectedCustomer", selectedCustomer));

                /*Open connection to database
                 * Execute querys
                 * Close connection */
                handler.OpenConnection();
                cmd.ExecuteNonQuery();
                cmdApo.ExecuteNonQuery();
                handler.CloseConnection();

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
        private void LoadCustomerDetails()
        {
            DataTable dtCustomerResult = LoadCustomer(selectedCustomer);
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
            string sqlQuery = "SELECT * FROM tbl_Appointments WHERE CUSTOMER_ID ='" + selectedCustomer + "'";

            SqlDataAdapter DA = new SqlDataAdapter(sqlQuery, handler.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];


            foreach (DataRow DR in DT.Rows)
            {
                txtAppointments.Text = DR["APPOIN_DATE"].ToString();
                txtInternalContact.Text = DR["INT_CONTACT"].ToString();
            }
        }
        private void LoadProjectDetails()
        {
            DataTable dtCustomerResult = LoadCustomer(selectedCustomer);

            foreach (DataRow dr in dtCustomerResult.Rows)
            {
                txtProjectCustomerID.Text = dr["COMPANYNAME"].ToString();
            }


            string sqlQueryPro = "SELECT * FROM tbl_Projects WHERE PROJECT_ID ='" + selectedProject + "'";
            SqlDataAdapter daProject = new SqlDataAdapter(sqlQueryPro, handler.GetConnection());
            DataSet dsProject = new DataSet();
            daProject.Fill(dsProject);
            DataTable dtProject = dsProject.Tables[0];
            DataRow drProject = dtProject.Rows[0];

            DateTime projectDeadline = new DateTime();
            projectDeadline = DateTime.Parse(drProject["DEADLINE"].ToString());
            txtProjectName.Text = drProject["NAME"].ToString();
            dtpDeadlineViewProject.Value = projectDeadline;
            txtProjectSubject.Text = drProject["SUBJECT"].ToString();
            txtProjectValue.Text = drProject["VALUE"].ToString();


        }
        private void DGVUserInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvUserInfo.Columns["cViewButton"].Index)
            {
                selectedCustomer = int.Parse(dgvUserInfo.Rows[e.RowIndex].Cells["cViewButton"].Value.ToString());
                LoadCustomerDetails();
                LoadAppointmentDetails();
                tbContr.SelectedIndex = 2;
            }
        }
        private void btnViewProjects_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 3;
            dgvProjects.Rows.Clear();
            GetProjects();
        }
        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            if (txtCustomerSearch.Text.Length > 0)
            {
                if (cBoxCustomerSearch.SelectedItem.ToString() == "Company Name")
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
            }
            else
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
        }
        private void btnAddProject_Click(object sender, EventArgs e)
        {
            DataTable dtCustomerResult = LoadCustomer(selectedCustomer);
            foreach (DataRow dr in dtCustomerResult.Rows)
            {
                txtProjectAddCompanyName.Text = dr["COMPANYNAME"].ToString();
            }
            tbContr.SelectedIndex = 5;
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

                LoadProjectDetails();
                tbContr.SelectedIndex = 4;

                txtProjectName.ReadOnly = true;
                txtProjectSubject.ReadOnly = true;
                txtProjectValue.ReadOnly = true;
                btnEditProject.Text = "Edit Fields";
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin formLogin = new frmLogin();
            formLogin.Show();
            this.Close();
        }
        private void btnProjectAdd_Click(object sender, EventArgs e)
        {
            string sqlQuery = "INSERT INTO tbl_Projects (CUSTOMER_ID, NAME, DEADLINE, SUBJECT, VALUE) VALUES (@SelectedCustomer, @Name, @Deadline, @Subject, @Value)";
            SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection());
            cmd.Parameters.Add(new SqlParameter("@SelectedCustomer", selectedCustomer));
            cmd.Parameters.Add(new SqlParameter("@Name", txtProjectAddName.Text));
            cmd.Parameters.Add(new SqlParameter("@Deadline", dtProjectAddDeadline.Value));
            cmd.Parameters.Add(new SqlParameter("@Subject", txtProjectAddSubject.Text));
            cmd.Parameters.Add(new SqlParameter("@Value", nudProjectAddValue.Value));

            // Connection & Execute
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        private DataTable LoadCustomer(int customerID)
        {
            string sqlQueryCustomer = "SELECT * FROM tbl_Customers WHERE CUSTOMER_ID ='" + customerID + "'";
            SqlDataAdapter daCustomer = new SqlDataAdapter(sqlQueryCustomer, handler.GetConnection());
            DataSet dSetCustomer = new DataSet();
            daCustomer.Fill(dSetCustomer);
            DataTable DT = dSetCustomer.Tables[0];

            return DT;
        }
    }
}
