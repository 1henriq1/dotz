using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Domain.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync(string name, string parentId = null);
    }
}
