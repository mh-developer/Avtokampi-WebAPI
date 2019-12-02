using AvtokampiWebAPI.Services;
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
    public class UporabnikiController : ControllerBase
    {
        private readonly IUporabnikiRepository _uporabnikiService;
        private readonly ILogger _logger;

        public UporabnikiController(UporabnikiRepository uporabnikiService, ILogger<UporabnikiController> logger)
        {
            _uporabnikiService = uporabnikiService;
            _logger = logger;
        }

        /// <summary>
        ///     Podatki o uporabniku
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     GET api/uporabniki/1234
        ///
        /// </remarks>
        /// <returns>Objekt Uporabniki</returns>
        /// <param name="user_id">Identifikator uporabnika</param>
        /// <response code="200">Uporabnik</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpGet("{user_id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetUporabnikByID(int user_id)
        {
            try
            {
                var result = _uporabnikiService.GetUporabnikByID(user_id);
                if (result == null)
                {
                    return NotFound(/*new ErrorHandlerModel($"Zaposleni z ID { id }, ne obstaja.", HttpStatusCode.NotFound)*/);
                }
                return Ok(result);
            }
            catch (ArgumentException)
            {
                return BadRequest(/*new ErrorHandlerModel($"Argument ID { id } ni v pravilni obliki.", HttpStatusCode.BadRequest)*/);
            }
            catch (Exception e)
            {
                _logger.LogError("GET uporabnik by id Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Podatki o uporabniku
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     GET api/uporabniki/asd
        ///
        /// </remarks>
        /// <returns>Objekt Uporabniki</returns>
        /// <param name="username">Uporabniško ime uporabnika (email)</param>
        /// <response code="200">Uporabnik</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpGet("{user_id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetUporabnikByUsername(string username)
        {
            try
            {
                var result = _uporabnikiService.GetUporabnikByUsername(username);
                if (result == null)
                {
                    return NotFound(/*new ErrorHandlerModel($"Zaposleni z ID { id }, ne obstaja.", HttpStatusCode.NotFound)*/);
                }
                return Ok(result);
            }
            catch (ArgumentException)
            {
                return BadRequest(/*new ErrorHandlerModel($"Argument ID { id } ni v pravilni obliki.", HttpStatusCode.BadRequest)*/);
            }
            catch (Exception e)
            {
                _logger.LogError("GET uporabnik by username Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }
    }
}