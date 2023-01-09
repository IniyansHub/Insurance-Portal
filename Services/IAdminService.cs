using System;
using InsurancePortal.Models;

namespace InsurancePortal.Services
{
	public interface IAdminService
	{

		public Task<Policy> CreatePolicy(Policy newPolicy);

		public Task<Boolean> UpdatePolicy(int id ,Policy updatedPolicy);

		public Task<Boolean> DeletePolicy(int policyId);
	}
}

