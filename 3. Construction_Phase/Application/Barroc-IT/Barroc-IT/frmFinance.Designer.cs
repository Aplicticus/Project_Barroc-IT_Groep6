namespace Barroc_IT
{
    partial class frmFinance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pWelcome = new System.Windows.Forms.Panel();
            this.lblFinancePanel = new System.Windows.Forms.Label();
            this.pButtons = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnFinanceSelectCustomer = new System.Windows.Forms.Button();
            this.btnFinanceHome = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbContr = new TablessControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnChangeBKR = new System.Windows.Forms.Button();
            this.btnEditFields = new System.Windows.Forms.Button();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.lblContactperson = new System.Windows.Forms.Label();
            this.lblSoftware = new System.Windows.Forms.Label();
            this.lblAppointmentCount = new System.Windows.Forms.Label();
            this.lblInternalContact = new System.Windows.Forms.Label();
            this.lblHardware = new System.Windows.Forms.Label();
            this.lblApplications = new System.Windows.Forms.Label();
            this.lblOpenProject = new System.Windows.Forms.Label();
            this.txtHardware = new System.Windows.Forms.TextBox();
            this.txtInternalContact = new System.Windows.Forms.TextBox();
            this.txtAppointments = new System.Windows.Forms.TextBox();
            this.lblFax = new System.Windows.Forms.Label();
            this.txtSoftware = new System.Windows.Forms.TextBox();
            this.txtApplications = new System.Windows.Forms.TextBox();
            this.txtOpenProject = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtMaintenance = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber1 = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblMaintenance = new System.Windows.Forms.Label();
            this.txtFaxNumber = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber1 = new System.Windows.Forms.Label();
            this.txtPostalCode1 = new System.Windows.Forms.TextBox();
            this.lblPostalCode1 = new System.Windows.Forms.Label();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.pWelcome.SuspendLayout();
            this.pButtons.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tbContr.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pWelcome
            // 
            this.pWelcome.BackColor = System.Drawing.SystemColors.Control;
            this.pWelcome.Controls.Add(this.lblFinancePanel);
            this.pWelcome.Location = new System.Drawing.Point(12, 12);
            this.pWelcome.Name = "pWelcome";
            this.pWelcome.Size = new System.Drawing.Size(984, 100);
            this.pWelcome.TabIndex = 0;
            // 
            // lblFinancePanel
            // 
            this.lblFinancePanel.AutoSize = true;
            this.lblFinancePanel.BackColor = System.Drawing.SystemColors.Control;
            this.lblFinancePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinancePanel.Location = new System.Drawing.Point(407, 30);
            this.lblFinancePanel.Name = "lblFinancePanel";
            this.lblFinancePanel.Size = new System.Drawing.Size(236, 39);
            this.lblFinancePanel.TabIndex = 0;
            this.lblFinancePanel.Text = "Finance Panel";
            // 
            // pButtons
            // 
            this.pButtons.BackColor = System.Drawing.SystemColors.Control;
            this.pButtons.Controls.Add(this.btnLogout);
            this.pButtons.Controls.Add(this.btnFinanceSelectCustomer);
            this.pButtons.Controls.Add(this.btnFinanceHome);
            this.pButtons.Location = new System.Drawing.Point(12, 118);
            this.pButtons.Name = "pButtons";
            this.pButtons.Size = new System.Drawing.Size(211, 600);
            this.pButtons.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(24, 533);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(165, 43);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnFinanceSelectCustomer
            // 
            this.btnFinanceSelectCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinanceSelectCustomer.Location = new System.Drawing.Point(24, 82);
            this.btnFinanceSelectCustomer.Name = "btnFinanceSelectCustomer";
            this.btnFinanceSelectCustomer.Size = new System.Drawing.Size(165, 43);
            this.btnFinanceSelectCustomer.TabIndex = 2;
            this.btnFinanceSelectCustomer.Text = "Select Customer";
            this.btnFinanceSelectCustomer.UseVisualStyleBackColor = true;
            this.btnFinanceSelectCustomer.Click += new System.EventHandler(this.btnFinanceSelectCustomer_Click);
            // 
            // btnFinanceHome
            // 
            this.btnFinanceHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinanceHome.Location = new System.Drawing.Point(24, 33);
            this.btnFinanceHome.Name = "btnFinanceHome";
            this.btnFinanceHome.Size = new System.Drawing.Size(165, 43);
            this.btnFinanceHome.TabIndex = 0;
            this.btnFinanceHome.Text = "Home";
            this.btnFinanceHome.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbContr);
            this.panel1.Location = new System.Drawing.Point(229, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(767, 600);
            this.panel1.TabIndex = 2;
            // 
            // tbContr
            // 
            this.tbContr.Controls.Add(this.tabPage3);
            this.tbContr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbContr.Location = new System.Drawing.Point(0, 0);
            this.tbContr.Name = "tbContr";
            this.tbContr.SelectedIndex = 0;
            this.tbContr.Size = new System.Drawing.Size(767, 600);
            this.tbContr.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.btnChangeBKR);
            this.tabPage3.Controls.Add(this.btnEditFields);
            this.tabPage3.Controls.Add(this.txtContactPerson);
            this.tabPage3.Controls.Add(this.lblContactperson);
            this.tabPage3.Controls.Add(this.lblSoftware);
            this.tabPage3.Controls.Add(this.lblAppointmentCount);
            this.tabPage3.Controls.Add(this.lblInternalContact);
            this.tabPage3.Controls.Add(this.lblHardware);
            this.tabPage3.Controls.Add(this.lblApplications);
            this.tabPage3.Controls.Add(this.lblOpenProject);
            this.tabPage3.Controls.Add(this.txtHardware);
            this.tabPage3.Controls.Add(this.txtInternalContact);
            this.tabPage3.Controls.Add(this.txtAppointments);
            this.tabPage3.Controls.Add(this.lblFax);
            this.tabPage3.Controls.Add(this.txtSoftware);
            this.tabPage3.Controls.Add(this.txtApplications);
            this.tabPage3.Controls.Add(this.txtOpenProject);
            this.tabPage3.Controls.Add(this.lblEmail);
            this.tabPage3.Controls.Add(this.txtMaintenance);
            this.tabPage3.Controls.Add(this.txtPhoneNumber1);
            this.tabPage3.Controls.Add(this.txtEmail);
            this.tabPage3.Controls.Add(this.lblMaintenance);
            this.tabPage3.Controls.Add(this.txtFaxNumber);
            this.tabPage3.Controls.Add(this.lblPhoneNumber1);
            this.tabPage3.Controls.Add(this.txtPostalCode1);
            this.tabPage3.Controls.Add(this.lblPostalCode1);
            this.tabPage3.Controls.Add(this.txtAddress1);
            this.tabPage3.Controls.Add(this.lblAddress);
            this.tabPage3.Controls.Add(this.lblCompanyName);
            this.tabPage3.Controls.Add(this.txtCompanyName);
            this.tabPage3.Controls.Add(this.lblCustomer);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(759, 574);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "selectedCustomer";
            // 
            // btnChangeBKR
            // 
            this.btnChangeBKR.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeBKR.Location = new System.Drawing.Point(203, 510);
            this.btnChangeBKR.Name = "btnChangeBKR";
            this.btnChangeBKR.Size = new System.Drawing.Size(165, 43);
            this.btnChangeBKR.TabIndex = 127;
            this.btnChangeBKR.Text = "Change BKR";
            this.btnChangeBKR.UseVisualStyleBackColor = true;
            // 
            // btnEditFields
            // 
            this.btnEditFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditFields.Location = new System.Drawing.Point(32, 510);
            this.btnEditFields.Name = "btnEditFields";
            this.btnEditFields.Size = new System.Drawing.Size(165, 43);
            this.btnEditFields.TabIndex = 6;
            this.btnEditFields.Text = "Edit Fields";
            this.btnEditFields.UseVisualStyleBackColor = true;
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Location = new System.Drawing.Point(226, 227);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.ReadOnly = true;
            this.txtContactPerson.Size = new System.Drawing.Size(137, 20);
            this.txtContactPerson.TabIndex = 125;
            // 
            // lblContactperson
            // 
            this.lblContactperson.AutoSize = true;
            this.lblContactperson.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactperson.Location = new System.Drawing.Point(51, 221);
            this.lblContactperson.Name = "lblContactperson";
            this.lblContactperson.Size = new System.Drawing.Size(146, 25);
            this.lblContactperson.TabIndex = 124;
            this.lblContactperson.Text = "Contactperson:";
            // 
            // lblSoftware
            // 
            this.lblSoftware.AutoSize = true;
            this.lblSoftware.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoftware.Location = new System.Drawing.Point(369, 161);
            this.lblSoftware.Name = "lblSoftware";
            this.lblSoftware.Size = new System.Drawing.Size(95, 25);
            this.lblSoftware.TabIndex = 123;
            this.lblSoftware.Text = "Software:";
            // 
            // lblAppointmentCount
            // 
            this.lblAppointmentCount.AutoSize = true;
            this.lblAppointmentCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentCount.Location = new System.Drawing.Point(369, 191);
            this.lblAppointmentCount.Name = "lblAppointmentCount";
            this.lblAppointmentCount.Size = new System.Drawing.Size(128, 25);
            this.lblAppointmentCount.TabIndex = 122;
            this.lblAppointmentCount.Text = "Appointment:";
            // 
            // lblInternalContact
            // 
            this.lblInternalContact.AutoSize = true;
            this.lblInternalContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternalContact.Location = new System.Drawing.Point(369, 221);
            this.lblInternalContact.Name = "lblInternalContact";
            this.lblInternalContact.Size = new System.Drawing.Size(222, 25);
            this.lblInternalContact.TabIndex = 121;
            this.lblInternalContact.Text = "Internal Contact Person:";
            // 
            // lblHardware
            // 
            this.lblHardware.AutoSize = true;
            this.lblHardware.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHardware.Location = new System.Drawing.Point(369, 131);
            this.lblHardware.Name = "lblHardware";
            this.lblHardware.Size = new System.Drawing.Size(102, 25);
            this.lblHardware.TabIndex = 120;
            this.lblHardware.Text = "Hardware:";
            // 
            // lblApplications
            // 
            this.lblApplications.AutoSize = true;
            this.lblApplications.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplications.Location = new System.Drawing.Point(369, 102);
            this.lblApplications.Name = "lblApplications";
            this.lblApplications.Size = new System.Drawing.Size(124, 25);
            this.lblApplications.TabIndex = 119;
            this.lblApplications.Text = "Applications:";
            // 
            // lblOpenProject
            // 
            this.lblOpenProject.AutoSize = true;
            this.lblOpenProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpenProject.Location = new System.Drawing.Point(369, 72);
            this.lblOpenProject.Name = "lblOpenProject";
            this.lblOpenProject.Size = new System.Drawing.Size(132, 25);
            this.lblOpenProject.TabIndex = 118;
            this.lblOpenProject.Text = "Open Project:";
            // 
            // txtHardware
            // 
            this.txtHardware.Location = new System.Drawing.Point(594, 137);
            this.txtHardware.Name = "txtHardware";
            this.txtHardware.ReadOnly = true;
            this.txtHardware.Size = new System.Drawing.Size(137, 20);
            this.txtHardware.TabIndex = 117;
            // 
            // txtInternalContact
            // 
            this.txtInternalContact.Location = new System.Drawing.Point(594, 227);
            this.txtInternalContact.Name = "txtInternalContact";
            this.txtInternalContact.ReadOnly = true;
            this.txtInternalContact.Size = new System.Drawing.Size(137, 20);
            this.txtInternalContact.TabIndex = 110;
            // 
            // txtAppointments
            // 
            this.txtAppointments.Location = new System.Drawing.Point(594, 197);
            this.txtAppointments.Name = "txtAppointments";
            this.txtAppointments.ReadOnly = true;
            this.txtAppointments.Size = new System.Drawing.Size(137, 20);
            this.txtAppointments.TabIndex = 108;
            // 
            // lblFax
            // 
            this.lblFax.AutoSize = true;
            this.lblFax.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFax.Location = new System.Drawing.Point(51, 161);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(130, 25);
            this.lblFax.TabIndex = 107;
            this.lblFax.Text = "Fax Number: ";
            // 
            // txtSoftware
            // 
            this.txtSoftware.Location = new System.Drawing.Point(594, 167);
            this.txtSoftware.Name = "txtSoftware";
            this.txtSoftware.ReadOnly = true;
            this.txtSoftware.Size = new System.Drawing.Size(137, 20);
            this.txtSoftware.TabIndex = 106;
            // 
            // txtApplications
            // 
            this.txtApplications.Location = new System.Drawing.Point(594, 108);
            this.txtApplications.Name = "txtApplications";
            this.txtApplications.ReadOnly = true;
            this.txtApplications.Size = new System.Drawing.Size(137, 20);
            this.txtApplications.TabIndex = 103;
            // 
            // txtOpenProject
            // 
            this.txtOpenProject.Location = new System.Drawing.Point(594, 78);
            this.txtOpenProject.Name = "txtOpenProject";
            this.txtOpenProject.ReadOnly = true;
            this.txtOpenProject.Size = new System.Drawing.Size(137, 20);
            this.txtOpenProject.TabIndex = 101;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(51, 191);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(73, 25);
            this.lblEmail.TabIndex = 99;
            this.lblEmail.Text = "E-mail:";
            // 
            // txtMaintenance
            // 
            this.txtMaintenance.Location = new System.Drawing.Point(594, 48);
            this.txtMaintenance.Name = "txtMaintenance";
            this.txtMaintenance.ReadOnly = true;
            this.txtMaintenance.Size = new System.Drawing.Size(137, 20);
            this.txtMaintenance.TabIndex = 98;
            // 
            // txtPhoneNumber1
            // 
            this.txtPhoneNumber1.Location = new System.Drawing.Point(226, 137);
            this.txtPhoneNumber1.Name = "txtPhoneNumber1";
            this.txtPhoneNumber1.ReadOnly = true;
            this.txtPhoneNumber1.Size = new System.Drawing.Size(137, 20);
            this.txtPhoneNumber1.TabIndex = 97;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(226, 197);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(137, 20);
            this.txtEmail.TabIndex = 86;
            // 
            // lblMaintenance
            // 
            this.lblMaintenance.AutoSize = true;
            this.lblMaintenance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaintenance.Location = new System.Drawing.Point(369, 42);
            this.lblMaintenance.Name = "lblMaintenance";
            this.lblMaintenance.Size = new System.Drawing.Size(210, 25);
            this.lblMaintenance.TabIndex = 85;
            this.lblMaintenance.Text = "Maintenance Contract:";
            // 
            // txtFaxNumber
            // 
            this.txtFaxNumber.Location = new System.Drawing.Point(226, 167);
            this.txtFaxNumber.Name = "txtFaxNumber";
            this.txtFaxNumber.ReadOnly = true;
            this.txtFaxNumber.Size = new System.Drawing.Size(137, 20);
            this.txtFaxNumber.TabIndex = 84;
            // 
            // lblPhoneNumber1
            // 
            this.lblPhoneNumber1.AutoSize = true;
            this.lblPhoneNumber1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumber1.Location = new System.Drawing.Point(51, 131);
            this.lblPhoneNumber1.Name = "lblPhoneNumber1";
            this.lblPhoneNumber1.Size = new System.Drawing.Size(149, 25);
            this.lblPhoneNumber1.TabIndex = 83;
            this.lblPhoneNumber1.Text = "Phone Number:";
            // 
            // txtPostalCode1
            // 
            this.txtPostalCode1.Location = new System.Drawing.Point(226, 108);
            this.txtPostalCode1.Name = "txtPostalCode1";
            this.txtPostalCode1.ReadOnly = true;
            this.txtPostalCode1.Size = new System.Drawing.Size(137, 20);
            this.txtPostalCode1.TabIndex = 81;
            // 
            // lblPostalCode1
            // 
            this.lblPostalCode1.AutoSize = true;
            this.lblPostalCode1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostalCode1.Location = new System.Drawing.Point(51, 102);
            this.lblPostalCode1.Name = "lblPostalCode1";
            this.lblPostalCode1.Size = new System.Drawing.Size(125, 25);
            this.lblPostalCode1.TabIndex = 80;
            this.lblPostalCode1.Text = "Postal Code:";
            // 
            // txtAddress1
            // 
            this.txtAddress1.Location = new System.Drawing.Point(226, 78);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.ReadOnly = true;
            this.txtAddress1.Size = new System.Drawing.Size(137, 20);
            this.txtAddress1.TabIndex = 79;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(51, 72);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(91, 25);
            this.lblAddress.TabIndex = 78;
            this.lblAddress.Text = "Address:";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.Location = new System.Drawing.Point(51, 43);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(160, 25);
            this.lblCompanyName.TabIndex = 76;
            this.lblCompanyName.Text = "Company Name:";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(226, 48);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.ReadOnly = true;
            this.txtCompanyName.Size = new System.Drawing.Size(137, 20);
            this.txtCompanyName.TabIndex = 75;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(315, 3);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(140, 31);
            this.lblCustomer.TabIndex = 23;
            this.lblCustomer.Text = "Customer";
            // 
            // frmFinance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pButtons);
            this.Controls.Add(this.pWelcome);
            this.Name = "frmFinance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Finance";            
            this.pWelcome.ResumeLayout(false);
            this.pWelcome.PerformLayout();
            this.pButtons.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tbContr.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pWelcome;
        private System.Windows.Forms.Label lblFinancePanel;
        private System.Windows.Forms.Panel pButtons;
        private System.Windows.Forms.Button btnFinanceSelectCustomer;
        private System.Windows.Forms.Button btnFinanceHome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel1;
        private TablessControl tbContr;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnChangeBKR;
        private System.Windows.Forms.Button btnEditFields;
        private System.Windows.Forms.TextBox txtContactPerson;
        private System.Windows.Forms.Label lblContactperson;
        private System.Windows.Forms.Label lblSoftware;
        private System.Windows.Forms.Label lblAppointmentCount;
        private System.Windows.Forms.Label lblInternalContact;
        private System.Windows.Forms.Label lblHardware;
        private System.Windows.Forms.Label lblApplications;
        private System.Windows.Forms.Label lblOpenProject;
        private System.Windows.Forms.TextBox txtHardware;
        private System.Windows.Forms.TextBox txtInternalContact;
        private System.Windows.Forms.TextBox txtAppointments;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.TextBox txtSoftware;
        private System.Windows.Forms.TextBox txtApplications;
        private System.Windows.Forms.TextBox txtOpenProject;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtMaintenance;
        private System.Windows.Forms.TextBox txtPhoneNumber1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblMaintenance;
        private System.Windows.Forms.TextBox txtFaxNumber;
        private System.Windows.Forms.Label lblPhoneNumber1;
        private System.Windows.Forms.TextBox txtPostalCode1;
        private System.Windows.Forms.Label lblPostalCode1;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblCustomer;
    }
}