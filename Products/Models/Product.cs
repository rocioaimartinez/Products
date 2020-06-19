using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Models
{
    /// <summary>
    /// Product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Id is auto-generated
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Name can't be longer than 50 characters
        /// </summary>
        [Required, StringLength(50, ErrorMessage ="Name can't be longer that 15 characters")]
        [MaxLength(50)]
        public string ProductName { get; set; }
        [Required]
        public string  ProductPrice { get; set; }
        public DateTime PriceDate { get; set; }
        public int Category { get; set; }
    }
}
