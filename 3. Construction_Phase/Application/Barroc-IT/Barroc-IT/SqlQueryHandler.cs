using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barroc_IT
{
    public class SqlQueryHandler
    {        
        public SqlQueryHandler()
        {

        }

        // Read Querys
        public string GetQuery(string sqlQuery)
        {
            // Sql Querys
            string loadCustomers = "SELECT * FROM tbl_Customers";
            string loadUsers = "SELECT tbl_Users.USER_NAME, tbl_Users.DEPARTMENT FROM tbl_Users";

            // Array
            string[] sqlQueryStrings = { "" + loadCustomers + "", "" + loadUsers + "" };
                
            // Return Strings
            switch(sqlQuery)
            {
                case "loadCustomers":
                    return sqlQueryStrings[0].ToString();
                case "loadUsers":
                    return sqlQueryStrings[1].ToString();
            }
            return sqlQuery;
        }
        public string GetQuery(string sqlQuery, int customerID)
        {
            string loadCustomerDetails = "SELECT * FROM tbl_Customers WHERE CUSTOMER_ID='" + customerID + "'";

            string loadProjects = "SELECT tbl_Projects.PROJECT_ID, tbl_Customers.COMPANYNAME, tbl_Projects.NAME, tbl_Projects.DEADLINE, " +
            "tbl_Projects.SUBJECT, tbl_Projects.VALUE FROM tbl_Customers " +
            "FULL OUTER JOIN tbl_Projects ON tbl_Customers.CUSTOMER_ID=tbl_Projects.CUSTOMER_ID " +
            "WHERE tbl_Customers.CUSTOMER_ID='" + customerID + "'";

            string loadInvoices = "SELECT tbl_Invoices.INVOICE_ID, tbl_Customers.COMPANYNAME, " +
            "tbl_Projects.SUBJECT, tbl_Invoices.INVOICE_VALUE, tbl_Invoices.INVOICE_END_DATE, " +
            "tbl_Invoices.INVOICE_SEND FROM tbl_Customers " +
            "FULL OUTER JOIN tbl_Projects ON tbl_Customers.CUSTOMER_ID=tbl_Projects.CUSTOMER_ID " +
            "FULL OUTER JOIN tbl_Invoices ON tbl_Projects.PROJECT_ID=tbl_Invoices.PROJECT_ID " +
            "WHERE tbl_Projects.PROJECT_ID='" + customerID + "'";

            string loadAppointments = "SELECT * FROM tbl_Customers " +
            "FULL OUTER JOIN tbl_Appointments ON tbl_Customers.CUSTOMER_ID=tbl_Appointments.CUSTOMER_ID " +
            "WHERE tbl_Appointments.CUSTOMER_ID='" + customerID + "'";
            
            string countInvoices = "SELECT COUNT (INVOICE_ID) FROM tbl_Customers " +
            "FULL OUTER JOIN tbl_Projects ON tbl_Customers.CUSTOMER_ID=tbl_Projects.CUSTOMER_ID " +
            "FULL OUTER JOIN tbl_Invoices ON tbl_Projects.PROJECT_ID=tbl_Invoices.PROJECT_ID " +
            "WHERE tbl_Customers.CUSTOMER_ID='" + customerID + "'";

            string countSales = "SELECT SUM (INVOICE_VALUE) FROM tbl_Customers " +
            "FULL OUTER JOIN tbl_Projects ON tbl_Customers.CUSTOMER_ID=tbl_Projects.CUSTOMER_ID " +
            "FULL OUTER JOIN tbl_Invoices ON tbl_Projects.PROJECT_ID=tbl_Invoices.PROJECT_ID " +
            "WHERE tbl_Customers.CUSTOMER_ID='" + customerID + "'";

            string countProjects = "SELECT COUNT (PROJECT_ID) FROM tbl_Customers " +
            "FULL OUTER JOIN tbl_Projects ON tbl_Customers.CUSTOMER_ID=tbl_Projects.CUSTOMER_ID " +
            "WHERE tbl_Customers.CUSTOMER_ID='" + customerID + "'";

            string countValues = "SELECT SUM (INVOICE_VALUE) FROM tbl_Invoices " +
            "WHERE tbl_Invoices.PROJECT_ID='" + customerID + "'";


            string[] sqlQueryStrings = { "" + loadProjects + "", "" 
            + loadInvoices + "", "" + loadCustomerDetails + "", "" 
            + countInvoices + "", "" + countSales + "", "" 
            + countProjects + "", "" + countValues + "", "" 
            + loadAppointments + ""};

            switch(sqlQuery)
            {
                case "loadProjects":
                    return sqlQueryStrings[0].ToString();
                case "loadInvoices":
                    return sqlQueryStrings[1].ToString();
                case "loadCustomerDetails":
                    return sqlQueryStrings[2].ToString();
                case "countInvoices":
                    return sqlQueryStrings[3].ToString();
                case "countSales":
                    return sqlQueryStrings[4].ToString();
                case "countProjects":
                    return sqlQueryStrings[5].ToString();
                case "countValues":
                    return sqlQueryStrings[6].ToString();
                case "loadAppointments":
                    return sqlQueryStrings[7].ToString();
            }
            return sqlQuery;
        }
        public string GetQuery(string sqlQuery, int customerID, int projectID)
        {
            string loadProjectDetails = "SELECT * FROM tbl_Customers " +
            "FULL OUTER JOIN tbl_Projects ON tbl_Customers.CUSTOMER_ID=tbl_Projects.CUSTOMER_ID " +
            "WHERE tbl_Customers.CUSTOMER_ID='" + customerID + "' AND tbl_Projects.PROJECT_ID='" + projectID + "'";

             string[] sqlQueryStrings = {"" + loadProjectDetails  + ""};

             switch (sqlQuery)
             {
                 case "loadProjectDetails":
                     return sqlQueryStrings[0].ToString();
             }
             return sqlQuery;
        }
        public string GetQuery(string sqlQuery, int customerID, int projectID, int invoiceID)
        {
            string loadInvoiceDetails = "SELECT * FROM tbl_Customers " +
            "FULL OUTER JOIN tbl_Projects ON tbl_Customers.CUSTOMER_ID=tbl_Projects.CUSTOMER_ID " +
            "FULL OUTER JOIN tbl_Invoices ON tbl_Projects.PROJECT_ID=tbl_Invoices.PROJECT_ID " +
            "WHERE tbl_Customers.CUSTOMER_ID='" + customerID + "' AND tbl_Projects.PROJECT_ID='"
            + projectID + "' AND tbl_Invoices.INVOICE_ID ='" + invoiceID + "'";

            string[] sqlQueryStrings = { "" + loadInvoiceDetails + "" };

            switch (sqlQuery)
            {
                case "loadInvoiceDetails":
                    return sqlQueryStrings[0].ToString();
            }
            return sqlQuery;
        }

        // Insert Querys
        public string SetQuery(string sqlQuery)
        {
            string addInvoice = "INSERT INTO tbl_Invoices (PROJECT_ID, INVOICE_VALUE, INVOICE_END_DATE, INVOICE_SEND) " +
            "VALUES (@SelectedProject, @InvoiceVal, @InvoiceEndDate, @InvoiceSend)";
            string addProject = "INSERT INTO tbl_Projects (CUSTOMER_ID, NAME, DEADLINE, SUBJECT, VALUE) " +
            "VALUES (@SelectedCustomer, @Name, @Deadline, @Subject, @Value)";
            string addUser = "INSERT INTO tbl_Users (USER_NAME, PASSWORD, DEPARTMENT) " +
            "VALUES (@Username, @Password, @Department)";

            string[] sqlQueryStrings = { "" + addInvoice + "", ""+ addProject +"", ""+ addUser +""};

            switch(sqlQuery)
            {
                case "addInvoice":
                    return sqlQueryStrings[0].ToString();
                case "addProject":
                    return sqlQueryStrings[1].ToString();
                case "addUser":
                    return sqlQueryStrings[2].ToString();
            }
            return sqlQuery;
        }

        // Update Querys
        public string UpdateQuery(string sqlQuery)
        {
            string updateFinCustomersInfo = "UPDATE tbl_Customers SET ACC_ID=@AccountID, BALANCE=@Balance, " +
            "LIMIT=@Limit, LEDGER_ID=@LedgerID, BTW_CODE=@BTWcode, BKR=@Bkr WHERE CUSTOMER_ID=@CustomerID";

            string[] sqlQueryStrings = { "" + updateFinCustomersInfo + ""};

            switch(sqlQuery)
            {
                case "updateFinCustomersInfo":
                    return sqlQueryStrings[0].ToString();                
            }
            return sqlQuery;            
        }
        public string UpdateQuery(string sqlQuery, int customerID)
        {
            string updateFinProjectInfo = "SELECT tbl_Projects.PROJECT_ID, tbl_Customers.COMPANYNAME, tbl_Projects.NAME, tbl_Projects.DEADLINE, " +
            "tbl_Projects.SUBJECT FROM tbl_Customers " +
            "FULL OUTER JOIN tbl_Projects ON tbl_Customers.CUSTOMER_ID=tbl_Projects.CUSTOMER_ID " +
            "WHERE tbl_Customers.CUSTOMER_ID='" + customerID + "'";
            string updateDevCustomerInfo = "UPDATE tbl_Customers SET MAINT_CONTR=@MaintenanceContract, " +
            "OPEN_PROJ=@OpenProjects, HARDWARE=@Hardware, SOFTWARE=@Software WHERE CUSTOMER_ID=@customerID";
            string updateDevAppointmentInfo = "UPDATE tbl_Appointments SET INT_CONTACT=@InternalContact " +
            "WHERE CUSTOMER_ID=@customerID";

            string[] sqlQueryStrings = { "" + updateFinProjectInfo + "", "" + updateDevCustomerInfo + "", "" + updateDevAppointmentInfo + "" };

            switch (sqlQuery)
            {
                case "updateFinProjectInfo":
                    return sqlQueryStrings[0].ToString();
                case "updateDevCustomerInfo":
                    return sqlQueryStrings[1].ToString();
                case "updateDevAppointmentInfo":
                    return sqlQueryStrings[2].ToString();
            }
            return sqlQuery;
        }

        public string UpdateQueryProject(string sqlQuery, int projectID)
        {
            string updateDevProjectInfo = "UPDATE tbl_Projects SET NAME=@ProjectName, DEADLINE=@Deadline, " +
           "SUBJECT=@Subject, VALUE=@Value WHERE PROJECT_ID=@ProjectID";

            string[] sqlQueryStrings = { "" + updateDevProjectInfo + ""};

            switch (sqlQuery)
            {
                case "updateDevProjectInfo":
                    return sqlQueryStrings[0].ToString();
            }
            return sqlQuery;
        }
    }
}
