using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Business;
using WebApplication2.Domain;

namespace WebApplication2.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopContext _context;
        public CategoryRepository(ShopContext context)
        {
            _context = context;
        }

        /*private List<Category> categories = new List<Category>()
        {
            new Category()
            {
                CategoryID=44,
                Name="Adidas",
                Description="Description1"
            },
            new Category()
            {
                CategoryID=45,
                Name="Puma",
                Description="Description2"
            }
        };*/

        public void DeleteCategory(Category category)
        {
            _context.Remove(category);
            _context.SaveChanges();
        }

        public Category EditCategory(Category category)
        {
            var existingCategory = GetCategory(category.CategoryID);
            existingCategory.Name = category.Name;
            existingCategory.Products = category.Products;
            existingCategory.Description = category.Description;
            _context.Update(existingCategory);
            _context.SaveChanges();
            return existingCategory;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
            //return categories;
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.SingleOrDefault(x => x.CategoryID == id);
        }

        public Category Insert(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return category;
        }
    }
}
