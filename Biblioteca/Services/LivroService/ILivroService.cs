using Biblioteca.Models;

namespace Biblioteca.Services.LivroService
{
    public interface ILivroService
    {
        Task<List<Livro>> GetAllAsync();
        Task<Livro?> GetLivroAsync(int id);
    }
}
