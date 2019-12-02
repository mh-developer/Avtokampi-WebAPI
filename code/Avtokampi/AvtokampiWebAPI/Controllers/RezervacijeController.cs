using AvtokampiWebAPI.Models;
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
    public class RezervacijeController : ControllerBase
    {
        private readonly IRezervacijeRepository _rezervacijeService;
        private readonly ILogger _logger;

        public RezervacijeController(RezervacijeRepository rezervacijeService, ILogger<RezervacijeController> logger)
        {
            _rezervacijeService = rezervacijeService;
            _logger = logger;
        }


        /// <summary>
        ///     Seznam rezervacij za prijavljenega uporabnika
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     GET api/rezervacije
        ///
        /// </remarks>
        /// <returns>Seznam rezervacij</returns>
        /// <response code="200">Seznam rezervacij za uporabnika</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpGet("{user_id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetRerezvacijeByUporabnik(int user_id)
        {
            try
            {
                var result = _rezervacijeService.GetRezervacijeByUporabnik(user_id);
                if (result == null)
                {
                    return NotFound(/*new ErrorHandlerModel($"Zaposleni z ID { id }, ne obstaja.", HttpStatusCode.NotFound)*/);
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError("GET rezervacije by user Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Podatki o rezervaciji
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     GET api/rezervacije/1234
        ///
        /// </remarks>
        /// <returns>Objekt Rezervacije</returns>
        /// <param name="rez_id">Identifikator rezervacije</param>
        /// <response code="200">Rezervacija</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpGet("{rez_id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetRezervacijaByID(int rez_id)
        {
            try
            {
                var result = _rezervacijeService.GetRezervacijaByID(rez_id);
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
                _logger.LogError("GET rezervacije by id Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Dodajanje nove rezervacije
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     POST api/rezervacije
        ///     {
        ///         "Datum": "1234-00-12 12:29"
        ///     }
        ///
        /// </remarks>
        /// <returns>Boolean value, success or not</returns>
        /// <param name="rezervacija">Podatki nove rezervacije</param>
        /// <response code="201">If successfully created: true or false</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult CreateRezervacija([FromBody] Rezervacije rezervacija)
        {
            try
            {
                var result = _rezervacijeService.CreateRezervacija(rezervacija);
                if (result == null)
                {
                    return NotFound(/*new ErrorHandlerModel($"Zaposleni z ID { id }, ne obstaja.", HttpStatusCode.NotFound)*/);
                }
                return Created("/rezervacije/id", result);
            }
            catch (ArgumentException)
            {
                return BadRequest(/*new ErrorHandlerModel($"Argument ID { id } ni v pravilni obliki.", HttpStatusCode.BadRequest)*/);
            }
            catch (Exception e)
            {
                _logger.LogError("CREATE rezervacije Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Urejanje podatkov o rezervaciji
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     PUT api/rezervacije/1234
        ///     {
        ///         "Datum": "Nov datum"
        ///     }
        ///
        /// </remarks>
        /// <returns>Objekt Rezervacije</returns>
        /// <param name="rezervacija">Podatki popravljene rezervacije</param>
        /// <param name="rez_id">Identifikator rezervacije</param>
        /// <response code="204">No content</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpPut("{rez_id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult UpdateRezervacije([FromBody] Rezervacije rezervacija, int rez_id)
        {
            try
            {
                var result = _rezervacijeService.UpdateRezervacija(rezervacija, rez_id);
                if (result == null)
                {
                    return NotFound(/*new ErrorHandlerModel($"Zaposleni z ID { id }, ne obstaja.", HttpStatusCode.NotFound)*/);
                }
                return NoContent();
            }
            catch (ArgumentException)
            {
                return BadRequest(/*new ErrorHandlerModel($"Argument ID { id } ni v pravilni obliki.", HttpStatusCode.BadRequest)*/);
            }
            catch (Exception e)
            {
                _logger.LogError("UPDATE rezervacije Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Brisanje rezervacije
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     DELETE api/rezervacije/1234
        ///
        /// </remarks>
        /// <returns>Boolean value</returns>
        /// <param name="rez_id">Identifikator rezervacije</param>
        /// <response code="204">No content</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpDelete("{rez_id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult DeleteRezervacija(int rez_id)
        {
            try
            {
                var result = _rezervacijeService.RemoveRezervacija(rez_id);
                if (result == null)
                {
                    return NotFound(/*new ErrorHandlerModel($"Zaposleni z ID { id }, ne obstaja.", HttpStatusCode.NotFound)*/);
                }
                return NoContent();
            }
            catch (ArgumentException)
            {
                return BadRequest(/*new ErrorHandlerModel($"Argument ID { id } ni v pravilni obliki.", HttpStatusCode.BadRequest)*/);
            }
            catch (Exception e)
            {
                _logger.LogError("DELETE rezervacije Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }
    }
}