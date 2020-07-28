using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Services
{
    public interface IPrenda
    {
        IEnumerable<Prenda> GetPrendasByPage();
        IEnumerable<Prenda> Get();
        Prenda GetPrenda(int prendaId);
        void AddPrenda(Prenda prenda);
        void UpdatePrenda(Prenda prenda);
        void DeletePrenda(int prendaId);
    }
}
