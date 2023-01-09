using System;
using InsurancePortal.Models;

namespace InsurancePortal.Services
{
	public interface IUserpolicyService
	{
		public Task<List<UserPolicy>> GetUserPolicy(string email);

		public Task<string> AddUserPolicy(UserPolicy newPolicy);

		public Task<UserPolicy> UpdateUserPolicyStatus(int userPolicyId);

	}
}

