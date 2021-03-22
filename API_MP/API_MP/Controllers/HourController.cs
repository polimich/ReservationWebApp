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
        /// <summary>
        /// Vrací všechny Hodiny
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Hour>> Get()
        {
            return await _hourManager.ListAllHours();
        }
        /// <summary>
        /// Vrací hodiny podle jejího id
        /// </summary>
        /// <param name="id">id hodiny</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task Get(int id)
        {
            await _hourManager.Read(id);
        }
        /// <summary>
        /// Vrací všechny hodiny pro daný týden na základě datetime hodnoty a id uživatele
        /// </summary>
        /// <param name="userid">id uživatele</param>
        /// <param name="startdate">datetime hodnota nacházející se někdy v průběhu požadované týdne</param>
        /// <returns></returns>
        [HttpGet("[action]/{userid}/{startdate}")]
        public async Task<IEnumerable<Hour>> GetUsersWeek(string userid, string startdate)
        {
            return await _hourManager.GetUsersWeek(userid, startdate);
        }
        /// <summary>
        /// Vrací hodinu pro daného uživatele v daný čas a datum
        /// </summary>
        /// <param name="userid">id uživatele</param>
        /// <param name="startdate">datetime údaj o začátku hodiny</param>
        /// <returns></returns>
        [HttpGet("{userid}/{startdate}")]
        public async Task<Hour> Get(string userid, string startdate)
        {
            return await _hourManager.GetHour(userid, startdate);
        }
        /// <summary>
        /// Vrací všechny hodiny, kterých se daný uživatel kdy zúčastnil
        /// </summary>
        /// <param name="userid">id uživatele</param>
        /// <returns></returns>
        [HttpGet("[action]/{userid}")]
        public async Task<ICollection<Hour>> GetAllUsersHours(string userid)
        {
            return await _hourManager.GetAllUsersHours(userid);
        }
        /// <summary>
        /// Přidá novou hodinu
        /// </summary>
        /// <param name="hour">vstup podle modelu Hour</param>
        /// <returns></returns>
        [HttpPost]
        public async Task Post([FromBody] Hour hour)
        {
            await _hourManager.Create(hour);
        }
        /// <summary>
        /// Edituje danou hodinu podle
        /// </summary>
        /// <param name="hour">vstup podle modelu Hour</param>
        /// <returns></returns>
        [HttpPut]
        public async Task Put([FromBody] Hour hour)
        {
            await _hourManager.Update(hour);
        }
        /// <summary>
        /// Odstran
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _hourManager.Delete(id);
        }
    }
}
