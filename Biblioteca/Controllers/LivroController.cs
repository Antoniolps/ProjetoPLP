using Biblioteca.Models;
using Biblioteca.Services.LivroService;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _livroservice;

        public LivroController(ILivroService livroservice)
        {
            _livroservice = livroservice;
        }

        [HttpGet]
        public async Task<ActionResult<List<Livro>>> GetLivros()
        {
            return await _livroservice.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivro(int id)
        {
            var result = await _livroservice.GetLivroAsync(id);

            if(result is null)
                return NotFound("Livro não encontrado");

            return Ok(result);
        }
        

        
    }
}
