using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portifolio.Models;
using Portifolio.Data;

namespace Portifolio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : ControllerBase
    {
        private AppDbContext _context;

        public AlunosController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos.ToList());
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();

            return Ok("Aluno criado com sucesso");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var existente = _context.Alunos.Find(id);

            if (existente == null)
                return NotFound();

            existente.Nome = aluno.Nome;
            existente.Email = aluno.Email;
            existente.TurmaId = aluno.TurmaId;

            _context.SaveChanges();

            return Ok("Aluno atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.Find(id);

            if (aluno == null)
                return NotFound();

            _context.Alunos.Remove(aluno);
            _context.SaveChanges();

            return Ok("Aluno removido com sucesso");
        }
    }
}