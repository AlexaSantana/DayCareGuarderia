using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DayCareGuarderia.Models.Entities;

namespace DayCareGuarderia.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly DayCareGuarderiaDataContext _context;

        public ActivitiesController(DayCareGuarderiaDataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Activities.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activities = await _context.Activities
                .FirstOrDefaultAsync(m => m.ActivitiesId == id);
            if (activities == null)
            {
                return NotFound();
            }

            return View(activities);
        }

        // GET: Activities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Activities activities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activities);
        }

        // GET: Activities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activities = await _context.Activities.FindAsync(id);
            if (activities == null)
            {
                return NotFound();
            }
            return View(activities);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Activities activities)
        {
            if (id != activities.ActivitiesId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(activities);
            }
                try
                {
                    _context.Update(activities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivitiesExists(activities.ActivitiesId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
        }

        // GET: Activities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activities = await _context.Activities
                .FirstOrDefaultAsync(m => m.ActivitiesId == id);
            if (activities == null)
            {
                return NotFound();
            }

            return View(activities);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activities = await _context.Activities.FindAsync(id);
            if (activities != null)
            {
                _context.Activities.Remove(activities);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivitiesExists(int id)
        {
            return _context.Activities.Any(e => e.ActivitiesId == id);
        }
    }
}
