using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecondAid.Data;
using SecondAid.Models.Health;
using SecondAid.Models.HealthViewModels;
using Microsoft.AspNetCore.Cors;

namespace SecondAid.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Clinics")]
    [EnableCors("SiteCorsPolicy")]
    public class ClinicsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClinicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Clinics
        [HttpGet]
        public IEnumerable<ClinicViewModel> GetClinics()
        {
            List < ClinicViewModel > list = new List<ClinicViewModel>();
            //List<Clinic> List = _context.Clinics.AsEnumerable().Select(e => new )

            foreach(var item in _context.Clinics.ToList())
            {
                ClinicViewModel model = new ClinicViewModel();
                model.ClinicId = item.ClinicId;
                model.ClinicName = item.ClinicName;
                model.ClinicAddress = item.ClinicAddress;
                model.PhoneNumber = item.PhoneNumber;

                list.Add(model);
            }

            return list;
            //return _context.Clinics;
        }

        // GET: api/Clinics/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClinic([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Clinic clinic = await _context.Clinics.SingleOrDefaultAsync(m => m.ClinicId == id);

            if (clinic == null)
            {
                return NotFound();
            }

            return Ok(clinic);
        }

        private bool ClinicExists(int id)
        {
            return _context.Clinics.Any(e => e.ClinicId == id);
        }
    }
}