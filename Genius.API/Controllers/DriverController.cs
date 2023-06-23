using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Genius.API.Input;
using Genius.API.Response;
using Genius.Domain;
using Genius.Infraestructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Genius.Infraestructure.Models;

namespace Genius.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private IDriverDomain _driverDomain;
        private IDriverInfraestructure _driverInfraestructure;
        private IMapper _mapper;

        public DriverController(IDriverDomain driverDomain, IDriverInfraestructure driverInfraestructure,
            IMapper mapper)
        {
            _driverDomain = driverDomain;
            _driverInfraestructure = driverInfraestructure;
            _mapper = mapper;
        }


        // GET: api/Driver
        [HttpGet]
        public async Task<List<DriverResponse>> Get()
        {
            var result = await _driverInfraestructure.GetAll();

            var list = _mapper.Map<List<Driver>, List<DriverResponse>>(result);
            return list;
        }

        [HttpGet("GetBy/{name}")]


        public async Task<List<Driver>> GetByName(string name)
        {
            return await _driverInfraestructure.GetByName(name);
        }


        // GET: api/Driver/5
        [HttpGet("{id}")]
        public Driver GetById(int id)
        {
            return _driverInfraestructure.GetById(id);
        }

        // POST: api/Driver
        [HttpPost]
        public async Task < IActionResult>PostAsync([FromBody] DriverInput driverInput)
        {

            try
            {
                if (!ModelState.IsValid) return BadRequest("Format error");
                var driver = _mapper.Map<DriverInput, Driver>(driverInput);
                var result  =  await _driverDomain.CreateAsync(driver);
                return StatusCode(StatusCodes.Status200OK, "The driver was created successfully");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to process");

            }
        }
        
        // PUT: api/Driver/5
        [HttpPut("{id}")]
        public async  Task<IActionResult>  Put(int id, [FromBody] DriverInput driverInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Format error");
                }

                var driver = _mapper.Map<DriverInput, Driver>(driverInput);
                driver.Id = id;
                var result =  _driverDomain.Update(id,driver);
                return StatusCode(StatusCodes.Status200OK, "Updated driver");

            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to process");

            }
            
        }

        // DELETE: api/Driver/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Format error");
                }

                var result = await _driverDomain.Delete(id);
                return StatusCode(StatusCodes.Status200OK, "Driver Removed successfully");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to process");

            }
        }
    }

}
