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
    public class ParticipacaoConcursosController : Controller
    {
        private readonly BdContexto _context;

        public ParticipacaoConcursosController(BdContexto context)
        {
            _context = context;
        }

        // GET: ParticipacaoConcursos
        public async Task<IActionResult> Index()
        {
            var bdContexto = _context.ParticipacaoConcursos.Include(p => p.Concorente).Include(p => p.Concurso);
            return View(await bdContexto.ToListAsync());
        }

        // GET: ParticipacaoConcursos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participacaoConcurso = await _context.ParticipacaoConcursos
                .Include(p => p.Concorente)
                .Include(p => p.Concurso)
                .FirstOrDefaultAsync(m => m.IdParticipacaoConcurso == id);
            if (participacaoConcurso == null)
            {
                return NotFound();
            }

            return View(participacaoConcurso);
        }

        // GET: ParticipacaoConcursos/Create
        public IActionResult Create()
        {
            ViewData["IdConcorente"] = new SelectList(_context.Concorentes, "IdConcorente", "IdConcorente");
            ViewData["IdConcurso"] = new SelectList(_context.Concursos, "IdConcurso", "IdConcurso");
            return View();
        }

        // POST: ParticipacaoConcursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdParticipacaoConcurso,Obs,PropostaVencedora,Preco,AvalicaoObtida,Estado,IdConcurso,IdConcorente")] ParticipacaoConcurso participacaoConcurso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(participacaoConcurso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdConcorente"] = new SelectList(_context.Concorentes, "IdConcorente", "IdConcorente", participacaoConcurso.IdConcorente);
            ViewData["IdConcurso"] = new SelectList(_context.Concursos, "IdConcurso", "IdConcurso", participacaoConcurso.IdConcurso);
            return View(participacaoConcurso);
        }

        // GET: ParticipacaoConcursos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participacaoConcurso = await _context.ParticipacaoConcursos.FindAsync(id);
            if (participacaoConcurso == null)
            {
                return NotFound();
            }
            ViewData["IdConcorente"] = new SelectList(_context.Concorentes, "IdConcorente", "IdConcorente", participacaoConcurso.IdConcorente);
            ViewData["IdConcurso"] = new SelectList(_context.Concursos, "IdConcurso", "IdConcurso", participacaoConcurso.IdConcurso);
            return View(participacaoConcurso);
        }

        // POST: ParticipacaoConcursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdParticipacaoConcurso,Obs,PropostaVencedora,Preco,AvalicaoObtida,Estado,IdConcurso,IdConcorente")] ParticipacaoConcurso participacaoConcurso)
        {
            if (id != participacaoConcurso.IdParticipacaoConcurso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participacaoConcurso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipacaoConcursoExists(participacaoConcurso.IdParticipacaoConcurso))
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
            ViewData["IdConcorente"] = new SelectList(_context.Concorentes, "IdConcorente", "IdConcorente", participacaoConcurso.IdConcorente);
            ViewData["IdConcurso"] = new SelectList(_context.Concursos, "IdConcurso", "IdConcurso", participacaoConcurso.IdConcurso);
            return View(participacaoConcurso);
        }

        // GET: ParticipacaoConcursos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participacaoConcurso = await _context.ParticipacaoConcursos
                .Include(p => p.Concorente)
                .Include(p => p.Concurso)
                .FirstOrDefaultAsync(m => m.IdParticipacaoConcurso == id);
            if (participacaoConcurso == null)
            {
                return NotFound();
            }

            return View(participacaoConcurso);
        }

        // POST: ParticipacaoConcursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var participacaoConcurso = await _context.ParticipacaoConcursos.FindAsync(id);
            _context.ParticipacaoConcursos.Remove(participacaoConcurso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticipacaoConcursoExists(int id)
        {
            return _context.ParticipacaoConcursos.Any(e => e.IdParticipacaoConcurso == id);
        }
    }
}
