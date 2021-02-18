using API_MP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_MP.Services.HourService
{
    public interface IHourManager
    {
        Task<ICollection<Hour>> ListAllHours();
        Task<ICollection<Hour>> GetCurrentUsersWeek(DateTime startdate); //id prihlaseneho
        Task<ICollection<Hour>> GetUsersWeek(string user, DateTime startdate);
        Task<Hour> Get(string Person, DateTime time);
        Task<Hour> Create(Hour input);
        Task<Hour> Delete(int id);
        Task<Hour> Update(int id, Hour input);
        Task<Hour> Read(int id);


    }
}
