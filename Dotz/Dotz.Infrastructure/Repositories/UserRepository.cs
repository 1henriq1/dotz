using Dotz.Domain.Entities;
using Dotz.Domain.Interfaces;
using Dotz.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DotzContext _dotzContext;
        public UserRepository(DotzContext dotzContext)
        {
            _dotzContext = dotzContext;
        }

        public async Task AddAsync(User user)
        {
            await _dotzContext.AddAsync(user);
            await _dotzContext.SaveChangesAsync();
        }

        public async Task<User> Find(string email)
        {
            return await _dotzContext.Users.FirstOrDefaultAsync(f => f.Email == email);
        }
        public async Task<User> Find(string email, string passwordHash)
        {
            return await _dotzContext.Users.FirstOrDefaultAsync(f => f.Email == email && f.PasswordHash == passwordHash);
        }

        public async Task Update(User user)
        {
            _dotzContext.Update(user);
            await _dotzContext.SaveChangesAsync();
        }
    }
}
