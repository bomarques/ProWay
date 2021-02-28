using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MatriculaProway.Models;

namespace MatriculaProway.Controllers
{
    public class LanchonetesController : Controller
    {
        private readonly testeprowayContext _context;

        public LanchonetesController(testeprowayContext context)
        {
            _context = context;
        }

        // GET: Lanchonetes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lanchonetes.ToListAsync());
        }

        // GET: Lanchonetes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lanchonete = await _context.Lanchonetes
                .FirstOrDefaultAsync(m => m.LanchoneteId == id);
            if (lanchonete == null)
            {
                return NotFound();
            }

            return View(lanchonete);
        }

        // GET: Lanchonetes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lanchonetes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LanchoneteId,Nome")] Lanchonete lanchonete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lanchonete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lanchonete);
        }

        // GET: Lanchonetes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lanchonete = await _context.Lanchonetes.FindAsync(id);
            if (lanchonete == null)
            {
                return NotFound();
            }
            return View(lanchonete);
        }

        // POST: Lanchonetes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LanchoneteId,Nome")] Lanchonete lanchonete)
        {
            if (id != lanchonete.LanchoneteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lanchonete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LanchoneteExists(lanchonete.LanchoneteId))
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
            return View(lanchonete);
        }

        // GET: Lanchonetes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lanchonete = await _context.Lanchonetes
                .FirstOrDefaultAsync(m => m.LanchoneteId == id);
            if (lanchonete == null)
            {
                return NotFound();
            }

            return View(lanchonete);
        }

        // POST: Lanchonetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lanchonete = await _context.Lanchonetes.FindAsync(id);
            _context.Lanchonetes.Remove(lanchonete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LanchoneteExists(int id)
        {
            return _context.Lanchonetes.Any(e => e.LanchoneteId == id);
        }
    }
}
