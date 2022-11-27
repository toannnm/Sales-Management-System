using SalesManagementLibrary.Models;
using SalesManagementLibrary.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagementApplication
{
    public partial class frmMemberManagement : Form
    {
        public bool InsertOrUpdate { get; set; }
        public IMember iMember { get; set; }
        public Member member { get; set; }
        public frmMemberManagement()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Member mem = new Member()
                {
                    Email = txtEmail.Text,
                    CompanyName = txtCompanyName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text,
                };
                if(InsertOrUpdate == true)
                {
                    mem.MemberId = int.Parse(txtMemberId.Text);
                    iMember.Update(mem);
                    MessageBox.Show("Update success.");
                    this.Close();
                }
                else
                {
                    iMember.Insert(mem);
                    MessageBox.Show("Add member success.");
                    this.Close();
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        private void GetMember()
        {
            txtMemberId.Text = member.MemberId.ToString();
            txtEmail.Text = member.Email;
            txtCompanyName.Text = member.CompanyName;
            txtCity.Text = member.City;
            txtCountry.Text = member.Country;
            txtPassword.Text = member.Password;
        }

        private void frmMemberManagement_Load(object sender, EventArgs e)
        {
            txtMemberId.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                GetMember();
            }
            else
            {
                txtMemberId.Visible = false;
                label1.Visible = false;
            }
        }
    }
}
