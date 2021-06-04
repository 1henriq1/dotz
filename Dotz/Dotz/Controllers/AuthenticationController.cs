using Dotz.Domain.Entities;
using Dotz.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Application.Controllers
{
    public class AuthenticationController : BaseController
    {
        private readonly ITokenService _tokenService;

        public AuthenticationController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] string email, string password)
        {
            // Recupera o usuário
            //var user = UserRepository.Get(model.Username, model.Password);
            var user = new User(email);
            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = _tokenService.GenerateToken(user);


            // Retorna os dados
            return Ok(token);
        }
    }
}
