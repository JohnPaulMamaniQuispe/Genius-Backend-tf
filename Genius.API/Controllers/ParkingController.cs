
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
    [Route("appi/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private IParkingDomain _parkingDomain;
        private IParkingInfraestructure _parkingInfraestructure;
        private IMapper _mapper;

        public ParkingController(IParkingDomain parkingDomain, IParkingInfraestructure parkingInfraestructure
            ,IMapper mapper)
        {
            _parkingDomain = parkingDomain;
            _parkingInfraestructure = parkingInfraestructure;
            _mapper = mapper;

        }
        
        
        
        
        // GET: api/Parking
        [HttpGet]
        public async Task<List<ParkingResponse>> Get()
        {
            var result = await _parkingInfraestructure.GetAll();

            var list = _mapper.Map<List<Parking>, List<ParkingResponse>>(result);
            return list;
        }

        [HttpGet("GetBy/{address}")]
        public async Task<List<Parking>> GetByAddress(string address)
        {
            return await _parkingInfraestructure.GetByAddress(address);
        }
        
        
        
        // GET: api/Parking/5
        [HttpGet("{id}")]
        public Parking GetById(int id)
        {
            return _parkingInfraestructure.GetById(id);
        }
        
        

        // POST: api/Parking
        [HttpPost]
        public async Task < IActionResult>PostAsync([FromBody] ParkingInput parkingInput)
        {

            try
            {
                if (!ModelState.IsValid) return BadRequest("Format error");
                var parking = _mapper.Map<ParkingInput, Parking>(parkingInput);
                var result  =  await _parkingDomain.CreateAsync(parking);
                return StatusCode(StatusCodes.Status200OK, "The driver was created successfully");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to process");

            }
        }
        // PUT: api/Parking/5
        [HttpPut("{id}")]
        public async  Task<IActionResult>  Put(int id, [FromBody] ParkingInput parkingInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Format error");
                }

                var parking = _mapper.Map<ParkingInput, Parking>(parkingInput);
                parking.Id = id;
                var result =  _parkingDomain.Update(id, parking);
                return StatusCode(StatusCodes.Status200OK, "Updated driver");

            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to process");

            }
            
        }

        // DELETE: api/Parking/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Format error");
                }

                var result = await _parkingDomain.Delete(id);
                return StatusCode(StatusCodes.Status200OK, "Driver Removed successfully");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to process");

            }
        }
    }
}
