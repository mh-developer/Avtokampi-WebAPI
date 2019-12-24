﻿using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

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

        public UporabnikiController(IUporabnikiRepository uporabnikiService, ILogger<UporabnikiController> logger)
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
        public async Task<IActionResult> GetUporabnikByID(int user_id)
        {
            try
            {
                var result = await _uporabnikiService.GetUporabnikByID(user_id);
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
        ///     Podatki o uporabniku po uporabniškem imenu
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     GET api/uporabniki/asd/username
        ///
        /// </remarks>
        /// <returns>Objekt Uporabniki</returns>
        /// <param name="username">Uporabniško ime uporabnika (email)</param>
        /// <response code="200">Uporabnik</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpGet("{username}/username")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetUporabnikByUsername(string username)
        {
            try
            {
                var result = await _uporabnikiService.GetUporabnikByUsername(username);
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

        /// <summary>
        ///     Mnenja uporabnika
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     GET api/uporabniki/1234/mnenja
        ///
        /// </remarks>
        /// <returns>Objekt Mnenja</returns>
        /// <param name="user_id">Identifikator uporabnika</param>
        /// <response code="200">Mnenja</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpGet("{user_id}/mnenja")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetMnenjeByUporabnik(int user_id)
        {
            try
            {
                var result = await _uporabnikiService.GetMnenjeByUporabnik(user_id);
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
                _logger.LogError("GET GetMnenjeByUporabnik Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Mnenja uporabnikov po avtokampih
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     GET api/uporabniki/avtokamp/1234/mnenja
        ///
        /// </remarks>
        /// <returns>Objekt Mnenja</returns>
        /// <param name="kamp_id">Identifikator avtokampa</param>
        /// <response code="200">Mnenja list</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpGet("avtokamp/{kamp_id}/mnenja")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetMnenjeByAvtokamp(int kamp_id)
        {
            try
            {
                var result = await _uporabnikiService.GetMnenjeByAvtokamp(kamp_id);
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
                _logger.LogError("GET GetMnenjeByUporabnik Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Mnenje uporabnika
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     GET api/uporabniki/1234/mnenje
        ///
        /// </remarks>
        /// <returns>Objekt Mnenja</returns>
        /// <param name="mnenje_id">Identifikator mnenja</param>
        /// <response code="200">Mnenje</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpGet("{mnenje_id}/mnenje")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetMnenje(int mnenje_id)
        {
            try
            {
                var result = await _uporabnikiService.GetMnenje(mnenje_id);
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
                _logger.LogError("GET GetMnenjeByUporabnik Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Dodajanje novega mnenja uporabnika k avtokampu
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     POST api/uporabniki/1234/mnenje
        ///     {
        ///         "Datum": "1234-00-12 12:29"
        ///     }
        ///
        /// </remarks>
        /// <returns>Objekt Mnenja</returns>
        /// <param name="mnenje">Object Mnenja</param>
        /// <param name="kamp_id">Identifikator kampa</param>
        /// <response code="201">If successfully created: true or false</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpPost("{kamp_id}/mnenje")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateMnenje([FromBody] Mnenja mnenje, int kamp_id)
        {
            try
            {
                var result = await _uporabnikiService.CreateMnenje(mnenje, kamp_id);
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
                _logger.LogError("GET GetMnenjeByUporabnik Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Urejanje podatkov o mnenju uporabnika
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     PUT api/uporabniki/1234/mnenje
        ///     {
        ///         "Datum": "Nov datum"
        ///     }
        ///
        /// </remarks>
        /// <returns>Objekt Mnenja</returns>
        /// <param name="mnenje">Object Mnenja</param>
        /// <param name="mnenje_id">Identifikator mnenja</param>
        /// <response code="204">No content</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpPut("{mnenje_id}/mnenje")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateMnenje([FromBody] Mnenja mnenje, int mnenje_id)
        {
            try
            {
                var result = await _uporabnikiService.UpdateMnenje(mnenje, mnenje_id);
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
                _logger.LogError("GET GetMnenjeByUporabnik Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Brisanje mnenje uporabnika
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     DELETE api/uporabniki/1234/mnenje
        ///
        /// </remarks>
        /// <returns>Boolean value</returns>
        /// <param name="mnenje_id">Identifikator mnenja</param>
        /// <response code="204">No content</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpDelete("{mnenje_id}/mnenje")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RemoveMnenje(int mnenje_id)
        {
            try
            {
                var result = await _uporabnikiService.RemoveMnenje(mnenje_id);
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
                _logger.LogError("GET GetMnenjeByUporabnik Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }
    }
}