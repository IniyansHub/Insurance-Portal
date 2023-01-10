using System;
using InsurancePortal.DTO;

namespace InsurancePortal.Services
{
	public interface IAuthService
	{
		public Task<String> authenticateUser(AuthDTO user);
		public Task<Boolean> registerUser(AuthDTO user);
	}
}

