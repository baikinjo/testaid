using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecondAid.Data;
using SecondAid.Models.Health;

namespace SecondAid.Controllers
{
    public class PatientProceduresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientProceduresController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: PatientProcedures
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PatientProcedure.Include(p => p.MedicationPrescribed).Include(p => p.Patient).Include(p => p.Procedure);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PatientProcedures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientProcedure = await _context.PatientProcedure.SingleOrDefaultAsync(m => m.PatientProcedureId == id);
            if (patientProcedure == null)
            {
                return NotFound();
            }

            return View(patientProcedure);
        }

        // GET: PatientProcedures/Create
        public IActionResult Create()
        {
            ViewData["MedicationId"] = new SelectList(_context.Medications, "MedicationId", "Name");
            ViewData["PatientId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            ViewData["ProcedureId"] = new SelectList(_context.Procedures, "ProcedureId", "Name");
            return View();
        }

        // POST: PatientProcedures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientProcedureId,MedicationId,PatientId,ProcedureId")] PatientProcedure patientProcedure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientProcedure);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["MedicationId"] = new SelectList(_context.Medications, "MedicationId", "Name", patientProcedure.MedicationId);
            ViewData["PatientId"] = new SelectList(_context.ApplicationUser, "Id", "Id", patientProcedure.PatientId);
            ViewData["ProcedureId"] = new SelectList(_context.Procedures, "ProcedureId", "Name", patientProcedure.ProcedureId);
            return View(patientProcedure);
        }

        // GET: PatientProcedures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientProcedure = await _context.PatientProcedure.SingleOrDefaultAsync(m => m.PatientProcedureId == id);
            if (patientProcedure == null)
            {
                return NotFound();
            }
            ViewData["MedicationId"] = new SelectList(_context.Medications, "MedicationId", "Name", patientProcedure.MedicationId);
            ViewData["PatientId"] = new SelectList(_context.ApplicationUser, "Id", "Id", patientProcedure.PatientId);
            ViewData["ProcedureId"] = new SelectList(_context.Procedures, "ProcedureId", "Name", patientProcedure.ProcedureId);
            return View(patientProcedure);
        }

        // POST: PatientProcedures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatientProcedureId,MedicationId,PatientId,ProcedureId")] PatientProcedure patientProcedure)
        {
            if (id != patientProcedure.PatientProcedureId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientProcedure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientProcedureExists(patientProcedure.PatientProcedureId))
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
            ViewData["MedicationId"] = new SelectList(_context.Medications, "MedicationId", "Name", patientProcedure.MedicationId);
            ViewData["PatientId"] = new SelectList(_context.ApplicationUser, "Id", "Id", patientProcedure.PatientId);
            ViewData["ProcedureId"] = new SelectList(_context.Procedures, "ProcedureId", "Name", patientProcedure.ProcedureId);
            return View(patientProcedure);
        }

        // GET: PatientProcedures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientProcedure = await _context.PatientProcedure.SingleOrDefaultAsync(m => m.PatientProcedureId == id);
            if (patientProcedure == null)
            {
                return NotFound();
            }

            return View(patientProcedure);
        }

        // POST: PatientProcedures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientProcedure = await _context.PatientProcedure.SingleOrDefaultAsync(m => m.PatientProcedureId == id);
            _context.PatientProcedure.Remove(patientProcedure);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PatientProcedureExists(int id)
        {
            return _context.PatientProcedure.Any(e => e.PatientProcedureId == id);
        }
    }
}
