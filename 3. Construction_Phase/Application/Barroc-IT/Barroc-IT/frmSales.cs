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

        private int selectedCustomer = 0;
        private int selectedAppoinment = 0;
        private bool closing = false;
        public frmSales(DatabaseHandler handler, frmLogin loginForm, DataTableHandler dthandler, SqlQueryHandler sqlhandler)
        {
            InitializeComponent();
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
        }
        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            tbContr.SelectedIndex = 5;
        }
        private void btnAppointmentAdd_Click(object sender, EventArgs e)
        {

        }
        private void btnAddInvoiceCancel_Click(object sender, EventArgs e)
        {

        }
        private void btnCusAddCustomer_Click(object sender, EventArgs e)
        {
            addCustomer();
            //tbContr.SelectedIndex = 1;
            dgvUserInfo.Rows.Clear();
            LoadCustomers();
        }
       /* private void btnEditFields_Click(object sender, EventArgs e)
        {
            if (btnEditCustomerFields.Text == "Edit Fields")
            {
                txtCusCompanyName.ReadOnly = false;
                txtCusNumberOfOffers.ReadOnly = true;

                txtCusAddress1.ReadOnly = false;
                txtCusPostalCode1.ReadOnly = false;
                txtCusResidence1.ReadOnly = false;
                //txtCusPhoneNumber1.ReadOnly = false;

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
        * */


        // Loads
        private void LoadCustomers()
        {
            dgvUserInfo.Rows.Clear();
            string selectCustomers = sqlhandler.GetQuery(Query.loadCustomers);
            DataTable customers = dthandler.ExecuteQuery(selectCustomers);
            AddItemsToDataGridView(customers, dgvUserInfo, "cCustomerID");
        }
        private void LoadAppointments()
        {
            dgvAppointments.Rows.Clear();
            string selectAppointments = sqlhandler.GetQuery(Query.loadAppointments);
            SqlParameter[] collection = { new SqlParameter("customerID", selectedCustomer) };
            DataTable appointments = dthandler.ExecuteQuery(selectAppointments, collection);
            AddItemsToDataGridView(appointments, dgvAppointments, "cAppointmentID");
        }

        // Methods  
        private bool addCustomer()
        {
#if DEBUG
            string regex = @"\b[1-9][0-9]{3}\b\b\s[A-Z]{2}\b";
            Regex regEx = new Regex(regex);
            if (regEx.IsMatch(txtCusAddPostalCode1.Text))
            {
                MessageBox.Show("MATCH");
            }
            else
            {
                MessageBox.Show("No Match");
            }
            return true;
#endif





            //string sqlQuery = sqlhandler.GetQuery(Query.addCustomer);
            //SqlCommand cmd = new SqlCommand(sqlQuery, handler.GetConnection());
            //cmd.Parameters.Add(new SqlParameter("@CompanyName", txtCusAddCompanyName.Text));
            //cmd.Parameters.Add(new SqlParameter("@Address1", txtCusAddAddress1.Text));
            //cmd.Parameters.Add(new SqlParameter("@PostalCode1", txtCusAddPostalCode1.Text));
            //cmd.Parameters.Add(new SqlParameter("@Residence1", txtCusAddResidence1.Text));
            //cmd.Parameters.Add(new SqlParameter("@Address2", txtCusAddAddress2.Text));
            //cmd.Parameters.Add(new SqlParameter("@PostalCode2", txtCusAddPostalCode2.Text));
            //cmd.Parameters.Add(new SqlParameter("@Residence2", txtCusAddResidence2.Text));
            //cmd.Parameters.Add(new SqlParameter("@ContactPerson", txtCusAddContactperson.Text));
            //cmd.Parameters.Add(new SqlParameter("@Initials", txtCusAddInitials.Text));
            //cmd.Parameters.Add(new SqlParameter("@PhoneNr1", txtCusAddPhoneNumber1.Text));
            //cmd.Parameters.Add(new SqlParameter("@PhoneNr2", txtCusAddPhoneNumber2.Text));
            //cmd.Parameters.Add(new SqlParameter("@FaxNumber", txtCusAddFaxNumber.Text));
            //cmd.Parameters.Add(new SqlParameter("@Email", txtCusAddEmail.Text));
            //cmd.Parameters.Add(new SqlParameter("@Prospect", cbCusAddProspect.SelectedIndex.ToString()));

            //cmd.Connection.Open();
            //int rowsAffected = cmd.ExecuteNonQuery();
            //cmd.Connection.Close();
            //if (rowsAffected > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
        private void btnAppointmentSearch_Click(object sender, EventArgs e)
        {

        }

        // Cell Content Clicks
        private void dgvUserInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvUserInfo.Columns["cViewButton"].Index)
            {
                selectedCustomer = int.Parse(dgvUserInfo.Rows[e.RowIndex].Cells["cCustomerID"].Value.ToString());
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

        // Reloads
        private void ReloadCustomers()
        {
            string sqlCustomers = sqlhandler.GetQuery(Query.loadCustomerDetails);
            SqlParameter[] collection = { new SqlParameter("customerID", selectedCustomer) };
            DataTable customerDetails = dthandler.ExecuteQuery(sqlCustomers, collection);

           // string sqlAppointments = sqlhandler.GetQuery(Query.countAppointments);
            collection = new SqlParameter[] { new SqlParameter("customerID", selectedCustomer) };
          //  DataTable countAppointments = dthandler.ExecuteQuery(sqlAppointments, collection);

          //  string sqlOffers = sqlhandler.GetQuery(Query.countOffers);
            collection = new SqlParameter[] { new SqlParameter("customerID", selectedCustomer) };
          //  DataTable countOffers = dthandler.ExecuteQuery(sqlOffers, collection);

           // LoadCustomerDetails(customerDetails, countAppointments, countOffers);
        }
        private void ReloadAppointments()
        {
           // string sqlCustomers = sqlhandler.GetQuery(Query.loadAppointmentDetails);
            SqlParameter[] collection = { new SqlParameter("customerID", selectedCustomer), new SqlParameter("appointmentID", selectedAppoinment) };
          //  DataTable customerDetails = dthandler.ExecuteQuery(sqlCustomers, collection);
            //LoadAppointmentDetails(customerDetails);
        }

        // Load Details
        private void LoadCustomerDetails(DataTable CusTable, DataTable countApo, DataTable countOff)
        {
            DataRow CusRow = CusTable.Rows[0];
            txtCusCompanyName.Text = CusRow["COMPANYNAME"].ToString();
            txtCusAddress1.Text = CusRow["ADDRESS1"].ToString();
            txtCusPostalCode1.Text = CusRow["POSTALCODE1"].ToString();
            //txtCusResidence1.Text = CusRow["RESIDENCE1"].ToString();
            txtCusPhoneNumber1.Text = CusRow["PHONE_NR1"].ToString();
            txtCusFaxNumber.Text = CusRow["FAXNUMBER"].ToString();
            txtCusEmail.Text = CusRow["EMAIL"].ToString();
            txtCusContactPerson.Text = CusRow["CONTACTPERSON"].ToString();
            cBoxCusProspect.Text = CusRow["PROSPECT"].ToString();
            txtCusOfferStatus.Text = CusRow["OFFER_STAT"].ToString();
            DateTime dateOfAction = DateTime.Parse(CusRow["DATE_OF_ACTION"].ToString());
            dtpCusSalesDateOfAction.Value = dateOfAction;
            DateTime lastContactDate = DateTime.Parse(CusRow["LAST_CONTACT_DATE"].ToString());
            dtpCusSalesLastContactDate.Value = lastContactDate;
            DateTime nextAction = DateTime.Parse(CusRow["NEXT_ACTION"].ToString());
            dtpCusSalesNextAction.Value = nextAction;
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

        //RecoverComboBoxFields
        private void RecoverComboBoxFields()
        {
            if (cBoxCusProspect.Text == "True" || cBoxCusProspect.Text == "1")
            {
                cBoxCusProspect.Text = "Yes";
            }
            else if (cBoxCusProspect.Text == "False" || cBoxCusProspect.Text == "0")
            {
                cBoxCusProspect.Text = "No";
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

        // Methods
        private void AddItemsToDataGridView(DataTable table, DataGridView dataGridView, string idColumnName)
        {
            dataGridView.Rows.Clear();
            table.Columns.Add(idColumnName);
            table.Columns[idColumnName].SetOrdinal(0);
            foreach (DataRow dr in table.Rows)
            {
                dataGridView.Rows.Add(dr.ItemArray);
            }
        }

        // Close To Login
        private void CloseToLogin()
        {
            closing = true;
            loginForm.ClearTextBoxes();
            loginForm.Show();
            this.Close();
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
    }
}
