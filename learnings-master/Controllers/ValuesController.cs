using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dockersampleconfig.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("getvalues")]
        public List<string> getvalues()
        {
            //comment added
            List<string> l = new List<string>();
            l.Add("value1");
            l.Add("value2");
            l.Add("value3");
            l.Add("Value4");
            l.Add("Value5");
            l.Add("Value6");
            l.Add("Value7");
            return l;
        }
    }
}
