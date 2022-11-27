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
    public partial class frmAdmin : Form
    {
        private IMember member = new MemberRepo();
        private IProduct product = new ProductRepo();
        private IOrder order = new OrderRepo();
        BindingSource source;

        public frmAdmin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            frmMemberManagement frmMemManagement = new frmMemberManagement
            {
                Text = "Add Member",
                InsertOrUpdate = false,
                iMember = member,
            };
            if (frmMemManagement.ShowDialog() == DialogResult.OK)
            {
                LoadMember();
                source.Position = source.Count - 1;
            }
        }

        private void btnUpdateMember_Click(object sender, EventArgs e)
        {
            frmMemberManagement frmMemManagement = new frmMemberManagement
            {
                Text = "Update Member",
                InsertOrUpdate = true,
                iMember = member,
                member = GetMember()
            };
            if (frmMemManagement.ShowDialog() == DialogResult.OK)
            {
                LoadMember();
                source.Position = source.Count - 1;
            }
        }

        private void btnDeleteMember_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                var mem = new Member
                {
                    MemberId = int.Parse(txtMemberId.Text)
                };
                member.Delete(mem);
                LoadMember();
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmProductManagement frmProduct = new frmProductManagement
            {
                Text = "Add Product",
                InsertOrUpdate = false,
                iProduct = product,
            };
            if (frmProduct.ShowDialog() == DialogResult.OK)
            {
                LoadProduct();
                source.Position = source.Count - 1;
            }
        }

        private void txtUpdateProduct_Click(object sender, EventArgs e)
        {
            frmProductManagement frmProduct = new frmProductManagement
            {
                Text = "Update Product",
                InsertOrUpdate = true,
                iProduct = product,
                product = GetProduct()
            };
            if (frmProduct.ShowDialog() == DialogResult.OK)
            {
                LoadProduct();
                source.Position = source.Count - 1;
            }
        }

        private void txtDeleteProduct_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                var pro = new Product
                {
                    ProductId = int.Parse(txtProductId.Text)
                };
                product.Delete(pro);
                LoadProduct();
            }
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            frmOrderManagement frmOrder = new frmOrderManagement
            {
                Text = "Add Order",
                InsertOrUpdate = false,
                iOrder = order,
            };
            if (frmOrder.ShowDialog() == DialogResult.OK)
            {
                LoadOrder();
                source.Position = source.Count - 1;
            }
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            frmOrderManagement frmOrder = new frmOrderManagement
            {
                Text = "Update Order",
                InsertOrUpdate = true,
                iOrder = order,
                order = GetOrder()
            };
            if (frmOrder.ShowDialog() == DialogResult.OK)
            {
                LoadOrder();
                source.Position = source.Count - 1;
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                var ord = new Order
                {
                    OrderId = int.Parse(txtOrderId.Text)
                };
                order.Delete(ord);
                LoadOrder();
            }
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            LoadMember();
            LoadProduct();
            LoadOrder();
        }

        private void LoadMember(string searchMember = null)
        {
            var allMember = member.GetMember();
            source = new BindingSource();

            if(searchMember != null && searchMember != "")
            {
                txtMemberId.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtCompanyName.DataBindings.Clear();
                txtCity.DataBindings.Clear();
                txtCountry.DataBindings.Clear();
                txtPassword.DataBindings.Clear();

                var email = allMember.Where(c => c.Email.ToUpper().Contains(searchMember.Trim()));
                source.DataSource = email;
            }
            else
            {
                txtMemberId.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtCompanyName.DataBindings.Clear();
                txtCity.DataBindings.Clear();
                txtCountry.DataBindings.Clear();
                txtPassword.DataBindings.Clear();

                source.DataSource = allMember;
            }

            dgvMember.DataSource = null;
            dgvMember.DataSource = source;

            txtMemberId.DataBindings.Add("Text", source, "MemberID");
            txtEmail.DataBindings.Add("Text", source, "Email");
            txtCompanyName.DataBindings.Add("Text", source, "CompanyName");
            txtCity.DataBindings.Add("Text", source, "City");
            txtCountry.DataBindings.Add("Text", source, "Country");
            txtPassword.DataBindings.Add("Text", source, "Password");

        }
        private void LoadProduct(string SearchProduct = null)
        {
            var allProduct = product.GetProduct();
            source = new BindingSource();
            if (SearchProduct != null && SearchProduct != "")
            {
                txtProductId.DataBindings.Clear();
                txtCategoryId.DataBindings.Clear();
                txtProductName.DataBindings.Clear();
                txtWeight.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                txtUnitInStock.DataBindings.Clear();

                var pro = allProduct.Where(c => c.ProductName.ToUpper().Contains(SearchProduct.Trim()));
                source.DataSource = pro;
            }
            else
            {
                txtProductId.DataBindings.Clear();
                txtCategoryId.DataBindings.Clear();
                txtProductName.DataBindings.Clear();
                txtWeight.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                txtUnitInStock.DataBindings.Clear();

                source.DataSource = allProduct;
            }

            dgvProduct.DataSource = null;
            dgvProduct.DataSource = source;

            txtProductId.DataBindings.Add("Text", source, "ProductId");
            txtCategoryId.DataBindings.Add("Text", source, "CategoryId");
            txtProductName.DataBindings.Add("Text", source, "ProductName");
            txtWeight.DataBindings.Add("Text", source, "Weight");
            txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
            txtUnitInStock.DataBindings.Add("Text", source, "UnitsInStock");
        }
        private void LoadOrder(string searchOrder = null)
        {
            var allOrd = order.GetOrder();
            source = new BindingSource();
            if (searchOrder != null && searchOrder != "")
            {
                txtOrderId.DataBindings.Clear();
                txtMemberId_Order.DataBindings.Clear();
                txtOrderDate.DataBindings.Clear();
                txtRequiredDate.DataBindings.Clear();
                txtShippedDate.DataBindings.Clear();
                txtFreight.DataBindings.Clear();

                var mem = allOrd.Where(c => c.MemberId.ToString().Equals(searchOrder.Trim()));
                source.DataSource = mem;
            }
            else
            {
                txtOrderId.DataBindings.Clear();
                txtMemberId_Order.DataBindings.Clear();
                txtOrderDate.DataBindings.Clear();
                txtRequiredDate.DataBindings.Clear();
                txtShippedDate.DataBindings.Clear();
                txtFreight.DataBindings.Clear();

                source.DataSource = allOrd;
            }

            dgvOrder.DataSource = null;
            dgvOrder.DataSource = source;

            txtOrderId.DataBindings.Add("Text", source, "OrderId");
            txtMemberId_Order.DataBindings.Add("Text", source, "MemberId");
            txtOrderDate.DataBindings.Add("Text", source, "OrderDate");
            txtRequiredDate.DataBindings.Add("Text", source, "RequiredDate");
            txtShippedDate.DataBindings.Add("Text", source, "ShippedDate");
            txtFreight.DataBindings.Add("Text", source, "Freight");
        }

        private void btnSearchMember_Click(object sender, EventArgs e)
        {
            var searchMember = txtSearchMember.Text.ToUpper();
            LoadMember(searchMember);
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            var searchProduct = txtSearchProduct.Text.ToUpper();
            LoadProduct(searchProduct);
        }
        private void btnSearchOrder_Click(object sender, EventArgs e)
        {
            var searchOrder = txtSearchOrder.Text.ToString();
            LoadOrder(searchOrder);
        }

        private Member GetMember()
        {
            Member mem = null;
            mem = new Member
            {
                MemberId = int.Parse(txtMemberId.Text),
                Email = txtEmail.Text,
                CompanyName = txtCompanyName.Text,
                City = txtCity.Text,
                Country = txtCountry.Text,
                Password = txtPassword.Text
            };
            return mem;
        }

        private Product GetProduct()
        {
            Product pro = null;
            pro = new Product
            {
                ProductId = int.Parse(txtProductId.Text),
                CategoryId = int.Parse(txtCategoryId.Text),
                ProductName = txtProductName.Text,
                Weight = float.Parse(txtWeight.Text),
                UnitPrice = decimal.Parse(txtUnitPrice.Text),
                UnitsInStock = int.Parse(txtUnitInStock.Text)
            };
            return pro;
        }
        private Order GetOrder()
        {
            Order ord = null;
            ord = new Order
            {
                OrderId = int.Parse(txtOrderId.Text),
                MemberId = int.Parse(txtMemberId_Order.Text),
                OrderDate = DateTime.Parse(txtOrderDate.Text),
                RequiredDate = DateTime.Parse(txtRequiredDate.Text),
                ShippedDate = DateTime.Parse(txtShippedDate.Text),
                Freight = decimal.Parse(txtFreight.Text)
            };
            return ord;
        }
    }
}
