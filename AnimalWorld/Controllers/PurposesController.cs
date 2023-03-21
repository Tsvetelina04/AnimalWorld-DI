using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnimalWorld.Data;

namespace AnimalWorld.Controllers
{
    public class PurposesController : Controller
    {
        private readonly AnimalWorldDbContext _context;

        public PurposesController(AnimalWorldDbContext context)
        {
            _context = context;
        }

        // GET: Purposes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Purposes.ToListAsync());
        }

        // GET: Purposes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purpose = await _context.Purposes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purpose == null)
            {
                return NotFound();
            }

            return View(purpose);
        }

        // GET: Purposes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Purposes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Purpose purpose)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purpose);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purpose);
        }

        // GET: Purposes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purpose = await _context.Purposes.FindAsync(id);
            if (purpose == null)
            {
                return NotFound();
            }
            return View(purpose);
        }

        // POST: Purposes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Purpose purpose)
        {
            if (id != purpose.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purpose);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurposeExists(purpose.Id))
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
            return View(purpose);
        }

        // GET: Purposes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purpose = await _context.Purposes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purpose == null)
            {
                return NotFound();
            }

            return View(purpose);
        }

        // POST: Purposes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purpose = await _context.Purposes.FindAsync(id);
            _context.Purposes.Remove(purpose);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurposeExists(int id)
        {
            return _context.Purposes.Any(e => e.Id == id);
        }
    }
}
