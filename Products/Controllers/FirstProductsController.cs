using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Models;

namespace Products.Controllers
{
    [Produces("application/json")]
    [Route("api/Products1")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        static List<Product> _products = new List<Product>()
        {
            new Product(){ProductId=1, ProductName="Laptop", ProductPrice="100"},
            new Product(){ProductId=2, ProductName="Smartphone", ProductPrice="100"}
        };
        public IActionResult Get()
        {
            return Ok(_products);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Product _product)
        {
            if (ModelState.IsValid)
            {
                _products.Add(_product);
                return StatusCode(StatusCodes.Status201Created);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            _products[id] = product;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _products.RemoveAt(id);
        }
    }
}
