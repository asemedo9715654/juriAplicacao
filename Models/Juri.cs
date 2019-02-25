using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace juriAplicacao.Models
{
    public class Juri
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdJuri { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public List<JuriConcurso> JuriConcursos { get; set; }
    }
}