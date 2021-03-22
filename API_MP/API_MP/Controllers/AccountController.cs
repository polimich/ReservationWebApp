using API_MP.Model;
using API_MP.Model.AcountIM;
using API_MP.Services;
using API_MP.Services.AccountService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_MP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountManager _accountManager;
        public AccountController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }
        /// <summary>
        /// Vrátí všechny uživatele
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<UserVM>> Get()
        {
            return await _accountManager.ListAllUsers();
        }
        /// <summary>
        /// Vrátí uživatele podle id
        /// </summary>
        /// <param name="id">id uživatele</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<UserVM> Get(string id)
        {
            return await _accountManager.Get(id);
        }
        /// <summary>
        /// Vrátí roli uživatele podle id
        /// </summary>
        /// <param name="id">id uřivatele</param>
        /// <returns></returns>
        [HttpGet("[action]/{id}")]
        public async Task<string> GetUserRole(string id)
        {
            return await _accountManager.GetUserRole(id);
        }
        /// <summary>
        /// Vrátí všechny uživatele s Rolí student
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ICollection<UserVM>> GetAllStudents()
        {
            return await _accountManager.GetAllStudents();
        }
        /// <summary>
        /// Vrátí všechny uživatele s rolí student, kteří mají hodinu s uživatelem trenér podle jeho id
        /// </summary>
        /// <param name="id">id uživatele s rolí trenéra</param>
        /// <returns></returns>
        [HttpGet("[action]/{id}")]
        public async Task<ICollection<UserVM>> GetUsersStudents(string id)
        {
            return await _accountManager.GetUsersStudents(id);
        }
        /// <summary>
        /// Vrátí všechny uživatele s rolí trenér, kteří mají hodinu s uživatelem student podle jeho id
        /// </summary>
        /// <param name="id">id uživatele s rolí student</param>
        /// <returns></returns>
        [HttpGet("[action]/{id}")]
        public async Task<ICollection<UserVM>> GetUsersTrainers(string id)
        {
            return await _accountManager.GetUsersTrainers(id);
        }
        /// <summary>
        /// Provede registraci nového uživatele
        /// </summary>
        /// <param name="value"> Vstupem jsou parametry podle modelu AccountRegistrationIM</param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AccountRegistrationIM value)
        {
            return await _accountManager.Register(value);
        }
        /// <summary>
        /// Provede přihlášení uživatele
        /// </summary>
        /// <param name="value">Vstupem jsou parametry podle modelu AccountLoginIM</param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AccountLoginIM value)
        {
            return await _accountManager.Login(value);
        }
        /// <summary>
        /// Provede odhlášení uživatele
        /// </summary>
        /// <returns></returns>
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            return await _accountManager.Logout();
        }
        /// <summary>
        /// Změní heslo uživatele
        /// </summary>
        /// <param name="id">id uživatele</param>
        /// <param name="value">parametry podle modelu ChangePasswordIM</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] ChangePasswordIM value)
        {
            return await _accountManager.ChangePassword(value, id);
        }
        /// <summary>
        /// Odstraní uživatele a všechny hodiny kterých se účastní
        /// </summary>
        /// <param name="id">id uživatele</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return await _accountManager.Delete(id);
        }
    }
}
