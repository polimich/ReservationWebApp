using API_MP.Model;
using API_MP.Services.HourService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_MP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HourController : ControllerBase
    {
        private IHourManager _hourManager;
        public HourController(IHourManager hourManager)
        {
            _hourManager = hourManager;
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<Hour>> Get()
        {
            return await _hourManager.ListAllHours();
        }
        [HttpGet("[action]/{userid}/{startdate}")]

        public async Task<IEnumerable<Hour>> GetUsersWeek(string userid, string startdate)
        {
            return await _hourManager.GetUsersWeek(userid ,startdate);
        }
        [HttpGet("{userid}/{startdate}")]

        public async Task<Hour> Get(string userid, string startdate)
        {
            return await _hourManager.GetHour(userid, startdate);
        }
        [HttpGet("[action]/{userid}")]
        public async Task<ICollection<Hour>>GetAllUsersHours(string userid)
        {
            return await _hourManager.GetAllUsersHours(userid);
        }
        [HttpPost]
        public async Task Post ([FromBody] Hour hour)
        {
            await _hourManager.Create(hour);
        }
        [HttpPut]
        public async Task Put( [FromBody] Hour hour)
        {
            await _hourManager.Update(hour);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _hourManager.Delete(id);
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task Get(int id)
        {
            await _hourManager.Read(id);
        }

    }
}
