using Microsoft.EntityFrameworkCore;
using NeadRosen.Models;

namespace NeadRosen.Data
{
    public class NeadTestContext : DbContext
    {
        public NeadTestContext(DbContextOptions<NeadTestContext> options) : base(options)
        {
        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Periodo> Periodos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Secao> Secoes { get; set; }
        public DbSet<Trabalho> Trabalhos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Secao>().HasData(
            //    new Secao { Id = 1, Titulo = "TCC", Conteudo = "Um TCC" },
            //    new Secao { Id = 2, Titulo = "Artigo", Conteudo = "Um Artigo" }
            //    );
            //modelBuilder.Entity<Trabalho>().HasData(
            //    new Trabalho { Id = 1, Titulo = "Webao"   },
            //    new Trabalho { Id = 2, Titulo = "Narigudo"  } 
            //    );
        }
    }
}

