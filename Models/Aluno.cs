namespace NeadRosen.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Matricula { get; set; }
        public List<Periodo> PeriodosRealizados { get; set; } = new List<Periodo>();
    }
}
