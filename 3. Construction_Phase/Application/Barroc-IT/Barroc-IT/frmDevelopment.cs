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
            string sqlQuery = "SELECT * FROM tbl_Projects WHERE CUSTOMER_ID ='" + selectedCustomer + "'";
            SqlDataAdapter DA = new SqlDataAdapter(sqlQuery, handler.GetConnection());
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
            else if(btnEditFields.Text == "Save Changes")
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
            string sqlQueryCus = "SELECT * FROM tbl_Customers WHERE CUSTOMER_ID='" + selectedCustomer + "'";
            SqlDataAdapter DACus = new SqlDataAdapter(sqlQueryCus, handler.GetConnection());
            DataSet DSCus = new DataSet();
            DACus.Fill(DSCus);
            DataTable DTCus = DSCus.Tables[0];
            DataRow DRCus = DTCus.Rows[0];


            txtCompanyName.Text = DRCus["COMPANYNAME"].ToString();
            txtAddress1.Text = DRCus["ADDRESS1"].ToString();
            txtPostalCode1.Text = DRCus["POSTALCODE1"].ToString();
            txtPhoneNumber1.Text = DRCus["PHONE_NR1"].ToString();
            txtFaxNumber.Text = DRCus["FAXNUMBER"].ToString();
            txtEmail.Text = DRCus["EMAIL"].ToString();
            txtContactPerson.Text = DRCus["CONTACTPERSON"].ToString();
            txtMaintenance.Text = DRCus["MAINT_CONTR"].ToString();
            txtOpenProject.Text = DRCus["OPEN_PROJ"].ToString();
            txtHardware.Text = DRCus["HARDWARE"].ToString();
            txtSoftware.Text = DRCus["SOFTWARE"].ToString();
        }

       /* private void LoadAppointmentDetails()
        {
            string sqlQueryApo = "SELECT * FROM tbl_Appointments";

            SqlDataAdapter DAApo = new SqlDataAdapter(sqlQueryApo, handler.GetConnection());
            DataSet DSApo = new DataSet();
            DAApo.Fill(DSApo);
            DataTable DTApo = DSApo.Tables[0];
            DataRow DRApo = DTApo.Rows[0];

            txtAppointments.Text = DRApo["APPOIN_DATE"].ToString();
            txtInternalContact.Text = DRApo["INT_CONTACT"].ToString();
        }*/

        private void LoadProjectDetails()
        {
            string sqlQueryPro = "SELECT * FROM tbl_Projects WHERE PROJECT_ID ='" + selectedProject + "'";
            SqlDataAdapter daProject = new SqlDataAdapter(sqlQueryPro, handler.GetConnection());
            DataSet dsProject = new DataSet();
            daProject.Fill(dsProject);
            DataTable dtProject = dsProject.Tables[0];
            DataRow drProject = dtProject.Rows[0];

            DateTime projectDeadline = new DateTime();
            projectDeadline = DateTime.Parse(drProject["DEADLINE"].ToString());

            txtProjectCustomerID.Text = drProject["CUSTOMER_ID"].ToString();
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
                //LoadAppointmentDetails();                

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
            this.Hide();
            frmLogin formLogin = new frmLogin();
            formLogin.Show();
        }
    }
}
