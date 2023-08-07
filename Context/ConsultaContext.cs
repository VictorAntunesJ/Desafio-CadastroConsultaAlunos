using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desaffio.Models;
using Microsoft.EntityFrameworkCore;

namespace Desaffio.Context
{
    public class ConsultaContext : DbContext
    {
        public ConsultaContext(DbContextOptions<ConsultaContext>options) :base(options)
        {

        }

        public DbSet<Aluno> Alunos {get; set;} 
        public DbSet<Curso> Cursos {get; set;}  
        public DbSet<Matricula> Matriculas {get;set;}
    }
}