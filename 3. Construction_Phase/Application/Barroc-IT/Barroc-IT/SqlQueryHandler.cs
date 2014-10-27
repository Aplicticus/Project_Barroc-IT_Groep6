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

        public string GetQuery(string sqlQuery)
        {
            string query = "";
            // Select querys
            string loadCustomers = "SELECT * FROM tbl_Customers";
            string loadUsers = "SELECT tbl_Users.USER_NAME, tbl_Users.DEPARTMENT FROM tbl_Users";

            //Insert querys
            string addInvoice = "INSERT INTO tbl_Invoices (PROJECT_ID, INVOICE_VALUE, INVOICE_END_DATE, INVOICE_SEND) " +
            "VALUES (@SelectedProject, @InvoiceVal, @InvoiceEndDate, @InvoiceSend)";
            string addProject = "INSERT INTO tbl_Projects (CUSTOMER_ID, NAME, DEADLINE, SUBJECT, VALUE) " +
            "VALUES (@SelectedCustomer, @Name, @Deadline, @Subject, @Value)";
            string addUser = "INSERT INTO tbl_Users (USER_NAME, PASSWORD, DEPARTMENT) " +
            "VALUES (@Username, @Password, @Department)";

            //update querys
            string updateFinCustomersInfo = "UPDATE tbl_Customers SET ACC_ID=@AccountID, BALANCE=@Balance, " +
            "LIMIT=@Limit, LEDGER_ID=@LedgerID, BTW_CODE=@BTWcode, BKR=@Bkr WHERE CUSTOMER_ID=@CustomerID";
            string updateDevProjectInfo = "UPDATE tbl_Projects SET NAME=@ProjectName, DEADLINE=@Deadline, " +
           "SUBJECT=@Subject, VALUE=@Value WHERE PROJECT_ID=@ProjectID";

            switch (sqlQuery)
            {
                case "loadCustomers":
                    query = loadCustomers;
                    break;
                case "loadUsers":
                    query = loadUsers;
                    break;
                case "addInvoice":
                    query = addInvoice;
                    break;
                case "addProject":
                    query = addProject;
                    break;
                case "addUser":
                    query = addUser;
                    break;
                case "updateFinCustomersInfo":
                    query = updateFinCustomersInfo;
                    break;
                case "updateDevProjectInfo":
                    query = updateDevProjectInfo;
                    break;
                default:
                    query = "";
                    break;
            }

            return query;
        }
        public string GetQuery(string sqlQuery, int customerID)
        {
            string query = "";


            //Select querys
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

            string updateFinProjectInfo = "SELECT tbl_Projects.PROJECT_ID, tbl_Customers.COMPANYNAME, tbl_Projects.NAME, tbl_Projects.DEADLINE, " +
            "tbl_Projects.SUBJECT FROM tbl_Customers " +
            "FULL OUTER JOIN tbl_Projects ON tbl_Customers.CUSTOMER_ID=tbl_Projects.CUSTOMER_ID " +
            "WHERE tbl_Customers.CUSTOMER_ID='" + customerID + "'";

            //Update querys
            string updateDevCustomerInfo = "UPDATE tbl_Customers SET MAINT_CONTR=@MaintenanceContract, " +
            "OPEN_PROJ=@OpenProjects, HARDWARE=@Hardware, SOFTWARE=@Software WHERE CUSTOMER_ID=@customerID";

            string updateDevAppointmentInfo = "UPDATE tbl_Appointments SET INT_CONTACT=@InternalContact " +
            "WHERE CUSTOMER_ID=@customerID";

            switch (sqlQuery)
            {
                case "loadProjects":
                    query = loadProjects;
                    break;
                case "loadInvoices":
                    query = loadInvoices;
                    break;
                case "loadCustomerDetails":
                    query = loadCustomerDetails;
                    break;
                case "countInvoices":
                    query = countInvoices;
                    break;
                case "countSales":
                    query = countSales;
                    break;
                case "countProjects":
                    query = countProjects;
                    break;
                case "countValues":
                    query = countValues;
                    break;
                case "loadAppointments":
                    query = loadAppointments;
                    break;
                case "updateFinProjectInfo":
                    query = updateFinProjectInfo;
                    break;
                case "updateDevCustomerInfo":
                    query = updateDevCustomerInfo;
                    break;
                case "updateDevAppointmentInfo":
                    query = updateDevAppointmentInfo;
                    break;
                default:
                    query = "";
                    break;
            }

            return query;
        }
        public string GetQuery(string sqlQuery, int customerID, int projectID)
        {
            string query = "";

            string loadProjectDetails = "SELECT * FROM tbl_Customers " +
            "FULL OUTER JOIN tbl_Projects ON tbl_Customers.CUSTOMER_ID=tbl_Projects.CUSTOMER_ID " +
            "WHERE tbl_Customers.CUSTOMER_ID='" + customerID + "' AND tbl_Projects.PROJECT_ID='" + projectID + "'";

            switch (sqlQuery)
            {
                case "loadProjectDetails":
                    query = loadProjectDetails;
                    break;
                default:
                    query = "";
                    break;
            }

            return query;
        }
        public string GetQuery(string sqlQuery, int customerID, int projectID, int invoiceID)
        {
            string query = "";

            string loadInvoiceDetails = "SELECT * FROM tbl_Customers " +
            "FULL OUTER JOIN tbl_Projects ON tbl_Customers.CUSTOMER_ID=tbl_Projects.CUSTOMER_ID " +
            "FULL OUTER JOIN tbl_Invoices ON tbl_Projects.PROJECT_ID=tbl_Invoices.PROJECT_ID " +
            "WHERE tbl_Customers.CUSTOMER_ID='" + customerID + "' AND tbl_Projects.PROJECT_ID='"
            + projectID + "' AND tbl_Invoices.INVOICE_ID ='" + invoiceID + "'";

            switch (sqlQuery)
            {
                case "loadInvoiceDetails":
                    query = loadInvoiceDetails;
                    break;
                default:
                    query = "";
                    break;
            }

            return query;
        }

    }
}
