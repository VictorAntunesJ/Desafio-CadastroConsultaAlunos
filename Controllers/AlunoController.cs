using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desaffio.Context;
using Desaffio.Models;
using Microsoft.AspNetCore.Mvc;

namespace Desaffio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly ConsultaContext _context;

        public AlunoController(ConsultaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpGet("ObterAluno/{Id}")]
        public IActionResult ObterMatricula(int Id)
        {
            var aluno = _context.Alunos.Find(Id);
            if (aluno == null)
                return NotFound();

            return Ok(aluno);
        }

       

        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            var AlunoBanco = _context.Alunos.Find(Id);

            if (AlunoBanco == null)

                return NotFound();

            _context.Alunos.Remove(AlunoBanco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
