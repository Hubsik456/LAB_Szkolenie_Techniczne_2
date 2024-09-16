using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hubert_Michna_w67259.Models;

namespace Hubert_Michna_w67259.Controllers
{
    public class Typ_WydatkuController : Controller
    {
        private readonly DB_Context _context;

        public Typ_WydatkuController(DB_Context context)
        {
            _context = context;
        }

        // GET: Typ_Wydatku
        public async Task<IActionResult> Index()
        {
              return _context.Typ_Wydatku != null ? 
                          View(await _context.Typ_Wydatku.ToListAsync()) :
                          Problem("Entity set 'DB_Context.Typ_Wydatku'  is null.");
        }

        // GET: Typ_Wydatku/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Typ_Wydatku == null)
            {
                return NotFound();
            }

            var typ_Wydatku = await _context.Typ_Wydatku
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typ_Wydatku == null)
            {
                return NotFound();
            }

            return View(typ_Wydatku);
        }

        // GET: Typ_Wydatku/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Typ_Wydatku/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa")] Typ_Wydatku typ_Wydatku)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typ_Wydatku);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typ_Wydatku);
        }

        // GET: Typ_Wydatku/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Typ_Wydatku == null)
            {
                return NotFound();
            }

            var typ_Wydatku = await _context.Typ_Wydatku.FindAsync(id);
            if (typ_Wydatku == null)
            {
                return NotFound();
            }
            return View(typ_Wydatku);
        }

        // POST: Typ_Wydatku/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa")] Typ_Wydatku typ_Wydatku)
        {
            if (id != typ_Wydatku.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typ_Wydatku);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Typ_WydatkuExists(typ_Wydatku.Id))
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
            return View(typ_Wydatku);
        }

        // GET: Typ_Wydatku/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Typ_Wydatku == null)
            {
                return NotFound();
            }

            var typ_Wydatku = await _context.Typ_Wydatku
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typ_Wydatku == null)
            {
                return NotFound();
            }

            return View(typ_Wydatku);
        }

        // POST: Typ_Wydatku/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Typ_Wydatku == null)
            {
                return Problem("Entity set 'DB_Context.Typ_Wydatku'  is null.");
            }
            var typ_Wydatku = await _context.Typ_Wydatku.FindAsync(id);
            if (typ_Wydatku != null)
            {
                _context.Typ_Wydatku.Remove(typ_Wydatku);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Typ_WydatkuExists(int id)
        {
          return (_context.Typ_Wydatku?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
