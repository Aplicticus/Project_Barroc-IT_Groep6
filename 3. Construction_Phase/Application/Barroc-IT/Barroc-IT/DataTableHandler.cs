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
        private int selectedCustomer;
        public DataTableHandler()
        {
            handler = new DatabaseHandler();
            selectedCustomer = 0;
        }

        public DataTableHandler(DatabaseHandler handler, int selectedCustomer)
        {
            this.selectedCustomer = selectedCustomer;
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
            string sqlQuery = "SELECT tbl_Projects.PROJECT_ID, tbl_Customers.COMPANYNAME, tbl_Projects.NAME, tbl_Projects.DEADLINE, " +
            "tbl_Projects.SUBJECT, tbl_Projects.VALUE FROM tbl_Customers " +
            "FULL OUTER JOIN tbl_Projects ON tbl_Customers.CUSTOMER_ID=tbl_Projects.CUSTOMER_ID " +
            "WHERE tbl_Customers.CUSTOMER_ID='"+ customerID +"'";
                 
            
            SqlDataAdapter DA = new SqlDataAdapter(sqlQuery, handler.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];
            return DT;
        }

        public DataTable CountSales(int customerID)
        {
            // Column in DB VALUE of tbl_Projects != the count of Invoice_Value from tbl_Invoices
            string sql = "SELECT SUM (INVOICE_VALUE) FROM tbl_Customers " +
            "FULL OUTER JOIN tbl_Projects ON tbl_Customers.CUSTOMER_ID=tbl_Projects.CUSTOMER_ID " +
            "FULL OUTER JOIN tbl_Invoices ON tbl_Projects.PROJECT_ID=tbl_Invoices.PROJECT_ID " +
            "WHERE tbl_Customers.CUSTOMER_ID='" + customerID + "'";
            SqlDataAdapter DA = new SqlDataAdapter(sql, handler.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];
            return DT;
        }

        // Invoices
        public DataTable CountInvoices(int customerID)
        {
            string sql = "SELECT COUNT (INVOICE_ID) FROM tbl_Customers " +
            "FULL OUTER JOIN tbl_Projects ON tbl_Customers.CUSTOMER_ID=tbl_Projects.CUSTOMER_ID " +
            "FULL OUTER JOIN tbl_Invoices ON tbl_Projects.PROJECT_ID=tbl_Invoices.PROJECT_ID " +
            "WHERE tbl_Customers.CUSTOMER_ID='" + customerID + "'";
            SqlDataAdapter DA = new SqlDataAdapter(sql, handler.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];
            return DT;
        }

        public DataTable LoadInvoices(int projectID)
        {
            string sqlQuery = "SELECT tbl_Invoices.INVOICE_ID, tbl_Customers.COMPANYNAME, " +            
            "tbl_Projects.SUBJECT, tbl_Invoices.INVOICE_VALUE, tbl_Invoices.INVOICE_END_DATE, " +
            "tbl_Invoices.INVOICE_SEND FROM tbl_Customers " +
            "FULL OUTER JOIN tbl_Projects ON tbl_Customers.CUSTOMER_ID=tbl_Projects.CUSTOMER_ID " +
            "FULL OUTER JOIN tbl_Invoices ON tbl_Projects.PROJECT_ID=tbl_Invoices.PROJECT_ID " +
            "WHERE tbl_Projects.PROJECT_ID='" + projectID + "'";
            SqlDataAdapter DA = new SqlDataAdapter(sqlQuery, handler.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];
            return DT;
        }
        public DataTable LoadInvoiceDetails(int customerID, int projectID, int invoiceID)
        {
            string sql = "SELECT * FROM tbl_Customers " +            
            "FULL OUTER JOIN tbl_Projects ON tbl_Customers.CUSTOMER_ID=tbl_Projects.CUSTOMER_ID " +            
            "FULL OUTER JOIN tbl_Invoices ON tbl_Projects.PROJECT_ID=tbl_Invoices.PROJECT_ID " +
            "WHERE tbl_Customers.CUSTOMER_ID='" + customerID + "' AND tbl_Projects.PROJECT_ID='" + projectID + "' AND tbl_Invoices.INVOICE_ID ='" + invoiceID + "'";
            SqlDataAdapter DA = new SqlDataAdapter(sql, handler.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];
            return DT;
        }
        public DataTable LoadProjectDetails(int customerID, int projectID)
        {
            string sqlQueryProjects = "SELECT * FROM tbl_Customers " + 
            "FULL OUTER JOIN tbl_Projects ON tbl_Customers.CUSTOMER_ID=tbl_Projects.CUSTOMER_ID " +
            "WHERE tbl_Customers.CUSTOMER_ID='" + customerID + "' AND tbl_Projects.PROJECT_ID='" + projectID + "'";
            SqlDataAdapter DA = new SqlDataAdapter(sqlQueryProjects, handler.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable DT = DS.Tables[0];
            return DT;
        }
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
        public DataTable LoadAppointmentDetails(int appointmentID, int customerID)
        {
            string sqlQuery = "SELECT * FROM tbl_Appointments WHERE APPOINTMENT_ID ='" + appointmentID + "' AND CUSTOMER_ID='" + customerID + "'";
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
