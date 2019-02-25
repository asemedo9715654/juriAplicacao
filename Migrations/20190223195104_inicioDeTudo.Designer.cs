﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using juriAplicacao.Models;

namespace juriAplicacao.Migrations
{
    [DbContext(typeof(BdContexto))]
    [Migration("20190223195104_inicioDeTudo")]
    partial class inicioDeTudo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity("juriAplicacao.Models.Avalicao", b =>
                {
                    b.Property<int>("IdAvalicao")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Avalicaoatribuida");

                    b.Property<int>("IdRequisitos");

                    b.Property<string>("Obs");

                    b.HasKey("IdAvalicao");

                    b.HasIndex("IdRequisitos");

                    b.ToTable("Avalicoes");
                });

            modelBuilder.Entity("juriAplicacao.Models.Concorente", b =>
                {
                    b.Property<int>("IdConcorente")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Contacto");

                    b.Property<string>("Morada");

                    b.Property<string>("Nome");

                    b.Property<string>("Nome2");

                    b.HasKey("IdConcorente");

                    b.ToTable("Concorentes");
                });

            modelBuilder.Entity("juriAplicacao.Models.Concurso", b =>
                {
                    b.Property<int>("IdConcurso")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataFim");

                    b.Property<DateTime>("DataInicio");

                    b.Property<string>("Descricao");

                    b.Property<string>("Obs");

                    b.Property<decimal?>("PrecoBase");

                    b.Property<string>("Titulo");

                    b.HasKey("IdConcurso");

                    b.ToTable("Concursos");
                });

            modelBuilder.Entity("juriAplicacao.Models.Juri", b =>
                {
                    b.Property<int>("IdJuri")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apelido");

                    b.Property<string>("Nome");

                    b.HasKey("IdJuri");

                    b.ToTable("Juris");
                });

            modelBuilder.Entity("juriAplicacao.Models.JuriConcurso", b =>
                {
                    b.Property<int>("IdJuriConcurso")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdConcurso");

                    b.Property<int>("IdJuri");

                    b.HasKey("IdJuriConcurso");

                    b.HasIndex("IdConcurso");

                    b.HasIndex("IdJuri");

                    b.ToTable("JuriConcursos");
                });

            modelBuilder.Entity("juriAplicacao.Models.ParticipacaoConcurso", b =>
                {
                    b.Property<int>("IdParticipacaoConcurso")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AvalicaoObtida");

                    b.Property<int>("Estado");

                    b.Property<int>("IdConcorente");

                    b.Property<int>("IdConcurso");

                    b.Property<string>("Obs");

                    b.Property<decimal?>("Preco");

                    b.Property<bool>("PropostaVencedora");

                    b.HasKey("IdParticipacaoConcurso");

                    b.HasIndex("IdConcorente");

                    b.HasIndex("IdConcurso");

                    b.ToTable("ParticipacaoConcursos");
                });

            modelBuilder.Entity("juriAplicacao.Models.Requisitos", b =>
                {
                    b.Property<int>("IdRequisitos")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdConcurso");

                    b.Property<int>("PontuacaoMaxima");

                    b.Property<int>("PontuacaoMinimo");

                    b.Property<int>("Texto");

                    b.Property<int>("TipoAvalicao");

                    b.HasKey("IdRequisitos");

                    b.HasIndex("IdConcurso");

                    b.ToTable("Requisitoss");
                });

            modelBuilder.Entity("juriAplicacao.Models.Avalicao", b =>
                {
                    b.HasOne("juriAplicacao.Models.Requisitos", "Requisitos")
                        .WithMany("Avalicoes")
                        .HasForeignKey("IdRequisitos")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("juriAplicacao.Models.JuriConcurso", b =>
                {
                    b.HasOne("juriAplicacao.Models.Concurso", "Concurso")
                        .WithMany("JuriConcursos")
                        .HasForeignKey("IdConcurso")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("juriAplicacao.Models.Juri", "Juri")
                        .WithMany("JuriConcursos")
                        .HasForeignKey("IdJuri")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("juriAplicacao.Models.ParticipacaoConcurso", b =>
                {
                    b.HasOne("juriAplicacao.Models.Concorente", "Concorente")
                        .WithMany("ParticipacaoConcursos")
                        .HasForeignKey("IdConcorente")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("juriAplicacao.Models.Concurso", "Concurso")
                        .WithMany("ParticipacaoConcursos")
                        .HasForeignKey("IdConcurso")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("juriAplicacao.Models.Requisitos", b =>
                {
                    b.HasOne("juriAplicacao.Models.Concurso", "Concurso")
                        .WithMany("Requisitos")
                        .HasForeignKey("IdConcurso")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}