using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barroc_IT
{
    
    public partial class frmLogin : Form
    {
        private DatabaseHandler handler;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            handler = new DatabaseHandler();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login(txtUsername.Text, txtPassword.Text);
        }

        public void Login(string username, string password)
        {
            if ((username != null && username.Length > 0) && (password != null && password.Length > 0))
            {
                string sqlQuery = "SELECT COUNT(*) FROM tbl_Users WHERE USER_NAME=@Username AND PASSWORD=@Password";

                handler.OpenConnection();
                using (SqlCommand command = new SqlCommand(sqlQuery, handler.GetConnection()))
                {
                    //Add username and password to parameters
                    command.Parameters.Add(new SqlParameter("Username", username));
                    command.Parameters.Add(new SqlParameter("Password", password));


                    //Get count of rows
                    Int32 count = (Int32)command.ExecuteScalar();
                    if (count == 1)
                    {
                        this.Hide();
                        frmAdmin formAdmin = new frmAdmin();
                        formAdmin.Show();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect username or password!");
                    }
                }
                handler.CloseConnection();
            }
        }
    }
}
