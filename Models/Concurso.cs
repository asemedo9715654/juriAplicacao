using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace juriAplicacao.Models
{
    public class Concurso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdConcurso { get; set; }
        [Display(Name="Título")]
        public string Titulo { get; set; }
          [Display(Name="Descrição")]
        public string Descricao { get; set; }
        public string Obs { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal? PrecoBase { get; set; }
        public List<JuriConcurso> JuriConcursos { get; set; }
        public List<ParticipacaoConcurso> ParticipacaoConcursos { get; set; }
        public List<Requisitos> Requisitos { get; set; }
    }
}