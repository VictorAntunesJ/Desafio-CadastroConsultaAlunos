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
    public class CursoController : ControllerBase
    {
        private readonly ConsultaContext _context;

        public CursoController(ConsultaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            _context.Add(curso);
            _context.SaveChanges();
            return Ok(curso);
        }

        [HttpGet("ObterCurso/{id}")]
        public IActionResult ObterCodigo(int id)
        {
            var curso = _context.Cursos.Find(id);
            if(curso == null)
                return NotFound();

            return Ok(curso);
        }

       

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var CursoBanco = _context.Cursos.Find(id);
            if(CursoBanco == null)

                return NotFound();

                _context.Cursos.Remove(CursoBanco);
                _context.SaveChanges();
                return NoContent();
        }
    }
}
