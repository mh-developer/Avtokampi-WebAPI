using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvtokampiWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authService;

        public AuthController(IAuthRepository authService)
        {
            _authService = authService;
        }

        /// <summary>
        ///     Prijava uporabnika
        /// </summary>
        /// <returns>JWT Token</returns>
        /// <response code="200">Response JWT Token</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="401">Unauthorized</response>
        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult RequestToken([FromBody] TokenModel request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                string token;
                if (_authService.IsAuthenticated(request, out token))
                {
                    return Ok(new { token });
                }

                return Unauthorized(/*new ErrorHandlerModel("Napačno uporabniško ime ali geslo", HttpStatusCode.Unauthorized)*/);
            }
            catch (Exception e)
            {
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }
    }
}