using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecondAid.Models.Health;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Authorization;
using SecondAid.Data;
using Microsoft.AspNetCore.Identity;
using SecondAid.Models;
using System;

namespace SecondAid.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class SubProceduresController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IStringLocalizer<HomeController> _controllerLocalizer;
        private readonly UserManager<ApplicationUser> _userManager;

        public SubProceduresController(ApplicationDbContext context,
            IStringLocalizer<HomeController> controllerLocalizer,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _controllerLocalizer = controllerLocalizer;
        }

        // GET: SubProcedures
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SubProcedures.Include(s => s.Procedure);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SubProcedures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subProcedure = await _context
                .SubProcedures
                .Include(p => p.Procedure)
                .SingleOrDefaultAsync(m => m.SubProcedureId == id);

            if (subProcedure == null)
            {
                return NotFound();
            }

            return View(subProcedure);
        }

        // GET: SubProcedures/Create
        public IActionResult Create()
        {
            ViewData["ProcedureId"] = new SelectList(_context.Procedures, "ProcedureId", "Name");
            return View();
        }

        // POST: SubProcedures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubProcedureId,Description,Name,ProcedureId")] SubProcedure subProcedure)
        {
            if (ModelState.IsValid)
            {
                // ADDING A NEW QUESTIONNAIRE WHENEVER A NEW SUBPROCEDURE IS ADDED
                Questionnaire newQuestionnaire = new Questionnaire();

                newQuestionnaire.CreatedBy = _userManager.GetUserName(User);
                newQuestionnaire.DateCreated = DateTime.Today;
                newQuestionnaire.Name = subProcedure.Name + " Questionnaire";
                newQuestionnaire.SubProcedure = subProcedure;
                newQuestionnaire.SubProcedureId = subProcedure.SubProcedureId;
                // empty questions array that will be later updated once questions are added;
                newQuestionnaire.Questions = new System.Collections.Generic.List<Question>();


                _context.Add(subProcedure);
                _context.Add(newQuestionnaire);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            SelectList sl = new SelectList(_context.Procedures, "ProcedureId", "Name", subProcedure.ProcedureId);
            ViewData["ProcedureId"] = sl;
            return View(subProcedure);
        }

        // GET: SubProcedures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subProcedure = await _context.SubProcedures.SingleOrDefaultAsync(m => m.SubProcedureId == id);
            if (subProcedure == null)
            {
                return NotFound();
            }
            ViewData["ProcedureId"] = new SelectList(_context.Procedures, "ProcedureId", "Name", subProcedure.ProcedureId);
            return View(subProcedure);
        }

        // POST: SubProcedures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubProcedureId,Description,Name,ProcedureId")] SubProcedure subProcedure)
        {
            if (id != subProcedure.SubProcedureId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subProcedure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubProcedureExists(subProcedure.SubProcedureId))
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
            ViewData["ProcedureId"] = new SelectList(_context.Procedures, "ProcedureId", "Name", subProcedure.ProcedureId);
            return View(subProcedure);
        }

        // GET: SubProcedures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subProcedure = await _context
                .SubProcedures
                .Include(p => p.Procedure)
                .SingleOrDefaultAsync(m => m.SubProcedureId == id);

            if (subProcedure == null)
            {
                return NotFound();
            }

            return View(subProcedure);
        }

        // POST: SubProcedures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // removing questionnare and subprocedure
            var subProcedure = await _context.SubProcedures.SingleOrDefaultAsync(m => m.SubProcedureId == id);
            var questionnaire = await _context.Questionnaires
                                    .Include(q => q.Questions)
                                    .SingleOrDefaultAsync(m => m.SubProcedure == subProcedure);
            // removing all the questions stored along with this subprocedure;
            foreach ( var question in questionnaire.Questions )
            {
                _context.Question.Remove(question);
            }
            _context.SubProcedures.Remove(subProcedure);
            _context.Questionnaires.Remove(questionnaire);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SubProcedureExists(int id)
        {
            return _context.SubProcedures.Any(e => e.SubProcedureId == id);
        }
    }
}
