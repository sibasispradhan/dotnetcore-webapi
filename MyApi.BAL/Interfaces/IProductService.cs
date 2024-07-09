using System.Collections.Generic;
using MyApi.DTO;

namespace MyApi.BAL.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAllProducts();
        ProductDto GetProductById(int id);
        void AddProduct(ProductDto product);
        void UpdateProduct(ProductDto product);
        void DeleteProduct(int id);
    }
}
