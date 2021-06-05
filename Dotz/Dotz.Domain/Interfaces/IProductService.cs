using Dotz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Domain.Interfaces
{
    public interface IProductService
    {
        Task CreateAsync(string name, int value, int quantity, Guid categoryId);
        Task TradeAsync(Guid productId);
        Task<IEnumerable<Product>> GetAsync();
    }
}
