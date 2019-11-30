using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace AvtokampiWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authService;
        private readonly ILogger _logger;

        public AuthController(IAuthRepository authService, ILogger<AvtokampiController> logger)
        {
            _authService = authService;
            _logger = logger;
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
            catch (Exception)
            {
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }
    }
}