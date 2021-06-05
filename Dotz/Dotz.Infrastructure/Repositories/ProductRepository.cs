using Dotz.Domain.Entities;
using Dotz.Domain.Interfaces;
using Dotz.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductRepository(DotzContext dotzContext, IHttpContextAccessor httpContextAccessor) : base(dotzContext)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await _dotzContext.Products.Include(i => i.Category).Where(w => w.Quantity > 0).ToListAsync();
        }

        public async Task TradeAsync(Guid productId)
        {
            var userId = GetUserIdFromContext(_httpContextAccessor);
            var user = await _dotzContext.Users.FindAsync(userId);
            
            var product = await _dotzContext.Products.FindAsync(productId);
            user.ChangeBalance(user.Balance - product.Value);
            product.Quantity--;

            var order = new Order(userId, productId);
            var userHistory = new UserHistory(userId, "Troca de pontos por produto", product.Value, user.Balance);

            await _dotzContext.AddAsync(order);
            await _dotzContext.AddAsync(userHistory);
            await _dotzContext.SaveChangesAsync();
        }
    }
}
