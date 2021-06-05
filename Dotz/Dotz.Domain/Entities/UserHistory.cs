using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dotz.Domain.Entities
{
    public class UserHistory
    {
        public UserHistory()
        {

        }
        public UserHistory(Guid userId, string operation, int value, int balance)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Operation = operation;
            OperationDate = DateTime.Now;
            Value = value;
            Balance = balance;
        }
        public Guid Id { get; }
        [JsonIgnore]
        public Guid UserId { get; }
        [JsonIgnore]
        public User User { get; set; }
        public DateTime OperationDate { get;  }
        public string Operation { get; }
        public int Value { get; }
        public int Balance { get; }
    }
}
