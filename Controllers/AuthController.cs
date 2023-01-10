using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsurancePortal.DTO;
using InsurancePortal.Models;
using InsurancePortal.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InsurancePortal.Controllers
{
    [Route("api")]
    public class AuthController : Controller
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody]AuthDTO login)
        {
            string token = _authService.authenticateUser(login).Result;
            return Ok(token);
        }


        [HttpPost("register")]
        public ActionResult Register([FromBody] AuthDTO reg)
        {
            bool isUserRegistered = _authService.registerUser(reg).Result;
            if (isUserRegistered)
            {
                return Ok("User registered successfully");
            }
            else
            {
                return BadRequest("User with this email already exists");
            }
            
        }

    }
}

