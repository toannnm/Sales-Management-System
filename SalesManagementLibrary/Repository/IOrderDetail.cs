using SalesManagementLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementLibrary.Repository
{
    public interface IOrderDetail
    {
        OrderDetail GetOrderDetailId(int orderId);

        IEnumerable<OrderDetail> GetOrder();

        void Insert(OrderDetail orderDetail);

        void Update(OrderDetail orderDetail);

        void Delete(OrderDetail orderDetail);
    }
}
