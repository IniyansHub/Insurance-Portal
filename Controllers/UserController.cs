using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsurancePortal.Models;
using InsurancePortal.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InsurancePortal.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }


        [HttpGet("getprofile/{email}")]
        public ActionResult<UserDetail> Get(string email)
        {
            UserDetail profileDetail = _userService.GetUserProfile(email).Result;
            if (profileDetail != null)
            {
                return Ok(profileDetail);
            }
            else
            {
                return BadRequest("Profile with this email not found");
            }

        }


        [HttpPost("createprofile")]
        public ActionResult<UserDetail> Post([FromBody] UserDetail profiledata)
        {
            _logger.LogInformation("Inside profile creation");

            if (profiledata!=null && ModelState.IsValid)
            {
                UserDetail createdProfile = _userService.CreateUserProfile(profiledata).Result;
                if (createdProfile != null)
                {
                    return Ok("Profile created successfully " + createdProfile);
                }
                else
                {
                    return BadRequest("Unable to create a record");
                }
            }
            else
            {
                return BadRequest("All details are required to create a profile");
            }


        }


        [HttpPut("updateprofile/{email}")]
        public ActionResult<UserDetail> Put(string email, [FromBody] UserDetail updatedprofile)
        {
            _logger.LogInformation("Inside profile updation controller");
            var isUpdated = _userService.UpdateUserProfile(email, updatedprofile).Result;
            return isUpdated?Ok("Profile updation successfull "+updatedprofile):BadRequest("Unable to update the record");
        }


    }
}