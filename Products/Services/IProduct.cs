using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Services
{
    public interface IProduct
    {
        IEnumerable<Product> GetProductByPage();
        IEnumerable<Product> Get();

        Product GetProduct(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
