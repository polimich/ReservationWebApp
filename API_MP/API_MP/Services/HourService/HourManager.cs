using API_MP.Data;
using API_MP.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API_MP.Services.HourService
{
    public class HourManager : IHourManager
    {
        private ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private UserManager<ApplicationUser> _userManager;
        public HourManager(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<Hour> Create(Hour input)
        {
            Hour newHour = new Hour
            {
                Person = input.Person,
                Requester = input.Requester,
                End = input.End,
                Start = input.Start,
                isOnetime = input.isOnetime
            };
            _context.Hours.Add(newHour);
            await _context.SaveChangesAsync();
            return newHour;
        }

        public async Task<Hour> Delete(int id)
        {
            Hour hour = _context.Hours.Find(id);
            if (hour != null)
            {
                _context.Hours.Remove(hour);
                await _context.SaveChangesAsync();
            }
            return hour;
        }

        public async Task<ICollection<Hour>> ListAllHours()
        {
            return await _context.Hours.ToListAsync();
        }

        public async Task<Hour> Read(int id)
        {
            Hour hour = await _context.Hours.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (hour != null)
            {
                return hour;
            }
            else
            {
                return null;
            }
        }

        public async Task<Hour> Update(int id, Hour input)
        {
            Hour hour = _context.Hours.Find(id);
            if (hour != null)
            {

                hour.Person = input.Person;
                hour.Requester = input.Requester;
                hour.End = input.End;
                hour.Start = input.Start;
                hour.isOnetime = input.isOnetime;
                await _context.SaveChangesAsync();
                return hour;
            }
            else
            {
                return null;
            }


        }

        public async Task<ICollection<Hour>> GetUsersWeek(string userid, DateTime startdate)
        {

            return await _context.Hours.Where(hour => hour.Start.Date > StartOfWeek(startdate) && hour.Start.Date < EndOfWeek(startdate) && hour.Person == userid).ToListAsync();
        }

        public async Task<ICollection<Hour>> GetCurrentUsersWeek(DateTime startdate)
        {
            string userid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _context.Hours.Where(hour => hour.Start.Date > StartOfWeek(startdate) && hour.Start.Date < EndOfWeek(startdate) && hour.Person == userid).ToListAsync();
        }
        public static DateTime EndOfWeek(DateTime dateTime)
        {
            DateTime start = StartOfWeek(dateTime);

            return start.AddDays(6);
        }

        public static DateTime StartOfWeek(DateTime dateTime)
        {
            int days = dateTime.DayOfWeek - DayOfWeek.Monday;

            if (days < 0)
                days += 7;

            return dateTime.AddDays(-1 * days).Date;
        }

        public async Task<Hour> GetHour(string userid, string Start)
        {
            var user = _context.Users.Find(userid);
            
            if (await _userManager.IsInRoleAsync(user, "Trener"))
            {
                return await _context.Hours.FirstOrDefaultAsync(hour => hour.Requester == userid && hour.Start == DateTime.Parse(Start));
            }
            else
            {
                return await _context.Hours.FirstOrDefaultAsync(hour => hour.Person == userid && hour.Start == DateTime.Parse(Start));
            }
            
      
        }
    }
}
