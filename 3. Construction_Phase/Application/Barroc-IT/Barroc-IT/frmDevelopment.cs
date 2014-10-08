using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Barroc_IT
{
    public partial class frmDevelopment : Form
    {
        private DatabaseHandler handler;
        public frmDevelopment(DatabaseHandler handler)
        {
            InitializeComponent();
            cBoxCustomerSearch.SelectedIndex = 0;
            this.handler = handler;           
        }

        private void btnDevSelectCustomer_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 1;
            DGVUserInfo.Rows.Clear();
            GetCustomerInfo(); 


        }
        private void GetCustomerInfo()
        {
            string sqlQuery = "SELECT * FROM tbl_Customers ";
            SqlDataAdapter DA = new SqlDataAdapter(sqlQuery, handler.GetConnection());
            DataSet DS = new DataSet();            
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];

            foreach (DataRow dr in DT.Rows)
            {
                DGVUserInfo.Rows.Add(dr.ItemArray);
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
        private void DGVUserInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

            if (e.ColumnIndex == DGVUserInfo.Columns["cViewButton"].Index)
            {
                tbContr.SelectedIndex = 2;
                string sqlQuery = "SELECT * FROM tbl_Customers";
                SqlDataAdapter DA = new SqlDataAdapter(sqlQuery, handler.GetConnection());
                DataSet DS = new DataSet();
                DA.Fill(DS);
                DataTable DT = DS.Tables[0];

                foreach (DataRow DR in DT.Rows)
                {
                    
                }
                

                
                //foreach (DataRow DR in DT.Rows)
                //{
                //    txtCompanyName.Text = DR["COMPANYNAME"].ToString();
                //    txtAddress1.Text = DR["ADDRESS1"].ToString();
                //    txtPostalCode1.Text = DR["POSTALCODE1"].ToString();
                //}
            }
        }

        private void btnViewProjects_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 3;
        }
    }
}
