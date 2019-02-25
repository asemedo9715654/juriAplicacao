using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using juriAplicacao.Models;

namespace juriAplicacao.Controllers
{
    public class JuriConcursosController : Controller
    {
        private readonly BdContexto _context;

        public JuriConcursosController(BdContexto context)
        {
            _context = context;
        }

        // GET: JuriConcursos
        public async Task<IActionResult> Index()
        {
            var bdContexto = _context.JuriConcursos.Include(j => j.Concurso).Include(j => j.Juri);
            return View(await bdContexto.ToListAsync());
        }

        // GET: JuriConcursos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juriConcurso = await _context.JuriConcursos
                .Include(j => j.Concurso)
                .Include(j => j.Juri)
                .FirstOrDefaultAsync(m => m.IdJuriConcurso == id);
            if (juriConcurso == null)
            {
                return NotFound();
            }

            return View(juriConcurso);
        }

        // GET: JuriConcursos/Create
        public IActionResult Create()
        {
            ViewData["IdConcurso"] = new SelectList(_context.Concursos, "IdConcurso", "IdConcurso");
            ViewData["IdJuri"] = new SelectList(_context.Juris, "IdJuri", "IdJuri");
            return View();
        }

        // POST: JuriConcursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdJuriConcurso,IdJuri,IdConcurso")] JuriConcurso juriConcurso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(juriConcurso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdConcurso"] = new SelectList(_context.Concursos, "IdConcurso", "IdConcurso", juriConcurso.IdConcurso);
            ViewData["IdJuri"] = new SelectList(_context.Juris, "IdJuri", "IdJuri", juriConcurso.IdJuri);
            return View(juriConcurso);
        }

        // GET: JuriConcursos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juriConcurso = await _context.JuriConcursos.FindAsync(id);
            if (juriConcurso == null)
            {
                return NotFound();
            }
            ViewData["IdConcurso"] = new SelectList(_context.Concursos, "IdConcurso", "IdConcurso", juriConcurso.IdConcurso);
            ViewData["IdJuri"] = new SelectList(_context.Juris, "IdJuri", "IdJuri", juriConcurso.IdJuri);
            return View(juriConcurso);
        }

        // POST: JuriConcursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdJuriConcurso,IdJuri,IdConcurso")] JuriConcurso juriConcurso)
        {
            if (id != juriConcurso.IdJuriConcurso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(juriConcurso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JuriConcursoExists(juriConcurso.IdJuriConcurso))
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
            ViewData["IdConcurso"] = new SelectList(_context.Concursos, "IdConcurso", "IdConcurso", juriConcurso.IdConcurso);
            ViewData["IdJuri"] = new SelectList(_context.Juris, "IdJuri", "IdJuri", juriConcurso.IdJuri);
            return View(juriConcurso);
        }

        // GET: JuriConcursos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juriConcurso = await _context.JuriConcursos
                .Include(j => j.Concurso)
                .Include(j => j.Juri)
                .FirstOrDefaultAsync(m => m.IdJuriConcurso == id);
            if (juriConcurso == null)
            {
                return NotFound();
            }

            return View(juriConcurso);
        }

        // POST: JuriConcursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var juriConcurso = await _context.JuriConcursos.FindAsync(id);
            _context.JuriConcursos.Remove(juriConcurso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JuriConcursoExists(int id)
        {
            return _context.JuriConcursos.Any(e => e.IdJuriConcurso == id);
        }
    }
}
