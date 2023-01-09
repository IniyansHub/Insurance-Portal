using System;
using InsurancePortal.Data;
using InsurancePortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsurancePortal.Services
{
	public class PolicyService : IPolicyService
	{

        private readonly Insurance_PortalContext _insurancedb;

        public PolicyService(Insurance_PortalContext insurancedb)
        {
            _insurancedb = insurancedb;
        }


        public async Task<List<Policy>> GetAllPolicies()
        {
            List<Policy> policies = await _insurancedb.Policies.ToListAsync();

            return policies;
        }

        public async Task<Policy> GetPolicyById(int policyId)
        {
            Policy? policy = await _insurancedb.Policies.FirstOrDefaultAsync(x => x.PolicyId == policyId);
            return policy;
        }

    }
}

