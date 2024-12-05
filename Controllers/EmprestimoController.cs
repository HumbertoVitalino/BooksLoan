using ClosedXML.Excel;
using EmprestimoDeLivros.Data;
using EmprestimoDeLivros.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EmprestimoDeLivros.Controllers;

public class EmprestimoController : Controller
{
    private readonly AppDbContext _context;
    public EmprestimoController(AppDbContext context)
    {
        _context = context;
    }

    private DataTable GetDados()
    {
        DataTable dataTable = new DataTable();

        dataTable.TableName = "Dados empréstimos";

        dataTable.Columns.Add("Recebedor", typeof(string));
        dataTable.Columns.Add("Fornecedor", typeof(string));
        dataTable.Columns.Add("Livro", typeof(string));
        dataTable.Columns.Add("Data De Emprestimo", typeof(DateTime));

        var dados = _context.Emprestimos.ToList();

        if (dados.Count > 0)
        {
            dados.ForEach(emprestimo =>
            {
                dataTable.Rows.Add(emprestimo.Recebedor);
                dataTable.Rows.Add(emprestimo.Fornecedor);
                dataTable.Rows.Add(emprestimo.LivroEmprestado);
                dataTable.Rows.Add(emprestimo.DataUltimaAtualizacao);
            });
        }
        return dataTable;
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

    [HttpGet]
    public IActionResult Editar(int? id)
    {
        if(id == null || id == 0)
        {
            return NotFound();
        }

        EmprestimosModel emprestimo = _context.Emprestimos.FirstOrDefault(x => x.Id == id);

        if(emprestimo == null)
        {
            return NotFound();
        }

        return View(emprestimo);
    }

    [HttpGet]
    public IActionResult Excluir(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        EmprestimosModel emprestimo = _context.Emprestimos.FirstOrDefault(x => x.Id == id);

        if (emprestimo == null)
        {
            return NotFound();
        }

        return View(emprestimo);
    }

    [HttpGet]
    public IActionResult Exportar()
    {
        var dados = GetDados();

        using (XLWorkbook workBook = new XLWorkbook())
        {
            workBook.AddWorksheet(dados, "Dados Empréstimos");

            using (MemoryStream ms = new MemoryStream())
            {
                workBook.SaveAs(ms);
                return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Emprestimo.xls");
            }
        }
    }


    [HttpPost]
    public IActionResult Cadastrar(EmprestimosModel emprestimos) 
    {
        if (ModelState.IsValid)
        {
            _context.Emprestimos.Add(emprestimos);
            _context.SaveChanges();

            TempData["MensagemSucesso"] = "Cadastro realizado com sucesso";

            return RedirectToAction("Index");
        }

        return View();
    }

    [HttpPost]
    public IActionResult Editar(EmprestimosModel emprestimo)
    {
        if(ModelState.IsValid)
        {
            _context.Emprestimos.Update(emprestimo);
            _context.SaveChanges();

            TempData["MensagemSucesso"] = "Edição realizado com sucesso";

            return RedirectToAction("Index");
        }

        return View();
    }

    [HttpPost]
    public IActionResult Excluir(EmprestimosModel emprestimo)
    {
        if(emprestimo == null)
        {
            return NotFound();
        }

        _context.Emprestimos.Remove(emprestimo);
        _context.SaveChanges();

        TempData["MensagemSucesso"] = "Remoção realizada com sucesso";
        return RedirectToAction("Index");

    }
}
