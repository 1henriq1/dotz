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

        public User(string email, string passwordHash)
        {
            Id = Guid.NewGuid();
            Email = email;
            Balance = 0;
            PasswordHash = passwordHash;                
        }

        public Guid Id { get; }
        public string Email { get; }
        public string PasswordHash { get; set; }
        public int Balance { get; private set; }
        public void AddPoints(int points) => Balance += points;
        public List<Address> Addresses { get; }
    }
}
