using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Barroc_IT
{
    public class DataTableHandler
    {
        DatabaseHandler handler;        
        //private int selectedProject = 0;
        //private int selectedCustomer = 0;
        public DataTableHandler()
        {
            this.handler = new DatabaseHandler();
        }

        public DataTableHandler(DatabaseHandler handler)
        {
            this.handler = handler;
        }

        // Customers
        public DataTable LoadCustomers()
        {
            string sqlQuery = "SELECT * FROM tbl_Customers";
            SqlDataAdapter DA = new SqlDataAdapter(sqlQuery, handler.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];
            return DT;
        }

        public DataTable LoadCustomers(int customerID)
        { 
            string sqlQueryCustomer = "SELECT * FROM tbl_Customers WHERE CUSTOMER_ID ='" + customerID + "'";
            SqlDataAdapter daCustomer = new SqlDataAdapter(sqlQueryCustomer, handler.GetConnection());
            DataSet dSetCustomer = new DataSet();
            daCustomer.Fill(dSetCustomer);
            DataTable DT = dSetCustomer.Tables[0];
            return DT;
        }

        // Projects
        public DataTable LoadProjects(int customerID)
        {
            string sqlQueryProjects = "SELECT * FROM tbl_Projects WHERE CUSTOMER_ID ='" + customerID + "'";
            SqlDataAdapter DA = new SqlDataAdapter(sqlQueryProjects, handler.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];
            return DT;
        }

        //public DataTable LoadProjectDetails(int customerID)
        //{
        //    string sqlQueryPro = "SELECT * FROM tbl_Projects WHERE CUSTOMER_ID ='" + customerID + "'";
        //    SqlDataAdapter daProject = new SqlDataAdapter(sqlQueryPro, handler.GetConnection());
        //    DataSet dsProject = new DataSet();

        //    daProject.Fill(dsProject);
        //    DataTable dtProject = dsProject.Tables[0];

        //    return dtProject;
        //}

        // Appointments
        public DataTable LoadAppointments(int customerID)
        {
            string sqlQuery = "SELECT * FROM tbl_Appointments WHERE CUSTOMER_ID ='" + customerID + "'";
            SqlDataAdapter DA = new SqlDataAdapter(sqlQuery, handler.GetConnection());
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
                case Choice.Company:
                    selectedChoice = "COMPANYNAME";
                    break;
                case Choice.Email:
                    selectedChoice = "EMAIL";
                    break;
                case Choice.Initials:
                    selectedChoice = "INITIALS";
                    break;
                default:
                    selectedChoice = "";
                    break;
            }

            string sqlQuery = "SELECT * FROM tbl_Customers WHERE " + selectedChoice + " LIKE '%" + searchString + "%'";
            SqlDataAdapter DA = new SqlDataAdapter(sqlQuery, handler.GetConnection());

            DataSet DS = new DataSet();
            DA.Fill(DS);

            DataTable DT = DS.Tables[0];
            return DT;
        }



    }
}
