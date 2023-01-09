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

    [Route("api/policy")]
    public class PolicyController : Controller
    {

        private readonly IPolicyService _policyService;

        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            List<Policy> allpolicies = _policyService.GetAllPolicies().Result;
            if (allpolicies != null)
            {
                return Ok(allpolicies);

            }
            else
            {
                return BadRequest("Failed to fetch the policies");
            }
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Policy policy = _policyService.GetPolicyById(id).Result;
            if (policy != null)
            {
                return Ok(policy);
            }
            else
            {
                return BadRequest("No policy found with this Id");
            }
        }

     
    }
}

