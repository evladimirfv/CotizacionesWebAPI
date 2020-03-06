using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CotizacionesWebAPI.Services;

namespace CotizacionesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotizacionController : ControllerBase
    {

        ServiceContext sc = new ServiceContext(new CotizacionA());
        

        // GET api/cotizacion/5
        [HttpGet("{id}")]
        public string Get(string id = null)
        {

            return sc.ObtenerCotizacion(id);
        }

       
    }
}
