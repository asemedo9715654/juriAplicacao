using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace juriAplicacao.Models
{
    public class ParticipacaoConcurso
    {
         [Key]
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int IdParticipacaoConcurso { get; set; }
        public string Obs { get; set; }
        public bool PropostaVencedora { get; set; }
        public decimal? Preco { get; set; }
        public int AvalicaoObtida { get; set; }
        public EstadoConcurso Estado { get; set; } = EstadoConcurso.Inicio;
        //navegation proprietes
        public int IdConcurso { get; set; }
         public int IdConcorente { get; set; }
        public Concurso Concurso { get; set; }
         public Concorente Concorente { get; set; }
    }

    public enum EstadoConcurso
    {
        Inicio=1,
        AbertoPropostaTecnica=2,
        AbertoPropostaFinanceira=3,
        Finalizado=4,
        EmEspera=5,
        Cancelado =6
    }
}