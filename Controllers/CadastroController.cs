using System.Diagnostics;
using cruudd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cruudd.Controllers
{
    // CadastroController: Classe que controla as rotas ligadas ao cadastro.
    // : Controller: Classe "pai" do ASP.NET Core que oferece recursos para trabalhar com Views, HTTP e redirecionamentos.
    public class CadastroController : Controller
    {
        // AppDbContext: classe que representa o banco de dados.
        // _context: variável que vai armazenar a conexão com o banco e permitir manipular os dados.
        private readonly AppDbContext _context;


        // Construtor do Controller: recebe o AppDbContext pronto (injeção de dependência).
        // "context": variável local que chega pronta do ASP.NET com o banco configurado.
        public CadastroController(AppDbContext context)
        {
            // Guarda o AppDbContext recebido no campo privado _context.
            _context = context;
        }

        // Action Index: retorna a lista de cadastros.
        // IActionResult: tipo de retorno que pode ser uma View, JSON, erro, etc.
        public async Task<IActionResult> Index()
        {
            // _context.Cadastros: representa a tabela "Cadastros" no banco.
            // ToListAsync(): busca todos os registros e transforma em uma lista.
            var cadastros = await _context.Cadastros.ToListAsync();

            // Retorna a View Index.cshtml passando a lista (cadastros) como modelo.
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
