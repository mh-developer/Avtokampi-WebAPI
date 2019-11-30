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
    public class StoritveKampaController : ControllerBase
    {
        private readonly IStoritveKampaRepository _storitveKampaService;
        private readonly ILogger _logger;

        public StoritveKampaController(StoritveKampaRepository storitveKampaService, ILogger<StoritveKampaController> logger)
        {
            _storitveKampaService = storitveKampaService;
            _logger = logger;
        }
    }
}