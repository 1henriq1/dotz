using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Domain.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
    }
}
