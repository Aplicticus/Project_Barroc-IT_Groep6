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
        //private int selectedProject;
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
                txtMaintenance.ReadOnly = false;
                txtOpenProject.ReadOnly = false;
                txtApplications.ReadOnly = false;
                txtHardware.ReadOnly = false;
                txtSoftware.ReadOnly = false;
                txtAppointments.ReadOnly = false;
                txtInternalContact.ReadOnly = false;
                btnEditFields.Text = "Save Changes";
            }
            else if(btnEditFields.Text == "Save Changes")
            {
                txtMaintenance.ReadOnly = true;
                txtOpenProject.ReadOnly = true;
                txtApplications.ReadOnly = true;
                txtHardware.ReadOnly = true;
                txtSoftware.ReadOnly = true;
                txtAppointments.ReadOnly = true;
                txtInternalContact.ReadOnly = true;
                btnEditFields.Text = "Edit Fields";
                //Svae changes needs to be implemented
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
            SqlDataAdapter DAPro = new SqlDataAdapter(sqlQueryPro, handler.GetConnection());
            DataSet DSPro = new DataSet();
            DAPro.Fill(DSPro);
            DataTable DTPro = DSPro.Tables[0];
            DataRow DRPro = DTPro.Rows[0];


            txtProjectCustomerID.Text = DRPro["CUSTOMER_ID"].ToString();
            txtProjectName.Text = DRPro["NAME"].ToString();
            txtProjectDeadline.Text = DRPro["DEADLINE"].ToString();
            txtProjectSubject.Text = DRPro["SUBJECT"].ToString();
            txtProjectValue.Text = DRPro["VALUE"].ToString();

                
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
                btnSubmitProject.Hide();
                tbContr.SelectedIndex = 4;
            }
        }

        private void btnEditProject_Click(object sender, EventArgs e)
        {
            txtProjectName.ReadOnly = false;
            txtProjectDeadline.ReadOnly = false;
            txtProjectSubject.ReadOnly = false;
            txtProjectValue.ReadOnly = false;

            btnSubmitProject.Show();
        }

        private void btnSubmitProject_Click(object sender, EventArgs e)
        {
            string sqlQuery = "UPDATE tbl_Projects SET NAME=@ProjectName, DEADLINE=@Deadline, SUBJECT=@Subject, VALUE=@Value WHERE PROJECT_ID=@SelectedProject";

            SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection());
            cmd.Parameters.Add(new SqlParameter("ProjectName", txtProjectName.Text));
            cmd.Parameters.Add(new SqlParameter("Deadline", txtProjectDeadline.Text));
            cmd.Parameters.Add(new SqlParameter("Subject", txtProjectSubject.Text));
            cmd.Parameters.Add(new SqlParameter("Value", txtProjectValue.Text));
            cmd.Parameters.Add(new SqlParameter("SelectedProject", selectedProject));

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
           
            LoadProjectDetails();
            tbContr.SelectedIndex = 4;
        }
    }
}
