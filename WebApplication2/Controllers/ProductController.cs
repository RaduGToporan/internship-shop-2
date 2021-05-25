using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Business;
using WebApplication2.Domain;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ProductListRepresentation GetAll()
        {
            var dbProducts = _repo.GetAll();
            return new ProductListRepresentation(dbProducts);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _repo.GetProduct(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound($"Product with Id: {id} was not found");
        }

        [HttpPost("Create")]
        public IActionResult CreateProduct(Product product)
        {
            _repo.Insert(product);
            return Ok(product);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _repo.GetProduct(id);
            if (product != null)
            {
                _repo.DeleteProduct(product);
                return Ok();
            }
            return NotFound($"Product with Id: {id} was not found");
        }

        [HttpPatch("{id}")]
        public IActionResult EditProduct(int id, Product product)
        {
            var existingProduct = _repo.GetProduct(id);
            if (existingProduct != null)
            {
                product.ProductID = existingProduct.ProductID;
                _repo.EditProduct(product);
            }
            return Ok(product);
        }
    }
}
