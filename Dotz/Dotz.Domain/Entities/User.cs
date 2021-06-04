using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Domain.Entities
{
    public class User
    {
        public User()
        {

        }

        public User(string email)
        {
            Id = Guid.NewGuid();
            Email = email;
            Balance = 0;
        }

        public Guid Id { get; }
        public string Email { get; }
        public string Password { get; set; }
        public int Balance { get; }
        public List<Address> Addresses { get; }
    }
}
