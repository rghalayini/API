using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3CRUDWebAPI.Models;

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
        public IEnumerable<Product> Get()
        {
            return products;
        }
        //Get specific product
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = products.Find(p => p.Id == id);
            return product;
        }
        //Add new product
        [HttpPost]
        public void Post([FromBody]Product product)
        {
            products.Add(product);
        }
        //Delete product
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = products.Where(p => p.Id == id);
            products = products.Except(product).ToList();
        }
        //Update Product
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            var ExistingProduct = products.Where(p => p.Id == id);
            products = products.Except(ExistingProduct).ToList();
            products.Add(product);
        }

    }
}
