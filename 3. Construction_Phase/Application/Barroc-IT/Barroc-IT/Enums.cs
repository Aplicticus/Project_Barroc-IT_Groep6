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

        countSales,
        countProjects,
        countValues,
        countAppointments,
        countOffers,
        countInvoices,
        
        updateFinProjectInfo,
        updateDevCustomerInfo,
        updateDevAppointmentInfo,
        updateSalCustomerInfo,
        updateFinCustomersInfo,
        updateDevProjectInfo,
        updateLastLogin,
        updateAdmActivate
    }

}
