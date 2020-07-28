using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Models
{
    public class SaleItem
    {
        public int SaleItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal? ProductPrice { get; set; }
    }
}
