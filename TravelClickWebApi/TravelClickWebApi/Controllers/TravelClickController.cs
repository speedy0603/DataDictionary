using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TravelClickBusinessEntities.Model;
using TravelClickBusinessLayer;

namespace TravelClickWebApi.Controllers
{
    [EnableCors(origins: "http://localhost:56357/", headers: "*", methods: "*")]

    public class TravelClickController : ApiController
    {
        [HttpGet]
        [Route("api/GetAllDB")]
        public List<Database> GetAllDB()
        {
            return new TravelClickBL().GetAllDatabase();
        }
        [HttpGet]
        [Route("api/GetAllTable")]
        public IEnumerable<TableDetails> GetAllTable(string type, string name)

        {
            return new TravelClickBL().GetAllTable(type,name);
        }
    }
}
