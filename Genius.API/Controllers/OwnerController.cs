using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Genius.API.Input;
using Genius.API.Response;
using Genius.Domain;
using Genius.Infraestructure;
using Genius.Infraestructure.Models;
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

        public OwnerController(IOwnerDomain ownerDomain, IOwnerInfraestructure ownerInfraestructure, IMapper mapper)
        {
            _ownerDomain = ownerDomain;
            _ownerInfraestructure = ownerInfraestructure;
            _mapper = mapper;
        }
        
        // GET: api/Owner
        [HttpGet]
        public async Task<List<OwnerResponse>> Get()
        {
            var result = await _ownerInfraestructure.GetAll();

            var list = _mapper.Map<List<Owner>, List<OwnerResponse>>(result);
            return list;
        }

        
        [HttpGet("GetBy/{firtname}")]
        public async Task<List<Owner>> GetByFirtname(string firtname)
        {
            return await _ownerInfraestructure.GetByFirtname(firtname);
        }


        // GET: api/Owner/5
        [HttpGet( "{id}")]
        public Owner GetById(int id)
        {
            return _ownerInfraestructure.GetById(id);
        }

        // POST: api/Owner
        [HttpPost]
        public async Task <IActionResult>PostAsync([FromBody] OwnerInput ownerInput)
        {

            try
            {
                if (!ModelState.IsValid) return BadRequest("Format error");
                var owner = _mapper.Map<OwnerInput, Owner>(ownerInput);
                var result  =  await _ownerDomain.CreateAsync(owner);
                return StatusCode(StatusCodes.Status200OK, "The driver was created successfully");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to process");

            }
        }
        
        // PUT: api/Owner/5
        [HttpPut("{id}")]
        public async  Task<IActionResult>  Put(int id, [FromBody] OwnerInput ownerInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Format error");
                }

                var owner = _mapper.Map<OwnerInput, Owner>(ownerInput);
                owner.Id = id;
                var result =  _ownerDomain.Update(id,owner);
                return StatusCode(StatusCodes.Status200OK, "Updated driver");

            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to process");

            }
            
        }

        // DELETE: api/Owner/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Format error");
                }

                var result = await _ownerDomain.Delete(id);
                return StatusCode(StatusCodes.Status200OK, "Driver Removed successfully");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to process");

            }
        }
        
        
        
        
    }
}
