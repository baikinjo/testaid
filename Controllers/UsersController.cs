using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SecondAid.Models;

namespace SecondAid.Controllers
{
    public class UsersController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IStringLocalizer<UsersController> _controllerLocalizer;

        public UsersController(
            IStringLocalizer<UsersController> controllerLocalizer,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _controllerLocalizer = controllerLocalizer;
        }

        public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }

        public async Task<IActionResult> Lockout(string id)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
            if (user.UserName != "a")
            {
                user.LockoutEnabled = true;
            }
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Unlock(string id)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
            user.LockoutEnabled = false;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }

    }
}