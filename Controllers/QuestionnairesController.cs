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
    public class QuestionnairesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionnairesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Questionnaires
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Questionnaires.Include(q => q.SubProcedure);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Questionnaires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationDbContext = _context.Questionnaires.Include(q => q.Questions);

            var questionnaires = await applicationDbContext.ToListAsync();

            var questionnaire = questionnaires.Find(q => q.QuestionnaireId == id);

            if (questionnaire == null)
            {
                return NotFound();
            }

            return View(questionnaire);
        }


        // No point of having create, explicitly add questionnaire everytime a subprocedure is added
        // update the questionnarie everytime a question is updated/added

        //// GET: Questionnaires/Create
        //public IActionResult Create()
        //{
        //    ViewData["SubProcedureId"] = new SelectList(_context.SubProcedures, "SubProcedureId", "Name");
        //    return View();
        //}

        //// POST: Questionnaires/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("QuestionnaireId,Name,SubProcedureId")] Questionnaire questionnaire)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(questionnaire);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    ViewData["SubProcedureId"] = new SelectList(_context.SubProcedures, "SubProcedureId", "Name", questionnaire.SubProcedureId);
        //    return View(questionnaire);
        //}

        
        // Is there a need to update the questionnaries or delete them ??
        
        //// GET: Questionnaires/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var questionnaire = await _context.Questionnaires.SingleOrDefaultAsync(m => m.QuestionnaireId == id);
        //    if (questionnaire == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["SubProcedureId"] = new SelectList(_context.SubProcedures, "SubProcedureId", "Name", questionnaire.SubProcedureId);
        //    return View(questionnaire);
        //}

        //// POST: Questionnaires/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("QuestionnaireId,Name,SubProcedureId")] Questionnaire questionnaire)
        //{
        //    if (id != questionnaire.QuestionnaireId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(questionnaire);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!QuestionnaireExists(questionnaire.QuestionnaireId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    ViewData["SubProcedureId"] = new SelectList(_context.SubProcedures, "SubProcedureId", "Name", questionnaire.SubProcedureId);
        //    return View(questionnaire);
        //}

        //// GET: Questionnaires/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var questionnaire = await _context.Questionnaires.SingleOrDefaultAsync(m => m.QuestionnaireId == id);
        //    if (questionnaire == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(questionnaire);
        //}

        //// POST: Questionnaires/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var questionnaire = await _context.Questionnaires.SingleOrDefaultAsync(m => m.QuestionnaireId == id);
        //    _context.Questionnaires.Remove(questionnaire);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        private bool QuestionnaireExists(int id)
        {
            return _context.Questionnaires.Any(e => e.QuestionnaireId == id);
        }
    }
}
