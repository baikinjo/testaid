using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecondAid.Models.Health;
using Microsoft.Extensions.Localization;
using SecondAid.Resources;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Cors;
using SecondAid.Data;

namespace SecondAid.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/SubProcedures")]
    public class SubProceduresController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;
        private readonly IStringLocalizer<SubProceduresController> _controllerLocalizer;
        private readonly IHtmlLocalizer _htmlLocalizer;

        public SubProceduresController(ApplicationDbContext context,
            IStringLocalizer<SharedResource> sharedLocalizer,
            IStringLocalizer<SubProceduresController> controllerLocalizer,
            IHtmlLocalizer<SubProceduresController> htmlLocalizer)
        {
            _context = context;
            _sharedLocalizer = sharedLocalizer;
            _controllerLocalizer = controllerLocalizer;
            _htmlLocalizer = htmlLocalizer;
        }

        // GET: api/SubProcedures
        [HttpGet]
        public IEnumerable<SubProcedure> GetSubProcedures()
        {
            return _context.SubProcedures.Include(s => s.Procedure);
        }

        // GET: api/SubProcedures/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubProcedure([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SubProcedure subProcedure = await _context
                .SubProcedures
                .Include(s => s.Procedure)
                .SingleOrDefaultAsync(m => m.SubProcedureId == id);

            if (subProcedure == null)
            {
                return NotFound();
            }

            return Ok(subProcedure);
        }

        // GET /json/api/SubProcedures/filter/or
[HttpGet("Filter/{term}")]
        public IEnumerable<SubProcedure> Filter(string term)
        {
            return _context.SubProcedures
                .Where(m => m.Name.Contains(term.Trim()));
        }

        // PUT: api/SubProcedures/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubProcedure([FromRoute] int id, [FromBody] SubProcedure subProcedure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subProcedure.SubProcedureId)
            {
                return BadRequest();
            }

            _context.Entry(subProcedure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubProcedureExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SubProcedures
        [HttpPost]
        public async Task<IActionResult> PostSubProcedure([FromBody] SubProcedure subProcedure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SubProcedures.Add(subProcedure);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubProcedureExists(subProcedure.SubProcedureId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSubProcedure", new { id = subProcedure.SubProcedureId }, subProcedure);
        }

        // DELETE: api/SubProcedures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubProcedure([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SubProcedure subProcedure = await _context.SubProcedures.SingleOrDefaultAsync(m => m.SubProcedureId == id);
            if (subProcedure == null)
            {
                return NotFound();
            }

            _context.SubProcedures.Remove(subProcedure);
            await _context.SaveChangesAsync();

            return Ok(subProcedure);
        }

        private bool SubProcedureExists(int id)
        {
            return _context.SubProcedures.Any(e => e.SubProcedureId == id);
        }
    }
}