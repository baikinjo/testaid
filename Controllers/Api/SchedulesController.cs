using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecondAid.Data;
using SecondAid.Models.Health;
using Microsoft.AspNetCore.Authorization;
using SecondAid.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;

namespace SecondAid.Controllers.Api
{
	[Produces("application/json")]
    [Route("api/Schedules")]
	[Authorize]
    [EnableCors("SiteCorsPolicy")]
    public class SchedulesController : Controller
    {
		private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SchedulesController(ApplicationDbContext context, 
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

		[HttpGet]
        [Produces("application/json")]
        public IEnumerable<Schedule> GetSchedules()
        {
            var userID = _userManager.GetUserId(User);

            var applicationDbContext = _context.Schedule
                .Where(u => u.PatientId == userID);

            return applicationDbContext;
        } 
	}
}