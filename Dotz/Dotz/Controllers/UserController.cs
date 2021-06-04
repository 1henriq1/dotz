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
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IActionResult))]
        public async Task<IActionResult> CreateAsync([FromBody] string email)
        {
            await _userService.CreateAsync(email);
            return Ok();
        }

        [HttpPost("address")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IActionResult))]
        public async Task<IActionResult> CreateAddressAsync([FromBody] string description)
        {
            await _userService.CreateAddressAsync(description);
            return Ok();
        }

        [HttpGet("balance")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserHistory>))]
        public async Task<IActionResult> GetBalanceAsync()
        {
            return Result(await _userService.GetUserHistoryAsync());
        }


        [HttpGet("orders")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Order>))]
        public async Task<IActionResult> GetOrdersAsync()
        {
            return Result(await _userService.GetOrdersAsync());
        }
    }
}
