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
    public class OwnerTypeController : ControllerBase
    {

        private IOwnerTypeInfraestructure _ownerTypeInfraestructure;
        private IOwnerTypeDomain _ownerTypeDomain;
        private IMapper _mapper;

        public OwnerTypeController(IOwnerTypeInfraestructure ownerTypeInfraestructure
            , IOwnerTypeDomain ownerTypeDomain, IMapper mapper)
        {
            _ownerTypeInfraestructure = ownerTypeInfraestructure;
            _ownerTypeDomain = ownerTypeDomain;
            _mapper = mapper;
        }
        
        
        
        
        // GET: api/OwnerType
        [HttpGet]
        public async Task<List<OwnerTypeResponse>> Get()
        {
            var result = await _ownerTypeInfraestructure.GetAll();

            var list = _mapper.Map<List<OwnerType>, List<OwnerTypeResponse>>(result);
            return list;
        }

        // GET: api/OwnerType/5
        [HttpGet("{id}")]
        public OwnerType GetById(int id)
        {
            return _ownerTypeInfraestructure.GetById(id);
        }
        
        
        // POST: api/OwnerType
        [HttpPost]
        public async Task < IActionResult>PostAsync([FromBody] OwnerTypeInput ownerTypeInput)
        {

            try
            {
                if (!ModelState.IsValid) return BadRequest("Format error");
                var ownerType = _mapper.Map<OwnerTypeInput, OwnerType>(ownerTypeInput);
                var result  =  await _ownerTypeDomain.CreateAsync(ownerType);
                return StatusCode(StatusCodes.Status200OK, "The driver was created successfully");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to process");

            }
        }

        // PUT: api/OwnerType/5
        [HttpPut("{id}")]
        public async  Task<IActionResult>  Put(int id, [FromBody] OwnerTypeInput ownerTypeInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Format error");
                }

                var ownerType = _mapper.Map<OwnerTypeInput, OwnerType>(ownerTypeInput);
                ownerType.Id = id;
                var result =  _ownerTypeDomain.Update(id,ownerType);
                return StatusCode(StatusCodes.Status200OK, "Updated driver");

            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to process");

            }
            
        }

        // DELETE: api/OwnerType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Format error");
                }

                var result = await _ownerTypeDomain.Delete(id);
                return StatusCode(StatusCodes.Status200OK, "Driver Removed successfully");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to process");

            }
        }
    }
}
