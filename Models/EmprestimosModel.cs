using System.ComponentModel.DataAnnotations;

namespace EmprestimoDeLivros.Models;

public class EmprestimosModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Digite o recebedor")]
    public string Recebedor { get; set; }

    [Required(ErrorMessage = "Digite o fornecedor")]
    public string Fornecedor { get; set; }

    [Required(ErrorMessage = "Digite o livro emprestado")]
    public string LivroEmprestado { get; set; }
    public DateTime DataUltimaAtualizacao {  get; set; } = DateTime.Now;
}


