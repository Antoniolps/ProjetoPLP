using Biblioteca.Models;
using Biblioteca.Dtos;

namespace Biblioteca.Services.LivroService
{
    public interface ILivroService
    {
        Task<List<Livro>> GetAllAsync();
        Task<Livro?> GetLivroAsync(int id);
        Task<Livro?> CreateLivroAsync(CreateLivroDto livro);
        Task<Livro?> UpdateLivroAsync(int id, bool disponibilidade);
        Task<bool> DeleteLivroAsync(int id);
    }
}
