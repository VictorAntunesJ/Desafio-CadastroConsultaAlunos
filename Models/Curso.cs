using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Desaffio.Models
{
    public class Curso
    {
        [Key]
        public int id { get; set; }
        public string nomeCurso {get; set;}
    }
}