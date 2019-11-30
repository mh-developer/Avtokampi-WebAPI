using AvtokampiWebAPI.Models;
using AvtokampiWebAPI.Services;
using AvtokampiWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

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

        [HttpGet]
        public ActionResult GetAll()
        {
            using (var _db = new avtokampiContext())
            {
                return Ok(_db.Uporabniki.ToList());
            }
        }
    }
}