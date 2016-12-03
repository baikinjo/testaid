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
    [Route("api/PatientProcedures")]
    public class PatientProceduresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientProceduresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PatientProcedures
        [HttpGet]
        public IEnumerable<PatientProcedure> GetPatientProcedure()
        {
            return _context.PatientProcedure;
        }

        // GET: api/PatientProcedures/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientProcedure([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PatientProcedure patientProcedure = await _context.PatientProcedure.SingleOrDefaultAsync(m => m.PatientProcedureId == id);

            if (patientProcedure == null)
            {
                return NotFound();
            }

            return Ok(patientProcedure);
        }

        private bool PatientProcedureExists(int id)
        {
            return _context.PatientProcedure.Any(e => e.PatientProcedureId == id);
        }
    }
}