using System;
using System.Collections.Generic;

namespace SalesManagementLibrary.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    public string ProductName { get; set; } = null!;

    public float Weight { get; set; }

    public decimal UnitPrice { get; set; }

    public int UnitsInStock { get; set; }

    public virtual ProductCategory Category { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();
}
