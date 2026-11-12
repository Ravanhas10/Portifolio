using Microsoft.EntityFrameworkCore;
using Portifolio.Models;

namespace Portifolio.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options)
        {
        }

        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
    }
}
