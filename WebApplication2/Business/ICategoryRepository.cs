using System.Collections.Generic;
using WebApplication2.Domain;

namespace WebApplication2.Business
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category Insert(Category category);
    }
}
