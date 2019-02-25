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
    public class JurisController : Controller
    {
        private readonly BdContexto _context;

        public JurisController(BdContexto context)
        {
            _context = context;
        }

        // GET: Juris
        public async Task<IActionResult> Index()
        {
            return View(await _context.Juris.ToListAsync());
        }

        // GET: Juris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juri = await _context.Juris
                .FirstOrDefaultAsync(m => m.IdJuri == id);
            if (juri == null)
            {
                return NotFound();
            }

            return View(juri);
        }

        // GET: Juris/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Juris/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdJuri,Nome,Apelido")] Juri juri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(juri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(juri);
        }

        // GET: Juris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juri = await _context.Juris.FindAsync(id);
            if (juri == null)
            {
                return NotFound();
            }
            return View(juri);
        }

        // POST: Juris/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdJuri,Nome,Apelido")] Juri juri)
        {
            if (id != juri.IdJuri)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(juri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JuriExists(juri.IdJuri))
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
            return View(juri);
        }

        // GET: Juris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juri = await _context.Juris
                .FirstOrDefaultAsync(m => m.IdJuri == id);
            if (juri == null)
            {
                return NotFound();
            }

            return View(juri);
        }

        // POST: Juris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var juri = await _context.Juris.FindAsync(id);
            _context.Juris.Remove(juri);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JuriExists(int id)
        {
            return _context.Juris.Any(e => e.IdJuri == id);
        }
    }
}
