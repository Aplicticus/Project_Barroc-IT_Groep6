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
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnAdminDeactivatedUsers = new System.Windows.Forms.Button();
            this.btnAdminUserInfo = new System.Windows.Forms.Button();
            this.btnAdminRegister = new System.Windows.Forms.Button();
            this.btnAdminHome = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbContr = new TablessControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblAdminHome = new System.Windows.Forms.Label();
            this.lblAdminWelcome = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtAdminRepeatPassword = new System.Windows.Forms.TextBox();
            this.lblAdminRepeatPassword = new System.Windows.Forms.Label();
            this.txtAdminPassword = new System.Windows.Forms.TextBox();
            this.lblAdminPassword = new System.Windows.Forms.Label();
            this.txtAdminUsername = new System.Windows.Forms.TextBox();
            this.lblAdminUsername = new System.Windows.Forms.Label();
            this.dAdminDownDepartment = new System.Windows.Forms.DomainUpDown();
            this.lblAdminDepartment = new System.Windows.Forms.Label();
            this.txtAdminInsertion = new System.Windows.Forms.TextBox();
            this.lblAdminInsertion = new System.Windows.Forms.Label();
            this.txtAdminSurname = new System.Windows.Forms.TextBox();
            this.lblAdminSurname = new System.Windows.Forms.Label();
            this.lblAdminRegister = new System.Windows.Forms.Label();
            this.lblAdminName = new System.Windows.Forms.Label();
            this.txtAdminName = new System.Windows.Forms.TextBox();
            this.btnAdminConfirmRegister = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.DGVUserInfo = new System.Windows.Forms.DataGridView();
            this.cUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLastLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDeactivate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lblDeactivatedUsers = new System.Windows.Forms.Label();
            this.DGVDeactivatedUsers = new System.Windows.Forms.DataGridView();
            this.dUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dLastLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dActivate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pWelcome.SuspendLayout();
            this.pButtons.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tbContr.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUserInfo)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDeactivatedUsers)).BeginInit();
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
            this.pButtons.Controls.Add(this.btnLogout);
            this.pButtons.Controls.Add(this.btnAdminDeactivatedUsers);
            this.pButtons.Controls.Add(this.btnAdminUserInfo);
            this.pButtons.Controls.Add(this.btnAdminRegister);
            this.pButtons.Controls.Add(this.btnAdminHome);
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
            // btnAdminDeactivatedUsers
            // 
            this.btnAdminDeactivatedUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminDeactivatedUsers.Location = new System.Drawing.Point(24, 240);
            this.btnAdminDeactivatedUsers.Name = "btnAdminDeactivatedUsers";
            this.btnAdminDeactivatedUsers.Size = new System.Drawing.Size(165, 43);
            this.btnAdminDeactivatedUsers.TabIndex = 3;
            this.btnAdminDeactivatedUsers.Text = "Deactived Users";
            this.btnAdminDeactivatedUsers.UseVisualStyleBackColor = true;
            this.btnAdminDeactivatedUsers.Click += new System.EventHandler(this.btnDeactivatedUsers_Click);
            // 
            // btnAdminUserInfo
            // 
            this.btnAdminUserInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminUserInfo.Location = new System.Drawing.Point(24, 172);
            this.btnAdminUserInfo.Name = "btnAdminUserInfo";
            this.btnAdminUserInfo.Size = new System.Drawing.Size(165, 43);
            this.btnAdminUserInfo.TabIndex = 2;
            this.btnAdminUserInfo.Text = "User Information";
            this.btnAdminUserInfo.UseVisualStyleBackColor = true;
            this.btnAdminUserInfo.Click += new System.EventHandler(this.btnUserInfo_Click);
            // 
            // btnAdminRegister
            // 
            this.btnAdminRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminRegister.Location = new System.Drawing.Point(24, 104);
            this.btnAdminRegister.Name = "btnAdminRegister";
            this.btnAdminRegister.Size = new System.Drawing.Size(165, 43);
            this.btnAdminRegister.TabIndex = 1;
            this.btnAdminRegister.Text = "Register";
            this.btnAdminRegister.UseVisualStyleBackColor = true;
            this.btnAdminRegister.Click += new System.EventHandler(this.btnRegister_Click);
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
            this.tbContr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbContr.Location = new System.Drawing.Point(0, 0);
            this.tbContr.Name = "tbContr";
            this.tbContr.SelectedIndex = 0;
            this.tbContr.Size = new System.Drawing.Size(767, 600);
            this.tbContr.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblAdminHome);
            this.tabPage1.Controls.Add(this.lblAdminWelcome);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(759, 574);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.lblAdminWelcome.Size = new System.Drawing.Size(219, 25);
            this.lblAdminWelcome.TabIndex = 31;
            this.lblAdminWelcome.Text = "Welcome, Administrator";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtAdminRepeatPassword);
            this.tabPage2.Controls.Add(this.lblAdminRepeatPassword);
            this.tabPage2.Controls.Add(this.txtAdminPassword);
            this.tabPage2.Controls.Add(this.lblAdminPassword);
            this.tabPage2.Controls.Add(this.txtAdminUsername);
            this.tabPage2.Controls.Add(this.lblAdminUsername);
            this.tabPage2.Controls.Add(this.dAdminDownDepartment);
            this.tabPage2.Controls.Add(this.lblAdminDepartment);
            this.tabPage2.Controls.Add(this.txtAdminInsertion);
            this.tabPage2.Controls.Add(this.lblAdminInsertion);
            this.tabPage2.Controls.Add(this.txtAdminSurname);
            this.tabPage2.Controls.Add(this.lblAdminSurname);
            this.tabPage2.Controls.Add(this.lblAdminRegister);
            this.tabPage2.Controls.Add(this.lblAdminName);
            this.tabPage2.Controls.Add(this.txtAdminName);
            this.tabPage2.Controls.Add(this.btnAdminConfirmRegister);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(759, 574);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtAdminRepeatPassword
            // 
            this.txtAdminRepeatPassword.Location = new System.Drawing.Point(415, 371);
            this.txtAdminRepeatPassword.Name = "txtAdminRepeatPassword";
            this.txtAdminRepeatPassword.Size = new System.Drawing.Size(137, 20);
            this.txtAdminRepeatPassword.TabIndex = 31;
            // 
            // lblAdminRepeatPassword
            // 
            this.lblAdminRepeatPassword.AutoSize = true;
            this.lblAdminRepeatPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminRepeatPassword.Location = new System.Drawing.Point(207, 365);
            this.lblAdminRepeatPassword.Name = "lblAdminRepeatPassword";
            this.lblAdminRepeatPassword.Size = new System.Drawing.Size(171, 25);
            this.lblAdminRepeatPassword.TabIndex = 30;
            this.lblAdminRepeatPassword.Text = "Repeat Password:";
            // 
            // txtAdminPassword
            // 
            this.txtAdminPassword.Location = new System.Drawing.Point(415, 328);
            this.txtAdminPassword.Name = "txtAdminPassword";
            this.txtAdminPassword.Size = new System.Drawing.Size(137, 20);
            this.txtAdminPassword.TabIndex = 29;
            // 
            // lblAdminPassword
            // 
            this.lblAdminPassword.AutoSize = true;
            this.lblAdminPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminPassword.Location = new System.Drawing.Point(207, 322);
            this.lblAdminPassword.Name = "lblAdminPassword";
            this.lblAdminPassword.Size = new System.Drawing.Size(104, 25);
            this.lblAdminPassword.TabIndex = 28;
            this.lblAdminPassword.Text = "Password:";
            // 
            // txtAdminUsername
            // 
            this.txtAdminUsername.Location = new System.Drawing.Point(415, 289);
            this.txtAdminUsername.Name = "txtAdminUsername";
            this.txtAdminUsername.Size = new System.Drawing.Size(137, 20);
            this.txtAdminUsername.TabIndex = 27;
            // 
            // lblAdminUsername
            // 
            this.lblAdminUsername.AutoSize = true;
            this.lblAdminUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminUsername.Location = new System.Drawing.Point(207, 283);
            this.lblAdminUsername.Name = "lblAdminUsername";
            this.lblAdminUsername.Size = new System.Drawing.Size(108, 25);
            this.lblAdminUsername.TabIndex = 26;
            this.lblAdminUsername.Text = "Username:";
            // 
            // dAdminDownDepartment
            // 
            this.dAdminDownDepartment.Location = new System.Drawing.Point(415, 246);
            this.dAdminDownDepartment.Name = "dAdminDownDepartment";
            this.dAdminDownDepartment.Size = new System.Drawing.Size(137, 20);
            this.dAdminDownDepartment.TabIndex = 25;
            // 
            // lblAdminDepartment
            // 
            this.lblAdminDepartment.AutoSize = true;
            this.lblAdminDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminDepartment.Location = new System.Drawing.Point(207, 242);
            this.lblAdminDepartment.Name = "lblAdminDepartment";
            this.lblAdminDepartment.Size = new System.Drawing.Size(119, 25);
            this.lblAdminDepartment.TabIndex = 24;
            this.lblAdminDepartment.Text = "Department:";
            // 
            // txtAdminInsertion
            // 
            this.txtAdminInsertion.Location = new System.Drawing.Point(415, 207);
            this.txtAdminInsertion.Name = "txtAdminInsertion";
            this.txtAdminInsertion.Size = new System.Drawing.Size(137, 20);
            this.txtAdminInsertion.TabIndex = 23;
            // 
            // lblAdminInsertion
            // 
            this.lblAdminInsertion.AutoSize = true;
            this.lblAdminInsertion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminInsertion.Location = new System.Drawing.Point(207, 201);
            this.lblAdminInsertion.Name = "lblAdminInsertion";
            this.lblAdminInsertion.Size = new System.Drawing.Size(92, 25);
            this.lblAdminInsertion.TabIndex = 22;
            this.lblAdminInsertion.Text = "Insertion:";
            // 
            // txtAdminSurname
            // 
            this.txtAdminSurname.Location = new System.Drawing.Point(415, 169);
            this.txtAdminSurname.Name = "txtAdminSurname";
            this.txtAdminSurname.Size = new System.Drawing.Size(137, 20);
            this.txtAdminSurname.TabIndex = 21;
            // 
            // lblAdminSurname
            // 
            this.lblAdminSurname.AutoSize = true;
            this.lblAdminSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminSurname.Location = new System.Drawing.Point(207, 163);
            this.lblAdminSurname.Name = "lblAdminSurname";
            this.lblAdminSurname.Size = new System.Drawing.Size(98, 25);
            this.lblAdminSurname.TabIndex = 20;
            this.lblAdminSurname.Text = "Surname:";
            // 
            // lblAdminRegister
            // 
            this.lblAdminRegister.AutoSize = true;
            this.lblAdminRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminRegister.Location = new System.Drawing.Point(297, 44);
            this.lblAdminRegister.Name = "lblAdminRegister";
            this.lblAdminRegister.Size = new System.Drawing.Size(124, 31);
            this.lblAdminRegister.TabIndex = 19;
            this.lblAdminRegister.Text = "Register";
            // 
            // lblAdminName
            // 
            this.lblAdminName.AutoSize = true;
            this.lblAdminName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminName.Location = new System.Drawing.Point(207, 125);
            this.lblAdminName.Name = "lblAdminName";
            this.lblAdminName.Size = new System.Drawing.Size(70, 25);
            this.lblAdminName.TabIndex = 18;
            this.lblAdminName.Text = "Name:";
            // 
            // txtAdminName
            // 
            this.txtAdminName.Location = new System.Drawing.Point(415, 131);
            this.txtAdminName.Name = "txtAdminName";
            this.txtAdminName.Size = new System.Drawing.Size(137, 20);
            this.txtAdminName.TabIndex = 17;
            // 
            // btnAdminConfirmRegister
            // 
            this.btnAdminConfirmRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminConfirmRegister.Location = new System.Drawing.Point(334, 479);
            this.btnAdminConfirmRegister.Name = "btnAdminConfirmRegister";
            this.btnAdminConfirmRegister.Size = new System.Drawing.Size(110, 32);
            this.btnAdminConfirmRegister.TabIndex = 16;
            this.btnAdminConfirmRegister.Text = "Register";
            this.btnAdminConfirmRegister.UseVisualStyleBackColor = true;
            this.btnAdminConfirmRegister.Click += new System.EventHandler(this.btnAdminConfirmRegister_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.DGVUserInfo);
            this.tabPage3.Controls.Add(this.lblUserInfo);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(759, 574);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // DGVUserInfo
            // 
            this.DGVUserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVUserInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cUserID,
            this.cName,
            this.cUsername,
            this.cDepartment,
            this.cEmail,
            this.cLastLogin,
            this.cDeactivate});
            this.DGVUserInfo.Location = new System.Drawing.Point(6, 94);
            this.DGVUserInfo.Name = "DGVUserInfo";
            this.DGVUserInfo.Size = new System.Drawing.Size(747, 477);
            this.DGVUserInfo.TabIndex = 21;
            // 
            // cUserID
            // 
            this.cUserID.HeaderText = "UserID";
            this.cUserID.Name = "cUserID";
            // 
            // cName
            // 
            this.cName.HeaderText = "Name";
            this.cName.Name = "cName";
            // 
            // cUsername
            // 
            this.cUsername.HeaderText = "Username";
            this.cUsername.Name = "cUsername";
            // 
            // cDepartment
            // 
            this.cDepartment.HeaderText = "Department";
            this.cDepartment.Name = "cDepartment";
            // 
            // cEmail
            // 
            this.cEmail.HeaderText = "E-mail";
            this.cEmail.Name = "cEmail";
            // 
            // cLastLogin
            // 
            this.cLastLogin.HeaderText = "Last Login";
            this.cLastLogin.Name = "cLastLogin";
            // 
            // cDeactivate
            // 
            this.cDeactivate.HeaderText = "Deactivate";
            this.cDeactivate.Name = "cDeactivate";
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
            this.tabPage4.Controls.Add(this.lblDeactivatedUsers);
            this.tabPage4.Controls.Add(this.DGVDeactivatedUsers);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(759, 574);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lblDeactivatedUsers
            // 
            this.lblDeactivatedUsers.AutoSize = true;
            this.lblDeactivatedUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeactivatedUsers.Location = new System.Drawing.Point(263, 56);
            this.lblDeactivatedUsers.Name = "lblDeactivatedUsers";
            this.lblDeactivatedUsers.Size = new System.Drawing.Size(255, 31);
            this.lblDeactivatedUsers.TabIndex = 23;
            this.lblDeactivatedUsers.Text = "Deactivated Users";
            // 
            // DGVDeactivatedUsers
            // 
            this.DGVDeactivatedUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVDeactivatedUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dUserID,
            this.dName,
            this.dUsername,
            this.dDepartment,
            this.dEmail,
            this.dLastLogin,
            this.dActivate});
            this.DGVDeactivatedUsers.Location = new System.Drawing.Point(6, 90);
            this.DGVDeactivatedUsers.Name = "DGVDeactivatedUsers";
            this.DGVDeactivatedUsers.Size = new System.Drawing.Size(747, 477);
            this.DGVDeactivatedUsers.TabIndex = 22;
            // 
            // dUserID
            // 
            this.dUserID.HeaderText = "UserID";
            this.dUserID.Name = "dUserID";
            // 
            // dName
            // 
            this.dName.HeaderText = "Name";
            this.dName.Name = "dName";
            // 
            // dUsername
            // 
            this.dUsername.HeaderText = "Username";
            this.dUsername.Name = "dUsername";
            // 
            // dDepartment
            // 
            this.dDepartment.HeaderText = "Department";
            this.dDepartment.Name = "dDepartment";
            // 
            // dEmail
            // 
            this.dEmail.HeaderText = "E-mail";
            this.dEmail.Name = "dEmail";
            // 
            // dLastLogin
            // 
            this.dLastLogin.HeaderText = "Last Login";
            this.dLastLogin.Name = "dLastLogin";
            // 
            // dActivate
            // 
            this.dActivate.HeaderText = "Activate";
            this.dActivate.Name = "dActivate";
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pButtons);
            this.Controls.Add(this.pWelcome);
            this.Name = "frmAdmin";
            this.Text = "Admin_Panel";
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
            ((System.ComponentModel.ISupportInitialize)(this.DGVUserInfo)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDeactivatedUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pWelcome;
        private System.Windows.Forms.Label lblAdminPanel;
        private System.Windows.Forms.Panel pButtons;
        private System.Windows.Forms.Button btnAdminDeactivatedUsers;
        private System.Windows.Forms.Button btnAdminUserInfo;
        private System.Windows.Forms.Button btnAdminRegister;
        private System.Windows.Forms.Button btnAdminHome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel1;
        private TablessControl tbContr;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblAdminWelcome;
        private System.Windows.Forms.TextBox txtAdminRepeatPassword;
        private System.Windows.Forms.Label lblAdminRepeatPassword;
        private System.Windows.Forms.TextBox txtAdminPassword;
        private System.Windows.Forms.Label lblAdminPassword;
        private System.Windows.Forms.TextBox txtAdminUsername;
        private System.Windows.Forms.Label lblAdminUsername;
        private System.Windows.Forms.DomainUpDown dAdminDownDepartment;
        private System.Windows.Forms.Label lblAdminDepartment;
        private System.Windows.Forms.TextBox txtAdminInsertion;
        private System.Windows.Forms.Label lblAdminInsertion;
        private System.Windows.Forms.TextBox txtAdminSurname;
        private System.Windows.Forms.Label lblAdminSurname;
        private System.Windows.Forms.Label lblAdminRegister;
        private System.Windows.Forms.Label lblAdminName;
        private System.Windows.Forms.TextBox txtAdminName;
        private System.Windows.Forms.Button btnAdminConfirmRegister;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label lblAdminHome;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.DataGridView DGVUserInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLastLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDeactivate;
        private System.Windows.Forms.DataGridView DGVDeactivatedUsers;
        private System.Windows.Forms.Label lblDeactivatedUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn dUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn dDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn dEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dLastLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dActivate;
    }
}