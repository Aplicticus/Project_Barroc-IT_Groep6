using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Barroc_IT
{
    /// <summary>
    /// Class that handles all database connections
    /// </summary>
    public class DatabaseHandler
    {
        private SqlConnection conn;

        /// <summary>
        /// Default constructor, creates new connection and sets default connectionstring.
        /// </summary>
        public DatabaseHandler()
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Resources\BarrocIT.mdf;Integrated Security=True";
        }

        /// <summary>
        /// Customer constructor, creates new connection and sets connectionstring from parameter.
        /// </summary>
        /// <param name="connectionString">The custom connectionstring for the database.</param>
        public DatabaseHandler(string connectionString)
        {
            conn = new SqlConnection();
            conn.ConnectionString = connectionString;
        }

        /// <summary>
        /// Opens and closes connection. If something wrong show error.
        /// </summary>
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

        /// <summary>
        /// Opens connection to the database.
        /// </summary>
        public void OpenConnection()
        {
            conn.Open();
        }

        /// <summary>
        /// Closes connection to the database
        /// </summary>
        public void CloseConnection()
        {
            conn.Close();
        }

        /// <summary>
        /// Gets the current connection.
        /// </summary>
        /// <returns>Returns the current sqlconnection.</returns>
        public SqlConnection GetConnection()
        {
            return this.conn;
        }
    }
}
