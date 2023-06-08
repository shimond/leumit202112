using Microsoft.Extensions.Logging;
using project_intro.Contracts;
using project_intro.Exceptions;
using project_intro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_intro.Services
{
    public class ProductMockService : IProductService
    {
        private readonly ILogger<ProductMockService> _logger;
        private List<Product> products = new List<Product>();

        public ProductMockService(ILogger<ProductMockService> logger)
        {
            _logger = logger;
            products.Add(new Product { ProductId = 1, ProductName = "Bamba", ProductPrice = 12.6 });
            products.Add(new Product { ProductId = 2, ProductName = "Kefli", ProductPrice = 2.6 });
            products.Add(new Product { ProductId = 3, ProductName = "Bisli", ProductPrice = 10.6 });
            products.Add(new Product { ProductId = 4, ProductName = "Mogzam", ProductPrice = 12.5 });
            products.Add(new Product { ProductId = 5, ProductName = "Doritos", ProductPrice = 11.6 });
        }

        public async Task<Product> AddNewProduct(Product pToAdd)
        {
            await Task.Delay(1000);
            var lastId = products.Max(x => x.ProductId);
            pToAdd.ProductId = lastId + 1;
            products.Add(pToAdd);
            return pToAdd;
        }

        public Task<Product> DeleteProduct(int id)
        {
            var itemToRemove = products.Find(x => x.ProductId == id);
            if (itemToRemove == null)
            {
                throw new CourseApiException(ApiExceptionType.NotFound);
            }
            products.Remove(itemToRemove);
            return Task.FromResult(itemToRemove);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            _logger.LogInformation("GetAllProducts invoked.");
            await Task.Delay(1000);
            return products;
        }

        public Task<Product> GetProductById(int id)
        {
            var res = products.Find(x => x.ProductId == id);
            if (res == null)
            {
                throw new CourseApiException(ApiExceptionType.NotFound);
            }
            return Task.FromResult(res);
        }

        public Task<List<Product>> SearchProduct(string term = "")
        {
            var termToLower = term != null ? term.ToLower() : "";
            var res = products.Where(x => x.ProductName.ToLower().Contains(termToLower));
            return Task.FromResult(res.ToList());
        }

        public Task<Product> UpdateProduct(Product pToUpdate)
        {
            var index = products.FindIndex(x => x.ProductId == pToUpdate.ProductId);
            if (index == -1)
            {
                throw new CourseApiException(ApiExceptionType.NotFound);
            }
            products[index] = pToUpdate;
            return Task.FromResult(pToUpdate);
        }
    }
}
