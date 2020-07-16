using Products.Data;
using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Services
{
    public class ProductRepository : IProduct
    {
        private ProductsDBContext productsDbContext;
        public ProductRepository(ProductsDBContext _productsDbContext)
        {
            productsDbContext = _productsDbContext;
        }
        public void AddProduct(Product product)
        {
            productsDbContext.Products.Add(product);
            productsDbContext.SaveChanges(true);
        }

        public void DeleteProduct(int id)
        {
            var product = productsDbContext.Products.Find(id);
            productsDbContext.Products.Remove(product);
            productsDbContext.SaveChanges(true);
        }

        public Product GetProduct(int id)
        {
            return productsDbContext.Products.SingleOrDefault(m => m.ProductId == id);
        }

        public IEnumerable<Product> GetProductByPage()
        {
            return from p in productsDbContext.Products.OrderBy(a => a.ProductId) select p;
        }

        public IEnumerable<Product> Get()
        {
            return productsDbContext.Products;
        }
        public void UpdateProduct(Product product)
        {
            productsDbContext.Products.Update(product);
            productsDbContext.SaveChanges(true);
        }
    }
}
