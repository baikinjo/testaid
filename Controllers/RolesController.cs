using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SecondAid.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SecondAid.Controllers
{
    public class RolesController : Controller
    {
        private readonly IStringLocalizer<RolesController> _controllerLocalizer;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public RolesController(
            IStringLocalizer<RolesController> controllerLocalizer,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _controllerLocalizer = controllerLocalizer;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Roles
        public ActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(string Name)
        {
            if (await _roleManager.RoleExistsAsync(Name))
            {
                string msg = string.Format("Role '{0}' already exists", Name);
                ModelState.AddModelError("", msg);
                return View();
            }

            var newResult = await _roleManager.CreateAsync(new IdentityRole(Name));

            if (!newResult.Succeeded)
            {
                string msg = string.Format("Role '{0}' could not be created: {1}", Name, String.Join(Environment.NewLine, newResult.Errors));
                ModelState.AddModelError("", msg);
            }
            else
            {
                ViewBag.Message = string.Format("Role '{0}' successfully created", Name);
            }
            return View("Created");
        }

        // GET: Roles/Delete/Rolename
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var role = _roleManager.Roles.FirstOrDefault(r => r.Name == id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // POST: Roles/Delete/Rolename
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var role = _roleManager.Roles.FirstOrDefault(r => r.Name == id);
            if (role == null)
            {
                ModelState.AddModelError("", string.Format("Role '{0}' does not exist", id));
                return View();
            }
            await _roleManager.DeleteAsync(role);

            return RedirectToAction("Index");
        }

        public IActionResult Users(string id)
        {
            var role = _roleManager.Roles.FirstOrDefault(r => r.Name == id);
            if (role == null)
            {
                return NotFound();
            }
            ViewBag.UsersToAdd = new SelectList(_userManager.Users.Where(u => !u.Roles.Any(r => r.RoleId == role.Id)).Select(u => u.UserName));
            ViewBag.RoleName = id;
            return View(_userManager.Users.Where(u => u.Roles.Any(r => r.RoleId == role.Id)).ToList());
        }

        public async Task<IActionResult> AddUserToRole(string RoleName, string UserName)
        {
            ViewBag.RoleName = RoleName;

            if (await _roleManager.RoleExistsAsync(RoleName) == false)
            {
                ViewBag.Message = string.Format("Role '{0}' does not exist", RoleName);
                return View();
            }

            var user = await _userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                string msg = string.Format("User '{0}' not exist", UserName);
                ModelState.AddModelError("", msg);
                ViewBag.Message = msg;
                return View();
            }

            string[] roles = { RoleName };
            var addResult = await _userManager.AddToRolesAsync(user, roles);
            if (addResult.Succeeded)
            {
                ViewBag.Message = string.Format("Successfully added user '{0}' to role '{1}'", UserName, RoleName);
                return View();
            }
            else
            {
                string msg = 
                    string.Format("Could not add user '{0}' to role '{1}': {2}", UserName, RoleName, String.Join(Environment.NewLine, addResult.Errors));
                ViewBag.Message = msg;
            }
            return View();
        }

        public async Task<IActionResult> RemoveUserFromRole(string RoleName, string UserName)
        {
            ViewBag.RoleName = RoleName;

            if (await _roleManager.RoleExistsAsync(RoleName) == false)
            {
                ViewBag.Message = string.Format("Role '{0}' does not exist", RoleName);
                return View();
            }

            var user = _userManager.Users.FirstOrDefault(u => u.UserName == UserName);

            if (user == null)
            {
                ViewBag.Message = string.Format("User '{0}' does not exist", UserName);
                return View();
            }
            if (user.UserName.ToLower().Contains("admin") && RoleName == "Admin")
            {
                ViewBag.Message = string.Format("User '{0}' is not permitted to be removed from role '{1}'.", UserName, RoleName);
                return View();
            }

            var removeResult = await _userManager.RemoveFromRoleAsync(user, RoleName);
            if (removeResult.Succeeded)
            {
                ViewBag.Message = string.Format("User '{0}' successfully removed from  role '{1}'.", UserName, RoleName);
                return View();
            }
            else
            {
                ViewBag.Message = string.Format("Could not remove user '{0}' from role '{1}': {2}", UserName, RoleName, String.Join(Environment.NewLine, removeResult.Errors));
            }
            return View();
        }

    }
}