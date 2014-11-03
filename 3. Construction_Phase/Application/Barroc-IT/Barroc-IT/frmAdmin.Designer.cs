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
            this.pWelcome = new System.Windows.Forms.Panel();
            this.lblAdminPanel = new System.Windows.Forms.Label();
            this.pButtons = new System.Windows.Forms.Panel();
            this.btnUserInformation = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnDeactivatedUsers = new System.Windows.Forms.Button();
            this.btnActivatedUsers = new System.Windows.Forms.Button();
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
            this.dgvActivatedUsers = new System.Windows.Forms.DataGridView();
            this.cActivateDeactivate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDeactivated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLastLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActivatedUsersBack = new System.Windows.Forms.Button();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvDeactivatedUsers = new System.Windows.Forms.DataGridView();
            this.xActivatedDeactivated = new System.Windows.Forms.DataGridViewButtonColumn();
            this.xUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xDeactivated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xLastlogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDeactivatedUsersBack = new System.Windows.Forms.Button();
            this.lblDeactivatedUsers = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dgvUserInfo = new System.Windows.Forms.DataGridView();
            this.uUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uDeactivated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uLastLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAdminUserInfo = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnUserInfoBack = new System.Windows.Forms.Button();
            this.pWelcome.SuspendLayout();
            this.pButtons.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tbContr.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivatedUsers)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeactivatedUsers)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // pWelcome
            // 
            this.pWelcome.BackColor = System.Drawing.SystemColors.Control;
            this.pWelcome.Controls.Add(this.lblAdminPanel);
            this.pWelcome.Location = new System.Drawing.Point(12, 12);
            this.pWelcome.Name = "pWelcome";
            this.pWelcome.Size = new System.Drawing.Size(984, 100);
            this.pWelcome.TabIndex = 0;
            // 
            // lblAdminPanel
            // 
            this.lblAdminPanel.AutoSize = true;
            this.lblAdminPanel.BackColor = System.Drawing.SystemColors.Control;
            this.lblAdminPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminPanel.Location = new System.Drawing.Point(305, 30);
            this.lblAdminPanel.Name = "lblAdminPanel";
            this.lblAdminPanel.Size = new System.Drawing.Size(314, 39);
            this.lblAdminPanel.TabIndex = 0;
            this.lblAdminPanel.Text = "Administrator Panel";
            // 
            // pButtons
            // 
            this.pButtons.BackColor = System.Drawing.SystemColors.Control;
            this.pButtons.Controls.Add(this.btnUserInformation);
            this.pButtons.Controls.Add(this.btnLogout);
            this.pButtons.Controls.Add(this.btnDeactivatedUsers);
            this.pButtons.Controls.Add(this.btnActivatedUsers);
            this.pButtons.Controls.Add(this.btnAdminAddUser);
            this.pButtons.Controls.Add(this.btnAdminHome);
            this.pButtons.Location = new System.Drawing.Point(12, 118);
            this.pButtons.Name = "pButtons";
            this.pButtons.Size = new System.Drawing.Size(211, 600);
            this.pButtons.TabIndex = 1;
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
            this.btnLogout.Location = new System.Drawing.Point(24, 533);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(165, 43);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnDeactivatedUsers
            // 
            this.btnDeactivatedUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeactivatedUsers.Location = new System.Drawing.Point(24, 261);
            this.btnDeactivatedUsers.Name = "btnDeactivatedUsers";
            this.btnDeactivatedUsers.Size = new System.Drawing.Size(165, 59);
            this.btnDeactivatedUsers.TabIndex = 3;
            this.btnDeactivatedUsers.Text = "Deactivated Users";
            this.btnDeactivatedUsers.UseVisualStyleBackColor = true;
            this.btnDeactivatedUsers.Click += new System.EventHandler(this.btnDeactivatedUsers_Click);
            // 
            // btnActivatedUsers
            // 
            this.btnActivatedUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivatedUsers.Location = new System.Drawing.Point(24, 196);
            this.btnActivatedUsers.Name = "btnActivatedUsers";
            this.btnActivatedUsers.Size = new System.Drawing.Size(165, 59);
            this.btnActivatedUsers.TabIndex = 2;
            this.btnActivatedUsers.Text = "Activated Users";
            this.btnActivatedUsers.UseVisualStyleBackColor = true;
            this.btnActivatedUsers.Click += new System.EventHandler(this.btnActivatedUsers_Click);
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
            this.btnAdminAddUser.Click += new System.EventHandler(this.btnRegister_Click);
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
            this.panel1.Location = new System.Drawing.Point(229, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(767, 600);
            this.panel1.TabIndex = 2;
            // 
            // tbContr
            // 
            this.tbContr.Controls.Add(this.tabPage1);
            this.tbContr.Controls.Add(this.tabPage2);
            this.tbContr.Controls.Add(this.tabPage3);
            this.tbContr.Controls.Add(this.tabPage4);
            this.tbContr.Controls.Add(this.tabPage5);
            this.tbContr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbContr.Location = new System.Drawing.Point(0, 0);
            this.tbContr.Name = "tbContr";
            this.tbContr.SelectedIndex = 0;
            this.tbContr.Size = new System.Drawing.Size(767, 600);
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
            this.tabPage1.Size = new System.Drawing.Size(759, 574);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "startAdmin";
            // 
            // lblAdminHome
            // 
            this.lblAdminHome.AutoSize = true;
            this.lblAdminHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminHome.Location = new System.Drawing.Point(326, 39);
            this.lblAdminHome.Name = "lblAdminHome";
            this.lblAdminHome.Size = new System.Drawing.Size(90, 31);
            this.lblAdminHome.TabIndex = 32;
            this.lblAdminHome.Text = "Home";
            // 
            // lblAdminWelcome
            // 
            this.lblAdminWelcome.AutoSize = true;
            this.lblAdminWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminWelcome.Location = new System.Drawing.Point(104, 126);
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
            this.tabPage2.Size = new System.Drawing.Size(759, 574);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "addUser";
            // 
            // btnAddUser
            // 
            this.btnAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.Location = new System.Drawing.Point(582, 541);
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
            this.btnAddUserBack.Location = new System.Drawing.Point(672, 541);
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
            this.cBoxAddDepartment.Location = new System.Drawing.Point(423, 213);
            this.cBoxAddDepartment.Name = "cBoxAddDepartment";
            this.cBoxAddDepartment.Size = new System.Drawing.Size(137, 21);
            this.cBoxAddDepartment.Sorted = true;
            this.cBoxAddDepartment.TabIndex = 35;
            // 
            // txtAddRepeatPassword
            // 
            this.txtAddRepeatPassword.Location = new System.Drawing.Point(423, 173);
            this.txtAddRepeatPassword.Name = "txtAddRepeatPassword";
            this.txtAddRepeatPassword.Size = new System.Drawing.Size(137, 20);
            this.txtAddRepeatPassword.TabIndex = 31;
            // 
            // lblAddRepeatPassword
            // 
            this.lblAddRepeatPassword.AutoSize = true;
            this.lblAddRepeatPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddRepeatPassword.Location = new System.Drawing.Point(215, 167);
            this.lblAddRepeatPassword.Name = "lblAddRepeatPassword";
            this.lblAddRepeatPassword.Size = new System.Drawing.Size(171, 25);
            this.lblAddRepeatPassword.TabIndex = 30;
            this.lblAddRepeatPassword.Text = "Repeat Password:";
            // 
            // txtAddPassword
            // 
            this.txtAddPassword.Location = new System.Drawing.Point(423, 136);
            this.txtAddPassword.Name = "txtAddPassword";
            this.txtAddPassword.Size = new System.Drawing.Size(137, 20);
            this.txtAddPassword.TabIndex = 29;
            // 
            // lblAddPassword
            // 
            this.lblAddPassword.AutoSize = true;
            this.lblAddPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddPassword.Location = new System.Drawing.Point(215, 130);
            this.lblAddPassword.Name = "lblAddPassword";
            this.lblAddPassword.Size = new System.Drawing.Size(104, 25);
            this.lblAddPassword.TabIndex = 28;
            this.lblAddPassword.Text = "Password:";
            // 
            // txtAddUserName
            // 
            this.txtAddUserName.Location = new System.Drawing.Point(423, 97);
            this.txtAddUserName.Name = "txtAddUserName";
            this.txtAddUserName.Size = new System.Drawing.Size(137, 20);
            this.txtAddUserName.TabIndex = 27;
            // 
            // lblAddUserName
            // 
            this.lblAddUserName.AutoSize = true;
            this.lblAddUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddUserName.Location = new System.Drawing.Point(215, 91);
            this.lblAddUserName.Name = "lblAddUserName";
            this.lblAddUserName.Size = new System.Drawing.Size(108, 25);
            this.lblAddUserName.TabIndex = 26;
            this.lblAddUserName.Text = "Username:";
            // 
            // lblAddDepartment
            // 
            this.lblAddDepartment.AutoSize = true;
            this.lblAddDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddDepartment.Location = new System.Drawing.Point(215, 207);
            this.lblAddDepartment.Name = "lblAddDepartment";
            this.lblAddDepartment.Size = new System.Drawing.Size(119, 25);
            this.lblAddDepartment.TabIndex = 24;
            this.lblAddDepartment.Text = "Department:";
            // 
            // lblAdminRegister
            // 
            this.lblAdminRegister.AutoSize = true;
            this.lblAdminRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminRegister.Location = new System.Drawing.Point(283, 14);
            this.lblAdminRegister.Name = "lblAdminRegister";
            this.lblAdminRegister.Size = new System.Drawing.Size(194, 31);
            this.lblAdminRegister.TabIndex = 19;
            this.lblAdminRegister.Text = "Register User";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.dgvActivatedUsers);
            this.tabPage3.Controls.Add(this.btnActivatedUsersBack);
            this.tabPage3.Controls.Add(this.lblUserInfo);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(759, 574);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "activatedUsers";
            // 
            // dgvActivatedUsers
            // 
            this.dgvActivatedUsers.AllowUserToAddRows = false;
            this.dgvActivatedUsers.AllowUserToDeleteRows = false;
            this.dgvActivatedUsers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvActivatedUsers.ColumnHeadersHeight = 34;
            this.dgvActivatedUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvActivatedUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cActivateDeactivate,
            this.cUserID,
            this.cUsername,
            this.cDepartment,
            this.cDeactivated,
            this.cLastLogin});
            this.dgvActivatedUsers.Location = new System.Drawing.Point(9, 34);
            this.dgvActivatedUsers.MultiSelect = false;
            this.dgvActivatedUsers.Name = "dgvActivatedUsers";
            this.dgvActivatedUsers.ReadOnly = true;
            this.dgvActivatedUsers.RowHeadersVisible = false;
            this.dgvActivatedUsers.Size = new System.Drawing.Size(744, 506);
            this.dgvActivatedUsers.TabIndex = 189;
            this.dgvActivatedUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdminUserInfo_CellContentClick);
            // 
            // cActivateDeactivate
            // 
            this.cActivateDeactivate.Frozen = true;
            this.cActivateDeactivate.HeaderText = "Activate/Deactivate";
            this.cActivateDeactivate.Name = "cActivateDeactivate";
            this.cActivateDeactivate.ReadOnly = true;
            this.cActivateDeactivate.Text = "";
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
            this.cLastLogin.HeaderText = "Last Login";
            this.cLastLogin.Name = "cLastLogin";
            this.cLastLogin.ReadOnly = true;
            // 
            // btnActivatedUsersBack
            // 
            this.btnActivatedUsersBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivatedUsersBack.Location = new System.Drawing.Point(669, 538);
            this.btnActivatedUsersBack.Name = "btnActivatedUsersBack";
            this.btnActivatedUsersBack.Size = new System.Drawing.Size(84, 60);
            this.btnActivatedUsersBack.TabIndex = 188;
            this.btnActivatedUsersBack.Text = "Back";
            this.btnActivatedUsersBack.UseVisualStyleBackColor = true;
            this.btnActivatedUsersBack.Click += new System.EventHandler(this.btnBackToHome_Click);
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserInfo.Location = new System.Drawing.Point(273, 60);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(231, 31);
            this.lblUserInfo.TabIndex = 20;
            this.lblUserInfo.Text = "User Information";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.dgvDeactivatedUsers);
            this.tabPage4.Controls.Add(this.btnDeactivatedUsersBack);
            this.tabPage4.Controls.Add(this.lblDeactivatedUsers);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(759, 574);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "deactivatedUsers";
            // 
            // dgvDeactivatedUsers
            // 
            this.dgvDeactivatedUsers.AllowUserToAddRows = false;
            this.dgvDeactivatedUsers.AllowUserToDeleteRows = false;
            this.dgvDeactivatedUsers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDeactivatedUsers.ColumnHeadersHeight = 34;
            this.dgvDeactivatedUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDeactivatedUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xActivatedDeactivated,
            this.xUserID,
            this.xUsername,
            this.xDepartment,
            this.xDeactivated,
            this.xLastlogin});
            this.dgvDeactivatedUsers.Location = new System.Drawing.Point(9, 94);
            this.dgvDeactivatedUsers.MultiSelect = false;
            this.dgvDeactivatedUsers.Name = "dgvDeactivatedUsers";
            this.dgvDeactivatedUsers.ReadOnly = true;
            this.dgvDeactivatedUsers.RowHeadersVisible = false;
            this.dgvDeactivatedUsers.Size = new System.Drawing.Size(744, 440);
            this.dgvDeactivatedUsers.TabIndex = 190;
            this.dgvDeactivatedUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeactivatedUsers_CellContentClick);
            // 
            // xActivatedDeactivated
            // 
            this.xActivatedDeactivated.Frozen = true;
            this.xActivatedDeactivated.HeaderText = "Activate/Deactivate";
            this.xActivatedDeactivated.Name = "xActivatedDeactivated";
            this.xActivatedDeactivated.ReadOnly = true;
            this.xActivatedDeactivated.Text = "";
            this.xActivatedDeactivated.UseColumnTextForButtonValue = true;
            this.xActivatedDeactivated.Width = 120;
            // 
            // xUserID
            // 
            this.xUserID.HeaderText = "UserID";
            this.xUserID.Name = "xUserID";
            this.xUserID.ReadOnly = true;
            this.xUserID.Visible = false;
            // 
            // xUsername
            // 
            this.xUsername.HeaderText = "Username";
            this.xUsername.Name = "xUsername";
            this.xUsername.ReadOnly = true;
            // 
            // xDepartment
            // 
            this.xDepartment.HeaderText = "Department";
            this.xDepartment.Name = "xDepartment";
            this.xDepartment.ReadOnly = true;
            // 
            // xDeactivated
            // 
            this.xDeactivated.HeaderText = "Deactivated";
            this.xDeactivated.Name = "xDeactivated";
            this.xDeactivated.ReadOnly = true;
            this.xDeactivated.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // xLastlogin
            // 
            this.xLastlogin.HeaderText = "Last Login";
            this.xLastlogin.Name = "xLastlogin";
            this.xLastlogin.ReadOnly = true;
            // 
            // btnDeactivatedUsersBack
            // 
            this.btnDeactivatedUsersBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeactivatedUsersBack.Location = new System.Drawing.Point(668, 540);
            this.btnDeactivatedUsersBack.Name = "btnDeactivatedUsersBack";
            this.btnDeactivatedUsersBack.Size = new System.Drawing.Size(84, 60);
            this.btnDeactivatedUsersBack.TabIndex = 189;
            this.btnDeactivatedUsersBack.Text = "Back";
            this.btnDeactivatedUsersBack.UseVisualStyleBackColor = true;
            this.btnDeactivatedUsersBack.Click += new System.EventHandler(this.btnBackToHome_Click);
            // 
            // lblDeactivatedUsers
            // 
            this.lblDeactivatedUsers.AutoSize = true;
            this.lblDeactivatedUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeactivatedUsers.Location = new System.Drawing.Point(249, 23);
            this.lblDeactivatedUsers.Name = "lblDeactivatedUsers";
            this.lblDeactivatedUsers.Size = new System.Drawing.Size(255, 31);
            this.lblDeactivatedUsers.TabIndex = 23;
            this.lblDeactivatedUsers.Text = "Deactivated Users";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage5.Controls.Add(this.btnUserInfoBack);
            this.tabPage5.Controls.Add(this.dgvUserInfo);
            this.tabPage5.Controls.Add(this.lblAdminUserInfo);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(759, 574);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "userInformation";
            // 
            // dgvUserInfo
            // 
            this.dgvUserInfo.AllowUserToAddRows = false;
            this.dgvUserInfo.AllowUserToDeleteRows = false;
            this.dgvUserInfo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvUserInfo.ColumnHeadersHeight = 34;
            this.dgvUserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUserInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uUserID,
            this.uUsername,
            this.uDepartment,
            this.uDeactivated,
            this.uLastLogin});
            this.dgvUserInfo.Location = new System.Drawing.Point(7, 67);
            this.dgvUserInfo.MultiSelect = false;
            this.dgvUserInfo.Name = "dgvUserInfo";
            this.dgvUserInfo.ReadOnly = true;
            this.dgvUserInfo.RowHeadersVisible = false;
            this.dgvUserInfo.Size = new System.Drawing.Size(744, 440);
            this.dgvUserInfo.TabIndex = 191;
            // 
            // uUserID
            // 
            this.uUserID.HeaderText = "UserID";
            this.uUserID.Name = "uUserID";
            this.uUserID.ReadOnly = true;
            this.uUserID.Visible = false;
            // 
            // uUsername
            // 
            this.uUsername.HeaderText = "Username";
            this.uUsername.Name = "uUsername";
            this.uUsername.ReadOnly = true;
            // 
            // uDepartment
            // 
            this.uDepartment.HeaderText = "Department";
            this.uDepartment.Name = "uDepartment";
            this.uDepartment.ReadOnly = true;
            // 
            // uDeactivated
            // 
            this.uDeactivated.HeaderText = "Deactivated";
            this.uDeactivated.Name = "uDeactivated";
            this.uDeactivated.ReadOnly = true;
            this.uDeactivated.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // uLastLogin
            // 
            this.uLastLogin.HeaderText = "Last Login";
            this.uLastLogin.Name = "uLastLogin";
            this.uLastLogin.ReadOnly = true;
            // 
            // lblAdminUserInfo
            // 
            this.lblAdminUserInfo.AutoSize = true;
            this.lblAdminUserInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminUserInfo.Location = new System.Drawing.Point(253, 23);
            this.lblAdminUserInfo.Name = "lblAdminUserInfo";
            this.lblAdminUserInfo.Size = new System.Drawing.Size(231, 31);
            this.lblAdminUserInfo.TabIndex = 24;
            this.lblAdminUserInfo.Text = "User Information";
            // 
            // btnUserInfoBack
            // 
            this.btnUserInfoBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserInfoBack.Location = new System.Drawing.Point(667, 513);
            this.btnUserInfoBack.Name = "btnUserInfoBack";
            this.btnUserInfoBack.Size = new System.Drawing.Size(84, 60);
            this.btnUserInfoBack.TabIndex = 192;
            this.btnUserInfoBack.Text = "Back";
            this.btnUserInfoBack.UseVisualStyleBackColor = true;
            this.btnUserInfoBack.Click += new System.EventHandler(this.btnBackToHome_Click);
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pButtons);
            this.Controls.Add(this.pWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin_Panel";
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivatedUsers)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeactivatedUsers)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pWelcome;
        private System.Windows.Forms.Label lblAdminPanel;
        private System.Windows.Forms.Panel pButtons;
        private System.Windows.Forms.Button btnDeactivatedUsers;
        private System.Windows.Forms.Button btnActivatedUsers;
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
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label lblAdminHome;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lblDeactivatedUsers;
        private System.Windows.Forms.ComboBox cBoxAddDepartment;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Button btnActivatedUsersBack;
        private System.Windows.Forms.Button btnAddUserBack;
        private System.Windows.Forms.Button btnDeactivatedUsersBack;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.DataGridView dgvActivatedUsers;
        private System.Windows.Forms.DataGridView dgvDeactivatedUsers;
        private System.Windows.Forms.DataGridViewButtonColumn xActivatedDeactivated;
        private System.Windows.Forms.DataGridViewTextBoxColumn xUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn xUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn xDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn xDeactivated;
        private System.Windows.Forms.DataGridViewTextBoxColumn xLastlogin;
        private System.Windows.Forms.Button btnUserInformation;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label lblAdminUserInfo;
        private System.Windows.Forms.DataGridView dgvUserInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn uUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn uUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn uDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn uDeactivated;
        private System.Windows.Forms.DataGridViewTextBoxColumn uLastLogin;
        private System.Windows.Forms.DataGridViewButtonColumn cActivateDeactivate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDeactivated;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLastLogin;
        private System.Windows.Forms.Button btnUserInfoBack;
    }
}