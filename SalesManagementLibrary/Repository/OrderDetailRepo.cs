using SalesManagementLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementLibrary.Repository
{
    public class OrderDetailRepo : IOrderDetail
    {
        private SalesManagementDbContext db;
        public OrderDetailRepo(SalesManagementDbContext db)
        {
            this.db = db;
        }
        public OrderDetailRepo()
        {
            db = new();
        }
        public void Delete(OrderDetail orderDetail)
        {
            try
            {
                var od = db.OrderDetails.SingleOrDefault(c => c.OrderId == orderDetail.OrderId);
                db.Remove(od);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<OrderDetail> GetOrder()
        {
            return db.OrderDetails.ToList();
        }

        public OrderDetail GetOrderDetailId(int orderId)
        {
            var od = db.OrderDetails.SingleOrDefault(c=>c.OrderDetaiId.Equals(orderId));
            return od;
        }

        public void Insert(OrderDetail orderDetail)
        {
            try
            {
                db.Add(orderDetail);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Update(OrderDetail orderDetail)
        {
            try
            {
                var od = db.OrderDetails.SingleOrDefault(c => c.OrderDetaiId == orderDetail.OrderDetaiId);
                od.OrderId = orderDetail.OrderId;
                od.ProductId = orderDetail.ProductId;
                od.UnitPrice = orderDetail.UnitPrice;
                od.Quantity = orderDetail.Quantity;
                od.Discount = orderDetail.Discount;

                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
