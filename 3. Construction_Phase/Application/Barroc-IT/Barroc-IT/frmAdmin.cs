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
        private int selectedUser = 0;
        public frmAdmin(DatabaseHandler handler, frmLogin loginForm, DataTableHandler dthandler, SqlQueryHandler sqlhandler)
        {
            InitializeComponent();
            this.handler = handler;
            this.loginForm = loginForm;
            this.dthandler = dthandler;
            this.sqlhandler = sqlhandler;
            cBoxAddDepartment.SelectedIndex = 0;
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
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (AddUser() == true)
            {
                tbContr.SelectedIndex = 5;
                LoadUsers();
                MessageBox.Show("User succesfully added!");
            }
            else
            {
                MessageBox.Show("There is a problem with adding a User!");
            }   
        }
        private void btnDeactivatedBack_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 0;
        }
        private void btnUserInfoBack_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 0;
        }
        private void btnAddUserBack_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 0;
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
            cmd.Parameters.Add(new SqlParameter("@UserName", txtAddUserName.Text));
            cmd.Parameters.Add(new SqlParameter("@Password", txtAddPassword.Text));
            cmd.Parameters.Add(new SqlParameter("@Department", cBoxAddDepartment.SelectedItem.ToString()));
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

        // Cell Content Click
        private void dgvAdminUserInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvAdminUserInfo.Columns["cDeactivate"].Index)
            {
                selectedUser = int.Parse(dgvAdminUserInfo.Rows[e.RowIndex].Cells["cUserID"].Value.ToString());
                if (UpdateUser(selectedUser) == true)
                {                    
                    LoadUsers();
                    MessageBox.Show("User succesfully deactivated!");
                }
                else
                {
                    MessageBox.Show("There is a problem with deactivating a user!");
                }  
            }
        }

        private bool UpdateUser(int userID)
        {
            string loadDeactivated = sqlhandler.GetQuery(Query.loadUsers);
            DataTable DT = dthandler.ExecuteQuery(loadDeactivated);
            DataRow DR = DT.Rows[0];
            bool activateUser = Convert.ToBoolean(DR["DEACTIVATED"].ToString());
            if (activateUser == true)
            {
                activateUser = false;
            }
            else 
            {
                activateUser = true;
            }


            string sqlQuery = sqlhandler.GetQuery(Query.updateAdmActivate);
            SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection());            
            cmd.Parameters.Add(new SqlParameter("Deactivated", activateUser));
            cmd.Parameters.Add(new SqlParameter("userID", userID));
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
    }
}
