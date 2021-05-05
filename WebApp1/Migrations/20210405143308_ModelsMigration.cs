using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp1.Migrations
{
    public partial class ModelsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    pkBook = table.Column<string>(type: "TEXT", nullable: false),
                    descrizioneBook = table.Column<string>(type: "TEXT", nullable: false),
                    dataBook = table.Column<DateTime>(type: "TEXT", nullable: false),
                    numeroScatti = table.Column<int>(type: "INTEGER", nullable: false),
                    fkModello = table.Column<string>(type: "TEXT", nullable: true),
                    fkCliente = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.pkBook);
                });

            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    pkCliente = table.Column<string>(type: "TEXT", nullable: false),
                    RagioneSocialeCliente = table.Column<string>(type: "TEXT", nullable: false),
                    NazioneCliente = table.Column<string>(type: "TEXT", nullable: false),
                    emailCliente = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienti", x => x.pkCliente);
                });

            migrationBuilder.CreateTable(
                name: "Modelli",
                columns: table => new
                {
                    pkModello = table.Column<string>(type: "TEXT", nullable: false),
                    NomeModello = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascita = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NazioneModello = table.Column<string>(type: "TEXT", nullable: false),
                    emailModello = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelli", x => x.pkModello);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Clienti");

            migrationBuilder.DropTable(
                name: "Modelli");
        }
    }
}
