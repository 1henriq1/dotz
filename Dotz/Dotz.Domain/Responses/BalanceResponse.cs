using Dotz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Domain.Responses
{
    public class BalanceResponse
    {
        public BalanceResponse(int balance, IEnumerable<UserHistory> statements)
        {
            Balance = balance;
            Statements = statements;
        }
        public int Balance { get; }
        public IEnumerable<UserHistory> Statements { get; }
    }
}
