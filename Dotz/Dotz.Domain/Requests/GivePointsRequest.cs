using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Application.Requests
{
    public class GivePointsRequest
    {
        public string Email { get; set; }
        public int Points { get; set; }
    }
}
