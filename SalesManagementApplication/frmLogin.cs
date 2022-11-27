using Microsoft.Extensions.Configuration;
using SalesManagementLibrary.Models;
using SalesManagementLibrary.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagementApplication
{
    public partial class frmLogin : Form
    {
        private IMember member = new MemberRepo();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, true).Build();

            var Email = config.GetSection("AdminAccount:Email").Value;
            var Password = config.GetSection("AdminAccount:Password").Value;

            Member memberLog = member.MemberLogin(txtEmail.Text, txtPassword.Text);

            if (Email.Equals(txtEmail.Text) && Password.Equals(txtPassword.Text))
            {
                frmAdmin frmAdmin = new frmAdmin();
                frmAdmin.Show();
                this.Hide();
            } else if(memberLog is not null){
                frmMember frmMember = new frmMember();
                frmMember.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorect Email or Password");
            }
        }
    }
}
