using System.Data;
using System.Data.SqlClient;

namespace Barroc_IT
{
    public enum Choice
    {
        CompanyName = 0,
        Email = 1,
        Initials = 2,
        Deadline = 3,        
        Subject = 4,
        ProjectName = 5
    }
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
        public DataTable SqlQueryToDataTableAppointment(string sql, int customerID, int appointmentID)
        {
            SqlDataAdapter DA = new SqlDataAdapter(sql, handler.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];
            return DT;
        }



        // Search
        public DataTable SearchText(Choice choice, string searchString)
        {
            string selectedChoice = "";
            switch (choice)
            {
                case Choice.CompanyName:
                    selectedChoice = "COMPANYNAME";
                    break;
                case Choice.Email:
                    selectedChoice = "EMAIL";
                    break;
                case Choice.Initials:
                    selectedChoice = "INITIALS";
                    break;
                case Choice.Deadline:
                    selectedChoice = "DEADLINE";
                    break;
                case Choice.ProjectName:
                    selectedChoice = "NAME";
                    break;
                case Choice.Subject:
                    selectedChoice = "SUBJECT";
                    break;
                default:
                    selectedChoice = "";
                    break;
            }

            string sqlQuery = "SELECT tbl_Projects.PROJECT_ID, tbl_Customers.COMPANYNAME, tbl_Projects.NAME, tbl_Projects.DEADLINE, tbl_Projects.SUBJECT FROM tbl_Customers " +
            "FULL OUTER JOIN tbl_Projects ON tbl_Customers.CUSTOMER_ID=tbl_Projects.CUSTOMER_ID WHERE " + selectedChoice + " LIKE '%" + searchString + "%'";
            SqlDataAdapter DA = new SqlDataAdapter(sqlQuery, handler.GetConnection());

            DataSet DS = new DataSet();
            DA.Fill(DS);

            DataTable DT = DS.Tables[0];
            return DT;
        }
    }
}
