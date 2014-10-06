namespace Barroc_IT
{
    partial class frmDevelopment
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
            this.lblSalesPanel = new System.Windows.Forms.Label();
            this.pButtons = new System.Windows.Forms.Panel();
            this.btnDevSelectCustomer = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnSalesHome = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbContr = new TablessControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblSalesHome = new System.Windows.Forms.Label();
            this.lblSalesWelcome = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cBoxSearch = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.DGVUserInfo = new System.Windows.Forms.DataGridView();
            this.cViewCustomer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAddress1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPostalCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cResidence1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAddress2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPostalCode2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cResidence2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cContactPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cInitials = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPhoneNumber1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPhoneNumber2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFaxNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCustomers = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pWelcome.SuspendLayout();
            this.pButtons.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tbContr.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUserInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // pWelcome
            // 
            this.pWelcome.BackColor = System.Drawing.SystemColors.Control;
            this.pWelcome.Controls.Add(this.lblSalesPanel);
            this.pWelcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.pWelcome.Location = new System.Drawing.Point(0, 0);
            this.pWelcome.Name = "pWelcome";
            this.pWelcome.Size = new System.Drawing.Size(1008, 112);
            this.pWelcome.TabIndex = 0;
            // 
            // lblSalesPanel
            // 
            this.lblSalesPanel.AutoSize = true;
            this.lblSalesPanel.BackColor = System.Drawing.SystemColors.Control;
            this.lblSalesPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesPanel.Location = new System.Drawing.Point(407, 30);
            this.lblSalesPanel.Name = "lblSalesPanel";
            this.lblSalesPanel.Size = new System.Drawing.Size(315, 39);
            this.lblSalesPanel.TabIndex = 0;
            this.lblSalesPanel.Text = "Development Panel";
            // 
            // pButtons
            // 
            this.pButtons.BackColor = System.Drawing.SystemColors.Control;
            this.pButtons.Controls.Add(this.btnDevSelectCustomer);
            this.pButtons.Controls.Add(this.btnLogout);
            this.pButtons.Controls.Add(this.btnSalesHome);
            this.pButtons.Location = new System.Drawing.Point(0, 118);
            this.pButtons.Name = "pButtons";
            this.pButtons.Size = new System.Drawing.Size(223, 612);
            this.pButtons.TabIndex = 1;
            // 
            // btnDevSelectCustomer
            // 
            this.btnDevSelectCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDevSelectCustomer.Location = new System.Drawing.Point(24, 110);
            this.btnDevSelectCustomer.Name = "btnDevSelectCustomer";
            this.btnDevSelectCustomer.Size = new System.Drawing.Size(165, 43);
            this.btnDevSelectCustomer.TabIndex = 5;
            this.btnDevSelectCustomer.Text = "Select Customer";
            this.btnDevSelectCustomer.UseVisualStyleBackColor = true;
            this.btnDevSelectCustomer.Click += new System.EventHandler(this.btnDevSelectCustomer_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(24, 532);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(165, 43);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnSalesHome
            // 
            this.btnSalesHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesHome.Location = new System.Drawing.Point(24, 33);
            this.btnSalesHome.Name = "btnSalesHome";
            this.btnSalesHome.Size = new System.Drawing.Size(165, 43);
            this.btnSalesHome.TabIndex = 0;
            this.btnSalesHome.Text = "Home";
            this.btnSalesHome.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbContr);
            this.panel1.Location = new System.Drawing.Point(229, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(779, 612);
            this.panel1.TabIndex = 2;
            // 
            // tbContr
            // 
            this.tbContr.Controls.Add(this.tabPage1);
            this.tbContr.Controls.Add(this.tabPage2);
            this.tbContr.Controls.Add(this.tabPage3);
            this.tbContr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbContr.Location = new System.Drawing.Point(0, 0);
            this.tbContr.Name = "tbContr";
            this.tbContr.SelectedIndex = 0;
            this.tbContr.Size = new System.Drawing.Size(779, 612);
            this.tbContr.TabIndex = 0;
            this.tbContr.SelectedIndexChanged += new System.EventHandler(this.tbContr_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.lblSalesHome);
            this.tabPage1.Controls.Add(this.lblSalesWelcome);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(771, 586);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // lblSalesHome
            // 
            this.lblSalesHome.AutoSize = true;
            this.lblSalesHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesHome.Location = new System.Drawing.Point(326, 39);
            this.lblSalesHome.Name = "lblSalesHome";
            this.lblSalesHome.Size = new System.Drawing.Size(90, 31);
            this.lblSalesHome.TabIndex = 32;
            this.lblSalesHome.Text = "Home";
            // 
            // lblSalesWelcome
            // 
            this.lblSalesWelcome.AutoSize = true;
            this.lblSalesWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesWelcome.Location = new System.Drawing.Point(104, 126);
            this.lblSalesWelcome.Name = "lblSalesWelcome";
            this.lblSalesWelcome.Size = new System.Drawing.Size(323, 25);
            this.lblSalesWelcome.TabIndex = 31;
            this.lblSalesWelcome.Text = "Welcome to the Development Panel";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.cBoxSearch);
            this.tabPage2.Controls.Add(this.btnSearch);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.DGVUserInfo);
            this.tabPage2.Controls.Add(this.lblCustomers);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(771, 586);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // cBoxSearch
            // 
            this.cBoxSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxSearch.FormattingEnabled = true;
            this.cBoxSearch.Items.AddRange(new object[] {
            "Company Name",
            "E-Mail",
            "Initials"});
            this.cBoxSearch.Location = new System.Drawing.Point(438, 11);
            this.cBoxSearch.Name = "cBoxSearch";
            this.cBoxSearch.Size = new System.Drawing.Size(121, 21);
            this.cBoxSearch.Sorted = true;
            this.cBoxSearch.TabIndex = 26;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(688, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 25;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(565, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(119, 20);
            this.textBox1.TabIndex = 24;
            // 
            // DGVUserInfo
            // 
            this.DGVUserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVUserInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cViewCustomer,
            this.cCompanyName,
            this.cAddress1,
            this.cPostalCode1,
            this.cResidence1,
            this.cAddress2,
            this.cPostalCode2,
            this.cResidence2,
            this.cContactPerson,
            this.cInitials,
            this.cPhoneNumber1,
            this.cPhoneNumber2,
            this.cFaxNumber,
            this.cEmail});
            this.DGVUserInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGVUserInfo.Location = new System.Drawing.Point(0, 23);
            this.DGVUserInfo.Name = "DGVUserInfo";
            this.DGVUserInfo.Size = new System.Drawing.Size(771, 563);
            this.DGVUserInfo.TabIndex = 23;
            // 
            // cViewCustomer
            // 
            this.cViewCustomer.HeaderText = "View";
            this.cViewCustomer.Name = "cViewCustomer";
            this.cViewCustomer.Text = "View";
            // 
            // cCompanyName
            // 
            this.cCompanyName.HeaderText = "Company Name";
            this.cCompanyName.Name = "cCompanyName";
            // 
            // cAddress1
            // 
            this.cAddress1.HeaderText = "Address 1";
            this.cAddress1.Name = "cAddress1";
            // 
            // cPostalCode1
            // 
            this.cPostalCode1.HeaderText = "Postal Code 1";
            this.cPostalCode1.Name = "cPostalCode1";
            // 
            // cResidence1
            // 
            this.cResidence1.HeaderText = "Residence 1";
            this.cResidence1.Name = "cResidence1";
            // 
            // cAddress2
            // 
            this.cAddress2.HeaderText = "Address 2";
            this.cAddress2.Name = "cAddress2";
            // 
            // cPostalCode2
            // 
            this.cPostalCode2.HeaderText = "Postal Code 2";
            this.cPostalCode2.Name = "cPostalCode2";
            // 
            // cResidence2
            // 
            this.cResidence2.HeaderText = "Residence 2";
            this.cResidence2.Name = "cResidence2";
            // 
            // cContactPerson
            // 
            this.cContactPerson.HeaderText = "Contactperson";
            this.cContactPerson.Name = "cContactPerson";
            // 
            // cInitials
            // 
            this.cInitials.HeaderText = "Initials";
            this.cInitials.Name = "cInitials";
            // 
            // cPhoneNumber1
            // 
            this.cPhoneNumber1.HeaderText = "Phone Number 1";
            this.cPhoneNumber1.Name = "cPhoneNumber1";
            // 
            // cPhoneNumber2
            // 
            this.cPhoneNumber2.HeaderText = "Phone Number 2";
            this.cPhoneNumber2.Name = "cPhoneNumber2";
            // 
            // cFaxNumber
            // 
            this.cFaxNumber.HeaderText = "Fax Number";
            this.cFaxNumber.Name = "cFaxNumber";
            // 
            // cEmail
            // 
            this.cEmail.HeaderText = "E-Mail";
            this.cEmail.Name = "cEmail";
            // 
            // lblCustomers
            // 
            this.lblCustomers.AutoSize = true;
            this.lblCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomers.Location = new System.Drawing.Point(3, 1);
            this.lblCustomers.Name = "lblCustomers";
            this.lblCustomers.Size = new System.Drawing.Size(155, 31);
            this.lblCustomers.TabIndex = 22;
            this.lblCustomers.Text = "Customers";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(771, 586);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            // 
            // frmDevelopment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pButtons);
            this.Controls.Add(this.pWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmDevelopment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Development";
            this.pWelcome.ResumeLayout(false);
            this.pWelcome.PerformLayout();
            this.pButtons.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tbContr.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUserInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pWelcome;
        private System.Windows.Forms.Label lblSalesPanel;
        private System.Windows.Forms.Panel pButtons;
        private System.Windows.Forms.Button btnSalesHome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel1;
        private TablessControl tbContr;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblSalesHome;
        private System.Windows.Forms.Label lblSalesWelcome;
        private System.Windows.Forms.Button btnDevSelectCustomer;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cBoxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView DGVUserInfo;
        private System.Windows.Forms.Label lblCustomers;
        private System.Windows.Forms.DataGridViewButtonColumn cViewCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAddress1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPostalCode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cResidence1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAddress2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPostalCode2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cResidence2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cContactPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn cInitials;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPhoneNumber1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPhoneNumber2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFaxNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEmail;
        private System.Windows.Forms.TabPage tabPage3;
    }
}