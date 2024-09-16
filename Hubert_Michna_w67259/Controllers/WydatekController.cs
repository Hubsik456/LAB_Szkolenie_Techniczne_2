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
    public class WydatekController : Controller
    {
        private readonly DB_Context _context;

        public WydatekController(DB_Context context)
        {
            _context = context;
        }

        // GET: Wydatek
        public async Task<IActionResult> Index()
        {
              return _context.Wydatek != null ? 
                          View(await _context.Wydatek.ToListAsync()) :
                          Problem("Entity set 'DB_Context.Wydatek'  is null.");
        }

        // GET: Wydatek/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Wydatek == null)
            {
                return NotFound();
            }

            var wydatek = await _context.Wydatek
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wydatek == null)
            {
                return NotFound();
            }

            return View(wydatek);
        }

        // GET: Wydatek/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wydatek/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa_Wydatku,Typ_Wydatku_ID,Cena,Data_Wydatku,Waluta")] Wydatek wydatek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wydatek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wydatek);
        }

        // GET: Wydatek/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Wydatek == null)
            {
                return NotFound();
            }

            var wydatek = await _context.Wydatek.FindAsync(id);
            if (wydatek == null)
            {
                return NotFound();
            }
            return View(wydatek);
        }

        // POST: Wydatek/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa_Wydatku,Typ_Wydatku_ID,Cena,Data_Wydatku,Waluta")] Wydatek wydatek)
        {
            if (id != wydatek.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wydatek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WydatekExists(wydatek.Id))
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
            return View(wydatek);
        }

        // GET: Wydatek/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Wydatek == null)
            {
                return NotFound();
            }

            var wydatek = await _context.Wydatek
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wydatek == null)
            {
                return NotFound();
            }

            return View(wydatek);
        }

        // POST: Wydatek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Wydatek == null)
            {
                return Problem("Entity set 'DB_Context.Wydatek'  is null.");
            }
            var wydatek = await _context.Wydatek.FindAsync(id);
            if (wydatek != null)
            {
                _context.Wydatek.Remove(wydatek);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WydatekExists(int id)
        {
          return (_context.Wydatek?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
