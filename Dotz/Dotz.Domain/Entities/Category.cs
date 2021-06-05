using System;
using System.Collections.Generic;

namespace Dotz.Domain.Entities
{
    public class Category
    {
        public Category()
        {

        }
        public Category(string name, string parentId)
        {
            Id = Guid.NewGuid();
            if(parentId != null)
                ParentId = Guid.Parse(parentId);
            Name = name;
        }
        public Guid Id { get; }
        public Guid? ParentId { get; }
        public Category ParentCategory { get; set; }
        public List<Category> SubCategories { get; set; }
        public string Name { get; }
    }
}