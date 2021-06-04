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
        Task CreateAsync(string email);
        Task CreateAddressAsync(string description);
        Task<IEnumerable<UserHistory>> GetUserHistoryAsync();
        Task<IEnumerable<Order>> GetOrdersAsync();

    }
}
