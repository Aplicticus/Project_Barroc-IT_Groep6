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
            cBoxSearch.SelectedIndex = 0;
            this.handler = handler;           
        }

        private void btnDevSelectCustomer_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 1;
            DGVUserInfo.Rows.Clear();
            GetCustomerInfo();    
        }

        private void tbContr_SelectedIndexChanged(object sender, EventArgs e)
        {
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

            foreach (DataRow DR in DT.Rows)
            {
                DGVUserInfo.Rows.Add(DR["Customer_ID"].ToString(), DR["COMPANYNAME"].ToString(), DR["ADDRESS1"].ToString(), DR["POSTALCODE1"].ToString(),
                DR["RESIDENCE1"].ToString(), DR["ADDRESS2"].ToString(), DR["POSTALCODE2"].ToString(), DR["RESIDENCE2"].ToString(),DR["CONTACTPERSON"].ToString(),DR["INITIALS"].ToString(),
                DR["PHONE_NR1"].ToString(),  DR["PHONE_NR2"].ToString(),DR["FAXNUMBER"].ToString(),DR["EMAIL"].ToString(),DR["DATE_OF_ACTION"].ToString(),DR["LAST_CONTACT_DATE"].ToString(),DR["NEXT_ACTION"].ToString(),DR["OFFER_NUMBERS"].ToString(),
                    
                    );
            }
            

            //     DGV.Rows.Add(DR["CustomerID"].ToString(), DR["CompanyName"].ToString(),
                //DR["ContactName"].ToString(), DR["ContactTitle"].ToString(),
                //DR["Address"].ToString(), DR["City"].ToString(), DR["Region"].ToString(),
                //DR["PostalCode"].ToString(), DR["Country"].ToString(),
                //DR["Phone"].ToString(), DR["Fax"].ToString());

        }
    }
}
