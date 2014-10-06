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
            LoadDepartments();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void LoadDepartments()
        {
            cbDepartment.Items.Add("Sales");
            cbDepartment.Items.Add("Finance");
            cbDepartment.Items.Add("Development");
            cbDepartment.Items.Add("Administrator");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            handler = new DatabaseHandler();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string selectedDepartment = cbDepartment.SelectedItem.ToString();
            Login(txtUsername.Text, txtPassword.Text, selectedDepartment);            
        }

        public void Login(string username, string password, string department)
        {
            if ((username != null && username.Length > 0) && (password != null && password.Length > 0) && (department != null))
            {
                string sqlQuery = "SELECT * FROM tbl_Users";


                    SqlDataAdapter DA = new SqlDataAdapter(sqlQuery, handler.GetConnection());                    
                    DataSet DS = new DataSet();
                    DA.Fill(DS);

                    DataTable DT = DS.Tables[0];
                    
                    foreach (DataRow DR in DT.Rows)
                    {

                        if (username == DR["USER_NAME"].ToString() && password == DR["PASSWORD"].ToString() && department == DR["DEPARTMENT"].ToString())
                        {
                            switch (department)
                            {
                                case "Administrator":
                                    this.Hide();
                                    frmAdmin formAdmin = new frmAdmin();
                                    formAdmin.Show();
                                    break;

                                case "Sales":
                                    this.Hide();
                                    frmSales formSales = new frmSales();
                                    formSales.Show();
                                    break;

                                //case "Finance":
                                //    this.Hide();
                                //    frmFinance = new frmFinance();
                                //    formFinance.Show();
                                //    break;

                                case "Development":
                                    this.Hide();
                                    frmDevelopment formDevelopment = new frmDevelopment();
                                    formDevelopment.Show();
                                    break;
                            }

                        }
                       
                }
                 
            }
            else
            {
                MessageBox.Show("Incorrect username, password or department!");
            }
            handler.CloseConnection();
        }
    }
}
    




