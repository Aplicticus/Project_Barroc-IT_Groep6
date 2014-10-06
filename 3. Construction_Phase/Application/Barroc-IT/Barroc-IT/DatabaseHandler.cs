using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barroc_IT
{
    public class DatabaseHandler
    {
        private SqlConnection conn;

        public DatabaseHandler()
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Resources\BarrocIT.mdf;Integrated Security=True";
        }
        public DatabaseHandler(string connectionString)
        {
            conn = new SqlConnection();
            conn.ConnectionString = connectionString;
        }
        public void TestConnection()
        {
            bool connOpen = false;

            try
            {
                OpenConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    connOpen = true;
                }
                CloseConnection();
            }

            if (!connOpen)
            {
                Application.Exit();
            }
        }

        public void OpenConnection()
        {
            conn.Open();
        }

        public void CloseConnection()
        {
            conn.Close();
        }

        public SqlConnection GetConnection()
        {
            return this.conn;
        }
    }
}
