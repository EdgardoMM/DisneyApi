using DisneyAPI.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class characters : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            RPPersonaje rpPj = new RPPersonaje();
            return Ok(rpPj.ObtenerPersonaje());
        }
    }
}
