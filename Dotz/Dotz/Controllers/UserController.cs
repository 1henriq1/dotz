using Dotz.Application.Requests;
using Dotz.Domain.Entities;
using Dotz.Domain.Interfaces;
using Dotz.Domain.Responses;
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
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IActionResult))]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserRequest request)
        {
            try
            {
                await _userService.CreateAsync(request.Email, request.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        
        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                return Ok(await _userService.Login(request.Email, request.Password));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("address")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IActionResult))]
        public async Task<IActionResult> CreateAddressAsync([FromBody] string description)
        {
            await _userService.CreateAddressAsync(description);
            return Ok();
        }

        [HttpPut("points")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IActionResult))]
        public async Task<IActionResult> GivePoints([FromBody] GivePointsRequest request)
        {
            await _userService.GivePoints(request.Email, request.Points);
            return Ok();
        }

        [HttpGet("balance")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserHistory>))]
        public async Task<IActionResult> GetBalanceAsync()
        {
            var userHistories = await _userService.GetUserHistoryAsync();
            return Result(new BalanceResponse(userHistories.Max(m => m.Balance), userHistories));
        }


        [HttpGet("orders")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Order>))]
        public async Task<IActionResult> GetOrdersAsync()
        {
            return Result(await _userService.GetOrdersAsync());
        }
    }
}
