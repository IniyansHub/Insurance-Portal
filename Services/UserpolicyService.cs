using System;
using InsurancePortal.Data;
using InsurancePortal.Models;
using Microsoft.EntityFrameworkCore;

namespace InsurancePortal.Services
{
	public class UserpolicyService : IUserpolicyService
	{
        private readonly Insurance_PortalContext _insurancedb;

        public UserpolicyService(Insurance_PortalContext insurancedb)
		{
            _insurancedb = insurancedb;
		}

        public async Task<String> AddUserPolicy(UserPolicy newPolicy)
        {
            UserPolicy? userPolicy = await _insurancedb.UserPolicies.FirstOrDefaultAsync(x => x.PolicyId == newPolicy.PolicyId);

            if (userPolicy != null)
            {
                if (userPolicy.PolicyStatus == "Expired")
                {
                    await _insurancedb.AddAsync(newPolicy);

                    await _insurancedb.SaveChangesAsync();
                }
                else
                {
                    return "Policy Renewed";
                }
                return "Policy already exists";
            }
            else
            {
                await _insurancedb.AddAsync(newPolicy);

                await _insurancedb.SaveChangesAsync();

                return "New policy added";
            }
        }

        public async Task<List<UserPolicy>> GetUserPolicy(string email)
        {
            List<UserPolicy> userPolicies = await _insurancedb.UserPolicies.Where(x => x.PolicyUserId == email).ToListAsync();

            return userPolicies;
        }

        public async Task<UserPolicy> UpdateUserPolicyStatus(int userPolicyId)
        {
            UserPolicy? userPolicy = await _insurancedb.UserPolicies.FirstOrDefaultAsync(x => x.RecordId == userPolicyId);

            if (userPolicy != null)
            {
                DateOnly startDate = DateOnly.Parse(userPolicy.PolicyStartDate);

                DateOnly endDate = DateOnly.Parse(userPolicy.PolicyEndDate);

                DateOnly currentDate = DateOnly.FromDateTime(DateTime.Today);

                if(currentDate >= startDate && currentDate<=endDate)
                {

                    userPolicy.PolicyStatus = "ACTIVE";

                }else if (currentDate > endDate)
                {

                    userPolicy.PolicyStatus = "EXPIRED";

                }

                await _insurancedb.SaveChangesAsync();
            }

            return userPolicy;

        }
    }
}

