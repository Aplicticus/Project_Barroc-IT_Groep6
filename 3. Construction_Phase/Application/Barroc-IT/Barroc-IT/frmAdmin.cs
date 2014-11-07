using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Barroc_IT
{
    public partial class frmAdmin : Form
    {
        #region Properties
        private DatabaseHandler handler;
        private DataTableHandler dthandler;
        private SqlQueryHandler sqlhandler;
        private frmLogin loginForm;
        private bool closing = false;
        private int selectedUser;
        private bool selectedDeactivated = false;
        #endregion

        #region Constructor
        public frmAdmin(DatabaseHandler handler, frmLogin loginForm, DataTableHandler dthandler, SqlQueryHandler sqlhandler)
        {
            InitializeComponent();
            this.handler = handler;
            this.loginForm = loginForm;
            this.dthandler = dthandler;
            this.sqlhandler = sqlhandler;
            cBoxAddDepartment.SelectedIndex = 0;
        }
        #endregion

        #region Click Events
        // Button Click Events
        private void btnAdminAddUser_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 1;
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 0;
        }
        private void btnUserInformation_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 2;
            dgvUsers.ReadOnly = true;
            LoadUsers();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult confirmationLogout = MessageBox.Show("Are you sure you want to log out?", "Confirm log out", MessageBoxButtons.YesNo);
            if (confirmationLogout == DialogResult.Yes)
            {
                CloseToLogin();
            }
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string password = txtAddPassword.Text;
            if (txtAddUserName.Text.Length > 0)
            {
                if (txtAddPassword.Text.Length > 0 && txtAddRepeatPassword.Text == password.ToString())
                {
                    if (AddUser() == true)
                    {
                        tbContr.SelectedIndex = 4;
                        LoadUsers();
                        MessageBox.Show("User succesfully added!");
                    }
                    else
                    {
                        MessageBox.Show("There is a problem with creating a User!");
                    }
                }
                else
                {
                    MessageBox.Show("Your password field is empty or your password is not equal to Repeat Password!");
                }
            }
            else
            {
                MessageBox.Show("The username field is empty!, Please fill a username to create a user!");
            }
            txtAddUserName.Clear();
            txtAddPassword.Clear();
            txtAddRepeatPassword.Clear();
            cBoxAddDepartment.ResetText();
        }
        private void btnBackToHome_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 0;
        }
        // Cell Content Clicks
        private void dgvAdminUserInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvUsers.Columns["cActivateDeactivate"].Index)
            {
                if (e.RowIndex >= 0)
                {
                    if (dgvUsers.Rows[e.RowIndex].Cells["cDepartment"].Value.ToString() == "Administrator")
                    {
                        MessageBox.Show("This user can't be disabled for security reasons.");
                    }
                    else
                    {
                        selectedUser = int.Parse(dgvUsers.Rows[e.RowIndex].Cells["cUserID"].Value.ToString());
                        selectedDeactivated = bool.Parse(dgvUsers.Rows[e.RowIndex].Cells["cDeactivated"].Value.ToString());
                        if (UpdateUser(selectedUser, selectedDeactivated) == true)
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
            }
        }
        #endregion

        #region Loaders
        private void LoadUsers()
        {
            dgvUsers.Rows.Clear();
            string selectUsers = sqlhandler.GetQuery(Query.loadUsers);
            DataTable allUsers = dthandler.ExecuteQuery(selectUsers);
            dthandler.AddItemsToDataGridView(allUsers, dgvUsers, "cUserID");
        }
        #endregion

        #region Methods
        private bool AddUser()
        {
            string sql = sqlhandler.GetQuery(Query.addUser);
            SqlCommand cmd = new SqlCommand(sql, handler.GetConnection());
            cmd.Parameters.Add(new SqlParameter("@UserName", txtAddUserName.Text));
            cmd.Parameters.Add(new SqlParameter("@Password", txtAddPassword.Text));
            cmd.Parameters.Add(new SqlParameter("@Department", cBoxAddDepartment.SelectedItem.ToString()));
            cmd.Parameters.Add(new SqlParameter("@Deactivated", true));
            cmd.Parameters.Add(new SqlParameter("@Last_Login", DateTime.Now));
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

        private bool SetCustomerVisible(int selectedCustomer)
        {
            string sql = sqlhandler.GetQuery(Query.setCustomerArchived);

            SqlCommand cmd = new SqlCommand(sql, handler.GetConnection());
            cmd.Parameters.Add(new SqlParameter("Archived", false));
            cmd.Parameters.Add(new SqlParameter("customerID", selectedCustomer));
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

        private void LoadArchiveCustomers()
        {
            string sql = sqlhandler.GetQuery(Query.selectArchivedCustomers);
            DataTable archivedCustomers = dthandler.ExecuteQuery(sql);
            dthandler.AddItemsToDataGridView(archivedCustomers, dgvArchivedCustomers, "cCustomerID");
        }
        #endregion

        #region Updaters / Editers
        private bool UpdateUser(int userID, bool deactivated)
        {
            deactivated = !deactivated;
            string sqlQuery = sqlhandler.GetQuery(Query.updateAdmActivate);
            SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection());
            cmd.Parameters.Add(new SqlParameter("Deactivated", deactivated));
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
        #endregion

        #region GoToLogin
        private void CloseToLogin()
        {
            closing = true;
            loginForm.ClearTextBoxes();
            loginForm.Show();
            loginForm.CenterScreen();
            this.Close();
        }
        #endregion

        #region Form Closing
        private void frmAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closing)
            {
                CloseToLogin();
            }
        }
        #endregion

        private void dgvArchivedCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvArchivedCustomers.Columns["cMakeVisible"].Index)
            {
                if (e.RowIndex >= 0)
                {
                    int selectedCustomer = int.Parse(dgvArchivedCustomers.Rows[e.RowIndex].Cells["cCustomerID"].Value.ToString());
                    if (SetCustomerVisible(selectedCustomer))
                    {
                        LoadArchiveCustomers();
                        MessageBox.Show("Customer maked visible!");
                    }
                    else
                    {
                        MessageBox.Show("There is a problem with making the customer visible!");
                    }
                }
            }
        }

        private void btnArchivedCustomers_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 3;
            LoadArchiveCustomers();
        }
    }
}
