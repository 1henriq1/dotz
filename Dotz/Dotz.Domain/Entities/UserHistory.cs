using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Domain.Entities
{
    public class UserHistory
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime OperationDate { get; set; }
        public string Operation { get; set; }
        public int Value { get; set; }
        public int Balance { get; set; }
    }
}
