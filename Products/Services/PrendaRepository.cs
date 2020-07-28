using Products.Data;
using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Services
{
    public class PrendaRepository :IPrenda
    {
        private ProductsDBContext productDbContext;
        public PrendaRepository(ProductsDBContext _productDbContext)
        {
            productDbContext = _productDbContext;
        }
        public void AddPrenda(Prenda prenda)
        {
            productDbContext.Prenda.Add(prenda);
            productDbContext.SaveChanges(true);
        }
        public void DeletePrenda(int prendaId)
        {
            var prenda = productDbContext.Prenda.Find(prendaId);
            productDbContext.Prenda.Remove(prenda);
            productDbContext.SaveChanges(true);
        }
        public void UpdatePrenda(Prenda prenda)
        {
            productDbContext.Prenda.Update(prenda);
            productDbContext.SaveChanges(true);
        }
        public IEnumerable<Prenda> Get()
        {
            return productDbContext.Prenda;
        }
        public IEnumerable<Prenda> GetPrendasByPage()
        {
            return from p in productDbContext.Prenda.OrderBy(a => a.PrendaId) select p;
        }
        public Prenda GetPrenda(int prendaId)
        {
            return productDbContext.Prenda.SingleOrDefault(p => p.PrendaId == prendaId);
        }
    }
}
