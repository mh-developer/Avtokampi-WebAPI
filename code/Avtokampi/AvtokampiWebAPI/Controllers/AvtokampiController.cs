using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

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

        public AvtokampiController(IAvtokampiRepository avtokampiService, ILogger<AvtokampiController> logger)
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
        [AllowAnonymous]
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
        [AllowAnonymous]
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

        /// <summary>
        ///     Slike za posamezni avtokamp
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     GET api/Avtokampi/1234/slike
        ///
        /// </remarks>
        /// <returns>Objekt slik Avtokampa</returns>
        /// <param name="kamp_id">Identifikator avtokampa</param>
        /// <response code="200">Slike Avtokampa</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpGet("{kamp_id}/slike")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [AllowAnonymous]
        public IActionResult GetSlikeAvtokampa(int kamp_id)
        {
            try
            {
                var result = _avtokampiService.GetSlikeAvtokampa(kamp_id);
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
                _logger.LogError("GET slike avtokamp Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Dodajanje slike novega avtokampa
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     POST api/Avtokampi/slika
        ///     {
        ///         "Naziv": "Slika"
        ///     }
        ///
        /// </remarks>
        /// <returns>Boolean value, success or not</returns>
        /// <param name="slika">Podatki o novi sliki za avtokamp</param>
        /// <param name="kamp_id">Identifikator avtokampa</param>
        /// <response code="201">If successfully created: true or false</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpPost("{kamp_id}/slika")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult CreateSlikaAvtokampa([FromBody] Slike slika, int kamp_id)
        {
            try
            {
                var result = _avtokampiService.CreateSlikaAvtokampa(slika, kamp_id);
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
                _logger.LogError("CREATE CreateSlikaAvtokampa Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Dodajanje seznama novih slik avtokampa
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     POST api/Avtokampi/{kamp_id}/slike
        ///     {
        ///         "Naziv": "Ime avtokampa"
        ///     }
        ///
        /// </remarks>
        /// <returns>Boolean value, success or not</returns>
        /// <param name="slike">Podatki novega avtokampa</param>
        /// <param name="kamp_id">Identifikator avtokampa</param>
        /// <response code="201">If successfully created: true or false</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpPost("{kamp_id}/slike")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult CreateListSlikeAvtokampa([FromBody] List<Slike> slike, int kamp_id)
        {
            try
            {
                var result = _avtokampiService.CreateSlikeAvtokampa(slike, kamp_id);
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
                _logger.LogError("CREATE CreateListSlikeAvtokampa Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Urejanje slike avtokampa
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
        /// <param name="slika">Podatki popravljenega avtokampa</param>
        /// <param name="slika_id">Identifikator slike</param>
        /// <response code="204">No content</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpPut("{slika_id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult UpdateSlikaAvtokampa([FromBody] Slike slika, int slika_id)
        {
            try
            {
                var result = _avtokampiService.UpdateSlikaAvtokampa(slika, slika_id);
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
                _logger.LogError("UPDATE UpdateSlikaAvtokampa Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        ///// <summary>
        /////     Urejanje podatkov o avtokampu
        ///// </summary>
        ///// <remarks>
        ///// Primer zahtevka:
        /////
        /////     PUT api/Avtokampi/1234
        /////     {
        /////         "Naziv": "Novo ime avtokampa"
        /////     }
        /////
        ///// </remarks>
        ///// <returns>Objekt Avtokamp</returns>
        ///// <param name="slike">Podatki popravljenega avtokampa</param>
        ///// <param name="slike_ids"></param>
        ///// <param name="slike_id">Identifikator slike</param>
        ///// <response code="204">No content</response>
        ///// <response code="400">Bad request error massage</response>
        ///// <response code="404">Not found error massage</response>
        //[HttpPut("{slike_id}")]
        //[ProducesResponseType(204)]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(400)]
        //public IActionResult UpdateSlikeAvtokampa([FromBody] List<Slike> slike, [FromBody] List<int> slike_ids, int slike_id)
        //{
        //    try
        //    {
        //        var result = _avtokampiService.UpdateSlikeAvtokampa(slike, slike_ids);
        //        if (result == null)
        //        {
        //            return NotFound(/*new ErrorHandlerModel($"Zaposleni z ID { id }, ne obstaja.", HttpStatusCode.NotFound)*/);
        //        }
        //        return NoContent();
        //    }
        //    catch (ArgumentException)
        //    {
        //        return BadRequest(/*new ErrorHandlerModel($"Argument ID { id } ni v pravilni obliki.", HttpStatusCode.BadRequest)*/);
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError("UPDATE UpdateSlikeAvtokampa Unhandled exception ...", e);
        //        return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
        //    }
        //}

        /// <summary>
        ///     Brisanje slike avtokampa
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     DELETE api/Avtokampi/1234
        ///
        /// </remarks>
        /// <returns>Boolean value</returns>
        /// <param name="slika_id">Identifikator slike</param>
        /// <response code="204">No content</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpDelete("{slika_id}/slika")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult DeleteSlikaAvtokampa(int slika_id)
        {
            try
            {
                var result = _avtokampiService.RemoveSlikaAvtokampa(slika_id);
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

        /// <summary>
        ///     Ceniki avtokampa
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
        [HttpGet("{kamp_id}/ceniki")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [AllowAnonymous]
        public IActionResult GetCenikiAvtokampa(int kamp_id)
        {
            try
            {
                var result = _avtokampiService.GetCenikiAvtokampa(kamp_id);
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
                _logger.LogError("GET GetCenikiAvtokampa Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Podrobnosti cenika avtokampa
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     GET api/Avtokampi/1234
        ///
        /// </remarks>
        /// <returns>Objekt Avtokamp</returns>
        /// <param name="cenik_id">Identifikator avtokampa</param>
        /// <response code="200">Avtokamp</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpGet("{cenik_id}/cenik")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [AllowAnonymous]
        public IActionResult GetCenikAvtokampa(int cenik_id)
        {
            try
            {
                var result = _avtokampiService.GetCenikAvtokampa(cenik_id);
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
                _logger.LogError("GET GetCenikiAvtokampa Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Dodajanje novega cenika avtokampa
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
        /// <param name="cenik">Podatki novega avtokampa</param>
        /// <param name="kamp_id"></param>
        /// <response code="201">If successfully created: true or false</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpPost("{kamp_id}/cenik")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult CreateCenikAvtokampa([FromBody] Ceniki cenik, int kamp_id)
        {
            try
            {
                var result = _avtokampiService.CreateCenikAvtokampa(cenik, kamp_id);
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
                _logger.LogError("CREATE CreateCenikAvtokampa Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Urejanje podatkov o ceniku
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
        /// <param name="cenik">Podatki popravljenega avtokampa</param>
        /// <param name="cenik_id">Identifikator avtokampa</param>
        /// <response code="204">No content</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpPut("{cenik_id}/cenik")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult UpdateCenikAvtokampa([FromBody] Ceniki cenik, int cenik_id)
        {
            try
            {
                var result = _avtokampiService.UpdateCenik(cenik, cenik_id);
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
                _logger.LogError("UPDATE UpdateCenikAvtokampa Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Brisanje cenika
        /// </summary>
        /// <remarks>
        /// Primer zahtevka:
        ///
        ///     DELETE api/Avtokampi/1234
        ///
        /// </remarks>
        /// <returns>Boolean value</returns>
        /// <param name="cenik_id">Identifikator avtokampa</param>
        /// <response code="204">No content</response>
        /// <response code="400">Bad request error massage</response>
        /// <response code="404">Not found error massage</response>
        [HttpDelete("{cenik_id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult DeleteCenikAvtokampa(int cenik_id)
        {
            try
            {
                var result = _avtokampiService.RemoveCenikAvtokampa(cenik_id);
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

        /// <summary>
        ///     Seznam regij
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
        [HttpGet("regije")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [AllowAnonymous]
        public IActionResult GetRegije()
        {
            try
            {
                var result = _avtokampiService.GetRegije();
                if (result == null)
                {
                    return NotFound(/*new ErrorHandlerModel($"Zaposleni z ID { id }, ne obstaja.", HttpStatusCode.NotFound)*/);
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError("GET GetRegije Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }

        /// <summary>
        ///     Seznam držav
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
        [HttpGet("drzave")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [AllowAnonymous]
        public IActionResult GetDrzave()
        {
            try
            {
                var result = _avtokampiService.GetDrzave();
                if (result == null)
                {
                    return NotFound(/*new ErrorHandlerModel($"Zaposleni z ID { id }, ne obstaja.", HttpStatusCode.NotFound)*/);
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError("GET GetDrzave Unhandled exception ...", e);
                return BadRequest(/*new ErrorHandlerModel(e.Message, HttpStatusCode.BadRequest)*/);
            }
        }
    }
}