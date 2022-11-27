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
    public partial class frmOrderManagement : Form
    {
        public bool InsertOrUpdate { get; set; }
        public IOrder iOrder { get; set; }
        public Order order { get; set; }
        private IOrderDetail orderDetail = new OrderDetailRepo();
        BindingSource source;

        public frmOrderManagement()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void frmOrderManagement_Load(object sender, EventArgs e)
        {
            LoadOrderDetail();
        }
        private void LoadOrderDetail()
        {
            var allOrdDetail = orderDetail.GetOrder();
            source = new BindingSource();

            
            if(InsertOrUpdate == true)
            {
                GetOrder();
                var id = txtOrderId.Text;
                var ord = allOrdDetail.Where(c => c.OrderId.ToString().Equals(id));
                source.DataSource = ord;
                dgvOrderDetail.DataSource = null;
                dgvOrderDetail.DataSource = source;
            }
            else
            {
                label1.Visible =false;
                txtOrderId.Visible = false;
            }
        }
        private void GetOrder()
        {
            txtOrderId.Text = order.OrderId.ToString();
            txtMemberId.Text = order.MemberId.ToString();
            txtOrderDate.Text = order.OrderDate.ToString();
            txtRequiredDate.Text = order.RequiredDate.ToString();
            txtShippedDate.Text = order.ShippedDate.ToString();
            txtFreight.Text = order.Freight.ToString();
        }

        private void btnAddOrderDetail_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateOrderDetail_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteOrderDetail_Click(object sender, EventArgs e)
        {

        }
    }
}
