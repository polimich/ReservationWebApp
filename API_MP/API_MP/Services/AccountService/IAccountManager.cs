using API_MP.Model;
using API_MP.Model.AcountIM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_MP.Services.AccountService
{
    public interface IAccountManager
    {
        Task<ICollection<ApplicationUser>> ListAllUsers();
        Task<IActionResult> Register(AccountRegistrationIM input);
        Task<IActionResult> Login(AccountLoginIM input);
        Task<IActionResult> Logout();
        Task<IActionResult> ChangePassword(ChangePasswordIM password, string id);
        Task<IActionResult> Delete(string id);
        Task<ApplicationUser> Get(string id);

    }
}
