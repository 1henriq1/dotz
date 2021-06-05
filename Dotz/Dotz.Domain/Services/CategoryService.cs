using Dotz.Domain.Entities;
using Dotz.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CreateAsync(string name, string parentId = null)
        {
            var newCategory = new Category(name, parentId);
            await _categoryRepository.AddAsync(newCategory);
        }
    }
}
