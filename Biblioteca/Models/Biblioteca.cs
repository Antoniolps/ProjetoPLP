namespace Biblioteca.Models
{
    public class Biblioteca
    {
        public int Id { get; set; }
        public List<Livro> acervo { get; set; }
        public List<Usuario> usuarios { get; set; }
        public List<Emprestimo> emprestimosAtivos { get; set;}
    }
}
