using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Desaffio.Models
{
    public class Aluno
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string idade { get; set; }
        public string email { get; set; }
             
    }
}
