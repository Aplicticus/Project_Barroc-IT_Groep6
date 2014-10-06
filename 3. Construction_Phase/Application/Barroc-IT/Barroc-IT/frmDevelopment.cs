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
        }

        private void tbContr_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlQuery = "SELECT * FROM tbl_Customers";
            if (tbContr.SelectedIndex == 1)
            {
                SqlDataAdapter dAdapter = new SqlDataAdapter(sqlQuery, handler.GetConnection());
                DataSet dSet = new DataSet();

                handler.OpenConnection();
                dAdapter.Fill(dSet);
                handler.CloseConnection();

                DataTable dTable = dSet.Tables[0];
                DGVUserInfo.DataSource = dTable;
            }
        }
    }
}
