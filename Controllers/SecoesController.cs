using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NeadRosen.Data;
using NeadRosen.Models;

namespace NeadRosen.Controllers
{
    public class SecoesController : Controller
    {
        private readonly NeadTestContext _context;

        public SecoesController(NeadTestContext context)
        {
            _context = context;
        }

        // GET: Secoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Secoes.ToListAsync());
        }

        // GET: Secoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secao = await _context.Secoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (secao == null)
            {
                return NotFound();
            }

            return View(secao);
        }

        // GET: Secoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Secoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Conteudo")] Secao secao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(secao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(secao);
        }

        // GET: Secoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secao = await _context.Secoes.FindAsync(id);
            if (secao == null)
            {
                return NotFound();
            }
            return View(secao);
        }

        // POST: Secoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Conteudo")] Secao secao)
        {
            if (id != secao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(secao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SecaoExists(secao.Id))
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
            return View(secao);
        }

        // GET: Secoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secao = await _context.Secoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (secao == null)
            {
                return NotFound();
            }

            return View(secao);
        }

        // POST: Secoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var secao = await _context.Secoes.FindAsync(id);
            if (secao != null)
            {
                _context.Secoes.Remove(secao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SecaoExists(int id)
        {
            return _context.Secoes.Any(e => e.Id == id);
        }
    }
}
