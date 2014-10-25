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
            string loadCustomers = "SELECT * FROM tbl_Customers";
            
            
            string[] sqlQueryStrings = { ""+ loadCustomers +""};
                       
            switch(sqlQuery)
            {
                case "loadCustomers":
                    return sqlQueryStrings[0].ToString();                    
                case "selectProject":
                    return sqlQueryStrings[1].ToString();   
                //case "":
                //    return sqlQueryStrings[2].ToString();
            }
            return sqlQuery;
        }

        public string GetQuery(string sqlQuery, int customerID)
        {
            string loadProjects = "SELECT tbl_Projects.PROJECT_ID, tbl_Customers.COMPANYNAME, tbl_Projects.NAME, tbl_Projects.DEADLINE, " +
            "tbl_Projects.SUBJECT FROM tbl_Customers " +
            "FULL OUTER JOIN tbl_Projects ON tbl_Customers.CUSTOMER_ID=tbl_Projects.CUSTOMER_ID " +
            "WHERE tbl_Customers.CUSTOMER_ID='" + customerID + "'";

            string loadInvoices = "SELECT tbl_Invoices.INVOICE_ID, tbl_Customers.COMPANYNAME, " +
            "tbl_Projects.SUBJECT, tbl_Invoices.INVOICE_VALUE, tbl_Invoices.INVOICE_END_DATE, " +
            "tbl_Invoices.INVOICE_SEND FROM tbl_Customers " +
            "FULL OUTER JOIN tbl_Projects ON tbl_Customers.CUSTOMER_ID=tbl_Projects.CUSTOMER_ID " +
            "FULL OUTER JOIN tbl_Invoices ON tbl_Projects.PROJECT_ID=tbl_Invoices.PROJECT_ID " +
            "WHERE tbl_Projects.PROJECT_ID='" + customerID + "'";



            string[] sqlQueryStrings = { ""+ loadProjects +"", "" + loadInvoices + ""};

            switch(sqlQuery)
            {
                case "loadProjects":
                    return sqlQueryStrings[0].ToString();
                case "loadInvoices":
                    return sqlQueryStrings[1].ToString();
            }
            return sqlQuery;
        }
    }
}
