using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Barroc_IT
{
    public partial class frmSales : Form
    {
        #region Properties
        private DatabaseHandler handler;
        private frmLogin loginForm;
        private SqlQueryHandler sqlhandler;
        private DataTableHandler dthandler;
        private int selectedCustomer;
        private int selectedAppointment;
        private bool closing = false;
        #endregion

        #region Constructor
        public frmSales(DatabaseHandler handler, frmLogin loginForm, DataTableHandler dthandler, SqlQueryHandler sqlhandler)
        {
            InitializeComponent();
            cBoxAppointmentSearch.SelectedIndex = 0;
            cBoxCustomerSearch.SelectedIndex = 0;

            this.handler = handler;
            this.loginForm = loginForm;
            this.dthandler = dthandler;
            this.sqlhandler = sqlhandler;
        }
        #endregion
        
        #region Click Events
        private void btnSalesSelectCustomer_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 1;
            LoadCustomers();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = tbContr.SelectedIndex - 1;
        }
        private void btnSalesHome_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 0;
        }
        private void btnSalesAddCustomer_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 6;
            txtCusAddCompanyName.Clear();
            txtCusAddInitials.Clear();
            txtCusAddContactperson.Clear();
            txtCusAddAddress1.Clear();
            txtCusAddPostalCode1.Clear();
            txtCusAddResidence1.Clear();
            txtCusAddPhoneNumber1.Clear();
            txtCusAddFaxNumber.Clear();
            txtCusAddEmail.Clear();

            txtCusAddAddress2.Clear();
            txtCusAddPostalCode2.Clear();
            txtCusResidence2.Clear();
            txtCusAddPhoneNumber2.Clear();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult confirmationLogout = MessageBox.Show("Are you sure you want to log out?", "Confirm log out", MessageBoxButtons.YesNo);
            if (confirmationLogout == DialogResult.Yes)
            {
                CloseToLogin();
            }
        }
        private void btnViewAppointments_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 3;
            LoadAppointments();
        }
        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            txtApoAddCompanyName.Text = txtCusCompanyName.Text;
            txtApoAddInternalContact.Clear();
            txtApoAddSubject.Clear();
            tbContr.SelectedIndex = 5;
        }
        private void btnAppointmentAdd_Click(object sender, EventArgs e)
        {
            if (txtApoAddInternalContact.TextLength > 0)
            {
                if (txtApoAddSubject.TextLength > 0)
                {
                    if (addAppointment())
                    {
                        MessageBox.Show("Appointment succesfully added.");
                        ReloadCustomers();
                        int temp = 0;
                        if (txtCusAppointment.Text != temp.ToString())
                        {
                            btnViewAppointment.Enabled = true;
                        }
                        else
                        {
                            btnViewAppointment.Enabled = false;
                        }
                        tbContr.SelectedIndex = 2;
                    }
                    else
                    {
                        MessageBox.Show("The appointment could not be added, please try again.");
                    }
                }
                else
                {
                    MessageBox.Show("Please check the subject.");
                }
            }
            else
            {
                MessageBox.Show("Please check the internal contact person.");
            }
        }
        private void btnAddInvoiceCancel_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 2;
        }
        private void btnAddCustomerCancel_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 0;
        }
        private void btnCusAddCustomer_Click(object sender, EventArgs e)
        {
            bool everythingCorrect = true;

            TextBox[] firstTextBoxes = { txtCusAddCompanyName, txtCusAddInitials, txtCusAddContactperson, txtCusAddAddress1, txtCusAddResidence1, txtCusAddEmail };
            if (!CheckTextBoxes(firstTextBoxes))
            {
                MessageBox.Show("Please check all the neccesary fields.");
            }
            else
            {
                if (txtCusAddPhoneNumber1.MaskFull)
                {
                    if (CheckPostalCode(txtCusAddPostalCode1))
                    {
                        if (CheckEmail(txtCusAddEmail))
                        {
                            string phoneNumber2Text = txtCusAddPhoneNumber2.Text.Replace(" ", "");
                            if (phoneNumber2Text.Length > 2)
                            {
                                if (txtCusAddPhoneNumber2.MaskFull)
                                {
                                    string faxNumberText = txtCusAddFaxNumber.Text.Replace(" ", "");
                                    if (faxNumberText.Length > 2)
                                    {
                                        if (txtCusAddFaxNumber.MaskFull)
                                        {
                                            if (txtCusAddPostalCode2.TextLength > 0)
                                            {
                                                if (!CheckPostalCode(txtCusAddPostalCode2))
                                                {
                                                    everythingCorrect = false;
                                                    MessageBox.Show("Please check the second postal code.");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            everythingCorrect = false;
                                            MessageBox.Show("Please check the fax number.");
                                        }
                                    }
                                }
                                else
                                {
                                    everythingCorrect = false;
                                    MessageBox.Show("Please check the second phone number.");
                                }
                            }
                        }
                        else
                        {
                            everythingCorrect = false;
                            MessageBox.Show("Please check the email address.");
                        }

                        if (everythingCorrect)
                        {
                            if (addCustomer())
                            {
                                MessageBox.Show("Customer succesfully added.");
                                tbContr.SelectedIndex = 1;
                                dgvCustomers.Rows.Clear();
                                LoadCustomers();
                            }
                            else
                            {
                                MessageBox.Show("The customer could not be added, please try again!");
                            }
                        }
                    }
                    else
                    {
                        everythingCorrect = false;
                        MessageBox.Show("Please check the first postal code.");
                    }
                }
                else
                {
                    everythingCorrect = false;
                    MessageBox.Show("Please check the first phone number.");
                }
            }
        }
        private void btnEditCustomerFields_Click(object sender, EventArgs e)
        {
            if (btnEditCustomerFields.Text == "Edit Fields")
            {
                txtCusCompanyName.ReadOnly = false;
                txtCusNumberOfOffers.ReadOnly = true;

                txtCusAddress1.ReadOnly = false;
                txtCusPostalCode1.ReadOnly = false;
                txtCusResidence1.ReadOnly = false;
                txtCusPhoneNumber1.ReadOnly = false;

                txtCusAddress2.ReadOnly = false;
                txtCusPostalCode2.ReadOnly = false;
                txtCusResidence2.ReadOnly = false;
                txtCusPhoneNumber2.ReadOnly = false;

                txtCusInitials.ReadOnly = false;
                txtCusFaxNumber.ReadOnly = false;
                cboxOfferStatus.Enabled = true;
                txtCusEmail.ReadOnly = false;
                dtpCusSalesDateOfAction.Enabled = true;
                txtCusContactPerson.ReadOnly = false;
                dtpCusSalesLastContactDate.Enabled = true;
                txtCusAppointment.ReadOnly = true;
                dtpCusSalesNextAction.Enabled = true;
                cBoxCusProspect.Enabled = true;
                nudCusSalePercentage.Enabled = false;
                btnEditCustomerFields.Text = "Save Changes";
                DisableAllButtons();
            }
            else if (btnEditCustomerFields.Text == "Save Changes")
            {
                bool everythingCorrect = true;

                TextBox[] firstTextBoxes = { txtCusCompanyName, txtCusInitials, txtCusContactPerson, txtCusAddress1, txtCusResidence1, txtCusEmail };
                if (!CheckTextBoxes(firstTextBoxes))
                {
                    MessageBox.Show("Please check all the neccesary fields.");
                }
                else
                {
                    if (txtCusPhoneNumber1.MaskFull)
                    {
                        if (CheckPostalCode(txtCusPostalCode1))
                        {
                            if (CheckEmail(txtCusEmail))
                            {
                                string phoneNumber2Text = txtCusPhoneNumber2.Text.Replace(" ", "");
                                if (phoneNumber2Text.Length > 2)
                                {
                                    if (txtCusPhoneNumber2.MaskFull)
                                    {
                                        string faxNumberText = txtCusFaxNumber.Text.Replace(" ", "");
                                        if (faxNumberText.Length > 2)
                                        {
                                            if (txtCusFaxNumber.MaskFull)
                                            {
                                                if (txtCusPostalCode2.TextLength > 0)
                                                {
                                                    if (!CheckPostalCode(txtCusPostalCode2))
                                                    {
                                                        everythingCorrect = false;
                                                        MessageBox.Show("Please check the second postal code.");
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                everythingCorrect = false;
                                                MessageBox.Show("Please check the fax number.");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        everythingCorrect = false;
                                        MessageBox.Show("Please check the second phone number.");
                                    }
                                }
                            }
                            else
                            {
                                everythingCorrect = false;
                                MessageBox.Show("Please check the email address.");
                            }

                            if (everythingCorrect)
                            {
                                if (UpdateCustomer(selectedCustomer) == true)
                                {
                                    MessageBox.Show("Customer succesfully modified!");
                                    ReloadCustomers();
                                    tbContr.SelectedIndex = 2;

                                    txtCusCompanyName.ReadOnly = true;
                                    txtCusNumberOfOffers.ReadOnly = true;

                                    txtCusAddress1.ReadOnly = true;
                                    txtCusPostalCode1.ReadOnly = true;
                                    txtCusResidence1.ReadOnly = true;
                                    txtCusPhoneNumber1.ReadOnly = true;

                                    txtCusAddress2.ReadOnly = true;
                                    txtCusPostalCode2.ReadOnly = true;
                                    txtCusResidence2.ReadOnly = true;
                                    txtCusPhoneNumber2.ReadOnly = true;

                                    txtCusInitials.ReadOnly = true;
                                    txtCusFaxNumber.ReadOnly = true;
                                    cboxOfferStatus.Enabled = false;
                                    txtCusEmail.ReadOnly = true;
                                    dtpCusSalesDateOfAction.Enabled = false;
                                    txtCusContactPerson.ReadOnly = true;
                                    dtpCusSalesLastContactDate.Enabled = false;
                                    txtCusAppointment.ReadOnly = true;
                                    dtpCusSalesNextAction.Enabled = false;
                                    cBoxCusProspect.Enabled = false;
                                    nudCusSalePercentage.Enabled = false;
                                    btnEditCustomerFields.Text = "Edit Fields";
                                    EnableAllButtons();
                                }
                                else
                                {
                                    MessageBox.Show("There is a problem with modifying the customer, please try again.");
                                }
                            }
                        }
                        else
                        {
                            everythingCorrect = false;
                            MessageBox.Show("Please check the first postal code.");
                        }
                    }
                    else
                    {
                        everythingCorrect = false;
                        MessageBox.Show("Please check the first phone number.");
                    }
                }

                

            }
        }
        private void btnAppointmentSearch_Click(object sender, EventArgs e)
        {
            if (txtAppointmentSearch.Text.Length > 0)
            {
                SearchChoice selectedItem;
                switch (cBoxAppointmentSearch.SelectedItem.ToString())
                {
                    case "Company Name":
                        selectedItem = SearchChoice.AppointmentCompanyName;
                        break;

                    case "Subject":
                        selectedItem = SearchChoice.AppointmentSubject;
                        break;

                    default:
                        selectedItem = SearchChoice.AppointmentCompanyName;
                        break;
                }
                DataTable resultOfSearch = dthandler.SearchText(selectedItem, txtAppointmentSearch.Text, selectedCustomer,0);

                dthandler.AddItemsToDataGridView(resultOfSearch, dgvAppointments, "cAppointmentID");
            }
        }
        private void btnEditAppointmentFields_Click(object sender, EventArgs e)
        {
            if (btnEditAppointmentFields.Text == "Edit Fields")
            {
                txtApoInternalContact.ReadOnly = false;
                txtApoSubject.ReadOnly = false;
                dtpAppointmentDate.Enabled = true;
                btnEditAppointmentFields.Text = "Save Changes";
                DisableAllButtons();
            }
            else if (btnEditAppointmentFields.Text == "Save Changes")
            {
                if (txtApoInternalContact.Text.Length > 0)
                {
                    if (txtApoSubject.Text.Length > 0)
                    {
                        if (dtpAppointmentDate.Value > dtpAppointmentDate.MinDate)
                        {
                            if (UpdateAppointment(selectedCustomer) == true)
                            {
                                MessageBox.Show("Appoinment succesfully modified!");
                                ReloadCustomers();
                            }
                            else
                            {
                                MessageBox.Show("There is a problem with modifying the appointment!");
                            }
                            txtApoInternalContact.ReadOnly = true;
                            txtApoSubject.ReadOnly = true;
                            dtpAppointmentDate.Enabled = false;
                            btnEditAppointmentFields.Text = "Edit Fields";
                            EnableAllButtons();
                        }
                        else
                        {
                            MessageBox.Show("Filled date is incorrect. Please check the date.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The Subject Field is empty! Please fill in.");
                    }
                }
                else
                {
                    MessageBox.Show("The Internal Contact field is empty! Please fill in.");
                }
            }
        }
        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            if (txtCustomerSearch.Text.Length > 0)
            {
                SearchChoice selectedItem;
                switch (cBoxCustomerSearch.SelectedItem.ToString())
                {
                    case "Company Name":
                        selectedItem = SearchChoice.CompanyName;
                        break;

                    case "E-Mail":
                        selectedItem = SearchChoice.Email;
                        break;

                    case "Initials":
                        selectedItem = SearchChoice.Initials;
                        break;

                    default:
                        selectedItem = SearchChoice.CompanyName;
                        break;
                }
                DataTable resultOfSearch = dthandler.SearchText(selectedItem, txtCustomerSearch.Text, selectedCustomer, 0);

                dthandler.AddItemsToDataGridView(resultOfSearch, dgvCustomers, "cCustomerID");
            }
        }
        private void btnArchiveAppointment_Click(object sender, EventArgs e)
        {
            UpdateAccomplish(selectedCustomer, selectedAppointment, true);
            LoadAppointments();
            tbContr.SelectedIndex = 3;
        }
        // Cell Content Clicks
        private void dgvUserInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCustomers.Columns["cViewButton"].Index)
            {
                if (e.RowIndex >= 0)
                {
                    selectedCustomer = int.Parse(dgvCustomers.Rows[e.RowIndex].Cells["cCustomerID"].Value.ToString());
                    ReloadCustomers();
                    tbContr.SelectedIndex = 2;
                    int temp = 0;
                    if (txtCusAppointment.Text != temp.ToString())
                    {
                        btnViewAppointment.Enabled = true;
                    }
                    else
                    {
                        btnViewAppointment.Enabled = false;
                    }
                }
            }
        }
        private void dgvAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvAppointments.Columns["cAppointmentViewButton"].Index)
            {
                if (e.RowIndex >= 0)
                {
                    selectedAppointment = int.Parse(dgvAppointments.Rows[e.RowIndex].Cells["cAppointmentID"].Value.ToString());
                    ReloadAppointments();
                    tbContr.SelectedIndex = 4;
                    if (txtApoAccomplished.Text == "True")
                    {
                        btnEditAppointmentFields.Enabled = false;
                        btnArchiveAppointment.Enabled = false;
                    }
                    else
                    {
                        btnEditAppointmentFields.Enabled = true;
                        btnArchiveAppointment.Enabled = true;
                    }
                }
            }
        }

        private void btnArchiveCustomer_Click(object sender, EventArgs e)
        {
            ArchiveCustomer();
        }
        #endregion

        #region Form Closing
        private void frmSales_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closing)
            {
                CloseToLogin();
                closing = true;
            }
        }
        #endregion

        #region Methods
        private bool addCustomer()
        {
            string sqlQuery = sqlhandler.GetQuery(Query.addCustomer);

            string faxNumberText = txtCusAddFaxNumber.Text.Replace(" ", "");

            if (faxNumberText.Length < 2)
            {
                faxNumberText = "";
            }

            string phoneNumber2Text = txtCusAddPhoneNumber2.Text.Replace(" ", "");
            if (phoneNumber2Text.Length < 2)
            {
                phoneNumber2Text = "";
            }

            SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection());
            cmd.Parameters.Add(new SqlParameter("@CompanyName", txtCusAddCompanyName.Text));
            cmd.Parameters.Add(new SqlParameter("@Address1", txtCusAddAddress1.Text));
            cmd.Parameters.Add(new SqlParameter("@PostalCode1", txtCusAddPostalCode1.Text));
            cmd.Parameters.Add(new SqlParameter("@Residence1", txtCusAddResidence1.Text));
            cmd.Parameters.Add(new SqlParameter("@Address2", txtCusAddAddress2.Text));
            cmd.Parameters.Add(new SqlParameter("@PostalCode2", txtCusAddPostalCode2.Text));
            cmd.Parameters.Add(new SqlParameter("@Residence2", txtCusAddResidence2.Text));
            cmd.Parameters.Add(new SqlParameter("@ContactPerson", txtCusAddContactperson.Text));
            cmd.Parameters.Add(new SqlParameter("@Initials", txtCusAddInitials.Text));
            cmd.Parameters.Add(new SqlParameter("@PhoneNr1", txtCusAddPhoneNumber1.Text));
            cmd.Parameters.Add(new SqlParameter("@PhoneNr2", phoneNumber2Text));
            cmd.Parameters.Add(new SqlParameter("@FaxNumber", faxNumberText));
            cmd.Parameters.Add(new SqlParameter("@Email", txtCusAddEmail.Text));
            cmd.Parameters.Add(new SqlParameter("@Prospect", cbCusAddProspect.SelectedIndex));

            cmd.Connection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool addAppointment()
        {
            string sqlQuery = sqlhandler.GetQuery(Query.addAppointment);

            SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection());
            cmd.Parameters.Add(new SqlParameter("customerID", selectedCustomer));
            cmd.Parameters.Add(new SqlParameter("appoinDate", dtpApoAddAppointmentDate.Value));
            cmd.Parameters.Add(new SqlParameter("subject", txtApoAddSubject.Text));
            cmd.Parameters.Add(new SqlParameter("intContact", txtApoAddInternalContact.Text));
            cmd.Parameters.Add(new SqlParameter("accomplished", false));

            cmd.Connection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void DisableAllButtons()
        {
            btnAddCustomer.Enabled = false;
            btnSelectCustomer.Enabled = false;
            btnHome.Enabled = false;
            btnSelectedCustomerBack.Enabled = false;
            btnLogout.Enabled = false;
            btnAddAppointment.Enabled = false;
            btnViewAppointment.Enabled = false;
            btnArchiveAppointment.Enabled = false;
            btnSelectedAppointmentBack.Enabled = false;
            this.ControlBox = false;
        }

        private void EnableAllButtons()
        {
            btnAddCustomer.Enabled = true;
            btnSelectCustomer.Enabled = true;
            btnHome.Enabled = true;
            btnSelectedCustomerBack.Enabled = true;
            btnLogout.Enabled = true;
            btnAddAppointment.Enabled = true;
            btnViewAppointment.Enabled = true;
            btnArchiveAppointment.Enabled = true;
            btnSelectedAppointmentBack.Enabled = true;
            this.ControlBox = true;
        }

        private void ArchiveCustomer()
        {
            string sqlQuery = sqlhandler.GetQuery(Query.setCustomerArchived);
            DialogResult confirmArchive = MessageBox.Show("Are you sure you want to archive this customer?", "Confirm Archive", MessageBoxButtons.YesNo);
            if (confirmArchive == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection());
                cmd.Parameters.Add(new SqlParameter("Archived", true));
                cmd.Parameters.Add(new SqlParameter("customerID", selectedCustomer));

                cmd.Connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Customer succesfully archived!");
                }
                else
                {
                    MessageBox.Show("There was a problem archiving this customer.");
                }

                LoadCustomers();
                tbContr.SelectedIndex = 1;
            }
        }
        #endregion

        #region Updaters / Editers
        private bool UpdateCustomer(int customerID)
        {
            string sqlQuery = sqlhandler.GetQuery(Query.updateSalCustomerInfo);
            SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection());
            cmd.Parameters.Add(new SqlParameter("CompanyName", txtCusCompanyName.Text));
            cmd.Parameters.Add(new SqlParameter("Address1", txtCusAddress1.Text));
            cmd.Parameters.Add(new SqlParameter("PostalCode1", txtCusPostalCode1.Text));
            cmd.Parameters.Add(new SqlParameter("Residence1", txtCusResidence1.Text));
            cmd.Parameters.Add(new SqlParameter("PhoneNumber1", txtCusPhoneNumber1.Text));
            cmd.Parameters.Add(new SqlParameter("Address2", txtCusAddress2.Text));
            cmd.Parameters.Add(new SqlParameter("PostalCode2", txtCusPostalCode2.Text));
            cmd.Parameters.Add(new SqlParameter("Residence2", txtCusResidence2.Text));
            cmd.Parameters.Add(new SqlParameter("PhoneNumber2", txtCusPhoneNumber2.Text));
            cmd.Parameters.Add(new SqlParameter("ContactPerson", txtCusContactPerson.Text));
            cmd.Parameters.Add(new SqlParameter("Initials", txtCusInitials.Text));
            cmd.Parameters.Add(new SqlParameter("OfferStatus", cboxOfferStatus.Text));
            cmd.Parameters.Add(new SqlParameter("FaxNumber", txtCusFaxNumber.Text));
            cmd.Parameters.Add(new SqlParameter("Email", txtCusEmail.Text));
            cmd.Parameters.Add(new SqlParameter("Prospect", cBoxCusProspect.Text));
            cmd.Parameters.Add(new SqlParameter("DateOfAction", dtpCusSalesDateOfAction.Value));
            cmd.Parameters.Add(new SqlParameter("LastContactDate", dtpCusSalesLastContactDate.Value));
            cmd.Parameters.Add(new SqlParameter("NextAction", dtpCusSalesNextAction.Value));
            cmd.Parameters.Add(new SqlParameter("customerID", customerID));

            cmd.Connection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool UpdateAppointment(int customerID)
        {
            string sqlQuery = sqlhandler.GetQuery(Query.updateAppointment);
            SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection());
            cmd.Parameters.Add(new SqlParameter("Int_Contact", txtApoInternalContact.Text));
            cmd.Parameters.Add(new SqlParameter("Subject", txtApoSubject.Text));
            cmd.Parameters.Add(new SqlParameter("Appoin_Date", dtpAppointmentDate.Value));
            cmd.Parameters.Add(new SqlParameter("customerID", customerID));
            cmd.Connection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool UpdateAccomplish(int customerID, int appointmentID, bool accomplished)
        {
            string sqlQuery = sqlhandler.GetQuery(Query.updateAccomplish);
            SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection());
            cmd.Parameters.Add(new SqlParameter("Accomplished", accomplished));
            cmd.Parameters.Add(new SqlParameter("customerID", customerID));
            cmd.Parameters.Add(new SqlParameter("appointmentID", appointmentID));
            cmd.Connection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        #endregion

        #region Loaders
        private void LoadCustomers()
        {
            dgvCustomers.Rows.Clear();
            string selectCustomers = sqlhandler.GetQuery(Query.loadCustomers);
            DataTable customers = dthandler.ExecuteQuery(selectCustomers);
            dthandler.AddItemsToDataGridView(customers, dgvCustomers, "cCustomerID");
        }
        private void LoadAppointments()
        {
            dgvAppointments.Rows.Clear();
            string selectAppointments = sqlhandler.GetQuery(Query.loadAppointments);
            SqlParameter[] collection = { new SqlParameter("customerID", selectedCustomer) };
            DataTable appointments = dthandler.ExecuteQuery(selectAppointments, collection);
            dthandler.AddItemsToDataGridView(appointments, dgvAppointments, "cAppointmentID");
        }
        // Reloaders
        private void ReloadCustomers()
        {
            string sqlCustomers = sqlhandler.GetQuery(Query.loadCustomerDetails);
            SqlParameter[] collection = { new SqlParameter("customerID", selectedCustomer) };
            DataTable customerDetails = dthandler.ExecuteQuery(sqlCustomers, collection);

            string sqlAppointments = sqlhandler.GetQuery(Query.countAppointments);
            collection = new SqlParameter[] { new SqlParameter("customerID", selectedCustomer) };
            DataTable countAppointments = dthandler.ExecuteQuery(sqlAppointments, collection);

            string sqlOffers = sqlhandler.GetQuery(Query.countOffers);
            collection = new SqlParameter[] { new SqlParameter("customerID", selectedCustomer) };
            DataTable countOffers = dthandler.ExecuteQuery(sqlOffers, collection);

            LoadCustomerDetails(customerDetails, countAppointments, countOffers);
        }
        private void ReloadAppointments()
        {
            string sqlCustomers = sqlhandler.GetQuery(Query.loadAppointmentDetails);
            SqlParameter[] collection = { new SqlParameter("customerID", selectedCustomer), new SqlParameter("appointmentID", selectedAppointment) };
            DataTable customerDetails = dthandler.ExecuteQuery(sqlCustomers, collection);
            LoadAppointmentDetails(customerDetails);
        }
        // Load Details
        private void LoadCustomerDetails(DataTable CusTable, DataTable countApo, DataTable countOff)
        {
            DataRow CusRow = CusTable.Rows[0];
            txtCusCompanyName.Text = CusRow["COMPANYNAME"].ToString();
            txtCusAddress1.Text = CusRow["ADDRESS1"].ToString();
            txtCusPostalCode1.Text = CusRow["POSTALCODE1"].ToString();
            txtCusResidence1.Text = CusRow["RESIDENCE1"].ToString();
            txtCusPhoneNumber1.Text = CusRow["PHONE_NR1"].ToString();
            txtCusAddress2.Text = CusRow["ADDRESS2"].ToString();
            txtCusPostalCode2.Text = CusRow["POSTALCODE2"].ToString();
            txtCusResidence2.Text = CusRow["RESIDENCE2"].ToString();
            txtCusPhoneNumber2.Text = CusRow["PHONE_NR2"].ToString();
            txtCusInitials.Text = CusRow["INITIALS"].ToString();
            txtCusFaxNumber.Text = CusRow["FAXNUMBER"].ToString();
            txtCusEmail.Text = CusRow["EMAIL"].ToString();
            txtCusContactPerson.Text = CusRow["CONTACTPERSON"].ToString();
            cBoxCusProspect.Text = CusRow["PROSPECT"].ToString();
            cboxOfferStatus.Text = CusRow["OFFER_STAT"].ToString();

            string sDateOfAction = CusRow["DATE_OF_ACTION"].ToString();
            if (sDateOfAction.Length > 0)
            {
                DateTime dateOfAction = DateTime.Parse(CusRow["DATE_OF_ACTION"].ToString());
                dtpCusSalesDateOfAction.Value = dateOfAction;
            }
            else
            {
                dtpCusSalesDateOfAction.Value = dtpCusSalesDateOfAction.MinDate;
            }

            string sLastContactDate = CusRow["LAST_CONTACT_DATE"].ToString();
            if (sLastContactDate.Length > 0)
            {
                DateTime lastContactDate = DateTime.Parse(CusRow["LAST_CONTACT_DATE"].ToString());
                dtpCusSalesLastContactDate.Value = lastContactDate;
            }
            else
            {
                dtpCusSalesLastContactDate.Value = dtpCusSalesLastContactDate.MinDate;
            }

            string sNextActionDate = CusRow["NEXT_ACTION"].ToString();
            if (sNextActionDate.Length > 0)
            {
                DateTime nextAction = DateTime.Parse(CusRow["NEXT_ACTION"].ToString());
                dtpCusSalesNextAction.Value = nextAction;
            }
            else
            {
                dtpCusSalesNextAction.Value = dtpCusSalesNextAction.MinDate;
            }

            DataRow countCus = countOff.Rows[0];
            txtCusNumberOfOffers.Text = countCus[0].ToString();
            DataRow ApoRow = countApo.Rows[0];
            txtCusAppointment.Text = ApoRow[0].ToString();
        }
        private void LoadAppointmentDetails(DataTable CusDet)
        {
            DataRow DRCusDet = CusDet.Rows[0];
            txtApoCompanyName.Text = DRCusDet["COMPANYNAME"].ToString();
            txtApoAddress.Text = DRCusDet["ADDRESS1"].ToString();
            txtApoPostalCode.Text = DRCusDet["POSTALCODE1"].ToString();
            txtApoPhoneNumber.Text = DRCusDet["PHONE_NR1"].ToString();
            txtApoContactperson.Text = DRCusDet["CONTACTPERSON"].ToString();
            txtApoInternalContact.Text = DRCusDet["INT_CONTACT"].ToString();
            txtApoSubject.Text = DRCusDet["SUBJECT"].ToString();
            DateTime appointmentDate = DateTime.Parse(DRCusDet["APPOIN_DATE"].ToString());
            dtpAppointmentDate.Value = appointmentDate;
            txtApoAccomplished.Text = DRCusDet["ACCOMPLISHED"].ToString();
        }
        #endregion

        #region Checkers
        private bool CheckTextBoxes(TextBox[] textBoxes)
        {
            bool textLengthCorrect = false;
            foreach (TextBox txt in textBoxes)
            {
                if (txt.TextLength > 0)
                {
                    textLengthCorrect = true;
                }
                else
                {
                    textLengthCorrect = false;
                    break;
                }
            }

            return textLengthCorrect;
        }
        private bool CheckPostalCode(TextBox postalCode)
        {
            string regex = @"\b[1-9][0-9]{3}\b\b\s[A-Z]{2}\b";
            Regex regEx = new Regex(regex);
            if (regEx.IsMatch(postalCode.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckEmail(TextBox email)
        {
            bool match = false;

            string sRegex = @"\b\S+\b\b[@]\b\b\S+\b[.]\b\S+\b$";
            Regex regex = new Regex(sRegex);

            if (regex.IsMatch(email.Text))
            {
                match = true;
            }
            else
            {
                match = false;
            }

            return match;
        }
        #endregion

        #region CloseToLogin
        private void CloseToLogin()
        {
            closing = true;
            loginForm.ClearTextBoxes();
            loginForm.Show();
            this.Close();
        }
        #endregion       
        }
}