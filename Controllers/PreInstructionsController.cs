using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecondAid.Models.Health;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using SecondAid.Resources;
using SecondAid.Data;

namespace SecondAid.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class PreInstructionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;
        private readonly IStringLocalizer<PreInstructionsController> _controllerLocalizer;
        private readonly IHtmlLocalizer _htmlLocalizer;

        public PreInstructionsController(ApplicationDbContext context,
            IStringLocalizer<SharedResource> sharedLocalizer,
            IStringLocalizer<PreInstructionsController> controllerLocalizer,
            IHtmlLocalizer<PreInstructionsController> htmlLocalizer)
        {
            _context = context;
            _sharedLocalizer = sharedLocalizer;
            _controllerLocalizer = controllerLocalizer;
            _htmlLocalizer = htmlLocalizer;
        }

        // GET: PreInstructions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PreInstructions.Include(p => p.SubProcedure);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PreInstructions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preInstruction = await _context.PreInstructions.SingleOrDefaultAsync(m => m.PreInstructionId == id);
            if (preInstruction == null)
            {
                return NotFound();
            }

            return View(preInstruction);
        }

        // GET: PreInstructions/Create
        public IActionResult Create()
        {
            ViewData["SubProcedureId"] = new SelectList(_context.SubProcedures, "SubProcedureId", "Name");
            return View();
        }

        // POST: PreInstructions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PreInstructionId,Description,SubProcedureId,Title")] PreInstruction preInstruction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(preInstruction);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["SubProcedureId"] = new SelectList(_context.SubProcedures, "SubProcedureId", "Name", preInstruction.SubProcedureId);
            return View(preInstruction);
        }

        // GET: PreInstructions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preInstruction = await _context.PreInstructions.SingleOrDefaultAsync(m => m.PreInstructionId == id);
            if (preInstruction == null)
            {
                return NotFound();
            }
            ViewData["SubProcedureId"] = new SelectList(_context.SubProcedures, "SubProcedureId", "Name", preInstruction.SubProcedureId);
            return View(preInstruction);
        }

        // POST: PreInstructions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PreInstructionId,Description,SubProcedureId,Title")] PreInstruction preInstruction)
        {
            if (id != preInstruction.PreInstructionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(preInstruction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreInstructionExists(preInstruction.PreInstructionId))
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
            ViewData["SubProcedureId"] = new SelectList(_context.SubProcedures, "SubProcedureId", "Name", preInstruction.SubProcedureId);
            return View(preInstruction);
        }

        // GET: PreInstructions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preInstruction = await _context.PreInstructions.SingleOrDefaultAsync(m => m.PreInstructionId == id);
            if (preInstruction == null)
            {
                return NotFound();
            }

            return View(preInstruction);
        }

        // POST: PreInstructions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var preInstruction = await _context.PreInstructions.SingleOrDefaultAsync(m => m.PreInstructionId == id);
            _context.PreInstructions.Remove(preInstruction);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PreInstructionExists(int id)
        {
            return _context.PreInstructions.Any(e => e.PreInstructionId == id);
        }
    }
}
