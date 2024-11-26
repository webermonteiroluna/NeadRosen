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
    public class TrabalhoController : Controller
    {
        private readonly NeadTestContext _context;

        public TrabalhoController(NeadTestContext context)
        {
            _context = context;
        }

        // GET: Trabalhos
        public async Task<IActionResult> Index()
        {
            var trabalhos = await _context.Trabalhos
             .Include(t => t.Disciplina) // Inclui a disciplina
             .Include(t => t.Secoes)    // Inclui as seções
             .ToListAsync();
            return View(trabalhos);
        }

        // GET: Trabalhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Retorna a pagina 404 (NotFound)
            }

            var trabalho = await _context.Trabalhos.Include(a => a.Secoes).FirstOrDefaultAsync(a => a.Id == id);
            if (trabalho == null)
            {
                return NotFound(); // Retorna a pagina 404 (NotFound)
            }

            return View(trabalho);
        }

        //Metodo -> GET: Trabalho/Create
        [HttpGet("Trabalho/Create")]
        public IActionResult Create()
        {
            var secoes = _context.Secoes.Select(d => new { d.Id, d.Conteudo }).ToList();
            ViewBag.Secoes = secoes;

            var disciplinas = _context.Disciplinas.Select(d => new { d.Id, d.Nome }).ToList();
            ViewBag.Disciplinas = new SelectList(disciplinas, "Id", "Nome");

            return View();

        }

        //Metodo -> POST: Aluno/Create
        [HttpPost("Trabalho/Create/{id?}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Trabalho trabalho, int[] SecoesItens, int DisciplinaId)
        {
            if (ModelState.IsValid)
            {
                // Associa a disciplina ao trabalho
                var disciplina = await _context.Disciplinas.FindAsync(DisciplinaId);
                if (disciplina != null)
                {
                    trabalho.DisciplinaId = disciplina.Id;
                    trabalho.Disciplina = disciplina;
                }

                _context.Trabalhos.Add(trabalho);
                await _context.SaveChangesAsync();

                // Associar as seções selecionadas
                if (SecoesItens != null && SecoesItens.Any())
                {
                    var secoes = _context.Secoes
                        .Where(d => SecoesItens.Contains(d.Id))
                        .ToList();

                    trabalho.Secoes = secoes;
                    _context.Update(trabalho);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Secoes = new SelectList(_context.Secoes, "Id", "Titulo", "Conteudo");
            ViewBag.Disciplinas = new SelectList(_context.Disciplinas, "Id", "Nome");
            return View(trabalho);
        }

        // GET: Trabalhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabalho = await _context.Trabalhos.FindAsync(id);
            if (trabalho == null)
            {
                return NotFound();
            }
            return View(trabalho);
        }

        // POST: Trabalhos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo")] Trabalho trabalho)
        {
            if (id != trabalho.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trabalho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrabalhoExists(trabalho.Id))
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
            return View(trabalho);
        }

        // GET: Trabalhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabalho = await _context.Trabalhos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trabalho == null)
            {
                return NotFound();
            }

            return View(trabalho);
        }

        // POST: Trabalhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trabalho = await _context.Trabalhos.FindAsync(id);
            if (trabalho != null)
            {
                _context.Trabalhos.Remove(trabalho);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrabalhoExists(int id)
        {
            return _context.Trabalhos.Any(e => e.Id == id);
        }
    }
}