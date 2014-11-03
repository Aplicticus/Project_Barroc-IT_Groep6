using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Barroc_IT
{
    public partial class frmLogin : Form
    {
        private DatabaseHandler handler;
        private DataTableHandler dthandler;
        private SqlQueryHandler sqlhandler;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            handler = new DatabaseHandler();
            dthandler = new DataTableHandler();
            sqlhandler = new SqlQueryHandler();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login(txtUsername.Text, txtPassword.Text);
        }

        public void Login(string username, string password)
        {
            string sqlQuery = "SELECT * FROM tbl_Users";
            string department = "";
            bool loggedIn = false;
            if ((username != null && username.Length > 0) && (password != null && password.Length > 0))
            {
                SqlDataAdapter dAdapter = new SqlDataAdapter(sqlQuery, handler.GetConnection());
                DataSet dSet = new DataSet();

                handler.OpenConnection();

                dAdapter.Fill(dSet);

                DataTable dTable = dSet.Tables[0];
                handler.CloseConnection();
                foreach (DataRow dRow in dTable.Rows)
                {
                    bool deactivated = Convert.ToBoolean(dRow["DEACTIVATED"].ToString());
                    if (username.ToLower() == dRow["USER_NAME"].ToString().ToLower() && 
                        password.ToLower() == dRow["PASSWORD"].ToString().ToLower() &&
                        deactivated == false)
                    {
                        loggedIn = true;
                        department = dRow["DEPARTMENT"].ToString().ToLower();
                        DateTime lastlogin = DateTime.Now;
                        int selectedUser = int.Parse(dRow["USER_ID"].ToString());
                        SetLastLogin(lastlogin, selectedUser, username);

                        switch (department)
                        {
                            case "administrator":
                                this.Hide();
                                frmAdmin formAdmin = new frmAdmin(handler, this, dthandler, sqlhandler);
                                formAdmin.Show();
                                break;
                            case "sales":
                                this.Hide();
                                frmSales formSales = new frmSales(handler, this, dthandler, sqlhandler);
                                formSales.Show();
                                break;
                            case "finance":
                                this.Hide();
                                frmFinance formFinance = new frmFinance(handler, this, dthandler, sqlhandler);
                                formFinance.Show();
                                break;
                            case "development":
                                this.Hide();
                                frmDevelopment formDevelopment = new frmDevelopment(handler, this, dthandler, sqlhandler);
                                formDevelopment.Show();
                                break;
                            default:
                                MessageBox.Show("Something went wrong, please try again!");
                                break;
                        }
                        break;
                    }
                }
            }

            if (!loggedIn)
            {
                MessageBox.Show("Incorrect username, password or a disabled useraccount!");
                ClearTextBoxes();
            }
        }

        private void SetLastLogin(DateTime lastlogin, int userID, string username)
        {
            string sql = sqlhandler.GetQuery(Query.updateLastLogin);
            SqlCommand cmd = new SqlCommand(sql, handler.GetConnection());
            cmd.Parameters.Add(new SqlParameter("Last_Login", lastlogin));
            cmd.Parameters.Add(new SqlParameter("userID", userID));
            cmd.Parameters.Add(new SqlParameter("User_Name", username));

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitProgram();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExitProgram();
        }

        private void ExitProgram()
        {
            Application.Exit();
        }

        private void txtLoginKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login(txtUsername.Text, txtPassword.Text);
            }
        }

        public void ClearTextBoxes()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Select();
        }
    }
}





