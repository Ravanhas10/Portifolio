using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portifolio.Models;
using Portifolio.Data;

namespace Portifolio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurmasController : ControllerBase
    {
        private AppDbContext _context;

        public TurmasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Turmas.ToList());
        }

        [HttpPost]
        public IActionResult Post(Turma turma)
        {
            _context.Turmas.Add(turma);
            _context.SaveChanges();

            return Ok("Turma criada com sucesso");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Turma turma)
        {
            var existente = _context.Turmas.Find(id);

            if (existente == null)
                return NotFound();

            existente.Nome = turma.Nome;
            existente.Ano = turma.Ano;

            _context.SaveChanges();

            return Ok("Turma atualizada com sucesso");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var turma = _context.Turmas.Find(id);

            if (turma == null)
                return NotFound();

            _context.Turmas.Remove(turma);
            _context.SaveChanges();

            return Ok("Turma removida com sucesso");
        }
    }
}