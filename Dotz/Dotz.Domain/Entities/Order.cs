using Dotz.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dotz.Domain.Entities
{
    public class Order
    {
        public Order()
        {

        }
        public Order(Guid userId, Guid productId)
        {
            UserId = userId;
            ProductId = productId;
            Status = OrderStatusEnum.Pending;
        }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public Product Product { get; set; }
        public OrderStatusEnum Status { get; set; }
    }
}
