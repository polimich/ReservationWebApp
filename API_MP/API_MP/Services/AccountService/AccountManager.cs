using API_MP.Data;
using API_MP.Model;
using API_MP.Model.AcountIM;
using API_MP.Services.AccountService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API_MP.Services
{
    public class AccountManager : ControllerBase, IAccountManager
    {
        private IConfiguration _config;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private ApplicationDbContext _context;
        private RoleManager<ApplicationRole> _roleManager;

        
        public AccountManager(IConfiguration config, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context, RoleManager<ApplicationRole> roleManager)
        {

            _config = config;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Delete(string id)
        {
            ApplicationUser user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return Ok("User deleted");
            }
            return BadRequest("User not found");
            
        }

        public async Task<ICollection<ApplicationUser>> ListAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IActionResult> Login(AccountLoginIM userData)
        {
            var result = await _signInManager.PasswordSignInAsync(userData.Email, userData.Password, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(userData.Email);
                AuthorizationToken token = GenerateJSONWebToken(user);
                return Ok(token);
            }
            return Unauthorized();
        }

        public async Task<IActionResult> Register(AccountRegistrationIM input)
        {
            var user = await _userManager.FindByNameAsync(input.Email);
            if (user != null)
            {
                return BadRequest("User already registered");
            }
            var hasher = new PasswordHasher<ApplicationUser>();
            var newUser = new ApplicationUser
            {
                UserName = input.Email,
                Email = input.Email,
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, input.Password)
            };
            
            
            var result = _userManager.CreateAsync(newUser, input.Password).Result;
            await _userManager.AddToRoleAsync(newUser, input.Role);
            if (result.Succeeded)
            {
                return Ok();
                //return CreatedAtAction("GetAccount", new { id = newUser.Id }, newUser);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        public async Task<IActionResult> ChangePassword(ChangePasswordIM password, string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var hasher = new PasswordHasher<ApplicationUser>();
            if (user != null)
            {
                if (user.PasswordHash == hasher.HashPassword(null, password.OldPassword))
                {
                    if (password.NewPassword == password.ConfirmNewPassword)
                    {
                        user.PasswordHash = hasher.HashPassword(null, password.NewPassword);
                        return Ok("Password succesfully changed");
                    }
                    else
                    {
                        return BadRequest("Passwords are not the same");
                    }
                }
                else
                {
                    return BadRequest("Old password is incorrect");
                }
                
            }
            else
            {
                return BadRequest("No such user");
            }


        }
        private AuthorizationToken GenerateJSONWebToken(ApplicationUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var expiration = DateTime.Now.AddMinutes(120);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: expiration,
                signingCredentials: credentials);
            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            return new AuthorizationToken { AccessToken = accessToken };
        }

        public async Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();
            return Ok("User Log out");
        }

        public async Task<ApplicationUser> Get(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}
