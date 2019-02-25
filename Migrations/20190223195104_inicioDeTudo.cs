using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace juriAplicacao.Migrations
{
    public partial class inicioDeTudo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Concorentes",
                columns: table => new
                {
                    IdConcorente = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Nome2 = table.Column<string>(nullable: true),
                    Contacto = table.Column<string>(nullable: true),
                    Morada = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concorentes", x => x.IdConcorente);
                });

            migrationBuilder.CreateTable(
                name: "Concursos",
                columns: table => new
                {
                    IdConcurso = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Obs = table.Column<string>(nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false),
                    PrecoBase = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concursos", x => x.IdConcurso);
                });

            migrationBuilder.CreateTable(
                name: "Juris",
                columns: table => new
                {
                    IdJuri = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Apelido = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Juris", x => x.IdJuri);
                });

            migrationBuilder.CreateTable(
                name: "ParticipacaoConcursos",
                columns: table => new
                {
                    IdParticipacaoConcurso = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Obs = table.Column<string>(nullable: true),
                    PropostaVencedora = table.Column<bool>(nullable: false),
                    Preco = table.Column<decimal>(nullable: true),
                    AvalicaoObtida = table.Column<int>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    IdConcurso = table.Column<int>(nullable: false),
                    IdConcorente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipacaoConcursos", x => x.IdParticipacaoConcurso);
                    table.ForeignKey(
                        name: "FK_ParticipacaoConcursos_Concorentes_IdConcorente",
                        column: x => x.IdConcorente,
                        principalTable: "Concorentes",
                        principalColumn: "IdConcorente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipacaoConcursos_Concursos_IdConcurso",
                        column: x => x.IdConcurso,
                        principalTable: "Concursos",
                        principalColumn: "IdConcurso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requisitoss",
                columns: table => new
                {
                    IdRequisitos = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Texto = table.Column<int>(nullable: false),
                    PontuacaoMaxima = table.Column<int>(nullable: false),
                    PontuacaoMinimo = table.Column<int>(nullable: false),
                    TipoAvalicao = table.Column<int>(nullable: false),
                    IdConcurso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisitoss", x => x.IdRequisitos);
                    table.ForeignKey(
                        name: "FK_Requisitoss_Concursos_IdConcurso",
                        column: x => x.IdConcurso,
                        principalTable: "Concursos",
                        principalColumn: "IdConcurso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JuriConcursos",
                columns: table => new
                {
                    IdJuriConcurso = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdJuri = table.Column<int>(nullable: false),
                    IdConcurso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuriConcursos", x => x.IdJuriConcurso);
                    table.ForeignKey(
                        name: "FK_JuriConcursos_Concursos_IdConcurso",
                        column: x => x.IdConcurso,
                        principalTable: "Concursos",
                        principalColumn: "IdConcurso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JuriConcursos_Juris_IdJuri",
                        column: x => x.IdJuri,
                        principalTable: "Juris",
                        principalColumn: "IdJuri",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Avalicoes",
                columns: table => new
                {
                    IdAvalicao = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Avalicaoatribuida = table.Column<int>(nullable: false),
                    Obs = table.Column<string>(nullable: true),
                    IdRequisitos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avalicoes", x => x.IdAvalicao);
                    table.ForeignKey(
                        name: "FK_Avalicoes_Requisitoss_IdRequisitos",
                        column: x => x.IdRequisitos,
                        principalTable: "Requisitoss",
                        principalColumn: "IdRequisitos",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avalicoes_IdRequisitos",
                table: "Avalicoes",
                column: "IdRequisitos");

            migrationBuilder.CreateIndex(
                name: "IX_JuriConcursos_IdConcurso",
                table: "JuriConcursos",
                column: "IdConcurso");

            migrationBuilder.CreateIndex(
                name: "IX_JuriConcursos_IdJuri",
                table: "JuriConcursos",
                column: "IdJuri");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipacaoConcursos_IdConcorente",
                table: "ParticipacaoConcursos",
                column: "IdConcorente");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipacaoConcursos_IdConcurso",
                table: "ParticipacaoConcursos",
                column: "IdConcurso");

            migrationBuilder.CreateIndex(
                name: "IX_Requisitoss_IdConcurso",
                table: "Requisitoss",
                column: "IdConcurso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avalicoes");

            migrationBuilder.DropTable(
                name: "JuriConcursos");

            migrationBuilder.DropTable(
                name: "ParticipacaoConcursos");

            migrationBuilder.DropTable(
                name: "Requisitoss");

            migrationBuilder.DropTable(
                name: "Juris");

            migrationBuilder.DropTable(
                name: "Concorentes");

            migrationBuilder.DropTable(
                name: "Concursos");
        }
    }
}
