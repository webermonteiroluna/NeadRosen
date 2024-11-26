namespace NeadRosen.Models
{
    public class Periodo
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Sala { get; set; }
        public List<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();
        public Curso Curso { get; set; }
    }

}
