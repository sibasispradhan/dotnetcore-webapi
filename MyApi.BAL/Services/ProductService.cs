using System.Collections.Generic;
using System.Linq;
using MyApi.BAL.Interfaces;
using MyApi.DAL;
using MyApi.DTO;
using MyApi.DAL.Entities;

namespace MyApi.BAL.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            return _context.Products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList();
        }

        public ProductDto GetProductById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        public void AddProduct(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price
            };
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(ProductDto productDto)
        {
            var product = _context.Products.Find(productDto.Id);
            if (product == null) return;

            product.Name = productDto.Name;
            product.Price = productDto.Price;

            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return;

            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
