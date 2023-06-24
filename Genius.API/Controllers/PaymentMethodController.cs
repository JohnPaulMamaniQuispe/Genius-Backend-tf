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
    public class PaymentMethodController : ControllerBase
    {
        private IPaymentMethodDomain _paymentMethodDomain;
        private IPaymentMethodInfraestructure _paymentMethodInfraestructure;
        private IMapper _mapper;

        public PaymentMethodController(IPaymentMethodDomain paymentMethodDomain,
            IPaymentMethodInfraestructure paymentMethodInfraestructure
            , IMapper mapper)
        {
            _paymentMethodDomain  = paymentMethodDomain;
            _paymentMethodInfraestructure = paymentMethodInfraestructure;
            _mapper = mapper;

        }
        
        
        
        // GET: api/PaymentMethod
        [HttpGet]
        public async Task<List<PaymentMethodResponse>> Get()
        {
            var result = await _paymentMethodInfraestructure.GetAll();

            var list = _mapper.Map<List<PaymentMethod>, List<PaymentMethodResponse>>(result);
            return list;
        }
        
        

        // GET: api/PaymentMethod/5
        [HttpGet("{id}")]
        public PaymentMethod GetById(int id)
        {
            return _paymentMethodInfraestructure.GetById(id);
        }
        
        // POST: api/PaymentMethod
        [HttpPost]
        public async Task < IActionResult>PostAsync([FromBody] PaymentMethodInput paymentMethodInput)
        {

            try
            {
                if (!ModelState.IsValid) return BadRequest("Format error");
                var driver = _mapper.Map<PaymentMethodInput, PaymentMethod>(paymentMethodInput);
                var result  =  await _paymentMethodDomain.CreateAsync(driver);
                return StatusCode(StatusCodes.Status200OK, "The driver was created successfully");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to process");

            }
        }
        // PUT: api/PaymentMethod/5
        [HttpPut("{id}")]
        public async  Task<IActionResult>  Put(int id, [FromBody] PaymentMethodInput paymentMethodInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Format error");
                }

                var paymentMethod = _mapper.Map<PaymentMethodInput, PaymentMethod>(paymentMethodInput);
                paymentMethod.Id = id;
                var result =  _paymentMethodDomain.Update(id, paymentMethod);
                return StatusCode(StatusCodes.Status200OK, "Updated driver");

            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to process");

            }
            
        }

        // DELETE: api/PaymentMethod/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Format error");
                }

                var result = await _paymentMethodDomain.Delete(id);
                return StatusCode(StatusCodes.Status200OK, "Driver Removed successfully");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to process");

            }
        }
    }
}
