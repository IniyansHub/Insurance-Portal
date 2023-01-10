using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using InsurancePortal.Data;
using InsurancePortal.DTO;
using InsurancePortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using bcrypt = BCrypt.Net.BCrypt;

namespace InsurancePortal.Services
{
	public class AuthService : IAuthService
	{

        private readonly Insurance_PortalContext _insurancedb;

        private readonly IConfiguration _configuration;

        public AuthService(Insurance_PortalContext insurancedb, IConfiguration configuration) 
		{
            _insurancedb = insurancedb;
            _configuration = configuration;
		}

        public async Task<string> authenticateUser(AuthDTO user)
        {
            AuthDetail? authData = await _insurancedb.AuthDetails.FirstOrDefaultAsync(x => x.Email == user.Email);

            if (authData != null)
            {
                if (bcrypt.Verify(user.Password, authData.Password))
                {
                    return this.CreateToken(authData);
                }

                return "Invalid username or password";
                
            }
            else
            {
                return "User not found";
            }
        }

        public async Task<bool> registerUser(AuthDTO user)
        {
            AuthDetail? UserFound = await _insurancedb.AuthDetails.FirstOrDefaultAsync(x => x.Email == user.Email);

            if (UserFound != null)
            {
                return false;
            }
            else
            {
                AuthDetail newUser = new AuthDetail();
                string hashedPassword = bcrypt.HashPassword(user.Password, 12);
                newUser.Email = user.Email;
                newUser.Password = hashedPassword;
                await _insurancedb.AddAsync(newUser);
                await _insurancedb.SaveChangesAsync();
                return true;
            }
        }


        private string CreateToken(AuthDetail user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role, user.IsAdmin==0?"USER":"ADMIN")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("JWT:Secret").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }



    }
}

