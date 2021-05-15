using System;
using System.Collections.Generic;
using WebApplication2.Domain;

namespace WebApplication2.Business
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category Insert(Category category);
        Category GetCategory(Guid id);
        Category AddCategory(Category category);
        void DeleteCategory(Category category);
        Category EditCategory(Category category);
    }
}
