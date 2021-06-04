using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public abstract class BaseController : Controller
    {
        protected IActionResult Result<TOutput>(TOutput output)
        {
            if (output == null)
                return NoContent();
            return Ok(output);
        }

        protected IActionResult Result<TOutput>(IEnumerable<TOutput> output)
        {
            if (IsNullOrEmpty(output))
                return NoContent();
            return Ok(output);
        }
        private static bool IsNullOrEmpty<T>(IEnumerable<T> list)
        {
            return !list.Any() || list == null;
        }
    }
}
