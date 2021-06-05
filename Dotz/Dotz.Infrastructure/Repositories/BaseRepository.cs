using Dotz.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Infrastructure.Repositories
{
    public abstract class BaseRepository<TEntity>
    {
        protected readonly DotzContext _dotzContext;
        public BaseRepository(DotzContext dotzContext)
        {
            _dotzContext = dotzContext;
        }
        public async Task AddAsync(TEntity product)
        {
            await _dotzContext.AddAsync(product);
            await _dotzContext.SaveChangesAsync();
        }
        protected Guid GetUserIdFromContext(IHttpContextAccessor httpContextAccessor)
        {
            return Guid.Parse(httpContextAccessor.HttpContext.User.FindFirstValue("UserId"));
        }
    }
}
