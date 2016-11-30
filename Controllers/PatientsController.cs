using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SecondAid.Models;
using Microsoft.Extensions.Localization;

namespace SecondAid.Controllers
{
    public class PatientsController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IStringLocalizer<UsersController> _controllerLocalizer;

        public PatientsController(
            IStringLocalizer<UsersController> controllerLocalizer,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _controllerLocalizer = controllerLocalizer;
        }

        // GET: Patients
        public async Task<ActionResult> Index()
        {
            var returnValue = (await _userManager.GetUsersInRoleAsync("Patient")).ToList();

            return View(returnValue);
        }

        // GET: Patients/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Patients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Patients/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}