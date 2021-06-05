using Dotz.Domain.Entities;
using Dotz.Domain.Interfaces;
using Dotz.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DotzContext context) : base(context)
        {

        }
    }
}
