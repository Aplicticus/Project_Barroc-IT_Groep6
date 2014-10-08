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
        private void DGVUserInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           if (e.ColumnIndex == DGVUserInfo.Columns["cViewButton"].Index && e.RowIndex >= 0)
           {
               tbContr.SelectedIndex = 2;
           }

        }

        
        
    }
}
