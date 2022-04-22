using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiAndEntity.Entities;
using WebApiAndEntity.Models;

namespace WebApiAndEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        ProductData db = new ProductData();

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = db.Products.Any(x => x.Id == id);
            if (!data)
            {
                return NotFound("Id does not match");
            }
            var product = db.Products.FirstOrDefault(x => x.Id == id);
            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Products.ToList());
        }

        [HttpPost]
        public IActionResult Add(Products product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return Ok("Added!");
        }

        [HttpPut]
        public IActionResult Update(Products products)
        {
            var data = db.Products.FirstOrDefault(x => x.Id == products.Id);
            data.Name = products.Name;
            data.StockAmount = products.StockAmount;
            db.SaveChanges();
            return Ok("Updated!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = db.Products.Any(x => x.Id == id);
            if (!data)
            {
                return NotFound("Product not found!");
            }
            var product = db.Products.FirstOrDefault(x => x.Id == id);
            db.Products.Remove(product);
            db.SaveChanges();
            return Ok("Deleted!");
        }

    }
}
