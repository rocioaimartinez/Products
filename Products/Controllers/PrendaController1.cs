using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Products.Models;
using Products.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Products.Controllers
{
    [Route("api/Prenda")]
    [ApiController]
    public class PrendaController1 : ControllerBase
    {
        public IPrenda prendaRepository;
        public PrendaController1(IPrenda _prendaRepository)
        {
            prendaRepository = _prendaRepository;
        }
        // GET: api/<PrendaController1>
        [HttpGet]
        [Route("/api/prendas")]
        public IEnumerable<Prenda> Get(int? pageNumber, int? pageSize)
        {
            var prendas = prendaRepository.GetPrendasByPage();

            int currentPage = pageNumber ?? 1;
            int currentSize = pageSize ?? 5;
            var items = prendas.
                Skip((currentPage-1)* currentSize).
                Take(currentSize).ToList();
            return items;
        }
        [HttpGet]
        [Route("/api/prendas/search")]
        public IEnumerable<Prenda> GetBySearch(string searchCriteria)
        {
            var prendas = prendaRepository.
                Get().
                Where(p => p.
                ProductName.StartsWith(searchCriteria) || p.ProductName.Contains(searchCriteria));
            return prendas;

        }

        // GET api/<PrendaController1>/5
        [HttpGet("{id}")]
        public ActionResult GetPrenda(int id)
        {
            var prenda = prendaRepository.GetPrenda(id);
            if (prenda == null)
            {
                return NotFound();
            }
            return Ok(prenda);
        }

        // POST api/<PrendaController1>
        [HttpPost]
        public IActionResult Post([FromBody] Prenda prenda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            prendaRepository.AddPrenda(prenda);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<PrendaController1>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Prenda prenda)
        {
            if (!ModelState.IsValid || id != prenda.PrendaId)
            {
                return BadRequest(ModelState);
            }
            try
            {
                prendaRepository.UpdatePrenda(prenda);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Not Record Found");
            }
            return StatusCode(StatusCodes.Status200OK);
        }

        // DELETE api/<PrendaController1>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                prendaRepository.DeletePrenda(id);
                return Ok("Successfully Deleted");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Not Record Found");
            }
            
            
        }
    }
}
