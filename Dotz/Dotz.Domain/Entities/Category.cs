using System;
using System.Collections.Generic;

namespace Dotz.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public List<Category> SubCategories { get; set; }
        public string Name { get; set; }
    }
}