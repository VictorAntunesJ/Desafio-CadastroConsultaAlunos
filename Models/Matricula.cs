using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Desaffio.Models
{
    public class Matricula
    {
        [Key]
        public int id { get; set; }
        public int idAluno { get; set; }
        public int idCurso { get; set; }

    }
}