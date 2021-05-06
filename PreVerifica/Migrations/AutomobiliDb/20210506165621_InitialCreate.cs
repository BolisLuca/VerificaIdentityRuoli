    using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PreVerifica.Migrations.AutomobiliDb
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Automobili",
                columns: table => new
                {
                    PkId = table.Column<string>(type: "TEXT", nullable: false),
                    NomeModello = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Descrizione = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    cavalli = table.Column<int>(type: "INTEGER", nullable: false),
                    data_di_produzione = table.Column<DateTime>(type: "TEXT", nullable: false),
                    fkUserName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobili", x => x.PkId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automobili");
        }
    }
}
