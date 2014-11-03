namespace Barroc_IT
{
    /// <summary>
    /// Class for getting the correct query.
    /// </summary>
    public class SqlQueryHandler
    {
        /// <summary>
        /// The default constructor
        /// </summary>
        public SqlQueryHandler()
        {

        }
        // Default OuterJoins
        string OuterJoinProCus =
        "FULL OUTER JOIN tbl_Projects ON tbl_Customers.CUSTOMER_ID=tbl_Projects.CUSTOMER_ID ";
        string OuterJoinInvPro =
        "FULL OUTER JOIN tbl_Invoices ON tbl_Projects.PROJECT_ID=tbl_Invoices.PROJECT_ID ";
        string OuterJoinApoCus =
        "FULL OUTER JOIN tbl_Appointments ON tbl_Customers.CUSTOMER_ID=tbl_Appointments.CUSTOMER_ID ";

        // Load Querys
        string loadCustomers = "SELECT * FROM tbl_Customers";
        string loadUsers = "SELECT tbl_Users.USER_NAME, tbl_Users.DEPARTMENT, tbl_Users.DEACTIVATED, tbl_Users.LAST_LOGIN FROM tbl_Users";
        string LoadDeactivatedUsers = "SELECT tbl_Users.USER_ID, tbl_Users.USER_NAME, tbl_Users.DEPARTMENT, tbl_Users.DEACTIVATED, tbl_Users.LAST_LOGIN FROM tbl_Users WHERE tbl_Users.DEACTIVATED='true'";
        string LoadActivatedUsers = "SELECT tbl_Users.USER_ID, tbl_Users.USER_NAME, tbl_Users.DEPARTMENT, tbl_Users.DEACTIVATED, tbl_Users.LAST_LOGIN FROM tbl_Users WHERE tbl_Users.DEACTIVATED='false'";
        string loadInvoiceDetails = "SELECT * FROM tbl_Customers {0}{1}WHERE tbl_Customers.CUSTOMER_ID=@customerID AND tbl_Projects.PROJECT_ID=@projectID AND tbl_Invoices.INVOICE_ID = @invoiceID";
        string loadProjectDetails = "SELECT * FROM tbl_Customers {0}WHERE tbl_Customers.CUSTOMER_ID=@customerID AND tbl_Projects.PROJECT_ID=@projectID";
        string loadAppointmentDetails = "SELECT * FROM tbl_Customers {0}WHERE tbl_Customers.CUSTOMER_ID=@customerID AND tbl_Appointments.APPOINTMENT_ID=@appointmentID";
        string loadCustomerDetails = "SELECT * FROM tbl_Customers WHERE CUSTOMER_ID=@customerID";
        string loadProjects = "SELECT tbl_Projects.PROJECT_ID, tbl_Customers.COMPANYNAME, tbl_Projects.NAME, tbl_Projects.DEADLINE, " +
        "tbl_Projects.SUBJECT, tbl_Projects.VALUE FROM tbl_Customers {0}WHERE tbl_Customers.CUSTOMER_ID=@customerID";
        string loadInvoices = "SELECT tbl_Invoices.INVOICE_ID, tbl_Customers.COMPANYNAME, " +
        "tbl_Projects.NAME, tbl_Invoices.INVOICE_VALUE, tbl_Invoices.INVOICE_END_DATE, " +
        "tbl_Invoices.INVOICE_SEND FROM tbl_Customers {0}{1}WHERE tbl_Projects.PROJECT_ID=@projectID";
        string loadAppointments = "SELECT tbl_Appointments.APPOINTMENT_ID, tbl_Customers.COMPANYNAME, tbl_Appointments.APPOIN_DATE, tbl_Appointments.SUBJECT, tbl_Appointments.INT_CONTACT FROM tbl_Customers {0}WHERE tbl_Appointments.CUSTOMER_ID=@customerID";

        //Insert querys
        string addInvoice = "INSERT INTO tbl_Invoices (PROJECT_ID, INVOICE_VALUE, INVOICE_END_DATE, INVOICE_SEND) " +
        "VALUES (@SelectedProject, @InvoiceVal, @InvoiceEndDate, @InvoiceSend)";
        string addProject = "INSERT INTO tbl_Projects (CUSTOMER_ID, NAME, DEADLINE, SUBJECT, VALUE) " +
        "VALUES (@SelectedCustomer, @Name, @Deadline, @Subject, @Value)";
        string addUser = "INSERT INTO tbl_Users (USER_NAME, PASSWORD, DEPARTMENT) " +
        "VALUES (@Username, @Password, @Department)";
        string addCustomer = "INSERT INTO tbl_Customers (COMPANYNAME, ADDRESS1, POSTALCODE1, RESIDENCE1, ADDRESS2, " +
        "POSTALCODE2, RESIDENCE2, CONTACTPERSON, INITIALS, PHONE_NR1, PHONE_NR2, FAXNUMBER, EMAIL, PROSPECT) " +
        "VALUES (@CompanyName, @Address1, @PostalCode1, @Residence1, @Address2, @PostalCode2, @Residence2, @ContactPerson, " +
        "@Initials, @PhoneNr1, @PhoneNr2, @FaxNumber, @Email, @Prospect)";
        
        // Count Querys
        string countInvoices = "SELECT COUNT (INVOICE_ID) FROM tbl_Customers {0}{1}WHERE tbl_Customers.CUSTOMER_ID=@customerID AND tbl_Projects.PROJECT_ID=@projectID";
        string countSales = "SELECT SUM (INVOICE_VALUE) FROM tbl_Customers {0}{1}WHERE tbl_Customers.CUSTOMER_ID=@customerID";
        string countProjects = "SELECT COUNT (PROJECT_ID) FROM tbl_Customers {0}WHERE tbl_Customers.CUSTOMER_ID=@customerID";
        string countValues = "SELECT SUM (INVOICE_VALUE) FROM tbl_Invoices WHERE tbl_Invoices.PROJECT_ID=@customerID";
        string countAppointments = "SELECT COUNT (APPOINTMENT_ID) FROM tbl_Customers {0} WHERE tbl_Customers.CUSTOMER_ID=@customerID";
        string countOffers = "SELECT COUNT (OFFER_NUMBERS) FROM tbl_Customers WHERE tbl_Customers.CUSTOMER_ID=@customerID";

        //Update Querys        
        string updateFinCustomersInfo = "UPDATE tbl_Customers SET ACC_ID=@AccountID, BALANCE=@Balance, " +
        "LIMIT=@Limit, LEDGER_ID=@LedgerID, BTW_CODE=@BTWcode, BKR=@Bkr WHERE CUSTOMER_ID=@customerID";
        string updateFinProjectInfo = "SELECT tbl_Projects.PROJECT_ID, tbl_Customers.COMPANYNAME, tbl_Projects.NAME, " +
        "tbl_Projects.DEADLINE, tbl_Projects.SUBJECT FROM tbl_Customers {0}WHERE tbl_Customers.CUSTOMER_ID=@customerID";
        string updateDevCustomerInfo = "UPDATE tbl_Customers SET MAINT_CONTR=@MaintenanceContract, " +
        "OPEN_PROJ=@OpenProjects, HARDWARE=@Hardware, SOFTWARE=@Software WHERE CUSTOMER_ID=@customerID";
        string updateDevProjectInfo = "UPDATE tbl_Projects SET NAME=@ProjectName, DEADLINE=@Deadline, " +
        "SUBJECT=@Subject, VALUE=@Value WHERE PROJECT_ID=@ProjectID";
        string updateDevAppointmentInfo = "UPDATE tbl_Appointments SET INT_CONTACT=@InternalContact " +
        "WHERE CUSTOMER_ID=@customerID";
        string updateSalCustomerInfo = "UPDATE tbl_Customers SET COMPANYNAME=@CompanyName, ADDRESS1=@Address1, " +
        "POSTALCODE1=@PostalCode1, RESIDENCE1=@Residence1, PHONE_NR1=@PhoneNumber1, ADDRESS2=@Address2, " +
        "POSTALCODE2=@PostalCode2, RESIDENCE2=@Residence2, PHONE_NR2=@PhoneNumber2, CONTACTPERSON=@ContactPerson, " +
        "INITIALS=@Initials, OFFER_STAT=@OfferStatus, FAXNUMBER=@FaxNumber, EMAIL=@Email, PROSPECT=@Prospect, " +
        "DATE_OF_ACTION=@DateOfAction, LAST_CONTACT_DATE=@LastContactDate, NEXT_ACTION=@NextAction " +
        "WHERE CUSTOMER_ID=@customerID";
        string updateAdmActivate = "UPDATE tbl_Users SET DEACTIVATED=@Deactivated WHERE USER_ID=@userID";
        string updateLastLogin = "UPDATE tbl_Users SET LAST_LOGIN=@Last_Login WHERE USER_ID=@userID AND USER_NAME=@User_Name";
       
        public string GetQuery(Query query)
        {
            // Default
            string sqlQuery = "";
            switch (query)
            {
                case Query.loadCustomers:
                    sqlQuery = loadCustomers;
                    break;
                case Query.loadUsers:
                    sqlQuery = loadUsers;
                    break;
                case Query.loadProjects:
                    sqlQuery = loadProjects;
                    sqlQuery = string.Format(sqlQuery, OuterJoinProCus);
                    break;
                case Query.loadInvoices:
                    sqlQuery = loadInvoices;
                    sqlQuery = string.Format(sqlQuery, OuterJoinProCus, OuterJoinInvPro);
                    break;
                case Query.loadCustomerDetails:
                    sqlQuery = loadCustomerDetails;
                    break;
                case Query.loadAppointmentDetails:
                    sqlQuery = loadAppointmentDetails;
                    sqlQuery = string.Format(sqlQuery, OuterJoinApoCus);
                    break;
                case Query.loadAppointments:
                    sqlQuery = loadAppointments;
                    sqlQuery = string.Format(sqlQuery, OuterJoinApoCus);
                    break;
                case Query.loadProjectDetails:
                    sqlQuery = loadProjectDetails;
                    sqlQuery = string.Format(sqlQuery, OuterJoinProCus);
                    break;
                case Query.loadInvoiceDetails:
                    sqlQuery = loadInvoiceDetails;
                    sqlQuery = string.Format(sqlQuery, OuterJoinProCus, OuterJoinInvPro);
                    break;
                case Query.LoadDeactivatedUsers:
                    sqlQuery = LoadDeactivatedUsers;
                    break;
                case Query.LoadActivatedUsers:
                    sqlQuery = LoadActivatedUsers;
                    break;

                case Query.addCustomer:
                    sqlQuery = addCustomer;
                    break;
                case Query.addInvoice:
                    sqlQuery = addInvoice;
                    break;
                case Query.addProject:
                    sqlQuery = addProject;
                    break;
                case Query.addUser:
                    sqlQuery = addUser;
                    break;

                case Query.updateFinCustomersInfo:
                    sqlQuery = updateFinCustomersInfo;
                    break;
                case Query.updateDevProjectInfo:
                    sqlQuery = updateDevProjectInfo;
                    break;
                case Query.updateSalCustomerInfo:
                    sqlQuery = updateSalCustomerInfo;
                    break;
                case Query.updateFinProjectInfo:
                    sqlQuery = updateFinProjectInfo;
                    sqlQuery = string.Format(sqlQuery, OuterJoinProCus);
                    break;
                case Query.updateDevCustomerInfo:
                    sqlQuery = updateDevCustomerInfo;
                    break;
                case Query.updateDevAppointmentInfo:
                    sqlQuery = updateDevAppointmentInfo;
                    break;
                case Query.updateAdmActivate:
                    sqlQuery = updateAdmActivate;
                    break;
                case Query.updateLastLogin:
                    sqlQuery = updateLastLogin;
                    break;

                case Query.countSales:
                    sqlQuery = countSales;
                    sqlQuery = string.Format(sqlQuery, OuterJoinProCus, OuterJoinInvPro);
                    break;
                case Query.countProjects:
                    sqlQuery = countProjects;
                    sqlQuery = string.Format(sqlQuery, OuterJoinProCus);
                    break;
                case Query.countValues:
                    sqlQuery = countValues;
                    break;
                case Query.countAppointments:
                    sqlQuery = countAppointments;
                    sqlQuery = string.Format(sqlQuery, OuterJoinApoCus);
                    break;
                case Query.countOffers:
                    sqlQuery = countOffers;
                    break;
                case Query.countInvoices:
                    sqlQuery = countInvoices;
                    sqlQuery = string.Format(sqlQuery, OuterJoinProCus, OuterJoinInvPro);
                    break;

                default:
                    sqlQuery = "";
                    break;
            }
            return sqlQuery;
        }
    }
}

