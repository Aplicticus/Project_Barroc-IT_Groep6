using System.Data;
using System.Data.SqlClient;

namespace Barroc_IT
{
    public class DataTableHandler
    {
        DatabaseHandler handler; 
        public DataTableHandler()
        {
            handler = new DatabaseHandler();            
        }
        public DataTableHandler(DatabaseHandler handler)
        {            
            this.handler = handler;
        }

        // DataTables
        public DataTable SqlQueryToDataTable(string sql)
        {
            SqlDataAdapter DA = new SqlDataAdapter(sql, handler.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];
            return DT;
        }
        public DataTable SqlQueryToDataTable(string sql, int customerID)
        {
            SqlDataAdapter DA = new SqlDataAdapter(sql, handler.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];
            return DT;
        }      
        public DataTable SqlQueryToDataTable(string sql, int customerID, int projectID)
        {
            SqlDataAdapter DA = new SqlDataAdapter(sql, handler.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];
            return DT;
        }
        public DataTable SqlQueryToDataTable(string sql, int customerID, int projectID, int invoiceID)
        {
            SqlDataAdapter DA = new SqlDataAdapter(sql, handler.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];
            return DT;
        }
        
        public DataTable SqlQueryToDataTableProject(string sql, int projectID)
        {
            SqlDataAdapter DA = new SqlDataAdapter(sql, handler.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];
            return DT;
        }
        public DataTable SqlQueryToDataTableAppointment(string sql, int customerID)
        {
            SqlDataAdapter DA = new SqlDataAdapter(sql, handler.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];
            return DT;
        }

        // Search
        public DataTable SearchText(SearchChoice choice, string searchString, int customerID, bool customer)
        {
            string selectedChoice = "";
            switch (choice)
            {
                case SearchChoice.CompanyName:
                    selectedChoice = "COMPANYNAME";
                    break;
                case SearchChoice.Email:
                    selectedChoice = "EMAIL";
                    break;
                case SearchChoice.Initials:
                    selectedChoice = "INITIALS";
                    break;
                default:
                    selectedChoice = "";
                    break;
            }

            string sqlQuery = "";

            if (customer)
            {
                sqlQuery = "SELECT * FROM tbl_Customers WHERE " + selectedChoice + " LIKE '%" + searchString + "%'";
            }
            else
            {
                SqlQueryHandler queryHandler = new SqlQueryHandler();
                sqlQuery = queryHandler.GetQuery("loadProjectsSearch", customerID, choice, searchString);
            }

            SqlDataAdapter DA = new SqlDataAdapter(sqlQuery, handler.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];
            return DT;
        }
    }
}
