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
    public class ConcursosController : Controller
    {
        private readonly BdContexto _context;

        public ConcursosController(BdContexto context)
        {
            _context = context;
        }

        // GET: Concursos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Concursos.ToListAsync());
        }

        // GET: Concursos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concurso = await _context.Concursos
                .FirstOrDefaultAsync(m => m.IdConcurso == id);
            if (concurso == null)
            {
                return NotFound();
            }

            return View(concurso);
        }

        // GET: Concursos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Concursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConcurso,Titulo,Descricao,Obs,DataInicio,DataFim,PrecoBase")] Concurso concurso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(concurso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(concurso);
        }

        // GET: Concursos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concurso = await _context.Concursos.FindAsync(id);
            if (concurso == null)
            {
                return NotFound();
            }
            return View(concurso);
        }

        // POST: Concursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConcurso,Titulo,Descricao,Obs,DataInicio,DataFim,PrecoBase")] Concurso concurso)
        {
            if (id != concurso.IdConcurso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(concurso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConcursoExists(concurso.IdConcurso))
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
            return View(concurso);
        }

        // GET: Concursos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concurso = await _context.Concursos
                .FirstOrDefaultAsync(m => m.IdConcurso == id);
            if (concurso == null)
            {
                return NotFound();
            }

            return View(concurso);
        }

        // POST: Concursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var concurso = await _context.Concursos.FindAsync(id);
            _context.Concursos.Remove(concurso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConcursoExists(int id)
        {
            return _context.Concursos.Any(e => e.IdConcurso == id);
        }
    }
}
