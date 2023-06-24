
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
    public class ReservationController : ControllerBase
    {
        private IReservationDomain _reservationDomain;
        private IReservationInfraestructure _reservationInfraestructure;
        private IMapper _mapper;

        public ReservationController(IReservationDomain reservationDomain,
            IReservationInfraestructure reservationInfraestructure, IMapper mapper)
        {
            _reservationDomain = reservationDomain;
            _reservationInfraestructure = reservationInfraestructure;
            _mapper = mapper;
        }
        
        
        
        // GET: api/Reservation
        [HttpGet]
        public async Task<List<ReservationResponse>>  Get()
        {
            var result = await _reservationInfraestructure.GetAll();

            var list = _mapper.Map<List<Reservation>, List<ReservationResponse>>(result);
            return list;
        }

        
        
        
        
        // GET: api/Reservation/5
        [HttpGet("{id}")]
        public Reservation GetById(int id)
        {
            return _reservationInfraestructure.GetById(id);
        }

        // POST: api/Reservation
        [HttpPost]
        public async  Task<BadRequestObjectResult> PostAsync([FromBody] ReservationInput reservationInput )
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Format error");
                var reservation = _mapper.Map<ReservationInput, Reservation>(reservationInput);
                var result  =  await _reservationDomain.CreateAsync(reservation);
                return (BadRequestObjectResult)StatusCode(StatusCodes.Status200OK, "The driver was created successfully");
            }
            catch (Exception exception)
            {
                return (BadRequestObjectResult)StatusCode(StatusCodes.Status500InternalServerError, "Failed to process");

            }
            
            
        }

        // PUT: api/Reservation/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ReservationInput reservationInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Format error");
                }

                var reservation = _mapper.Map<ReservationInput, Reservation>(reservationInput);
                reservation.Id = id;
                var result =  _reservationDomain.Update(id, reservation);
                return StatusCode(StatusCodes.Status200OK, "Updated driver");

            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to process");

            }
            
            
        }

        // DELETE: api/Reservation/5
        [HttpDelete("{id}")]
        public async  Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Format error");
                }

                var result = await _reservationDomain.Delete(id);
                return StatusCode(StatusCodes.Status200OK, "Driver Removed successfully");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to process");

            }
            
        }
    }
}
