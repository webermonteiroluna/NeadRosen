namespace NeadRosen.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        //public List<Trabalho> Trabalhos { get; set; } = new List<Trabalho>();

        public List<Trabalho> Trabalhos { get; set; } = new List<Trabalho>();
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();


    }

}
