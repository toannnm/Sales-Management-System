using SalesManagementLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementLibrary.Repository
{
    public interface IProduct
    {
        Product GetProductID(int id);
        IEnumerable<Product> GetProduct();
        IEnumerable<ProductCategory> GetProductCategories();
        void Insert(Product product);

        void Update(Product product);

        void Delete(Product product);
    }
}
