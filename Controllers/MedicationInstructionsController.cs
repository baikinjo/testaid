using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecondAid.Models.Health;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Authorization;
using SecondAid.Data;

namespace SecondAid.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class MedicationInstructionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IStringLocalizer<HomeController> _controllerLocalizer;

        public MedicationInstructionsController(ApplicationDbContext context,
            IStringLocalizer<HomeController> controllerLocalizer)
        {
            _context = context;
            _controllerLocalizer = controllerLocalizer;
        }

        // GET: MedicationInstructions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MedicationInstructions.Include(m => m.Medication);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MedicationInstructions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicationInstruction = await _context
                .MedicationInstructions
                .Include(m => m.Medication)
                .SingleOrDefaultAsync(m => m.MedicationInstructionId == id);

            if (medicationInstruction == null)
            {
                return NotFound();
            }

            return View(medicationInstruction);
        }

        // GET: MedicationInstructions/Create
        public IActionResult Create()
        {
            ViewData["MedicationId"] = new SelectList(_context.Medications, "MedicationId", "Name");
            return View();
        }

        // POST: MedicationInstructions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicationInstructionId,Instruction,MedicationId")] MedicationInstruction medicationInstruction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicationInstruction);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["MedicationId"] = new SelectList(_context.Medications, "MedicationId", "Name", medicationInstruction.MedicationId);
            return View(medicationInstruction);
        }

        // GET: MedicationInstructions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicationInstruction = await _context.MedicationInstructions.SingleOrDefaultAsync(m => m.MedicationInstructionId == id);
            if (medicationInstruction == null)
            {
                return NotFound();
            }
            ViewData["MedicationId"] = new SelectList(_context.Medications, "MedicationId", "Name", medicationInstruction.MedicationId);
            return View(medicationInstruction);
        }

        // POST: MedicationInstructions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedicationInstructionId,Instruction,MedicationId")] MedicationInstruction medicationInstruction)
        {
            if (id != medicationInstruction.MedicationInstructionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicationInstruction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicationInstructionExists(medicationInstruction.MedicationInstructionId))
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
            ViewData["MedicationId"] = new SelectList(_context.Medications, "MedicationId", "Name", medicationInstruction.MedicationId);
            return View(medicationInstruction);
        }

        // GET: MedicationInstructions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicationInstruction = await _context
                .MedicationInstructions
                .Include(m => m.Medication)
                .SingleOrDefaultAsync(m => m.MedicationInstructionId == id);

            if (medicationInstruction == null)
            {
                return NotFound();
            }

            return View(medicationInstruction);
        }

        // POST: MedicationInstructions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicationInstruction = await _context.MedicationInstructions.SingleOrDefaultAsync(m => m.MedicationInstructionId == id);
            _context.MedicationInstructions.Remove(medicationInstruction);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MedicationInstructionExists(int id)
        {
            return _context.MedicationInstructions.Any(e => e.MedicationInstructionId == id);
        }
    }
}
