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
    public class AvtokampiController : ControllerBase
    {
        private readonly IAvtokampiRepository _avtokampiService;
        private readonly ILogger _logger;

        public AvtokampiController(AvtokampiRepository avtokampiService, ILogger<AvtokampiController> logger)
        {
            _avtokampiService = avtokampiService;
            _logger = logger;
        }


        /// <summary>
        ///     Seznam avtokampov
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     GET api/Avtokampi
        ///
        /// </remarks>
        /// <returns>Seznam vseh aktivnih avtokampov</returns>
        /// <response code="200">Seznam avtokampov</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetAllAvtokampi()
        {
            try
            {
                var result = _avtokampiService.GetAll();
                if (result == null)
                {
                    return NotFound(/*new ErrorHandlerModel($"Zaposleni z ID { id }, ne obstaja.", HttpStatusCode.NotFound)*/);
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError("GET all avtokampi Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Podatki o posameznemu avtokampu
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     GET api/Avtokampi/1234
        ///
        /// </remarks>
        /// <returns>Objekt Avtokamp</returns>
        /// <param name="kamp_id">Identifikator avtokampa</param>
        /// <response code="200">Avtokamp</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpGet("{kamp_id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetAvtokamp(int kamp_id)
        {
            try
            {
                var result = _avtokampiService.GetAvtokampByID(kamp_id);
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
                _logger.LogError("GET avtokamp Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Dodajanje novega avtokampa
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     POST api/Avtokampi
        ///     {
        ///         "Naziv": "Ime avtokampa"
        ///     }
        ///
        /// </remarks>
        /// <returns>Boolean value, success or not</returns>
        /// <param name="avtokamp">Podatki novega avtokampa</param>
        /// <response code="201">If successfully created: true or false</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult CreateAvtokamp([FromBody] Avtokampi avtokamp)
        {
            try
            {
                var result = _avtokampiService.CreateAvtokamp(avtokamp);
                if (result == null)
                {
                    return NotFound(/*new ErrorHandlerModel($"Zaposleni z ID { id }, ne obstaja.", HttpStatusCode.NotFound)*/);
                }
                return Created("/avtokampi/id", result);
            }
            catch (ArgumentException)
            {
                return BadRequest(/*new ErrorHandlerModel($"Argument ID { id } ni v pravilni obliki.", HttpStatusCode.BadRequest)*/);
            }
            catch (Exception e)
            {
                _logger.LogError("CREATE avtokamp Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Urejanje podatkov o avtokampu
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     PUT api/Avtokampi/1234
        ///     {
        ///         "Naziv": "Novo ime avtokampa"
        ///     }
        ///
        /// </remarks>
        /// <returns>Objekt Avtokamp</returns>
        /// <param name="avtokamp">Podatki popravljenega avtokampa</param>
        /// <param name="kamp_id">Identifikator avtokampa</param>
        /// <response code="204">No content</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpPut("{kamp_id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult UpdateAvtokampi([FromBody] Avtokampi avtokamp, int kamp_id)
        {
            try
            {
                var result = _avtokampiService.UpdateAvtokamp(avtokamp, kamp_id);
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
                _logger.LogError("UPDATE avtokamp Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Brisanje avtokampa
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     DELETE api/Avtokampi/1234
        ///
        /// </remarks>
        /// <returns>Boolean value</returns>
        /// <param name="kamp_id">Identifikator avtokampa</param>
        /// <response code="204">No content</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpDelete("{kamp_id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult DeleteAvtokampi(int kamp_id)
        {
            try
            {
                var result = _avtokampiService.RemoveAvtokamp(kamp_id);
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
                _logger.LogError("DELETE avtokamp Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }
    }
}