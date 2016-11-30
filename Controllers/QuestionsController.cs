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
    public class QuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Question.Include(q => q.SubProcedure);
            Console.WriteLine((await applicationDbContext.ToListAsync()));
            return View(await applicationDbContext.ToListAsync());

            //return View(_context.Question.ToList());
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question.SingleOrDefaultAsync(m => m.QuestionId == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Questions/Create
        public IActionResult Create()
        {
            ViewData["SubProcedureId"] = new SelectList(_context.SubProcedures, "SubProcedureId", "Name");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestionId,QuestionBody,SubProcedureId")] Question question)
        {
            var subProcedure = _context.SubProcedures.FirstOrDefault(s => s.SubProcedureId == question.SubProcedureId);

            // once a question is created we need to append this question to its corresponding questionnaire

            var questionnaire = _context.Questionnaires
                .Include(q => q.Questions)
                .FirstOrDefault(q => q.SubProcedureId == subProcedure.SubProcedureId);
            
            if (ModelState.IsValid)
            {
                if(questionnaire.Questions == null)
                {
                    questionnaire.Questions = new List<Question> { question };
                } else
                {
                    questionnaire.Questions.Add(question);
                }

                _context.Add(question);

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["SubProcedureId"] = new SelectList(_context.SubProcedures, "SubProcedureId", "Name", question.SubProcedureId);
            return View(question);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question.SingleOrDefaultAsync(m => m.QuestionId == id);
            if (question == null)
            {
                return NotFound();
            }
            ViewData["SubProcedureId"] = new SelectList(_context.SubProcedures, "SubProcedureId", "Name", question.SubProcedureId);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuestionId,QuestionBody,SubProcedureId")] Question question)
        {
            if (id != question.QuestionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.QuestionId))
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
            ViewData["SubProcedureId"] = new SelectList(_context.SubProcedures, "SubProcedureId", "Name", question.SubProcedureId);
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question.SingleOrDefaultAsync(m => m.QuestionId == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // remove this question from its corresponding questionnaire as well

            var question = await _context.Question.SingleOrDefaultAsync(m => m.QuestionId == id);
            var questionnaire = await _context.Questionnaires.SingleOrDefaultAsync(q => q.SubProcedure == question.SubProcedure);

            questionnaire.Questions.Remove(question);
            _context.Question.Remove(question);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool QuestionExists(int id)
        {
            return _context.Question.Any(e => e.QuestionId == id);
        }
    }
}
