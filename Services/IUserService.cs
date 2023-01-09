using System;
using InsurancePortal.Models;

namespace InsurancePortal.Services
{
    public interface IUserService
    {
        public Task<UserDetail> GetUserProfile(string email);

        public Task<UserDetail> CreateUserProfile(UserDetail profiledata);

        public Task<Boolean> UpdateUserProfile(string email,UserDetail updatedprofile);
    }
}