using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2CreateAWebAPIFromScratch.Models;

namespace _2CreateAWebAPIFromScratch.Constrollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        List<Product> products = new List<Product>()
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
        [HttpGet] //to get all products
        public IEnumerable<Product> Get()
        {
            return products;
        }
        [HttpGet("{id}")] //Get a specific Product
        public Product Get(int id)
        {
            var product = products.Find(product => product.Id == id);
            return product;
        }
    }
}
