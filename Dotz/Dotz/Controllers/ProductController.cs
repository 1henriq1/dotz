using Dotz.Application.Requests;
using Dotz.Domain.Entities;
using Dotz.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Application.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IActionResult))]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProductRequest request)
        {
            await _productService.CreateAsync(request.Name, request.Value, request.Quantity, request.CategoryId);
            return Ok();
        }

        [HttpPost("trade")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IActionResult))]
        public async Task<IActionResult> TradeAsync([FromBody] string productId)
        {
            await _productService.TradeAsync(Guid.Parse(productId));
            return Ok();
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Product>))]
        public async Task<IActionResult> GetAsync()
        {
            return Result(await _productService.GetAsync());
        }
    }
}
