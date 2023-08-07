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
    public class MatriculaController : ControllerBase
    {
        private readonly ConsultaContext _context;

        public MatriculaController(ConsultaContext context)
        {
            _context = context;
        }

        [HttpGet("ObterAlunosCurso/{idCurso}")]
        public IActionResult ObterAlunosCurso(int idCurso)
        {
            var retorno = new List<Aluno>();
            var matricula = _context.Matriculas.Where(m => m.idCurso == idCurso).ToList();
            if (matricula == null)
            {
                return NotFound();
            }
            else if (matricula.Count > 0)
            {
                foreach (var m in matricula)
                {
                    var aluno = _context.Alunos.Find(m.idAluno);
                    if (aluno != null)
                    {
                        retorno.Add(aluno);
                    }
                }
            }
            return Ok(retorno);
        }

         [HttpPut("AtualizarAluno/{Id}")]
        public IActionResult AtualizarAluno(int Id, Aluno aluno)
        {
            var AlunoBanco = _context.Alunos.Find(Id);
            if (AlunoBanco == null)
                return NotFound();

            AlunoBanco.nome = aluno.nome;
            AlunoBanco.idade = aluno.idade;
            AlunoBanco.email = aluno.email;

            _context.Alunos.Update(AlunoBanco);
            _context.SaveChanges();

            return Ok(AlunoBanco);
        }

         [HttpPut("AtualizarCurso/{id}")]
        public IActionResult AtualizarCurso(int id, Curso curso)
        {
            var CursoBanco = _context.Cursos.Find(id);
            if(CursoBanco == null)
                return NotFound();

                CursoBanco.nomeCurso = curso.nomeCurso;

                _context.Cursos.Update(CursoBanco);
                _context.SaveChanges();

                return Ok(CursoBanco);
        }
    }
}

