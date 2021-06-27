using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IProductRepository _context;
        public static IWebHostEnvironment _webHostEnvironment;

        public ProductController(IProductRepository repo, IWebHostEnvironment webHostEnvironment)
        {
            _context = repo;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public ProductListRepresentation GetAll()
        {
            var dbProducts = _context.GetAll();
            return new ProductListRepresentation(dbProducts);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _context.GetProduct(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound($"Product with Id: {id} was not found");
        }

        [HttpPost("Create")]
        public IActionResult CreateProduct(Product product)
        {
            _context.Insert(product);
            return Ok(product);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.GetProduct(id);
            if (product != null)
            {
                _context.DeleteProduct(product);
                return Ok();
            }
            return NotFound($"Product with Id: {id} was not found");
        }

        [HttpPatch("{id}")]
        public IActionResult EditProduct(int id, Product product)
        {
            var existingProduct = _context.GetProduct(id);
            if (existingProduct != null)
            {
                product.ProductID = existingProduct.ProductID;
                _context.EditProduct(product);
            }
            return Ok(product);
        }

        [HttpPost("{id}/image")]
        public async Task<ActionResult<string>> SaveImage([FromRoute] int id, [FromForm] IFormFile imageFile)
        {

            var product = _context.GetProduct(id);
            if (product == null)
                return NotFound($"Product with Id = {id} not found");

            product.ImageName = imageFile.FileName;
            _context.EditProduct(product);

            try
            {
                if (imageFile.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    using (var filestream = System.IO.File.Create(path + imageFile.FileName))
                    {
                        imageFile.CopyTo(filestream);
                        filestream.Flush();
                        return "Uploaded";
                    }
                }
                else
                {
                    return "Not Uploaded";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}
