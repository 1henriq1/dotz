using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Application.Requests
{
    public class CreateCategoryRequest
    {
        public string Name { get; set; }
        public string ParentId { get; set; }
    }
}
