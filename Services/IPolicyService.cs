using System;
using InsurancePortal.Models;

namespace InsurancePortal.Services
{
	public interface IPolicyService
	{
        public Task<List<Policy>> GetAllPolicies();

        public Task<Policy> GetPolicyById(int policyId);
    }
}

