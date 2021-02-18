using API_MP.Model;
using API_MP.Model.AcountIM;
using API_MP.Services;
using API_MP.Services.AccountService;
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
        // GET: api/<AccountController>
        [HttpGet]
        public async Task<IEnumerable<ApplicationUser>> Get()
        {
            return await _accountManager.ListAllUsers();
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public async Task<ApplicationUser> Get(string id)
        {
            return await _accountManager.Get(id);
        }

        // POST api/<AccountController>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AccountRegistrationIM value)
        {
            return  await _accountManager.Register(value);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AccountLoginIM value)
        {
            return await _accountManager.Login(value);
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] ChangePasswordIM value)
        {
            return await _accountManager.ChangePassword(value, id);
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public  async Task<IActionResult> Delete(string id)
        {
            return await _accountManager.Delete(id);
        }
    }
}
