using System;

namespace Dotz.Domain.Entities
{
    public class Address
    {
        public Address()
        {

        }
        public Address(string description, Guid userId)
        {
            Id = Guid.NewGuid();
            Description = description;
            UserId = userId;
        }
        public Guid Id { get; }
        public Guid UserId { get; }
        public User User { get; set; }
        public string Description { get; }
    }
}