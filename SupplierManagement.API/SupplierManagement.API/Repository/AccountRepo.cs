using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SupplierManagement.API.IRepository;
using SupplierManagement.Data.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SupplierManagement.API.Repository
{
    public class AccountRepo : IAccount
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        private readonly IConfiguration _configuration;

        public AccountRepo(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<bool> CheckUser(string Email)
        {
            var userCheck = await _userManager.FindByEmailAsync(Email);
            if (userCheck == null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> SignupUser(UserSignup UserDto)
        {

            var user = new User
            {
                UserName = UserDto.Email,
                FirstName = UserDto.FirstName,
                LastName = UserDto.LastName,
                NormalizedUserName = UserDto.Email,
                Email = UserDto.Email,
                EmailConfirmed = true,
            };
            var result = await _userManager.CreateAsync(user, UserDto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                return true;
            }
            return false;
        }

        public async Task<bool> LoginUser(UserLogin UserLogin)
        {
            var user = await _userManager.FindByEmailAsync(UserLogin.UserName);
            if (user != null && !user.EmailConfirmed)
            {
                return false;
            }
            if (await _userManager.CheckPasswordAsync(user, UserLogin.Password) == false)
            {
                return false;

            }

            return true;
        }

        public async Task<string> CreateToken(string Email)
        {

            var user = await _userManager.FindByEmailAsync(Email);
            var role = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            List<Claim> claims = new List<Claim>
            {
                new Claim("name", user.FirstName),
                new Claim(ClaimTypes.Role, role[0]),
                new Claim(ClaimTypes.NameIdentifier,
            user.Id)

            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken
                (
                issuer: _configuration.GetSection("AppSettings:Issuer").Value,
                audience: _configuration.GetSection("AppSettings:Audience").Value,
                claims: claims,
                expires: DateTime.Now.AddSeconds(90),
                signingCredentials: cred


                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
