using Microsoft.EntityFrameworkCore.Migrations;

namespace IMCApi.Migrations
{
    public partial class CriaMigrationIMC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Classificacao",
                table: "IMCs",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ImcUsuario",
                table: "IMCs",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Classificacao",
                table: "IMCs");

            migrationBuilder.DropColumn(
                name: "ImcUsuario",
                table: "IMCs");
        }
    }
}
