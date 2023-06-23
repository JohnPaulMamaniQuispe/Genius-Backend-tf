
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Genius.API.Controllers
{
    [Route("appi/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        // GET: api/Parking
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Parking/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Parking
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Parking/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Parking/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
