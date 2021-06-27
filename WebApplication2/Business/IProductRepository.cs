using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Domain;

namespace WebApplication2.Business
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product Insert(Product product);
        Product GetProduct(int id);
        void DeleteProduct(Product product);
        Product EditProduct(Product product);
    }
}
