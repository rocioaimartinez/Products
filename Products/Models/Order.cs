using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public decimal? PrePaid { get; set; }
    }
}
