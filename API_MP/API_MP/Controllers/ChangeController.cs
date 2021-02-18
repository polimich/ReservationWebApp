using API_MP.Model;
using API_MP.Services.ChangeService;
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
    public class ChangeController : ControllerBase
    {
        private IChangeManager _changeManager;
        public ChangeController(IChangeManager changeManager)
        {
            _changeManager = changeManager;
        }
        // GET: api/<AccountController>
        [HttpGet]
        public async Task<IEnumerable<Change>> Get()
        {
            return await _changeManager.ListAllChanges();
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public async Task<Change> Get(int id)
        {
            return await _changeManager.Read(id);
        }

        // POST api/<AccountController>
        [HttpPost]
        public async Task Post([FromBody] Change value)
        {
            await _changeManager.Create(value);
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public async Task<Change> Put(int id, [FromBody] Change value)
        {
            await _changeManager.Update(id, value);
            return await _changeManager.Read(id);
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _changeManager.Delete(id);
        }
    }
}
