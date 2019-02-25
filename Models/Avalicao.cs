using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace juriAplicacao.Models
{
    public class Avalicao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAvalicao { get; set; }
        public int Avalicaoatribuida { get; set; }
        public string Obs { get; set; }
         public int IdRequisitos { get; set; }
        public Requisitos Requisitos { get; set; }

    }
}