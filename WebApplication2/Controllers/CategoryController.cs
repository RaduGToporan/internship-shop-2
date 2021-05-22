using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text;
using WebApplication2.Business;
using WebApplication2.Domain;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;

        public CategoryController(ICategoryRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public CategoryListRepresentation GetAll()
        {
            var dbCategories = _repo.GetAll();
            return new CategoryListRepresentation(dbCategories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _repo.GetCategory(id);
            if (category != null)
            {
                return Ok(category);
            }
            return NotFound($"Category with Id: {id} was not found");
        }

        [HttpPost("Create")]
        public IActionResult CreateCategory(Category category)
        {
            _repo.Insert(category);
            return Ok(category);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _repo.GetCategory(id);
            if (category != null)
            {
                _repo.DeleteCategory(category);
                return Ok();
            }
            return NotFound($"Category with Id: {id} was not found");
        }

        [HttpPatch("{id}")]
        public IActionResult EditCategory(int id, Category category)
        {
            var existingCategory = _repo.GetCategory(id);
            if (existingCategory != null)
            {
                category.CategoryID = existingCategory.CategoryID;
                _repo.EditCategory(category);
            }
            return Ok(category);
        }

        /*[HttpGet]
        [Route("writetext/{text}")]
        //[Route("/{text}")]
        public IActionResult WriteText(string text)
        {
            return Ok($"Textul nou 2 este: {text}");
        }*/
    }
}
