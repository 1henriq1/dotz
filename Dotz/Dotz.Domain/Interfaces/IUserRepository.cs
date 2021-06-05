using Dotz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Find(string email);
        Task<User> Find(string email, string passwordHash);
        Task Update(User user, UserHistory userHistory);
        Task CreateUserAddress(string description);
        Task<IEnumerable<UserHistory>> GetUserHistories();
        Task<IEnumerable<Order>> GetOrders();
    }
}
