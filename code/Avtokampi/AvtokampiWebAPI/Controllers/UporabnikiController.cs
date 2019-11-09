using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvtokampiWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                return Ok(_db.Users.ToList());
            }
            return null;
        }
    }
}