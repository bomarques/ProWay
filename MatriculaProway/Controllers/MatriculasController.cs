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
    public class MatriculasController : Controller
    {
        private readonly testeprowayContext _context;

        public MatriculasController(testeprowayContext context)
        {
            _context = context;
        }

        // GET: Matriculas
        public async Task<IActionResult> Index()
        {
            var testeprowayContext = _context.Matriculas.Include(m => m.Aluno).Include(m => m.Etapa1Navigation).Include(m => m.Etapa2Navigation).Include(m => m.Turno1LanchoneteNavigation).Include(m => m.Turno2LanchoneteNavigation);
            return View(await testeprowayContext.ToListAsync());
        }

        // GET: Matriculas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas
                .Include(m => m.Aluno)
                .Include(m => m.Etapa1Navigation)
                .Include(m => m.Etapa2Navigation)
                .Include(m => m.Turno1LanchoneteNavigation)
                .Include(m => m.Turno2LanchoneteNavigation)
                .FirstOrDefaultAsync(m => m.MatriculaId == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // GET: Matriculas/Create
        public IActionResult Create()
        {
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "AlunoId", "AlunoId");
            ViewData["Etapa1"] = new SelectList(_context.Salas, "SalaId", "SalaId");
            ViewData["Etapa2"] = new SelectList(_context.Salas, "SalaId", "SalaId");
            ViewData["Turno1Lanchonete"] = new SelectList(_context.Lanchonetes, "LanchoneteId", "LanchoneteId");
            ViewData["Turno2Lanchonete"] = new SelectList(_context.Lanchonetes, "LanchoneteId", "LanchoneteId");
            return View();
        }

        // POST: Matriculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MatriculaId,AlunoId,Etapa1,Etapa2,Turno1Lanchonete,Turno2Lanchonete")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matricula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "AlunoId", "AlunoId", matricula.AlunoId);
            ViewData["Etapa1"] = new SelectList(_context.Salas, "SalaId", "SalaId", matricula.Etapa1);
            ViewData["Etapa2"] = new SelectList(_context.Salas, "SalaId", "SalaId", matricula.Etapa2);
            ViewData["Turno1Lanchonete"] = new SelectList(_context.Lanchonetes, "LanchoneteId", "LanchoneteId", matricula.Turno1Lanchonete);
            ViewData["Turno2Lanchonete"] = new SelectList(_context.Lanchonetes, "LanchoneteId", "LanchoneteId", matricula.Turno2Lanchonete);
            return View(matricula);
        }

        // GET: Matriculas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas.FindAsync(id);
            if (matricula == null)
            {
                return NotFound();
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "AlunoId", "AlunoId", matricula.AlunoId);
            ViewData["Etapa1"] = new SelectList(_context.Salas, "SalaId", "SalaId", matricula.Etapa1);
            ViewData["Etapa2"] = new SelectList(_context.Salas, "SalaId", "SalaId", matricula.Etapa2);
            ViewData["Turno1Lanchonete"] = new SelectList(_context.Lanchonetes, "LanchoneteId", "LanchoneteId", matricula.Turno1Lanchonete);
            ViewData["Turno2Lanchonete"] = new SelectList(_context.Lanchonetes, "LanchoneteId", "LanchoneteId", matricula.Turno2Lanchonete);
            return View(matricula);
        }

        // POST: Matriculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MatriculaId,AlunoId,Etapa1,Etapa2,Turno1Lanchonete,Turno2Lanchonete")] Matricula matricula)
        {
            if (id != matricula.MatriculaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matricula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatriculaExists(matricula.MatriculaId))
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
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "AlunoId", "AlunoId", matricula.AlunoId);
            ViewData["Etapa1"] = new SelectList(_context.Salas, "SalaId", "SalaId", matricula.Etapa1);
            ViewData["Etapa2"] = new SelectList(_context.Salas, "SalaId", "SalaId", matricula.Etapa2);
            ViewData["Turno1Lanchonete"] = new SelectList(_context.Lanchonetes, "LanchoneteId", "LanchoneteId", matricula.Turno1Lanchonete);
            ViewData["Turno2Lanchonete"] = new SelectList(_context.Lanchonetes, "LanchoneteId", "LanchoneteId", matricula.Turno2Lanchonete);
            return View(matricula);
        }

        // GET: Matriculas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas
                .Include(m => m.Aluno)
                .Include(m => m.Etapa1)
                .Include(m => m.Etapa2Navigation)
                .Include(m => m.Turno1LanchoneteNavigation)
                .Include(m => m.Turno2LanchoneteNavigation)
                .FirstOrDefaultAsync(m => m.MatriculaId == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matricula = await _context.Matriculas.FindAsync(id);
            _context.Matriculas.Remove(matricula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatriculaExists(int id)
        {
            return _context.Matriculas.Any(e => e.MatriculaId == id);
        }
    }
}
