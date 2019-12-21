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
    public class StoritveKampaController : ControllerBase
    {
        private readonly IStoritveKampaRepository _storitveKampaService;
        private readonly ILogger _logger;

        public StoritveKampaController(IStoritveKampaRepository storitveKampaService, ILogger<StoritveKampaController> logger)
        {
            _storitveKampaService = storitveKampaService;
            _logger = logger;
        }

        /// <summary>
        ///     Seznam storitev avtokampa
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     GET api/storitvekampa/123
        ///
        /// </remarks>
        /// <returns>Seznam vseh aktivnih storitev avtokampa</returns>
        /// <param name="kamp_id">Identifikator avtokampa</param>
        /// <response code="200">Seznam storitev avtokampa</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpGet("{kamp_id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetStoritveAvtokampa(int kamp_id)
        {
            try
            {
                var result = _storitveKampaService.GetStortiveByAvtokamp(kamp_id);
                if (result == null)
                {
                    return NotFound(/*new ErrorHandlerModel($"Zaposleni z ID { id }, ne obstaja.", HttpStatusCode.NotFound)*/);
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError("GET storitve kampa Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Seznam storitev za kampirno mesto
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     GET api/storitvekampa/1234
        ///
        /// </remarks>
        /// <returns>Objekt StoritveKampa</returns>
        /// <param name="kamp_mesto_id">Identifikator kampirnega mesta</param>
        /// <response code="200">Seznam storitev kampirnega mesta</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpGet("{kamp_mesto_id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetStoritveKampirnegaMesta(int kamp_mesto_id)
        {
            try
            {
                var result = _storitveKampaService.GetStoritveByKampirnoMesto(kamp_mesto_id);
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
                _logger.LogError("GET storitve kampirnega mesta Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Podrobnosti storitve
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     GET api/storitvekampa/1234
        ///
        /// </remarks>
        /// <returns>Objekt StoritveKampa</returns>
        /// <param name="storitev_id">Identifikator storitve</param>
        /// <response code="200">Podrobnosti o storitvi</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpGet("{storitev_id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetStoritev(int storitev_id)
        {
            try
            {
                var result = _storitveKampaService.GetStoritevByID(storitev_id);
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
                _logger.LogError("GET storitev Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Dodajanje nove storitve
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     POST api/storitvekampa
        ///     {
        ///         "Naziv": "Ime storitvekampa"
        ///     }
        ///
        /// </remarks>
        /// <returns>Boolean value, success or not</returns>
        /// <param name="storitev">Podatki nove storitve</param>
        /// <param name="kamp_id">Identifikator kampa</param>
        /// <response code="201">If successfully created: true or false</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpPost("{kamp_id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult CreateStoritev([FromBody] Storitve storitev, int kamp_id)
        {
            try
            {
                var result = _storitveKampaService.CreateStoritev(storitev, kamp_id);
                if (result == null)
                {
                    return NotFound(/*new ErrorHandlerModel($"Zaposleni z ID { id }, ne obstaja.", HttpStatusCode.NotFound)*/);
                }
                return Created("/storitvekampa/id", result);
            }
            catch (ArgumentException)
            {
                return BadRequest(/*new ErrorHandlerModel($"Argument ID { id } ni v pravilni obliki.", HttpStatusCode.BadRequest)*/);
            }
            catch (Exception e)
            {
                _logger.LogError("CREATE storitve Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Urejanje podatkov o storitvi
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     PUT api/storitvekampa/1234
        ///     {
        ///         "Naziv": "Nov ime storitvekampa"
        ///     }
        ///
        /// </remarks>
        /// <returns>Objekt Storitve</returns>
        /// <param name="storitev">Podatki popravljene storitve</param>
        /// <param name="storitev_id">Identifikator storitve</param>
        /// <response code="204">No content</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpPut("{storitev_id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult UpdateStoritev([FromBody] Storitve storitev, int storitev_id)
        {
            try
            {
                var result = _storitveKampaService.UpdateStoritev(storitev, storitev_id);
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
                _logger.LogError("UPDATE storitve Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Brisanje storitve
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     DELETE api/storitvekampa/1234
        ///
        /// </remarks>
        /// <returns>Boolean value</returns>
        /// <param name="storitev_id">Identifikator storitve</param>
        /// <response code="204">No content</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpDelete("{storitev_id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult DeleteStoritev(int storitev_id)
        {
            try
            {
                var result = _storitveKampaService.RemoveStoritev(storitev_id);
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
                _logger.LogError("DELETE storitve Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Seznam kategorij storitev
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     GET api/storitvekampa/kategorije
        ///
        /// </remarks>
        /// <returns>Seznam kategorij storitev</returns>
        /// <response code="200">Seznam kategorij storitev</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpGet("kategorije")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetKategorijeStoritev()
        {
            try
            {
                var result = _storitveKampaService.GetKategorijeStoritev();
                if (result == null)
                {
                    return NotFound(/*new ErrorHandlerModel($"Zaposleni z ID { id }, ne obstaja.", HttpStatusCode.NotFound)*/);
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError("GET GetKategorijeStoritev Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }
    }
}