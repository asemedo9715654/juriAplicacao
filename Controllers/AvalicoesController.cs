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
    public class AvalicoesController : Controller
    {
        private readonly BdContexto _context;

        public AvalicoesController(BdContexto context)
        {
            _context = context;
        }

        // GET: Avalicoes
        public async Task<IActionResult> Index()
        {
            var bdContexto = _context.Avalicoes.Include(a => a.Requisitos);
            return View(await bdContexto.ToListAsync());
        }

        // GET: Avalicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avalicao = await _context.Avalicoes
                .Include(a => a.Requisitos)
                .FirstOrDefaultAsync(m => m.IdAvalicao == id);
            if (avalicao == null)
            {
                return NotFound();
            }

            return View(avalicao);
        }

        // GET: Avalicoes/Create
        public IActionResult Create()
        {
            ViewData["IdRequisitos"] = new SelectList(_context.Requisitoss, "IdRequisitos", "IdRequisitos");
            return View();
        }

        // POST: Avalicoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAvalicao,Avalicaoatribuida,Obs,IdRequisitos")] Avalicao avalicao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avalicao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRequisitos"] = new SelectList(_context.Requisitoss, "IdRequisitos", "IdRequisitos", avalicao.IdRequisitos);
            return View(avalicao);
        }

        // GET: Avalicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avalicao = await _context.Avalicoes.FindAsync(id);
            if (avalicao == null)
            {
                return NotFound();
            }
            ViewData["IdRequisitos"] = new SelectList(_context.Requisitoss, "IdRequisitos", "IdRequisitos", avalicao.IdRequisitos);
            return View(avalicao);
        }

        // POST: Avalicoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAvalicao,Avalicaoatribuida,Obs,IdRequisitos")] Avalicao avalicao)
        {
            if (id != avalicao.IdAvalicao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avalicao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvalicaoExists(avalicao.IdAvalicao))
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
            ViewData["IdRequisitos"] = new SelectList(_context.Requisitoss, "IdRequisitos", "IdRequisitos", avalicao.IdRequisitos);
            return View(avalicao);
        }

        // GET: Avalicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avalicao = await _context.Avalicoes
                .Include(a => a.Requisitos)
                .FirstOrDefaultAsync(m => m.IdAvalicao == id);
            if (avalicao == null)
            {
                return NotFound();
            }

            return View(avalicao);
        }

        // POST: Avalicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var avalicao = await _context.Avalicoes.FindAsync(id);
            _context.Avalicoes.Remove(avalicao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvalicaoExists(int id)
        {
            return _context.Avalicoes.Any(e => e.IdAvalicao == id);
        }
    }
}
