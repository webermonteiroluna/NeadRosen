using System.ComponentModel.DataAnnotations;

namespace NeadRosen.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }


    }
}
