using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Barroc_IT
{
    public partial class frmSales : Form
    {
        private DatabaseHandler handler;
        private frmLogin loginForm;

        private int selectedCustomer = 0;
        private bool closing = false;
        public frmSales(DatabaseHandler handler, frmLogin loginForm)
        {
            InitializeComponent();
            this.handler = handler;
            this.loginForm = loginForm;
        }

        private void btnSalesSelectCustomer_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 1;
        }

        private void frmSales_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closing)
            {
                CloseToLogin();
                closing = true;
            }
        }

        private void CloseToLogin()
        {
            closing = true;
            loginForm.ClearTextBoxes();
            loginForm.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            CloseToLogin();
        }

        private void dgvUserInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvUserInfo.Columns["cViewButton"].Index)
            {
                selectedCustomer = int.Parse(dgvUserInfo.Rows[e.RowIndex].Cells["cViewButton"].Value.ToString());
                //LoadCustomerDetails();
                //LoadAppointmentDetails();
                tbContr.SelectedIndex = 2;
            }
        }

        private void btnSalesAddCustomer_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 6;
        }

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
        #endregion

        private void btnBack_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = tbContr.SelectedIndex - 1;
        }
    }
}
