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
            this.btnFinanceHome = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbContr = new TablessControl();
            this.pWelcome.SuspendLayout();
            this.pButtons.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.tbContr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbContr.Location = new System.Drawing.Point(0, 0);
            this.tbContr.Name = "tbContr";
            this.tbContr.SelectedIndex = 0;
            this.tbContr.Size = new System.Drawing.Size(767, 600);
            this.tbContr.TabIndex = 1;
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
            this.Text = "Sales";
            this.pWelcome.ResumeLayout(false);
            this.pWelcome.PerformLayout();
            this.pButtons.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pWelcome;
        private System.Windows.Forms.Label lblFinancePanel;
        private System.Windows.Forms.Panel pButtons;
        private System.Windows.Forms.Button btnFinanceHome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel1;
        private TablessControl tbContr;
    }
}