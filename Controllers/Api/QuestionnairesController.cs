using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecondAid.Data;
using SecondAid.Models.Health;

namespace SecondAid.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Questionnaires")]
    public class QuestionnairesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionnairesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Questionnaires
        [HttpGet]
        public IEnumerable<Questionnaire> GetQuestionnaires()
        {
            return _context.Questionnaires
                        .Include(q => q.Questions);
        }

        // get the questionnaire based on the 
        // GET: api/Questionnaires/SubProcedure/5
        [HttpGet("{id}")]
        public IActionResult GetQuestionnaireSubProcedure([FromRoute] int id)
        {

            Console.WriteLine("********");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Console.WriteLine("********");
            Console.WriteLine(id);

            Questionnaire questionnaire = _context.Questionnaires
                                                .Include(q => q.Questions)
                                                .Include(q => q.SubProcedure)
                                                .FirstOrDefault(m => m.SubProcedureId == id);

            if (questionnaire == null)
            {
                return NotFound();
            }

            return Ok(questionnaire);
        }

        //// GET: api/Questionnaires/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetQuestionnaire([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Questionnaire questionnaire = await _context.Questionnaires
        //                                        .Include(q => q.Questions)
        //                                        .Include(q => q.SubProcedure)
        //                                        .SingleOrDefaultAsync(m => m.QuestionnaireId == id);

        //    if (questionnaire == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(questionnaire);
        //}

        //    // PUT: api/Questionnaires/5
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutQuestionnaire([FromRoute] int id, [FromBody] Questionnaire questionnaire)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        if (id != questionnaire.QuestionnaireId)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(questionnaire).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!QuestionnaireExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        //    // POST: api/Questionnaires
        //    [HttpPost]
        //    public async Task<IActionResult> PostQuestionnaire([FromBody] Questionnaire questionnaire)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        _context.Questionnaires.Add(questionnaire);
        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateException)
        //        {
        //            if (QuestionnaireExists(questionnaire.QuestionnaireId))
        //            {
        //                return new StatusCodeResult(StatusCodes.Status409Conflict);
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return CreatedAtAction("GetQuestionnaire", new { id = questionnaire.QuestionnaireId }, questionnaire);
        //    }

        //    // DELETE: api/Questionnaires/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteQuestionnaire([FromRoute] int id)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        Questionnaire questionnaire = await _context.Questionnaires.SingleOrDefaultAsync(m => m.QuestionnaireId == id);
        //        if (questionnaire == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Questionnaires.Remove(questionnaire);
        //        await _context.SaveChangesAsync();

        //        return Ok(questionnaire);
        //    }

        private bool QuestionnaireExists(int id)
        {
            return _context.Questionnaires.Any(e => e.QuestionnaireId == id);
        }
    }
}