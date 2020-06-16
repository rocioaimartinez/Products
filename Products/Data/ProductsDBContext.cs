using Microsoft.EntityFrameworkCore;
using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Data
{
    public class ProductsDBContext : DbContext
    {
        public ProductsDBContext(DbContextOptions<ProductsDBContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }


    }
}
