using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace juriAplicacao.Models
{
    public class Requisitos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRequisitos { get; set; }
        public int Texto { get; set; }
        public int PontuacaoMaxima { get; set; }
        public int PontuacaoMinimo{ get; set; }
        public TipoAvalicao TipoAvalicao { get; set; }
        public int IdConcurso { get; set; }
         public Concurso Concurso { get; set; }
        public List<Avalicao> Avalicoes { get; set; }
    }

    public enum TipoAvalicao
    {
        Quantitativa=1,
        Qualitativa=2
    }
}