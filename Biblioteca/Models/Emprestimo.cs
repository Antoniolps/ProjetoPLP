namespace Biblioteca.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public Livro livro { get; set; }
        public Usuario usuario { get; set;}
        public DateTime dataEmprestimo { get; set; }
        public DateTime dataDevolucao { get; set; }
    }
}
