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
    class DatabaseHandler
    {
        private static SqlConnection conn;

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
            try
            {
                conn.Open();
                MessageBox.Show("conn opE1!");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
