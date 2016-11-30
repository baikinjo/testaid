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
    [Route("api/PreInstructions")]
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

        // GET: api/PreInstructions
        [HttpGet]
        public IEnumerable<PreInstruction> GetPreInstructions()
        {
            return _context.PreInstructions;
        }

        // GET: api/PreInstructions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPreInstruction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PreInstruction preInstruction = await _context.PreInstructions.SingleOrDefaultAsync(m => m.PreInstructionId == id);

            if (preInstruction == null)
            {
                return NotFound();
            }

            return Ok(preInstruction);
        }

        // GET /json/api/PreInstructions/filter/or
[HttpGet("Filter/{term}")]
        public IEnumerable<PreInstruction> Filter(string term)
        {
            return _context.PreInstructions
                .Where(m => m.Title.Contains(term.Trim()));
        }

        // PUT: api/PreInstructions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreInstruction([FromRoute] int id, [FromBody] PreInstruction preInstruction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != preInstruction.PreInstructionId)
            {
                return BadRequest();
            }

            _context.Entry(preInstruction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreInstructionExists(id))
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

        // POST: api/PreInstructions
        [HttpPost]
        public async Task<IActionResult> PostPreInstruction([FromBody] PreInstruction preInstruction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PreInstructions.Add(preInstruction);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PreInstructionExists(preInstruction.PreInstructionId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPreInstruction", new { id = preInstruction.PreInstructionId }, preInstruction);
        }

        // DELETE: api/PreInstructions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreInstruction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PreInstruction preInstruction = await _context.PreInstructions.SingleOrDefaultAsync(m => m.PreInstructionId == id);
            if (preInstruction == null)
            {
                return NotFound();
            }

            _context.PreInstructions.Remove(preInstruction);
            await _context.SaveChangesAsync();

            return Ok(preInstruction);
        }

        private bool PreInstructionExists(int id)
        {
            return _context.PreInstructions.Any(e => e.PreInstructionId == id);
        }
    }
}