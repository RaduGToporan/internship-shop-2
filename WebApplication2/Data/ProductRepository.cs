using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Business;
using WebApplication2.Domain;

namespace WebApplication2.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext _context;
        public ProductRepository(ShopContext context)
        {
            _context = context;
        }
        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product Insert(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product GetProduct(int id)
        {
            return _context.Products.SingleOrDefault(x => x.ProductID == id);
        }

        public void DeleteProduct(Product product)
        {
            _context.Remove(product);
            _context.SaveChanges();
        }

        public Product EditProduct(Product product)
        {
            var existingProduct = GetProduct(product.ProductID);
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.BasePrice = product.BasePrice;
            existingProduct.Description = product.Description;
            existingProduct.ProductID = product.ProductID;
            existingProduct.ImageName = product.ImageName;
            _context.Update(existingProduct);
            _context.SaveChanges();
            return existingProduct;
        }

    }
}
