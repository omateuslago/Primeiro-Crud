using System.Diagnostics;
using cruudd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cruudd.Controllers
{
    public class CadastroController : Controller
    {
        private readonly AppDbContext _context;

        public CadastroController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cadastros = await _context.Cadastros.ToListAsync();
            return View(cadastros);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastro);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var cadastro = await _context.Cadastros.FindAsync(id);
            if (cadastro == null) return NotFound();
            return View(cadastro);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Cadastro cadastro)
        {
            if (id != cadastro.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(cadastro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastro);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var cadastro = await _context.Cadastros.FindAsync(id);
            if (cadastro == null) return NotFound();
            return View(cadastro);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastro = await _context.Cadastros.FindAsync(id);
            _context.Cadastros.Remove(cadastro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
