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
    [Route("api/userpolicy")]
    public class UserpolicyController : Controller
    {
        private readonly IUserpolicyService _userpolicyService;

        public UserpolicyController(IUserpolicyService userpolicyService)
        {
            _userpolicyService = userpolicyService;
        }
        
        [HttpGet("{userId}")]
        public ActionResult Get(string userId)
        {
            List<UserPolicy> userPolicies = _userpolicyService.GetUserPolicy(userId).Result;
            return Ok(userPolicies);
        }

        [HttpPost]
        public ActionResult Post([FromBody]UserPolicy newPolicy)
        {
            var message = _userpolicyService.AddUserPolicy(newPolicy).Result;
            return Ok(message);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]string status)
        {
            var updatedUserPolicy = _userpolicyService.UpdateUserPolicyStatus(id).Result;
            return Ok(updatedUserPolicy);
        }

   
    }
}

