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
    public class ParentsController : Controller
    {
        private readonly DayCareGuarderiaDataContext _context;

        public ParentsController(DayCareGuarderiaDataContext context)
        {
            _context = context;
        }

        // GET: Parents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parent.ToListAsync());
        }

        // GET: Parents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parents = await _context.Parent
                .FirstOrDefaultAsync(m => m.ParentId == id);
            if (parents == null)
            {
                return NotFound();
            }

            return View(parents);
        }

        // GET: Parents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Parent Parent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Parent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Parent);
        }

        // GET: Parents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parents = await _context.Parent.FindAsync(id);
            if (parents == null)
            {
                return NotFound();
            }
            return View(parents);
        }

        // POST: Parents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Parent parents)
        {
            if (id != parents.ParentId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(parents);
            }
                try
                {
                    _context.Update(parents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParentsExists(parents.ParentId))
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

        // GET: Parents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parents = await _context.Parent
                .FirstOrDefaultAsync(m => m.ParentId == id);
            if (parents == null)
            {
                return NotFound();
            }

            return View(parents);
        }

        // POST: Parents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parents = await _context.Parent.FindAsync(id);
            if (parents != null)
            {
                _context.Parent.Remove(parents);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParentsExists(int id)
        {
            return _context.Parent.Any(e => e.ParentId == id);
        }
    }
}
