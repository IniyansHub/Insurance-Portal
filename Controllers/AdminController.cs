using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsurancePortal.Data;
using InsurancePortal.Models;
using InsurancePortal.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InsurancePortal.Controllers
{
    [Route("api/admin/")]
    public class AdminController : Controller
    {

        private readonly ILogger<AdminController> _logger;

        private readonly IAdminService _adminService;

        public AdminController(ILogger<AdminController> logger, IAdminService adminService)
        {
            _logger = logger;
            _adminService = adminService;
        }


        [HttpGet("getallPolicy")]
        public ActionResult<List<Policy>> Get()
        {
            List<Policy> allPolicyList = _adminService.GetAllPolicies();
            return Ok(allPolicyList) ;
        }


        [HttpGet("getpolicy/{id}")]
        public ActionResult<Policy> Get(int id)
        {
            Policy policy = _adminService.GetPolicyById(id).Result;
            return Ok(policy);
        }


        [HttpPost("addpolicy")]
        public ActionResult<Policy> Post([FromBody]Policy newPolicy)
        {
            Policy policyCreated = _adminService.CreatePolicy(newPolicy).Result;
            return Ok(policyCreated);
        }


        [HttpPut("updatepolicy/{id}")]
        public ActionResult Put(int id, [FromBody]Policy updatedPolicy)
        {
            bool isUpdated = _adminService.UpdatePolicy(id,updatedPolicy).Result;
            return isUpdated ? Ok("Policy updation successful") : BadRequest("Unable to update the policy!");
        }

        [HttpDelete("deletepolicy/{id}")]
        public ActionResult Delete(int id)
        {
            bool isDeleted = _adminService.DeletePolicy(id).Result;
            return isDeleted ? Ok("Policy deletion successful") : BadRequest("Unable to delete the policy!");

        }
    }
}

