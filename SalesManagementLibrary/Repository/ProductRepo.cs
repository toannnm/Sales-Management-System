using SalesManagementLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementLibrary.Repository
{
    public class ProductRepo : IProduct
    {
        private SalesManagementDbContext db;
        public ProductRepo(SalesManagementDbContext db)
        {
            this.db = db;
        }
        public ProductRepo()
        {
            db = new();
        }
        public void Delete(Product product)
        {
            try
            {
                var pro = db.Products.SingleOrDefault(c => c.ProductId == product.ProductId);
                db.Remove(pro);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Product> GetProduct()
        {
            return db.Products.ToList();
        }

        public void Insert(Product product)
        {
            try
            {
                db.Add(product);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Update(Product product)
        {
            try
            {
                var pro = db.Products.SingleOrDefault(c => c.ProductId == product.ProductId);
                pro.CategoryId = product.CategoryId;
                pro.ProductName = product.ProductName;
                pro.Weight = product.Weight;
                pro.UnitPrice = product.UnitPrice;
                pro.UnitsInStock = product.UnitsInStock;

                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Product GetProductID(int id)
        {
            return db.Products.SingleOrDefault(c => c.ProductId.Equals(id));
        }

        public IEnumerable<ProductCategory> GetProductCategories()
        {
            return db.ProductCategories.ToList();
        }
    }
}
