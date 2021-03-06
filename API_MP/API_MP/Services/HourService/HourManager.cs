﻿using API_MP.Data;
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
        /// <summary>
        /// Metoda pro vytvoření hodiny
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Hour> Create(Hour input)
        {
            Hour newHour = new Hour
            {
                Person = input.Person,
                Requester = input.Requester,
                End = input.End,
                Start = input.Start,
                isOnetime = input.isOnetime,
                Name = input.Name

            };
            _context.Hours.Add(newHour);
            await _context.SaveChangesAsync();
            return newHour;
        }
        /// <summary>
        /// Metoda pro smazání hodiny
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Metoda pro výpis všech hodin
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Hour>> ListAllHours()
        {
            return await _context.Hours.ToListAsync();
        }
        /// <summary>
        /// Metoda pro cteni hodiny
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Metoda pro upraveni hodiny
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Hour> Update(Hour input)
        {
            Hour hour = _context.Hours.Find(input.Id);
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
        /// <summary>
        /// metoda pro ziskani seznamu hodin uzivatele na dany tyden
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="startdate"></param>
        /// <returns></returns>
        public async Task<ICollection<Hour>> GetUsersWeek(string userid, string startdate)
        {
            DateTime Start = DateTime.Parse(startdate);
            var user = _context.Users.Find(userid);
            if (await _userManager.IsInRoleAsync(user, "Trener"))
            {
                return await _context.Hours.Where(hour => hour.Start.Date > StartOfWeek(Start) && hour.Start.Date < EndOfWeek(Start) && hour.Requester == userid).ToListAsync();
            }
            else
            {
                return await _context.Hours.Where(hour => hour.Start.Date > StartOfWeek(Start) && hour.Start.Date < EndOfWeek(Start) && hour.Person == userid).ToListAsync();

            }
        }
        /// <summary>
        /// metoda zjistujici konec tydne na zaklade data
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime EndOfWeek(DateTime dateTime)
        {
            DateTime start = StartOfWeek(dateTime);

            return start.AddDays(6);
        }
        /// <summary>
        /// metoda zjistujici zacatek tydne na zaklade data
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime StartOfWeek(DateTime dateTime)
        {
            int days = dateTime.DayOfWeek - DayOfWeek.Monday;

            if (days < 0)
                days += 7;

            return dateTime.AddDays(-1 * days).Date;
        }
        /// <summary>
        /// Metoda na ziskani hodiny na zaklade userid a data
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="Start"></param>
        /// <returns></returns>
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
        /// <summary>
        /// metoda pro ziskani vsech hodin daneho uzivatele
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public async Task<ICollection<Hour>> GetAllUsersHours(string userid)
        {
            return await _context.Hours.Where(hour => hour.Requester == userid).ToListAsync();
        }
    }
}
