using Dotz.Domain.Entities;
using Dotz.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Domain.Services
{
    public class UserService : IUserService
    {
        public Task CreateAddressAsync(string description)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserHistory>> GetUserHistoryAsync()
        {
            throw new NotImplementedException();
        }
    }
}
