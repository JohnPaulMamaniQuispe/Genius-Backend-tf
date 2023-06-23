using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper; 
using Genius.Domain;
using Genius.Infraestructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Genius.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private IOwnerDomain _ownerDomain;
        private IOwnerInfraestructure _ownerInfraestructure;
        private IMapper _mapper;

        public OwnerController(IOwnerDomain ownerDomain, IOwnerInfraestructure ownerInfraestructure, IOwnerDomain mapper)
        {
            _ownerDomain = ownerDomain;
            _ownerInfraestructure = ownerInfraestructure;
            _ownerDomain = mapper;
        }
        
        // GET: api/Owner
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Owner/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Owner
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Owner/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Owner/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
