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
using Microsoft.AspNetCore.Authorization;
using SecondAid.Data;

namespace SecondAid.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Procedures")]
    public class ProceduresController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;
        private readonly IStringLocalizer<ProceduresController> _controllerLocalizer;
        private readonly IHtmlLocalizer _htmlLocalizer;

        public ProceduresController(ApplicationDbContext context,
            IStringLocalizer<SharedResource> sharedLocalizer,
            IStringLocalizer<ProceduresController> controllerLocalizer,
            IHtmlLocalizer<ProceduresController> htmlLocalizer)
        {
            _context = context;
            _sharedLocalizer = sharedLocalizer;
            _controllerLocalizer = controllerLocalizer;
            _htmlLocalizer = htmlLocalizer;
        }

        // GET: api/Procedures
        [HttpGet]
        public IEnumerable<Procedure> GetProcedures()
        {
            return _context.Procedures;
        }

        // GET: api/Procedures/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProcedure([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Procedure procedure = await _context.Procedures.SingleOrDefaultAsync(m => m.ProcedureId == id);

            if (procedure == null)
            {
                return NotFound();
            }

            return Ok(procedure);
        }

        // GET /json/api/Procedures/filter/or
[HttpGet("Filter/{term}")]
        public IEnumerable<Procedure> Filter(string term)
        {
            return _context.Procedures
                .Where(m => m.Name.Contains(term.Trim()));
        }

        // PUT: api/Procedures/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcedure([FromRoute] int id, [FromBody] Procedure procedure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != procedure.ProcedureId)
            {
                return BadRequest();
            }

            _context.Entry(procedure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcedureExists(id))
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

        // POST: api/Procedures
        [HttpPost]
        public async Task<IActionResult> PostProcedure([FromBody] Procedure procedure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Procedures.Add(procedure);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProcedureExists(procedure.ProcedureId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProcedure", new { id = procedure.ProcedureId }, procedure);
        }

        // DELETE: api/Procedures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcedure([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Procedure procedure = await _context.Procedures.SingleOrDefaultAsync(m => m.ProcedureId == id);
            if (procedure == null)
            {
                return NotFound();
            }

            _context.Procedures.Remove(procedure);
            await _context.SaveChangesAsync();

            return Ok(procedure);
        }

        private bool ProcedureExists(int id)
        {
            return _context.Procedures.Any(e => e.ProcedureId == id);
        }
    }
}