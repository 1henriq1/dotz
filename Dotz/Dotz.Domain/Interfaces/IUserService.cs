using Dotz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Domain.Interfaces
{
    public interface IUserService
    {
        Task CreateAsync(string email, string password);
        Task CreateAddressAsync(string description);
        Task<IEnumerable<UserHistory>> GetUserHistoryAsync();
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<string> Login(string email, string password);
        Task GivePoints(string email, int points);
    }
}
