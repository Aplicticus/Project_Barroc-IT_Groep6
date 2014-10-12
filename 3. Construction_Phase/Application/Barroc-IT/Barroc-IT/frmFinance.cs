using System;
using System.Windows.Forms;

namespace Barroc_IT
{
    public partial class frmFinance : Form
    {
        private DatabaseHandler handler;
        private frmLogin loginForm;
       
        public frmFinance(DatabaseHandler handler, frmLogin loginForm)
        {
            InitializeComponent();
            this.handler = handler;
            this.loginForm = loginForm;
        }
    }
}
