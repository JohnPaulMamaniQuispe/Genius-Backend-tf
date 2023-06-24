using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Genius.API.Input;
using Genius.API.Response;
using Genius.Domain;
using Genius.Infraestructure;
using Genius.Infraestructure.Model;
using Genius.Infraestructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Genius.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private IUserDomain _userDomain;
        private IMapper _mapper;
        private IUserInfraestructure _userInfraestructure;

        public UserController(IUserDomain userDomain, IMapper mapper,IUserInfraestructure userInfraestructure )
        {
            _userDomain = userDomain;
            _mapper = mapper;
            _userInfraestructure = userInfraestructure;
        }

        
        // GET: api/Driver
        [HttpGet]
        public async Task<List<UserResponse>> Get()
        {
            var result = await _userInfraestructure.GetAll();

            var list = _mapper.Map<List<User>, List<UserResponse>>(result);
            return list;
        }
        
        // GET: api/User
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginInput userLoginInput)
        {
            try
            {
                var user = _mapper.Map<UserLoginInput, User>(userLoginInput);

                var jwt = await _userDomain.Login(user);

                return Ok(jwt);
            }
            catch (Exception ex)
            {
                throw;
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        }


        // POST: api/User
        //[Filter.Authorize("admin")]
        [HttpPost(Name = "Signup")]
        public async Task<IActionResult> Signup([FromBody] UserInput userInput)
        {
            
            var user = _mapper.Map<UserInput, User>(userInput);
            var id = await _userDomain.Signup(user);
            
            if (id > 0)
                return Ok(id.ToString());
            else
                return BadRequest();
        }
    }
}
