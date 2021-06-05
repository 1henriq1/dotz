using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Domain.Entities
{
    public class Product
    {
        public Product()
        {

        }
        public Product(string name, int value, int quantity, Guid categoryId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Value = value;
            Quantity = quantity;
            CategoryId = categoryId;
        }
        public Guid Id { get; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
