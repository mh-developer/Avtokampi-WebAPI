using AvtokampiWebAPI.Services;
using AvtokampiWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
    }
}