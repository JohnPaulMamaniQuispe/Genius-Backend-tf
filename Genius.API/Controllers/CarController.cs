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
    public class CarController : ControllerBase
    {
        private ICarDomain _carDomain;
        private ICarInfraestructure _carInfraestructure;
        private IMapper _mapper;

        public CarController(ICarDomain carDomain, ICarInfraestructure carInfraestructure, IMapper mapper)
        {
            _carDomain = carDomain;
            _carInfraestructure = carInfraestructure;
            _mapper = mapper;
        }
        
        // GET: api/Car
        [HttpGet]
        public async Task<List<CarResponse>> Get()
        {
            var result = await _carDomain.GetAll();
            var list = _mapper.Map<List<Car>, List<CarResponse>>(result);
            return list;
            //return await _carDomain.GetAll();

        }
        
        [HttpGet("GetBy/{placa}")]
        
        public async Task<List<Car>> GetByName(string placa)
        {
            return await _carInfraestructure.GetByName(placa);
        }
        
        
        
        // GET: api/Driver/5
        [HttpGet("{id}")]
        public Car GetById(int id)
        {
            return _carInfraestructure.GetById(id);
        }

        // POST: api/Car
        [HttpPost]
        public  async  Task PostAsync([FromBody] CarInput input)
        {
            // _driverDomain.Create(value,age,license,phone);
            if (ModelState.IsValid)
            {
                var car = _mapper.Map<CarInput, Car>(input);
                await _carDomain.CreateAsync(car);
            }
            else
            {
                StatusCode(400);
            }
        }
        
        // PUT: api/Car/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CarInput input)
        {
            if (ModelState.IsValid)
            {
                Car car = new Car()
                {
                    Modelo = input.Modelo,
                    Placa = input.Placa
                };
                _carDomain.Update(id, car);
            }
            else
            {
                StatusCode(400);
            }

        }

        // DELETE: api/Car/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _carDomain.Delete(id);
        }
    }
}
