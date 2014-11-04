using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Barroc_IT
{
    public class DataTableHandler
    {
        private DatabaseHandler handler;        

        public DataTableHandler()
        {
            handler = new DatabaseHandler();
        }

        public DataTableHandler(DatabaseHandler handler)
        {
            this.handler = handler;
        }

        /// <summary>
        /// Executes a sql query.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>A DataTable result from the executed query.</returns>
        public DataTable ExecuteQuery(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, handler.GetConnection());
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];
            return DT;
        }

        /// <summary>
        /// Executes a sql query with parameters.
        /// </summary>
        /// <param name="sql">The query to execute.</param>
        /// <param name="parameters">The parameters to add into the query.</param>
        /// <returns>A DataTable result from the executed query.</returns>
        public DataTable ExecuteQuery(string sql, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(sql, handler.GetConnection());
            foreach (SqlParameter parameter in parameters)
            {
                cmd.Parameters.Add(parameter);
            }

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];
            return DT;
        }

        public void AddItemsToDataGridView(DataTable table, DataGridView dataGridView, string idColumnName)
        {
            dataGridView.Rows.Clear();
            table.Columns.Add(idColumnName);
            table.Columns[idColumnName].SetOrdinal(0);

            foreach (DataRow dr in table.Rows)
            {
                dataGridView.Rows.Add(dr.ItemArray);
            }
        }


        /// <summary>
        /// Searches for a SearchChoice in the database.
        /// The table is automatticly determined by the SearchChoice.
        /// </summary>
        /// <param name="choice">The UserSelected Choice to search for.</param>
        /// <param name="searchString">The text to search for.</param>
        /// <param name="customerID">The customer id.</param>
        /// <returns><The DataTable result from the search./returns>
        public DataTable SearchText(SearchChoice choice, string searchString, int customerID)
        {
            bool customer = false;
            bool project = false;
            bool appointment = false;
            string selectedChoice = "";

            switch (choice)
            {
                case SearchChoice.CompanyName:
                    selectedChoice = "COMPANYNAME";
                    customer = true;
                    break;
                case SearchChoice.Email:
                    selectedChoice = "EMAIL";
                    customer = true;
                    break;
                case SearchChoice.Initials:
                    selectedChoice = "INITIALS";
                    customer = true;
                    break;
                case SearchChoice.ProjectName:
                    selectedChoice = "NAME";
                    project = true;
                    customer = false;
                    break;
                case SearchChoice.ProjectSubject:
                    selectedChoice = "SUBJECT";
                    project = true;
                    customer = false;
                    break;
                case SearchChoice.AppointmentCompanyName:
                    selectedChoice = "tbl_Customers.COMPANYNAME";
                    project = false;
                    customer = false;
                    appointment = true;
                    break;
                case SearchChoice.AppointmentSubject:
                    selectedChoice = "SUBJECT";
                    project = false;
                    customer = false;
                    appointment = true;
                    break;
                default:
                    customer = true;
                    selectedChoice = "";
                    break;

            }

            string sqlQuery = "";

            SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection());

            if (customer)
            {
                sqlQuery = "SELECT * FROM tbl_Customers WHERE {0} LIKE @searchString";
                sqlQuery = string.Format(sqlQuery, selectedChoice);

                cmd.CommandText = sqlQuery;
                cmd.Parameters.AddWithValue("searchString", "%" + searchString + "%");
            }
            else if(project)
            {
                sqlQuery = "SELECT tbl_Projects.PROJECT_ID, tbl_Customers.COMPANYNAME, tbl_Projects.NAME, tbl_Projects.DEADLINE, " +
            "tbl_Projects.SUBJECT, tbl_Projects.VALUE FROM tbl_Customers " +
            "FULL OUTER JOIN tbl_Projects ON tbl_Customers.CUSTOMER_ID=tbl_Projects.CUSTOMER_ID " +
            "WHERE tbl_Customers.CUSTOMER_ID = @customerID AND {0} LIKE @searchString";
                sqlQuery = string.Format(sqlQuery, "tbl_Projects." + selectedChoice);

                cmd.CommandText = sqlQuery;
                cmd.Parameters.AddWithValue("customerID", customerID);
                cmd.Parameters.AddWithValue("searchString", "%" + searchString + "%");
            }
            else if (appointment)
            {
                sqlQuery = "SELECT tbl_Appointments.APPOINTMENT_ID, tbl_Customers.COMPANYNAME, tbl_Appointments.APPOIN_DATE, tbl_Appointments.SUBJECT, tbl_Appointments.INT_CONTACT FROM tbl_Customers {0}WHERE tbl_Customers.CUSTOMER_ID = @customerID AND {1} LIKE @searchString";
                sqlQuery = string.Format(sqlQuery, "FULL OUTER JOIN tbl_Appointments ON tbl_Customers.CUSTOMER_ID=tbl_Appointments.CUSTOMER_ID ", selectedChoice);

                cmd.CommandText = sqlQuery;
                cmd.Parameters.AddWithValue("customerID", customerID);
                cmd.Parameters.AddWithValue("searchString", "%" + searchString + "%");
            }

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];
            return DT;
        }
    }
}
