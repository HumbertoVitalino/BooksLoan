using EmprestimoDeLivros.Models;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoDeLivros.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {        
    }

    public DbSet<EmprestimosModel> Emprestimos { get; set; }
}
