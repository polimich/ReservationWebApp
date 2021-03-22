using API_MP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_MP.Services.HourService
{
    /// <summary>
    /// Rozhoraní pro metody pracující s Hour Entitou
    /// </summary>
    public interface IHourManager
    {
        Task<ICollection<Hour>> ListAllHours();
        Task<ICollection<Hour>> GetUsersWeek(string user, string startdate);
        Task<Hour> GetHour(string userid, string time);
        Task<Hour> Create(Hour input);
        Task<Hour> Delete(int id);
        Task<Hour> Update(Hour input);
        Task<Hour> Read(int id);
        Task<ICollection<Hour>> GetAllUsersHours(string userid);


    }
}
