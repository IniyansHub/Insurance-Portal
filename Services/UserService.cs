using System;
using InsurancePortal.Data;
using InsurancePortal.Models;
using Microsoft.EntityFrameworkCore;

namespace InsurancePortal.Services
{
    public class UserService : IUserService
    {

        private readonly Insurance_PortalContext _insurancedb;

        public UserService(Insurance_PortalContext insurancedb)
        {
            _insurancedb = insurancedb;
        }

        public async Task<UserDetail> GetUserProfile(string email)
        {
            UserDetail? profileData = await _insurancedb.UserDetails.FirstOrDefaultAsync(x => x.Email == email);
            return profileData;
        }

        public async Task<UserDetail> CreateUserProfile(UserDetail profiledata)
        {
            UserDetail? profileData = await _insurancedb.UserDetails.FirstOrDefaultAsync(x => x.Email == profiledata.Email);
            if (profileData == null)
            {
                await _insurancedb.UserDetails.AddAsync(profiledata);
                await _insurancedb.SaveChangesAsync();
                return profiledata;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UpdateUserProfile(string email, UserDetail updatedprofile)
        {
            UserDetail? existingProfile = await _insurancedb.UserDetails.FirstOrDefaultAsync(x => x.Email == email);
            if (existingProfile != null)
            {
                existingProfile.FirstName = updatedprofile.FirstName;
                existingProfile.LastName = updatedprofile.LastName;
                existingProfile.Gender = updatedprofile.Gender;
                existingProfile.Address = updatedprofile.Address;
                existingProfile.MobileNumber = updatedprofile.MobileNumber;
                existingProfile.Dob = updatedprofile.Dob;
                await _insurancedb.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}