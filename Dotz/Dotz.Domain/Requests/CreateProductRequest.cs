using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Application.Requests
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }
    }
}
