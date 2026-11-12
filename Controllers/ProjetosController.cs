using Microsoft.AspNetCore.Mvc;
using Portifolio.Models;
using Portifolio.Data;

namespace Portifolio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetosController : ControllerBase
    {
        private AppDbContext _context;

        public ProjetosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Projetos.ToList());
        }

        [HttpPost]
        public IActionResult Post(Projeto projeto)
        {
            _context.Projetos.Add(projeto);
            _context.SaveChanges();

            return Ok("Projeto criado com sucesso");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Projeto projeto)
        {
            var existente = _context.Projetos.Find(id);

            if (existente == null)
                return NotFound();

            existente.Nome = projeto.Nome;
            existente.Descricao = projeto.Descricao;
            existente.Link = projeto.Link;

            _context.SaveChanges();

            return Ok("Projeto atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var projeto = _context.Projetos.Find(id);

            if (projeto == null)
                return NotFound();

            _context.Projetos.Remove(projeto);
            _context.SaveChanges();

            return Ok("Projeto removido com sucesso");
        }
    }
}