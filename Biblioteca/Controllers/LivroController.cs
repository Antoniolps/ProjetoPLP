using Biblioteca.Dtos;
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
            try
            {
                return await _livroservice.GetAllAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivro(int id)
        {
            try
            {
                var result = await _livroservice.GetLivroAsync(id);

                if (result is null)
                    return NotFound("Livro não encontrado");

                return Ok(result);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Livro>> CreateLivro(CreateLivroDto request)
        {
            try
            {
                var result = await _livroservice.CreateLivroAsync(request);

                if (result is null)
                    return BadRequest("O livro já existe.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Livro>> UpdateLivro(int id, bool disponiblidade)
        {
            try
            {
                var result = await _livroservice.UpdateLivroAsync(id, disponiblidade);

                if (result is null)
                    return NotFound("O livro não existe.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteLivro(int id)
        {
            try
            {
                var result = await _livroservice.DeleteLivroAsync(id);

                if (!result)
                    return NotFound("O livro não existe");

                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        

        

        
    }
}
