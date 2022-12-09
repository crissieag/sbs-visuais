using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IMCApi.Migrations
{
    public partial class AlteraIMC2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassificacaoFormatada",
                table: "IMCs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "IMCs",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassificacaoFormatada",
                table: "IMCs");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "IMCs");
        }
    }
}
