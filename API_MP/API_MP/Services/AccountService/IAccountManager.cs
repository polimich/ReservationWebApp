using API_MP.Model;
using API_MP.Model.AcountIM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_MP.Services.AccountService
{
    /// <summary>
    /// Rozhraní pracující s ApplicationUser Entitou
    /// </summary>
    public interface IAccountManager
    {
        Task<ICollection<UserVM>> ListAllUsers();
        Task<IActionResult> Register(AccountRegistrationIM input);
        Task<IActionResult> Login(AccountLoginIM input);
        Task<IActionResult> Logout();
        Task<IActionResult> ChangePassword(ChangePasswordIM password, string id);
        Task<IActionResult> Delete(string id);
        Task<UserVM> Get(string id);
        Task<string> GetUserRole(string id);
        Task<ICollection<UserVM>> GetAllStudents();
        Task<ICollection<UserVM>> GetUsersStudents(string id);
        Task<ICollection<UserVM>> GetUsersTrainers(string id);
    }
}
