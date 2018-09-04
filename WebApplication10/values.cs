using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication10
{

    [Route("api/values")]
    public class valuesController : ApiController
    {
        models.Connection con = new models.Connection();
        [HttpGet]

        public bool GetName(models.Register reg)
        {
            return con.Login(reg);
        }

        [HttpPost]

        public int Register([FromBody]models.Register log)
        {
            return con.AddRegister(log);

        }
    }
}

