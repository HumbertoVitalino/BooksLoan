using EmprestimoDeLivros.Data;
using EmprestimoDeLivros.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoDeLivros.Controllers;

public class EmprestimoController : Controller
{
    private readonly AppDbContext _context;
    public EmprestimoController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        IEnumerable<EmprestimosModel> emprestimos = _context.Emprestimos;
        return View(emprestimos);
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Cadastrar(EmprestimosModel emprestimos) 
    {
        if (ModelState.IsValid)
        {
            _context.Emprestimos.Add(emprestimos);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        return View();
    }
}
