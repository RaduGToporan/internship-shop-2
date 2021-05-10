using Microsoft.AspNetCore.Mvc;
using WebApplication2.Business;
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

        public CategoryListRepresentation GetAll()
        {
            var dbCategories = _repo.GetAll();

            return new CategoryListRepresentation(dbCategories);
        }
    }
}
