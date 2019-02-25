using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace juriAplicacao.Models
{
    public class JuriConcurso
    {
         [Key]
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdJuriConcurso { get; set; }
        public int IdJuri { get; set; }
        public int IdConcurso { get; set; }
        public Juri Juri { get; set; }
        public Concurso Concurso { get; set; }
    }
}