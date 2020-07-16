using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Data;
using Products.Models;
using Products.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Products.Controllers
{
    [Produces("application/json", "application/xml")]
    [Route("api/Products")]
    [ApiController]
    public class ProductsController1 : ControllerBase
    {
        private IProduct productRepository;
        public ProductsController1(IProduct _productRepository)
        {
            productRepository = _productRepository;
        }
        // GET: api/<ProductsController1>
        /// <summary>
        /// Products with pagination
        /// </summary>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/products")]
        public IEnumerable<Product> Get(int? pageNumber, int? pageSize)
        {
            var products = productRepository.GetProductByPage();

            int currentPage = pageNumber ?? 1;
            int currentSize = pageSize ?? 5;
            var items = products.
                Skip((currentPage - 1) * currentSize).
                Take(currentSize).ToList();
            return items;
        }
        /// <summary>
        /// Search Products By Name
        /// </summary>
        /// <param name="searchProduct">Product Name</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/products/search")]
        public IEnumerable<Product> GetBySearch(string searchProduct)
        {
            var products = productRepository.
                                        Get().
                                        Where(p => p.
                                        ProductName.StartsWith(searchProduct));
            return products;
        }
        [HttpGet]
        [Route("/api/products/sort")]
        public IEnumerable<Product> GetSort(string sortPrice)
        {
            IQueryable<Product> products;
            switch (sortPrice)
            {
                case "desc":
                    products = (IQueryable<Product>)productRepository.
                               Get().
                               OrderByDescending(p => p.ProductPrice);
                    break;
                case "asc":
                    products = (IQueryable<Product>)productRepository.
                                Get().OrderBy(p => p.
                                ProductPrice);
                    break;
                default:
                    products = (IQueryable<Product>)productRepository.
                                Get();
                    break;
            }
            return products;
        }
        // GET api/<ProductsController1>/5
        /// <summary>
        /// Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type= typeof(Product))]
        [HttpGet("{id}", Name = "GetSingleProd")]
        public IActionResult Get2(int id)
        {
            var product = productRepository.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST api/<ProductsController1>
        [HttpPost]
        [Consumes("application/json")]
        public IActionResult Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            productRepository.AddProduct(product);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<ProductsController1>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id!= product.ProductId)
            {
                return BadRequest();
            }
            try
            {
                productRepository.UpdateProduct(product);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Not Record Found");
            }
            return Ok("Product Updated Successfully");
        }

        // DELETE api/<ProductsController1>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            productRepository.DeleteProduct(id);
            return Ok("Record deleted");
        }
    }
}
