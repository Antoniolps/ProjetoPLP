using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Services.LivroService
{
    public class LivroService : ILivroService
    {
        private readonly DataContext _context;
        public LivroService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Livro>> GetAllAsync()
        {
            return await _context.Livros.ToListAsync();
        }

        public async Task<Livro?> GetLivroAsync(int id)
        {
            return await _context.Livros.Where(l => l.Id == id).FirstOrDefaultAsync();
        }
    }
}
