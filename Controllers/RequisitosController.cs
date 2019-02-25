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
    public class RequisitosController : Controller
    {
        private readonly BdContexto _context;

        public RequisitosController(BdContexto context)
        {
            _context = context;
        }

        // GET: Requisitos
        public async Task<IActionResult> Index()
        {
            var bdContexto = _context.Requisitoss.Include(r => r.Concurso);
            return View(await bdContexto.ToListAsync());
        }

        // GET: Requisitos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisitos = await _context.Requisitoss
                .Include(r => r.Concurso)
                .FirstOrDefaultAsync(m => m.IdRequisitos == id);
            if (requisitos == null)
            {
                return NotFound();
            }

            return View(requisitos);
        }

        // GET: Requisitos/Create
        public IActionResult Create()
        {
            ViewData["IdConcurso"] = new SelectList(_context.Concursos, "IdConcurso", "IdConcurso");
            return View();
        }

        // POST: Requisitos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRequisitos,Texto,PontuacaoMaxima,PontuacaoMinimo,TipoAvalicao,IdConcurso")] Requisitos requisitos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requisitos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdConcurso"] = new SelectList(_context.Concursos, "IdConcurso", "IdConcurso", requisitos.IdConcurso);
            return View(requisitos);
        }

        // GET: Requisitos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisitos = await _context.Requisitoss.FindAsync(id);
            if (requisitos == null)
            {
                return NotFound();
            }
            ViewData["IdConcurso"] = new SelectList(_context.Concursos, "IdConcurso", "IdConcurso", requisitos.IdConcurso);
            return View(requisitos);
        }

        // POST: Requisitos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRequisitos,Texto,PontuacaoMaxima,PontuacaoMinimo,TipoAvalicao,IdConcurso")] Requisitos requisitos)
        {
            if (id != requisitos.IdRequisitos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requisitos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequisitosExists(requisitos.IdRequisitos))
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
            ViewData["IdConcurso"] = new SelectList(_context.Concursos, "IdConcurso", "IdConcurso", requisitos.IdConcurso);
            return View(requisitos);
        }

        // GET: Requisitos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisitos = await _context.Requisitoss
                .Include(r => r.Concurso)
                .FirstOrDefaultAsync(m => m.IdRequisitos == id);
            if (requisitos == null)
            {
                return NotFound();
            }

            return View(requisitos);
        }

        // POST: Requisitos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requisitos = await _context.Requisitoss.FindAsync(id);
            _context.Requisitoss.Remove(requisitos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequisitosExists(int id)
        {
            return _context.Requisitoss.Any(e => e.IdRequisitos == id);
        }
    }
}
