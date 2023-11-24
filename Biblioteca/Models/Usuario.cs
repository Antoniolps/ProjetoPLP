namespace Biblioteca.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Livro> livrosPosse { get; set; }
    }
}
