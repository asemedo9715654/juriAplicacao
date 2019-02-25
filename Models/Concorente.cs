using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace juriAplicacao.Models
{
    public class Concorente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdConcorente { get; set; }
        public string Nome { get; set; }
          public string Nome2 { get; set; }
        public string Contacto { get; set; }
        public string Morada { get; set; }
        public List<ParticipacaoConcurso> ParticipacaoConcursos { get; set; }
    }
}