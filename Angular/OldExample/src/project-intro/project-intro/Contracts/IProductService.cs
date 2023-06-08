using project_intro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_intro.Contracts
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<Product> AddNewProduct(Product pToAdd);
        Task<Product> UpdateProduct(Product pToUpdate);
        Task<Product> DeleteProduct(int id);
        Task<List<Product>> SearchProduct(string term);
    }
}
