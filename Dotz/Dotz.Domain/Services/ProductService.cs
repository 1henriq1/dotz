using Dotz.Domain.Entities;
using Dotz.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task CreateAsync(string name, int value, int quantity, Guid categoryId)
        {
            var newProduct = new Product(name, value, quantity, categoryId);
            await _productRepository.AddAsync(newProduct);
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await _productRepository.GetAsync();
        }

        public async Task TradeAsync(Guid productId)
        {
            await _productRepository.TradeAsync(productId);
        }
    }
}
