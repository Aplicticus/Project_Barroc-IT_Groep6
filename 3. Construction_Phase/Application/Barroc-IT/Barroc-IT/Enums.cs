namespace Barroc_IT
{
    /// <summary>
    /// The enum for SearchChoice
    /// </summary>
    public enum SearchChoice
    {
        CompanyName,
        Email,
        Initials,
        ProjectName,
        ProjectSubject,
        AppointmentCompanyName,
        AppointmentSubject
    }

    public enum Query
    {
        copyCountInvoicesToBalance,

        addCustomer,
        addInvoice,
        addProject,
        addUser,

        loadCustomers,
        loadUsers,
        loadProjects,
        loadInvoices,
        loadAppointments,
        loadCustomerDetails,
        LoadDeactivatedUsers,
        loadProjectDetails,
        loadAppointmentDetails,
        loadInvoiceDetails,
        LoadActivatedUsers,

        countInvoices,
        countPaidInvoices,
        countOpenInvoices,
        countAllInvoices,
        countProjects,
        countValues,
        countAppointments,
        countOffers,        
        
        updateFinProjectInfo,
        updateDevCustomerInfo,
        updateDevAppointmentInfo,
        updateSalCustomerInfo,
        updateFinCustomersInfo,
        updateDevProjectInfo,
        updateLastLogin,
        updateFinPayment,
        updateAdmActivate,

        archiveProject
    }

}
