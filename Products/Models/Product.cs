using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required, StringLength(15, ErrorMessage ="Name can't be longer that 15 characters")]
        public string ProductName { get; set; }
        public string  ProductPrice { get; set; }
        public DateTime PriceDate { get; set; }
        public int Category { get; set; }
    }
}
