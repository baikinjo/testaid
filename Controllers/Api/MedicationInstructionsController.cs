using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecondAid.Models.Health;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using SecondAid.Resources;
using Microsoft.AspNetCore.Cors;
using SecondAid.Data;

namespace SecondAid.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/MedicationInstructions")]
    [EnableCors("SiteCorsPolicy")] 
    public class MedicationInstructionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;
        private readonly IStringLocalizer<MedicationInstructionsController> _controllerLocalizer;
        private readonly IHtmlLocalizer _htmlLocalizer;

        public MedicationInstructionsController(ApplicationDbContext context,
            IStringLocalizer<SharedResource> sharedLocalizer,
            IStringLocalizer<MedicationInstructionsController> controllerLocalizer,
            IHtmlLocalizer<MedicationInstructionsController> htmlLocalizer)
        {
            _context = context;
            _sharedLocalizer = sharedLocalizer;
            _controllerLocalizer = controllerLocalizer;
            _htmlLocalizer = htmlLocalizer;
        }

        // GET: api/MedicationInstructions
        [HttpGet]
        public IEnumerable<MedicationInstruction> GetMedicationInstructions()
        {
            return _context.MedicationInstructions.
                Include(i => i.Medication);
        }

        // GET: api/MedicationInstructions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicationInstruction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MedicationInstruction medicationInstruction = await _context
                .MedicationInstructions
                .Include(i => i.Medication)
                .SingleOrDefaultAsync(m => m.MedicationInstructionId == id);

            if (medicationInstruction == null)
            {
                return NotFound();
            }

            return Ok(medicationInstruction);
        }

        // GET /json/api/MedicationInstructions/filter/or
[HttpGet("Filter/{term}")]
        public IEnumerable<MedicationInstruction> Filter(string term)
        {
            return _context.MedicationInstructions
                .Where(m => m.Instruction.Contains(term.Trim()));
        }

        // PUT: api/MedicationInstructions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicationInstruction([FromRoute] int id, [FromBody] MedicationInstruction medicationInstruction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicationInstruction.MedicationInstructionId)
            {
                return BadRequest();
            }

            _context.Entry(medicationInstruction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicationInstructionExists(id))
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

        // POST: api/MedicationInstructions
        [HttpPost]
        public async Task<IActionResult> PostMedicationInstruction([FromBody] MedicationInstruction medicationInstruction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MedicationInstructions.Add(medicationInstruction);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MedicationInstructionExists(medicationInstruction.MedicationInstructionId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMedicationInstruction", new { id = medicationInstruction.MedicationInstructionId }, medicationInstruction);
        }

        // DELETE: api/MedicationInstructions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicationInstruction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MedicationInstruction medicationInstruction = await _context.MedicationInstructions.SingleOrDefaultAsync(m => m.MedicationInstructionId == id);
            if (medicationInstruction == null)
            {
                return NotFound();
            }

            _context.MedicationInstructions.Remove(medicationInstruction);
            await _context.SaveChangesAsync();

            return Ok(medicationInstruction);
        }

        private bool MedicationInstructionExists(int id)
        {
            return _context.MedicationInstructions.Any(e => e.MedicationInstructionId == id);
        }
    }
}