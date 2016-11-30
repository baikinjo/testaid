using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecondAid.Models.Health;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using SecondAid.Resources;
using Microsoft.AspNetCore.Mvc.Localization;
using SecondAid.Data;

namespace SecondAid.Controllers
{
    [Authorize (Roles = "Administrator")]
    public class VideosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;
        private readonly IStringLocalizer<VideosController> _controllerLocalizer;
        private readonly IHtmlLocalizer _htmlLocalizer;

        public VideosController(ApplicationDbContext context,
            IStringLocalizer<SharedResource> sharedLocalizer,
            IStringLocalizer<VideosController> controllerLocalizer,
            IHtmlLocalizer<VideosController> htmlLocalizer)
        {
            _context = context;
            _sharedLocalizer = sharedLocalizer;
            _controllerLocalizer = controllerLocalizer;
            _htmlLocalizer = htmlLocalizer;
        }

        // GET: Videos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Videos.Include(v => v.SubProcedure);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Videos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _context.Videos.SingleOrDefaultAsync(m => m.VideoId == id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // GET: Videos/Create
        public IActionResult Create()
        {
            ViewData["SubProcedureId"] = new SelectList(_context.SubProcedures, "SubProcedureId", "Name");
            return View();
        }

        // POST: Videos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VideoId,Description,SubProcedureId,Title,URL")] Video video)
        {
            if (ModelState.IsValid)
            {
                _context.Add(video);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["SubProcedureId"] = new SelectList(_context.SubProcedures, "SubProcedureId", "Name", video.SubProcedureId);
            return View(video);
        }

        // GET: Videos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _context.Videos.SingleOrDefaultAsync(m => m.VideoId == id);
            if (video == null)
            {
                return NotFound();
            }
            ViewData["SubProcedureId"] = new SelectList(_context.SubProcedures, "SubProcedureId", "Name", video.SubProcedureId);
            return View(video);
        }

        // POST: Videos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VideoId,Description,SubProcedureId,Title,URL")] Video video)
        {
            if (id != video.VideoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(video);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoExists(video.VideoId))
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
            ViewData["SubProcedureId"] = new SelectList(_context.SubProcedures, "SubProcedureId", "Name", video.SubProcedureId);
            return View(video);
        }

        // GET: Videos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _context.Videos.SingleOrDefaultAsync(m => m.VideoId == id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var video = await _context.Videos.SingleOrDefaultAsync(m => m.VideoId == id);
            _context.Videos.Remove(video);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool VideoExists(int id)
        {
            return _context.Videos.Any(e => e.VideoId == id);
        }
    }
}
