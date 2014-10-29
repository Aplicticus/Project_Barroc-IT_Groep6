using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Barroc_IT
{
    public partial class frmAdmin : Form
    {

        private DatabaseHandler handler;
        private DataTableHandler dthandler;
        private SqlQueryHandler sqlhandler;
        private frmLogin loginForm;
        private bool closing = false;
        public frmAdmin(DatabaseHandler handler, frmLogin loginForm, DataTableHandler dthandler, SqlQueryHandler sqlhandler)
        {
            InitializeComponent();
            this.handler = handler;
            this.loginForm = loginForm;
            this.dthandler = dthandler;
            this.sqlhandler = sqlhandler;
            cBoxAdminDepartment.SelectedIndex = 0;
        }
        
        // Click events
        private void btnRegister_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 1;
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 0;
        }
        private void btnUserInfo_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 2;
            LoadUsers(); 
        }
        private void btnDeactivatedUsers_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 3;
            DGVDeactivatedUsers.ReadOnly = true;
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult confirmationLogout = MessageBox.Show("Are you sure you want to log out?", "Confirm log out", MessageBoxButtons.YesNo);
            if (confirmationLogout == DialogResult.Yes)
            {
                CloseToLogin();
            }            
        }
        private void btnAdminConfirmRegister_Click(object sender, EventArgs e)
        {
            if (AddUser() == true)
            {                
                tbContr.SelectedIndex = 2;
                LoadUsers();
                MessageBox.Show("User succesfully added!");
            }
            else
            {
                MessageBox.Show("There is a problem with adding a User!");
            }             
        }

        // Loads
        private void LoadUsers()
        {
            dgvAdminUserInfo.Rows.Clear();

            string selectUsers = sqlhandler.GetQuery(Query.loadUsers);
            DataTable customers = dthandler.ExecuteQuery(selectUsers);
            AddItemsToDataGridView(customers, dgvAdminUserInfo, "cUserID");
        }

        // Methods
        private bool AddUser()
        {
            string sql = sqlhandler.GetQuery(Query.addUser);
            SqlCommand cmd = new SqlCommand(sql, handler.GetConnection());
            cmd.Parameters.Add(new SqlParameter("@UserName", txtAdminUsername.Text));
            cmd.Parameters.Add(new SqlParameter("@Password", txtAdminPassword.Text));
            cmd.Parameters.Add(new SqlParameter("@Department", cBoxAdminDepartment.SelectedItem.ToString()));
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

        // Go to Login
        private void CloseToLogin()
        {
            closing = true;
            loginForm.ClearTextBoxes();
            loginForm.Show();
            this.Close();
        }

        // Form Closing
        private void frmAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closing)
            {
                CloseToLogin();
            }
        }        
    }
}
