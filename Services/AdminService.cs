using System;
using InsurancePortal.Data;
using InsurancePortal.Models;
using Microsoft.EntityFrameworkCore;

namespace InsurancePortal.Services
{
	public class AdminService : IAdminService
	{
        private readonly Insurance_PortalContext _insurancedb;

        public AdminService(Insurance_PortalContext insurancedb)
		{
            _insurancedb = insurancedb;
        }

        public async Task<Policy> CreatePolicy(Policy newPolicy)
        {
            await _insurancedb.Policies.AddAsync(newPolicy);
            await _insurancedb.SaveChangesAsync();
            return newPolicy;
        }

        public async Task<bool> DeletePolicy(int policyId)
        {
            Policy? policy = await _insurancedb.Policies.FirstOrDefaultAsync(x => x.PolicyId == policyId);
            if (policy != null)
            {
                _insurancedb.Policies.Remove(policy);
                await _insurancedb.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Policy> GetAllPolicies()
        {
            List<Policy> policies =  _insurancedb.Policies.ToList();

            return policies;
        }

        public async Task<Policy> GetPolicyById(int policyId)
        {
            Policy? policy = await _insurancedb.Policies.FirstOrDefaultAsync(x=>x.PolicyId == policyId);
            return policy;
        }

        public async Task<bool> UpdatePolicy(int id,Policy updatedPolicy)
        {
            Policy? existingPolicy = await _insurancedb.Policies.FirstOrDefaultAsync(x => x.PolicyId == id);
            if (existingPolicy != null)
            {
                existingPolicy.PolicyName = updatedPolicy.PolicyName;
                existingPolicy.PolicyPrice = updatedPolicy.PolicyPrice;
                existingPolicy.PolicyType = updatedPolicy.PolicyType;
                existingPolicy.PolicyValidity = updatedPolicy.PolicyValidity;
                existingPolicy.PolicyDescription = updatedPolicy.PolicyDescription;
                await _insurancedb.SaveChangesAsync();
                return true;

            }
            else{
                return false;
            }
        }



    }
}

