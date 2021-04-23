using DemoData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmisoresController : ControllerBase
    {
       

        [HttpGet]
        public List<Emisores> Get()
        {
            myHelperData contexData = new myHelperData();
            return contexData.GeTEmisores();
        }
        [HttpPost]
        public void Post([FromBody] Emisores value)
        {
            myHelperData contexData = new myHelperData();
            contexData.SaveEmisores(value);
        }
    }
}
