using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _4CRUDwithActionResult.Models;

namespace _3CRUDWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>()
        {
            new Product
            {
                Id = 1006368,
                Name = "Austin and Barbeque AABQ wifi Food Thermometer",
                Description = "Thermometer and wifi for an optimal temperature",
                Price = 399
            },
            new Product
            {
                Id = 1009334,
                Name = "Anderson electrick toothbrush",
                Description = "just an electric toothbrush",
                Price = 89
            },
            new Product
            {
                Id = 1002265,
                Name = "Non-stick spray",
                Description = "BBQ oil spray for your food",
                Price = 99
            }
        };
        //Get all products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return products;
        }
        //Get specific product
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = products.Find(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }
        //Add new product
        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            if (products.Exists(p => p.Id == product.Id))
            {
                return Conflict();
            }
            products.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id}, products);
        }
        //Delete product
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Product>> Delete(int id)
        {
            var product = products.Where(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            products = products.Except(product).ToList();
            return products;
        }
        //Update Product
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Product>> Put(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            var ExistingProduct = products.Where(p => p.Id == id);
            products = products.Except(ExistingProduct).ToList();
            products.Add(product);
            return products;
        }

    }
}
