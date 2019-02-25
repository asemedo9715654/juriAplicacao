using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace juriAplicacao.Models
{
    public class BdContexto: DbContext
    {
        public BdContexto(DbContextOptions<BdContexto> options): base(options)
        {

        }

        public DbSet<Avalicao> Avalicoes { get; set; }
        public DbSet<Concorente> Concorentes { get; set; }
        public DbSet<Concurso> Concursos { get; set; }
        public DbSet<Juri> Juris { get; set; }
        public DbSet<JuriConcurso> JuriConcursos { get; set; }
        public DbSet<ParticipacaoConcurso> ParticipacaoConcursos { get; set; }
        public DbSet<Requisitos> Requisitoss { get; set; }

        

    }
}