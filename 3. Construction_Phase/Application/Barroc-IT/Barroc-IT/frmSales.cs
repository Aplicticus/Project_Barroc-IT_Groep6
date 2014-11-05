using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Barroc_IT
{
    public partial class frmSales : Form
    {
        // Properties, Instances
        private DatabaseHandler handler;

        private frmLogin loginForm;
        private SqlQueryHandler sqlhandler;
        private DataTableHandler dthandler;

        private int selectedCustomer;
        private int selectedAppoinment;
        private bool closing = false;

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

        // Click Events
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
            tbContr.SelectedIndex = 5;
        }

        private void btnAppointmentAdd_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 2;
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

                txtCusFaxNumber.ReadOnly = false;
                txtCusOfferStatus.ReadOnly = false;
                txtCusEmail.ReadOnly = false;
                dtpCusSalesDateOfAction.Enabled = true;
                txtCusContactPerson.ReadOnly = false;
                dtpCusSalesLastContactDate.Enabled = true;
                txtCusAppointment.ReadOnly = true;
                dtpCusSalesNextAction.Enabled = true;
                cBoxCusProspect.Enabled = true;
                nudCusSalePercentage.Enabled = false;
                btnEditCustomerFields.Text = "Save Changes";
            }
            else if (btnEditCustomerFields.Text == "Save Changes")
            {
                if (UpdateCustomer(selectedCustomer) == true)
                {
                    MessageBox.Show("Customer succesfully modified!");
                    ReloadCustomers();
                    tbContr.SelectedIndex = 2;
                }
                else
                {
                    MessageBox.Show("There is a problem with modifying the customer!");
                }
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

                txtCusFaxNumber.ReadOnly = true;
                txtCusOfferStatus.ReadOnly = true;
                txtCusEmail.ReadOnly = true;
                dtpCusSalesDateOfAction.Enabled = false;
                txtCusContactPerson.ReadOnly = true;
                dtpCusSalesLastContactDate.Enabled = false;
                txtCusAppointment.ReadOnly = true;
                dtpCusSalesNextAction.Enabled = false;
                cBoxCusProspect.Enabled = false;
                nudCusSalePercentage.Enabled = false;
                btnEditCustomerFields.Text = "Edit Fields";
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
                DataTable resultOfSearch = dthandler.SearchText(selectedItem, txtAppointmentSearch.Text, selectedCustomer);

                dthandler.AddItemsToDataGridView(resultOfSearch, dgvAppointments, "cAppointmentID");
            }
        }

        // Cell Content Clicks
        private void dgvUserInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCustomers.Columns["cViewButton"].Index)
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

        private void dgvAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvAppointments.Columns["cAppointmentViewButton"].Index)
            {
                selectedAppoinment = int.Parse(dgvAppointments.Rows[e.RowIndex].Cells["cAppointmentID"].Value.ToString());
                ReloadAppointments();
                tbContr.SelectedIndex = 4;
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

        //RecoverComboBoxFields
        private void RecoverComboBoxFields()
        {
            if (cBoxCusProspect.Text == "True" || cBoxCusProspect.Text == "1")
            {
                cBoxCusProspect.Text = "Yes";
            }
            else if (cBoxCusProspect.Text == "Yes")
            {
                cBoxCusProspect.Text = "True";
            }
            else if (cBoxCusProspect.Text == "False" || cBoxCusProspect.Text == "0")
            {
                cBoxCusProspect.Text = "No";
            }
            else if (cBoxCusProspect.Text == "No")
            {
                cBoxCusProspect.Text = "False";
            }

            if (txtCusOfferStatus.Text == "True" || txtCusOfferStatus.Text == "1")
            {
                txtCusOfferStatus.Text = "Yes";
            }
            else
            {
                txtCusOfferStatus.Text = "No";
            }
        }

        // Form Closing
        private void frmSales_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closing)
            {
                CloseToLogin();
                closing = true;
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
                DataTable resultOfSearch = dthandler.SearchText(selectedItem, txtCustomerSearch.Text, selectedCustomer);

                dthandler.AddItemsToDataGridView(resultOfSearch, dgvCustomers, "cCustomerID");
            }
        }

        // Methods
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

        // Updaters / Editers
        private bool UpdateCustomer(int customerID)
        {
            RecoverComboBoxFields();
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
            cmd.Parameters.Add(new SqlParameter("PhoneNumber2", txtCusAddPhoneNumber2.Text));
            cmd.Parameters.Add(new SqlParameter("ContactPerson", txtCusContactPerson.Text));
            cmd.Parameters.Add(new SqlParameter("Initials", txtCusInitials.Text));
            cmd.Parameters.Add(new SqlParameter("OfferStatus", txtCusOfferStatus.Text));
            cmd.Parameters.Add(new SqlParameter("FaxNumber", txtCusAddFaxNumber.Text));
            cmd.Parameters.Add(new SqlParameter("Email", txtCusEmail.Text));
            cmd.Parameters.Add(new SqlParameter("Prospect", cBoxCusProspect.SelectedIndex));
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

        // Loads
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

        // Reloads
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
            SqlParameter[] collection = { new SqlParameter("customerID", selectedCustomer), new SqlParameter("appointmentID", selectedAppoinment) };
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
            txtCusOfferStatus.Text = CusRow["OFFER_STAT"].ToString();

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
            RecoverComboBoxFields();
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
        }

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

        // Close To Login
        private void CloseToLogin()
        {
            closing = true;
            loginForm.ClearTextBoxes();
            loginForm.Show();
            this.Close();
        }
    }
}