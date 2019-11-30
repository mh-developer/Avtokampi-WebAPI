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
    public class KampirnaMestaController : ControllerBase
    {
        private readonly IKampirnaMestaRepository _kampirnaMestaService;
        private readonly ILogger _logger;

        public KampirnaMestaController(KampirnaMestaRepository kampirnaMestaService, ILogger<KampirnaMestaController> logger)
        {
            _kampirnaMestaService = kampirnaMestaService;
            _logger = logger;
        }
    }
}