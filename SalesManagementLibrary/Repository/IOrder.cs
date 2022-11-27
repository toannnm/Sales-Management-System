using SalesManagementLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementLibrary.Repository
{
    public interface IOrder
    {
        Order GetOrderId(int orderId);

        IEnumerable<Order> GetOrder();

        void Insert(Order order);

        void Update(Order order);

        void Delete(Order order);
    }
}
