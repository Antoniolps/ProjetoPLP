using Biblioteca.Data;
using Biblioteca.Dtos;
using Biblioteca.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task<Livro?> CreateLivroAsync(CreateLivroDto livro)
        {
            var livroExiste = await _context.Livros.Where(l=> l.Titulo.ToUpper() == livro.Titulo.ToUpper() && l.Autor.ToUpper() == livro.Autor.ToUpper()).FirstOrDefaultAsync();

                if (livroExiste != null)
                    return null;

            var novoLivro = new Livro
            {
                Titulo = livro.Titulo,
                Autor = livro.Autor,
                Disponibilidade = true
            };

            _context.Livros.Add(novoLivro);
            await _context.SaveChangesAsync();

            var livroCriado = await _context.Livros
                .Where(l => l.Titulo == novoLivro.Titulo && l.Autor == novoLivro.Autor).FirstAsync();

            return livroCriado;
        }

        public async Task<Livro?> UpdateLivroAsync(int id, bool disponibilidade)
        {
            var livro = await _context.Livros
                .Where(l => l.Id == id)
                .FirstOrDefaultAsync();

            if (livro == null)
                return null;

            livro.Disponibilidade = disponibilidade;
            await _context.SaveChangesAsync();

            return livro;
        }

        public async Task<bool> DeleteLivroAsync(int id)
        {
            var livro = await _context.Livros.FindAsync(id);

            if (livro == null) 
                return false;

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();

            return true;
        }


    }
}
