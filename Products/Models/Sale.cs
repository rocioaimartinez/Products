using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Models
{
    public class Sale
    {
        public Sale(): this(0)
        {

        }
        public Sale(int saleId)
        {
            SaleId = saleId;
            Items = new List<SaleItem>();
        }
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public int MyProperty { get; set; }
        public decimal? Total { get; set; }
        public List<SaleItem> Items { get; set; }

        public decimal? CalculateTotal()
        {  
            foreach (SaleItem item in Items)
            {
                Total += (item.ProductPrice * item.Quantity);
            }
            return Total;
        }
    }
}
