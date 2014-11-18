namespace Barroc_IT
{
    partial class frmAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdmin));
            this.pWelcome = new System.Windows.Forms.Panel();
            this.lblAdminPanel = new System.Windows.Forms.Label();
            this.pButtons = new System.Windows.Forms.Panel();
            this.btnArchivedCustomers = new System.Windows.Forms.Button();
            this.btnUserInformation = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnAdminAddUser = new System.Windows.Forms.Button();
            this.btnAdminHome = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbContr = new TablessControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblAdminHome = new System.Windows.Forms.Label();
            this.lblAdminWelcome = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnAddUserBack = new System.Windows.Forms.Button();
            this.cBoxAddDepartment = new System.Windows.Forms.ComboBox();
            this.txtAddRepeatPassword = new System.Windows.Forms.TextBox();
            this.lblAddRepeatPassword = new System.Windows.Forms.Label();
            this.txtAddPassword = new System.Windows.Forms.TextBox();
            this.lblAddPassword = new System.Windows.Forms.Label();
            this.txtAddUserName = new System.Windows.Forms.TextBox();
            this.lblAddUserName = new System.Windows.Forms.Label();
            this.lblAddDepartment = new System.Windows.Forms.Label();
            this.lblAdminRegister = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.cActivateDeactivate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDeactivated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLastLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActivatedUsersBack = new System.Windows.Forms.Button();
            this.lblUserInformation = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.btnArchivedCustomersBack = new System.Windows.Forms.Button();
            this.dgvArchivedCustomers = new System.Windows.Forms.DataGridView();
            this.lblArchivedCustomer = new System.Windows.Forms.Label();
            this.cMakeVisible = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cCustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pWelcome.SuspendLayout();
            this.pButtons.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tbContr.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchivedCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // pWelcome
            // 
            this.pWelcome.BackColor = System.Drawing.SystemColors.Control;
            this.pWelcome.Controls.Add(this.lblAdminPanel);
            this.pWelcome.Location = new System.Drawing.Point(1, -1);
            this.pWelcome.Name = "pWelcome";
            this.pWelcome.Size = new System.Drawing.Size(1004, 113);
            this.pWelcome.TabIndex = 0;
            // 
            // lblAdminPanel
            // 
            this.lblAdminPanel.AutoSize = true;
            this.lblAdminPanel.BackColor = System.Drawing.SystemColors.Control;
            this.lblAdminPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminPanel.Location = new System.Drawing.Point(369, 30);
            this.lblAdminPanel.Name = "lblAdminPanel";
            this.lblAdminPanel.Size = new System.Drawing.Size(314, 39);
            this.lblAdminPanel.TabIndex = 0;
            this.lblAdminPanel.Text = "Administrator Panel";
            // 
            // pButtons
            // 
            this.pButtons.BackColor = System.Drawing.SystemColors.Control;
            this.pButtons.Controls.Add(this.btnArchivedCustomers);
            this.pButtons.Controls.Add(this.btnUserInformation);
            this.pButtons.Controls.Add(this.btnLogout);
            this.pButtons.Controls.Add(this.btnAdminAddUser);
            this.pButtons.Controls.Add(this.btnAdminHome);
            this.pButtons.Location = new System.Drawing.Point(1, 118);
            this.pButtons.Name = "pButtons";
            this.pButtons.Size = new System.Drawing.Size(211, 610);
            this.pButtons.TabIndex = 1;
            // 
            // btnArchivedCustomers
            // 
            this.btnArchivedCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchivedCustomers.Location = new System.Drawing.Point(24, 196);
            this.btnArchivedCustomers.Name = "btnArchivedCustomers";
            this.btnArchivedCustomers.Size = new System.Drawing.Size(165, 59);
            this.btnArchivedCustomers.TabIndex = 6;
            this.btnArchivedCustomers.Text = "Archived Customers";
            this.btnArchivedCustomers.UseVisualStyleBackColor = true;
            this.btnArchivedCustomers.Click += new System.EventHandler(this.btnArchivedCustomers_Click);
            // 
            // btnUserInformation
            // 
            this.btnUserInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserInformation.Location = new System.Drawing.Point(24, 131);
            this.btnUserInformation.Name = "btnUserInformation";
            this.btnUserInformation.Size = new System.Drawing.Size(165, 59);
            this.btnUserInformation.TabIndex = 5;
            this.btnUserInformation.Text = "User Information";
            this.btnUserInformation.UseVisualStyleBackColor = true;
            this.btnUserInformation.Click += new System.EventHandler(this.btnUserInformation_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(24, 562);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(165, 43);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnAdminAddUser
            // 
            this.btnAdminAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminAddUser.Location = new System.Drawing.Point(24, 82);
            this.btnAdminAddUser.Name = "btnAdminAddUser";
            this.btnAdminAddUser.Size = new System.Drawing.Size(165, 43);
            this.btnAdminAddUser.TabIndex = 1;
            this.btnAdminAddUser.Text = "Add User";
            this.btnAdminAddUser.UseVisualStyleBackColor = true;
            this.btnAdminAddUser.Click += new System.EventHandler(this.btnAdminAddUser_Click);
            // 
            // btnAdminHome
            // 
            this.btnAdminHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminHome.Location = new System.Drawing.Point(24, 33);
            this.btnAdminHome.Name = "btnAdminHome";
            this.btnAdminHome.Size = new System.Drawing.Size(165, 43);
            this.btnAdminHome.TabIndex = 0;
            this.btnAdminHome.Text = "Home";
            this.btnAdminHome.UseVisualStyleBackColor = true;
            this.btnAdminHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbContr);
            this.panel1.Location = new System.Drawing.Point(218, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 614);
            this.panel1.TabIndex = 2;
            // 
            // tbContr
            // 
            this.tbContr.Controls.Add(this.tabPage1);
            this.tbContr.Controls.Add(this.tabPage2);
            this.tbContr.Controls.Add(this.tabPage3);
            this.tbContr.Controls.Add(this.tabPage6);
            this.tbContr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbContr.Location = new System.Drawing.Point(0, 0);
            this.tbContr.Name = "tbContr";
            this.tbContr.SelectedIndex = 0;
            this.tbContr.Size = new System.Drawing.Size(791, 614);
            this.tbContr.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.lblAdminHome);
            this.tabPage1.Controls.Add(this.lblAdminWelcome);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(783, 588);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "startAdmin";
            // 
            // lblAdminHome
            // 
            this.lblAdminHome.AutoSize = true;
            this.lblAdminHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminHome.Location = new System.Drawing.Point(340, 23);
            this.lblAdminHome.Name = "lblAdminHome";
            this.lblAdminHome.Size = new System.Drawing.Size(90, 31);
            this.lblAdminHome.TabIndex = 32;
            this.lblAdminHome.Text = "Home";
            // 
            // lblAdminWelcome
            // 
            this.lblAdminWelcome.AutoSize = true;
            this.lblAdminWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminWelcome.Location = new System.Drawing.Point(105, 100);
            this.lblAdminWelcome.Name = "lblAdminWelcome";
            this.lblAdminWelcome.Size = new System.Drawing.Size(264, 25);
            this.lblAdminWelcome.TabIndex = 31;
            this.lblAdminWelcome.Text = "Welcome to the Admin Panel";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.btnAddUser);
            this.tabPage2.Controls.Add(this.btnAddUserBack);
            this.tabPage2.Controls.Add(this.cBoxAddDepartment);
            this.tabPage2.Controls.Add(this.txtAddRepeatPassword);
            this.tabPage2.Controls.Add(this.lblAddRepeatPassword);
            this.tabPage2.Controls.Add(this.txtAddPassword);
            this.tabPage2.Controls.Add(this.lblAddPassword);
            this.tabPage2.Controls.Add(this.txtAddUserName);
            this.tabPage2.Controls.Add(this.lblAddUserName);
            this.tabPage2.Controls.Add(this.lblAddDepartment);
            this.tabPage2.Controls.Add(this.lblAdminRegister);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(783, 588);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "addUser";
            // 
            // btnAddUser
            // 
            this.btnAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.Location = new System.Drawing.Point(575, 540);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(84, 60);
            this.btnAddUser.TabIndex = 190;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnAddUserBack
            // 
            this.btnAddUserBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUserBack.Location = new System.Drawing.Point(665, 540);
            this.btnAddUserBack.Name = "btnAddUserBack";
            this.btnAddUserBack.Size = new System.Drawing.Size(84, 60);
            this.btnAddUserBack.TabIndex = 189;
            this.btnAddUserBack.Text = "Back";
            this.btnAddUserBack.UseVisualStyleBackColor = true;
            this.btnAddUserBack.Click += new System.EventHandler(this.btnBackToHome_Click);
            // 
            // cBoxAddDepartment
            // 
            this.cBoxAddDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxAddDepartment.FormattingEnabled = true;
            this.cBoxAddDepartment.Items.AddRange(new object[] {
            "Administrator",
            "Development",
            "Finance",
            "Sales"});
            this.cBoxAddDepartment.Location = new System.Drawing.Point(402, 248);
            this.cBoxAddDepartment.Name = "cBoxAddDepartment";
            this.cBoxAddDepartment.Size = new System.Drawing.Size(137, 21);
            this.cBoxAddDepartment.Sorted = true;
            this.cBoxAddDepartment.TabIndex = 35;
            // 
            // txtAddRepeatPassword
            // 
            this.txtAddRepeatPassword.Location = new System.Drawing.Point(402, 208);
            this.txtAddRepeatPassword.Name = "txtAddRepeatPassword";
            this.txtAddRepeatPassword.PasswordChar = '*';
            this.txtAddRepeatPassword.Size = new System.Drawing.Size(137, 20);
            this.txtAddRepeatPassword.TabIndex = 31;
            // 
            // lblAddRepeatPassword
            // 
            this.lblAddRepeatPassword.AutoSize = true;
            this.lblAddRepeatPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddRepeatPassword.Location = new System.Drawing.Point(194, 202);
            this.lblAddRepeatPassword.Name = "lblAddRepeatPassword";
            this.lblAddRepeatPassword.Size = new System.Drawing.Size(171, 25);
            this.lblAddRepeatPassword.TabIndex = 30;
            this.lblAddRepeatPassword.Text = "Repeat Password:";
            // 
            // txtAddPassword
            // 
            this.txtAddPassword.Location = new System.Drawing.Point(402, 171);
            this.txtAddPassword.Name = "txtAddPassword";
            this.txtAddPassword.PasswordChar = '*';
            this.txtAddPassword.Size = new System.Drawing.Size(137, 20);
            this.txtAddPassword.TabIndex = 29;
            // 
            // lblAddPassword
            // 
            this.lblAddPassword.AutoSize = true;
            this.lblAddPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddPassword.Location = new System.Drawing.Point(194, 165);
            this.lblAddPassword.Name = "lblAddPassword";
            this.lblAddPassword.Size = new System.Drawing.Size(104, 25);
            this.lblAddPassword.TabIndex = 28;
            this.lblAddPassword.Text = "Password:";
            // 
            // txtAddUserName
            // 
            this.txtAddUserName.Location = new System.Drawing.Point(402, 132);
            this.txtAddUserName.Name = "txtAddUserName";
            this.txtAddUserName.Size = new System.Drawing.Size(137, 20);
            this.txtAddUserName.TabIndex = 27;
            // 
            // lblAddUserName
            // 
            this.lblAddUserName.AutoSize = true;
            this.lblAddUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddUserName.Location = new System.Drawing.Point(194, 126);
            this.lblAddUserName.Name = "lblAddUserName";
            this.lblAddUserName.Size = new System.Drawing.Size(108, 25);
            this.lblAddUserName.TabIndex = 26;
            this.lblAddUserName.Text = "Username:";
            // 
            // lblAddDepartment
            // 
            this.lblAddDepartment.AutoSize = true;
            this.lblAddDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddDepartment.Location = new System.Drawing.Point(194, 242);
            this.lblAddDepartment.Name = "lblAddDepartment";
            this.lblAddDepartment.Size = new System.Drawing.Size(119, 25);
            this.lblAddDepartment.TabIndex = 24;
            this.lblAddDepartment.Text = "Department:";
            // 
            // lblAdminRegister
            // 
            this.lblAdminRegister.AutoSize = true;
            this.lblAdminRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminRegister.Location = new System.Drawing.Point(249, 23);
            this.lblAdminRegister.Name = "lblAdminRegister";
            this.lblAdminRegister.Size = new System.Drawing.Size(194, 31);
            this.lblAdminRegister.TabIndex = 19;
            this.lblAdminRegister.Text = "Register User";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.dgvUsers);
            this.tabPage3.Controls.Add(this.btnActivatedUsersBack);
            this.tabPage3.Controls.Add(this.lblUserInformation);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(783, 588);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "activatedUsers";
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToResizeRows = false;
            this.dgvUsers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvUsers.ColumnHeadersHeight = 34;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cActivateDeactivate,
            this.cUserID,
            this.cUsername,
            this.cDepartment,
            this.cDeactivated,
            this.cLastLogin});
            this.dgvUsers.Location = new System.Drawing.Point(9, 94);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.Size = new System.Drawing.Size(740, 440);
            this.dgvUsers.TabIndex = 189;
            this.dgvUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdminUserInfo_CellContentClick);
            // 
            // cActivateDeactivate
            // 
            this.cActivateDeactivate.Frozen = true;
            this.cActivateDeactivate.HeaderText = "Activate/Deactivate";
            this.cActivateDeactivate.Name = "cActivateDeactivate";
            this.cActivateDeactivate.ReadOnly = true;
            this.cActivateDeactivate.Text = "Activate/Deactivate";
            this.cActivateDeactivate.UseColumnTextForButtonValue = true;
            this.cActivateDeactivate.Width = 120;
            // 
            // cUserID
            // 
            this.cUserID.HeaderText = "UserID";
            this.cUserID.Name = "cUserID";
            this.cUserID.ReadOnly = true;
            this.cUserID.Visible = false;
            // 
            // cUsername
            // 
            this.cUsername.HeaderText = "Username";
            this.cUsername.Name = "cUsername";
            this.cUsername.ReadOnly = true;
            // 
            // cDepartment
            // 
            this.cDepartment.HeaderText = "Department";
            this.cDepartment.Name = "cDepartment";
            this.cDepartment.ReadOnly = true;
            // 
            // cDeactivated
            // 
            this.cDeactivated.HeaderText = "Deactivated";
            this.cDeactivated.Name = "cDeactivated";
            this.cDeactivated.ReadOnly = true;
            this.cDeactivated.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // cLastLogin
            // 
            dataGridViewCellStyle1.Format = "d";
            this.cLastLogin.DefaultCellStyle = dataGridViewCellStyle1;
            this.cLastLogin.HeaderText = "Last Login";
            this.cLastLogin.Name = "cLastLogin";
            this.cLastLogin.ReadOnly = true;
            // 
            // btnActivatedUsersBack
            // 
            this.btnActivatedUsersBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivatedUsersBack.Location = new System.Drawing.Point(665, 540);
            this.btnActivatedUsersBack.Name = "btnActivatedUsersBack";
            this.btnActivatedUsersBack.Size = new System.Drawing.Size(84, 60);
            this.btnActivatedUsersBack.TabIndex = 188;
            this.btnActivatedUsersBack.Text = "Back";
            this.btnActivatedUsersBack.UseVisualStyleBackColor = true;
            this.btnActivatedUsersBack.Click += new System.EventHandler(this.btnBackToHome_Click);
            // 
            // lblUserInformation
            // 
            this.lblUserInformation.AutoSize = true;
            this.lblUserInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserInformation.Location = new System.Drawing.Point(249, 23);
            this.lblUserInformation.Name = "lblUserInformation";
            this.lblUserInformation.Size = new System.Drawing.Size(231, 31);
            this.lblUserInformation.TabIndex = 20;
            this.lblUserInformation.Text = "User Information";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.btnArchivedCustomersBack);
            this.tabPage6.Controls.Add(this.dgvArchivedCustomers);
            this.tabPage6.Controls.Add(this.lblArchivedCustomer);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(783, 588);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "ArchivedCustomers";
            // 
            // btnArchivedCustomersBack
            // 
            this.btnArchivedCustomersBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchivedCustomersBack.Location = new System.Drawing.Point(665, 540);
            this.btnArchivedCustomersBack.Name = "btnArchivedCustomersBack";
            this.btnArchivedCustomersBack.Size = new System.Drawing.Size(84, 60);
            this.btnArchivedCustomersBack.TabIndex = 190;
            this.btnArchivedCustomersBack.Text = "Back";
            this.btnArchivedCustomersBack.UseVisualStyleBackColor = true;
            this.btnArchivedCustomersBack.Click += new System.EventHandler(this.btnBackToHome_Click);
            // 
            // dgvArchivedCustomers
            // 
            this.dgvArchivedCustomers.AllowUserToAddRows = false;
            this.dgvArchivedCustomers.AllowUserToDeleteRows = false;
            this.dgvArchivedCustomers.AllowUserToResizeRows = false;
            this.dgvArchivedCustomers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvArchivedCustomers.ColumnHeadersHeight = 34;
            this.dgvArchivedCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvArchivedCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cMakeVisible,
            this.cCustomerID,
            this.cCompanyName});
            this.dgvArchivedCustomers.Location = new System.Drawing.Point(9, 94);
            this.dgvArchivedCustomers.Name = "dgvArchivedCustomers";
            this.dgvArchivedCustomers.ReadOnly = true;
            this.dgvArchivedCustomers.RowHeadersVisible = false;
            this.dgvArchivedCustomers.Size = new System.Drawing.Size(740, 440);
            this.dgvArchivedCustomers.TabIndex = 26;
            this.dgvArchivedCustomers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArchivedCustomers_CellContentClick);
            // 
            // lblArchivedCustomer
            // 
            this.lblArchivedCustomer.AutoSize = true;
            this.lblArchivedCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArchivedCustomer.Location = new System.Drawing.Point(246, 23);
            this.lblArchivedCustomer.Name = "lblArchivedCustomer";
            this.lblArchivedCustomer.Size = new System.Drawing.Size(277, 31);
            this.lblArchivedCustomer.TabIndex = 25;
            this.lblArchivedCustomer.Text = "Archived Customers";
            // 
            // cMakeVisible
            // 
            this.cMakeVisible.HeaderText = "Make Visible";
            this.cMakeVisible.Name = "cMakeVisible";
            this.cMakeVisible.ReadOnly = true;
            this.cMakeVisible.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cMakeVisible.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cMakeVisible.Text = "Restore";
            this.cMakeVisible.UseColumnTextForButtonValue = true;
            // 
            // cCustomerID
            // 
            this.cCustomerID.HeaderText = "CustomerID";
            this.cCustomerID.Name = "cCustomerID";
            this.cCustomerID.ReadOnly = true;
            this.cCustomerID.Visible = false;
            // 
            // cCompanyName
            // 
            this.cCompanyName.HeaderText = "Company Name";
            this.cCompanyName.Name = "cCompanyName";
            this.cCompanyName.ReadOnly = true;
            this.cCompanyName.Width = 635;
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pButtons);
            this.Controls.Add(this.pWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAdmin_FormClosing);
            this.pWelcome.ResumeLayout(false);
            this.pWelcome.PerformLayout();
            this.pButtons.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tbContr.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchivedCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pWelcome;
        private System.Windows.Forms.Label lblAdminPanel;
        private System.Windows.Forms.Panel pButtons;
        private System.Windows.Forms.Button btnAdminAddUser;
        private System.Windows.Forms.Button btnAdminHome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel1;
        private TablessControl tbContr;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblAdminWelcome;
        private System.Windows.Forms.TextBox txtAddRepeatPassword;
        private System.Windows.Forms.Label lblAddRepeatPassword;
        private System.Windows.Forms.TextBox txtAddPassword;
        private System.Windows.Forms.Label lblAddPassword;
        private System.Windows.Forms.TextBox txtAddUserName;
        private System.Windows.Forms.Label lblAddUserName;
        private System.Windows.Forms.Label lblAddDepartment;
        private System.Windows.Forms.Label lblAdminRegister;
        private System.Windows.Forms.Label lblAdminHome;
        private System.Windows.Forms.ComboBox cBoxAddDepartment;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblUserInformation;
        private System.Windows.Forms.Button btnActivatedUsersBack;
        private System.Windows.Forms.Button btnAddUserBack;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnUserInformation;
        private System.Windows.Forms.Button btnArchivedCustomers;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridView dgvArchivedCustomers;
        private System.Windows.Forms.Label lblArchivedCustomer;
        private System.Windows.Forms.Button btnArchivedCustomersBack;
        private System.Windows.Forms.DataGridViewButtonColumn cActivateDeactivate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDeactivated;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLastLogin;
        private System.Windows.Forms.DataGridViewButtonColumn cMakeVisible;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCompanyName;
    }
}