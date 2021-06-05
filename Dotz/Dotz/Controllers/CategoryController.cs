using Dotz.Application.Requests;
using Dotz.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Application.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IActionResult))]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryRequest request)
        {
            await _categoryService.CreateAsync(request.Name, request.ParentId);
            return Ok();
        }
    }
}
