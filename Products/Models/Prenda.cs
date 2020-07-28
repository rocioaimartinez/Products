using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Models
{
    public class Prenda : Product
    {
        public int PrendaId { get; set; }
        public int Color { get; set; }
        public int Size { get; set; }
        public int PrintTechnic { get; set; }
    }
}
