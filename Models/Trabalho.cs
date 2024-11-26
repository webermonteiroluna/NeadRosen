namespace NeadRosen.Models
{
    public class Trabalho
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public List<Secao> Secoes { get; set; } = new List<Secao>();

        public int DisciplinaId { get; set; } // Define a chave estrangeira
        public Disciplina? Disciplina { get; set; }

    }
}
