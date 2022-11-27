using SalesManagementLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementLibrary.Repository
{
    public class OrderRepo : IOrder
    {
        private SalesManagementDbContext db;
        public OrderRepo(SalesManagementDbContext db)
        {
            this.db = db;
        }
        public OrderRepo()
        {
            db = new();
        }
        public void Delete(Order order)
        {
            try
            {
                var ord = db.Orders.SingleOrDefault(c => c.OrderId == order.OrderId);
                db.Remove(ord);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Order> GetOrder()
        {
            return db.Orders.ToList();
        }

        public Order GetOrderId(int orderId)
        {
            Order ord = db.Orders.SingleOrDefault(c => c.OrderId == orderId);
            return ord;
        }

        public void Insert(Order order)
        {
            try
            {
                db.Add(order);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Update(Order order)
        {
            try
            {
                var ord = db.Orders.SingleOrDefault(c => c.OrderId == order.OrderId);
                ord.MemberId = order.MemberId;
                ord.OrderDate = order.OrderDate;
                ord.RequiredDate = order.RequiredDate;
                ord.ShippedDate = order.ShippedDate;
                ord.Freight = order.Freight;

                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
