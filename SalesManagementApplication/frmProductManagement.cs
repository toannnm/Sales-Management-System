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
    public partial class frmProductManagement : Form
    {
        public bool InsertOrUpdate { get; set; }
        public IProduct iProduct { get; set; }
        public Product product { get; set; }
        public frmProductManagement()
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
                Product pro = new Product()
                {
                    CategoryId = int.Parse(cboCategory.SelectedValue.ToString()),
                    ProductName = txtProductName.Text,
                    Weight = float.Parse(txtWeight.Text),
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    UnitsInStock = int.Parse(txtUnitInStock.Text),
                };
                if (InsertOrUpdate == true)
                {
                    pro.ProductId = int.Parse(txtProductId.Text);
                    iProduct.Update(pro);
                    MessageBox.Show("Update success.");
                    this.Close();
                }
                else
                {
                    iProduct.Insert(pro);
                    MessageBox.Show("Add product success.");
                    this.Close();
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private void frmProductManagement_Load(object sender, EventArgs e)
        {
            var pro = iProduct.GetProductCategories();
            this.cboCategory.DataSource = pro;
            this.cboCategory.ValueMember = "CategoryId";
            this.cboCategory.DisplayMember = "CategoryName";
            this.cboCategory.SelectedIndex = 0;

            txtProductId.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                GetProduct();
            }
            else
            {
                label1.Visible = false;
                txtProductId.Visible = false;
            }
        }
        private void GetProduct()
        {
            txtProductId.Text = product.ProductId.ToString();
            cboCategory.Text = product.CategoryId.ToString();
            txtProductName.Text = product.ProductName;
            txtWeight.Text = product.Weight.ToString();
            txtUnitPrice.Text = product.UnitPrice.ToString();
            txtUnitInStock.Text = product.UnitsInStock.ToString();
        }
    }
}
