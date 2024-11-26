namespace NeadRosen.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public List<Disciplina> DisciplinasRevisadas { get; set; } = new List<Disciplina>();
    }
}
