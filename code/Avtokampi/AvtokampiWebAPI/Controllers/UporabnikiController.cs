using AvtokampiWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AvtokampiWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UporabnikiController : ControllerBase
    {

        [HttpGet]
        public ActionResult getAll()
        {
            using (var _db = new avtokampiContext())
            {
                return Ok(_db.Uporabniki.ToList());
            }
            return null;
        }
    }
}