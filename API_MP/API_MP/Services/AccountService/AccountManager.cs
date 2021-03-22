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
using Newtonsoft.Json;
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

        public async Task<ICollection<UserVM>> ListAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            List<UserVM> userVMs = new List<UserVM>();
            foreach (var user in users)
            {
                UserVM userVM = new UserVM();
                userVM.Id = user.Id;
                userVM.Name = user.FirstName + " " + user.LastName;
                userVMs.Add(userVM);
            }
            return userVMs;
        }
        /// <summary>
        /// Metoda pro přihlášení
        /// </summary>
        /// <param name="userData">data podle modelu AccountLoginIM</param>
        /// <returns></returns>
        public async Task<IActionResult> Login(AccountLoginIM userData)
        {
            var result = await _signInManager.PasswordSignInAsync(userData.Email, userData.Password, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(userData.Email);
                var role = await _userManager.IsInRoleAsync(user, "Trener");
                AuthorizationToken token = GenerateJSONWebToken(user);
                LoginResponse response = new LoginResponse();
                response.Name = user.FirstName + " " + user.LastName;
                response.Role = role ? "Trener" : "Student";
                response.Token = token;
                response.UserId = user.Id;
                response.WhatITeach = user.WhatITeach;
                return Ok(response);
            }
            return Unauthorized();
        }
        /// <summary>
        /// Metoda pro registraci
        /// </summary>
        /// <param name="input">data podle modelu AccountRegistrationIM</param>
        /// <returns></returns>
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
                PasswordHash = hasher.HashPassword(null, input.Password),
                FirstName = input.Firstname,
                LastName = input.LastName,
                WhatITeach = input.WhatITeach


            };

            //Po registraci následnuje přihlášení
            var result = _userManager.CreateAsync(newUser, input.Password).Result;
            await _userManager.AddToRoleAsync(newUser, input.Role);
            if (result.Succeeded)
            {
                var result1 = await _signInManager.PasswordSignInAsync(newUser.Email, input.Password, false, false);
                if (result1.Succeeded)
                {
                    user = await _userManager.FindByNameAsync(newUser.Email);
                    var role = await _userManager.IsInRoleAsync(user, "Trener");
                    AuthorizationToken token = GenerateJSONWebToken(user);
                    LoginResponse response = new LoginResponse();
                    response.Name = user.FirstName + " " + user.LastName;
                    response.Role = role ? "Trener" : "Student";
                    response.Token = token;
                    response.UserId = user.Id;
                    response.WhatITeach = user.WhatITeach;
                    return Ok(response);
                }
                //Ošetření chybových hlášek
                else { return BadRequest(result.Errors); }
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
        /// <summary>
        /// Metoda na změnu hesla
        /// </summary>
        /// <param name="password"> data podle modelu ChangePasswordIM</param>
        /// <param name="id">id uživatele</param>
        /// <returns></returns>
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
                        //Ošetření chybových hlášek
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
        /// <summary>
        /// Metoda pro vytváření JWT Tokenu
        /// </summary>
        /// <param name="user">uživatel, který se přihlašuje</param>
        /// <returns>JWT Token</returns>
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
        /// <summary>
        /// Metoda pro odhlášení
        /// </summary>
        /// <returns>výsledek operace</returns>
        public async Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();
            return Ok("User Log out");
        }
        /// <summary>
        /// Metoda pro získání uživatele podle id
        /// </summary>
        /// <param name="id">id uživatele</param>
        /// <returns>ApplicationUser</returns>
        public async Task<UserVM> Get(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            UserVM userVm = new UserVM();
            userVm.Id = user.Id;
            userVm.Name = user.FirstName + " " + user.LastName;
            return userVm;
        }
        /// <summary>
        /// Vrátí roli uživatele
        /// </summary>
        /// <param name="id">id uživatele</param>
        /// <returns>vrací string s rolí</returns>
        public async Task<string> GetUserRole(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var role = await _userManager.IsInRoleAsync(user, "Trener");
            return role ? "Trener" : "Student";
        }
        /// <summary>
        /// Vrátí všechny uživatele s rolí student
        /// </summary>
        /// <returns>list studentů podle modelu userVM</returns>
        public async Task<ICollection<UserVM>> GetAllStudents()
        {
            var users = await _userManager.GetUsersInRoleAsync("Student");
            List<UserVM> userVMs = new List<UserVM>();
            foreach (var user in users)
            {
                UserVM userVM = new UserVM();
                userVM.Id = user.Id;
                userVM.Name = user.FirstName + " " + user.LastName;
                userVMs.Add(userVM);
            }
            return userVMs;
        }
        /// <summary>
        /// Vrátí všechny uživatele s rolí student, kteří mají hodinu s daných trenérem
        /// </summary>
        /// <returns>list studentu podle modelu userVM</returns>
        public async Task<ICollection<UserVM>> GetUsersStudents(string id)
        {
            var usersHours = await _context.Hours.Where(hour => hour.Requester == id).ToListAsync();
            List<UserVM> users = new List<UserVM>();
            foreach (var hour in usersHours)
            {
                var user = await _context.Users.Where(user => user.Id == hour.Person).FirstOrDefaultAsync();
                UserVM userVM = new UserVM();
                userVM.Id = user.Id;
                userVM.Name = user.FirstName + " " + user.LastName;
                if (!users.Any(u => u.Id == userVM.Id))
                {
                    users.Add(userVM);
                }
            }
            return users;
        }
        /// <summary>
        /// Vrátí všechny uživatele s rolí trenér, kteří mají hodinu s daných studentem
        /// </summary>
        /// <returns>list trenéru podle modelu userVM</returns>
        public async Task<ICollection<UserVM>> GetUsersTrainers(string id)
        {
            var usersHours = await _context.Hours.Where(hour => hour.Person == id).ToListAsync();
            List<UserVM> users = new List<UserVM>();
            foreach (var hour in usersHours)
            {
                var user = await _context.Users.Where(user => user.Id == hour.Requester).FirstOrDefaultAsync();
                UserVM userVM = new UserVM();
                userVM.Id = user.Id;
                userVM.Name = user.FirstName + " " + user.LastName;
                if (!users.Any(u => u.Id == userVM.Id))
                {
                    users.Add(userVM);
                }
            }
            return users;
        }
    }
}
