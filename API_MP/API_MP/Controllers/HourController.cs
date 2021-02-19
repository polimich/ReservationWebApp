using API_MP.Model;
using API_MP.Services.HourService;
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
        public async Task<IEnumerable<Hour>> Get()
        {
            return await _hourManager.ListAllHours();
        }
        [HttpGet("{startdate}"), ActionName("GetCurrentUsersWeek")]

        public async Task<IEnumerable<Hour>> Get(DateTime startdate)
        {
            return await _hourManager.GetCurrentUsersWeek(startdate);
        }
        [HttpGet("{userid}/{stardate}")]

        public async Task<Hour> Get( string userid, string startdate)
        {
            return await _hourManager.GetHour(userid, startdate);
        }
        [HttpPost]
        public async Task Post ([FromBody] Hour hour)
        {
            await _hourManager.Create(hour);
        }
        [HttpPut]
        public async Task Put(int id, [FromBody] Hour hour)
        {
            await _hourManager.Update(id,hour);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _hourManager.Delete(id);
        }
        [HttpGet("{id}")]
        public async Task Get(int id)
        {
            await _hourManager.Delete(id);
        }

    }
}
