
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
    public class PlaceController : ControllerBase
    {
        private IPlaceDomain _placeDomain;
        private IPlaceInfraestructure _placeInfraestructure;
        private IMapper _mapper;

        public PlaceController(IPlaceDomain placeDomain, IPlaceInfraestructure placeInfraestructure
            , IMapper mapper)
        {
            _placeDomain = placeDomain;
            _placeInfraestructure = placeInfraestructure;
            _mapper = mapper;
        }
        
        
        
        
        
        // GET: api/Place
        [HttpGet]
        public async Task<List<PlaceResponse>> Get()
        {
            var result = await _placeInfraestructure.GetAll();

            var list = _mapper.Map<List<Place>, List<PlaceResponse>>(result);
            return list;
        }

        // GET: api/Place/5
        [HttpGet("{id}")]
        public Place GetById(int id)
        {
            return _placeInfraestructure.GetById(id);
        }

        // POST: api/Place
        [HttpPost]
        public async Task < IActionResult>PostAsync([FromBody] PlaceInput placeInput)
        {

            try
            {
                if (!ModelState.IsValid) return BadRequest("Format error");
                var place = _mapper.Map<PlaceInput, Place>(placeInput);
                var result  =  await _placeDomain.CreateAsync(place);
                return StatusCode(StatusCodes.Status200OK, "The place was created successfully");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to process");

            }
        }
        // PUT: api/Place/5
        [HttpPut("{id}")]
        public async  Task<IActionResult>  Put(int id, [FromBody] PlaceInput placeInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Format error");
                }

                var place = _mapper.Map<PlaceInput, Place>(placeInput);
                place.Id = id;
                var result =  _placeDomain.Update(id,place);
                return StatusCode(StatusCodes.Status200OK, "Updated place");

            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to process");

            }
            
        }

        // DELETE: api/Place/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Format error");
                }

                var result = await _placeDomain.Delete(id);
                return StatusCode(StatusCodes.Status200OK, "Place Removed successfully");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to process");

            }
        }
    }
}
