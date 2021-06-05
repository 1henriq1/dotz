using Dotz.Domain.Entities;
using Dotz.Domain.Interfaces;
using Dotz.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(DotzContext dotzContext, IHttpContextAccessor httpContextAccessor) : base(dotzContext)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddAsync(User user)
        {
            await _dotzContext.AddAsync(user);
            await _dotzContext.SaveChangesAsync();
        }

        public async Task CreateUserAddress(string description)
        {
            var newAddress = new Address(description, GetUserIdFromContext());
            await _dotzContext.AddAsync(newAddress);
            await _dotzContext.SaveChangesAsync();
        }

        private Guid GetUserIdFromContext()
        {
            return Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue("UserId"));
        }

        public async Task<User> Find(string email)
        {
            return await _dotzContext.Users.FirstOrDefaultAsync(f => f.Email == email);
        }
        public async Task<User> Find(string email, string passwordHash)
        {
            return await _dotzContext.Users.FirstOrDefaultAsync(f => f.Email == email && f.PasswordHash == passwordHash);
        }

        public async Task<IEnumerable<UserHistory>> GetUserHistories()
        {
            return await _dotzContext.UserHistories.Where(w => w.UserId == GetUserIdFromContext()).ToListAsync();
        }

        public async Task Update(User user, UserHistory userHistory)
        {
            _dotzContext.Update(user);
            await _dotzContext.AddAsync(userHistory);
            await _dotzContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            var userId = GetUserIdFromContext();
            return await _dotzContext.Orders.Include(i => i.User).Include(i => i.Product).Where(w => w.UserId == userId).ToListAsync();
        }
    }
}
