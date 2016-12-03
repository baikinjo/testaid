using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecondAid.Data;
using SecondAid.Models.Health;
using Microsoft.AspNetCore.Identity;
using SecondAid.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SecondAid.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SchedulesController(
            ApplicationDbContext context, 
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Schedules
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Schedule.Include(s => s.Patient).Include(s => s.Procedure);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .Include(s => s.Procedure)
                .Include(s => s.Patient)
                .SingleOrDefaultAsync(m => m.ScheduleId == id);

            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // marks the procedure completed for the specified schedule id
        public IActionResult Complete(int id)
        {
            var schedule = _context.Schedule.FirstOrDefault(r => r.ScheduleId == id);
            
            schedule.IsCompleted = true;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Schedules/Create
        public async Task<IActionResult> Create()
        {
            //var users = _roleManager
            var users = await _userManager.GetUsersInRoleAsync("Patient");
            ViewData["PatientId"] = new SelectList(users, "UserName", "UserName");
            ViewData["ProcedureId"] = new SelectList(_context.Procedures, "ProcedureId", "Name");
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScheduleId,IsCompleted,PatientId,ProcedureId,Time")] Schedule schedule)
        {
            Console.WriteLine("****************");
            //Console.WriteLine(schedule.Patient);
            Console.WriteLine(schedule.PatientId);
            Console.WriteLine(schedule.ProcedureId);

            schedule.Procedure = _context.Procedures.FirstOrDefault(r => r.ProcedureId == schedule.ProcedureId);

            if(DateTime.Today > schedule.Time)
            {
                ViewData["PatientId"] = new SelectList(_context.ApplicationUser, "UserName", "UserName", schedule.PatientId);
                ViewData["ProcedureId"] = new SelectList(_context.Procedures, "ProcedureId", "Name", schedule.ProcedureId);
                ModelState.AddModelError(string.Empty, "The date/time is not valid!");
                return View(schedule);
            }

            if (ModelState.IsValid)
            {
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["PatientId"] = new SelectList(_context.ApplicationUser, "UserName", "UserName", schedule.PatientId);
            ViewData["ProcedureId"] = new SelectList(_context.Procedures, "ProcedureId", "Name", schedule.ProcedureId);
            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .Include(s => s.Patient)
                .SingleOrDefaultAsync(m => m.ScheduleId == id);

            if (schedule == null)
            {
                return NotFound();
            }

            ViewData["PatientId"] = new SelectList(_context.ApplicationUser, "UserName", "UserName", schedule.PatientId);
            ViewData["ProcedureId"] = new SelectList(_context.Procedures, "ProcedureId", "Name", schedule.ProcedureId);
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScheduleId,IsCompleted,PatientId,ProcedureId,Time")] Schedule schedule)
        {
            if (id != schedule.ScheduleId)
            {
                return NotFound();
            }

            if (DateTime.Today > schedule.Time)
            {
                ViewData["PatientId"] = new SelectList(_context.ApplicationUser, "UserName", "UserName", schedule.PatientId);
                ViewData["ProcedureId"] = new SelectList(_context.Procedures, "ProcedureId", "Name", schedule.ProcedureId);
                ModelState.AddModelError(string.Empty, "The date/time is not valid!");
                return View(schedule);
            }

            if (ModelState.IsValid)
            {
                schedule.Procedure = _context.Procedures.FirstOrDefault(r => r.ProcedureId == schedule.ProcedureId);
                schedule.Patient = _context.ApplicationUser.FirstOrDefault(r => r.UserName == schedule.PatientId);

                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.ScheduleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["PatientId"] = new SelectList(_context.ApplicationUser, "UserName", "UserName", schedule.PatientId);
            ViewData["ProcedureId"] = new SelectList(_context.Procedures, "ProcedureId", "Name", schedule.ProcedureId);
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule.SingleOrDefaultAsync(m => m.ScheduleId == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schedule = await _context.Schedule.SingleOrDefaultAsync(m => m.ScheduleId == id);
            _context.Schedule.Remove(schedule);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ScheduleExists(int id)
        {
            return _context.Schedule.Any(e => e.ScheduleId == id);
        }
    }
}
