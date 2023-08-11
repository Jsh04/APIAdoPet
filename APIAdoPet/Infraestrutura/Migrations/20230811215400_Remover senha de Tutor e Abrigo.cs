using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIAdoPet.Migrations
{
    /// <inheritdoc />
    public partial class RemoversenhadeTutoreAbrigo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Tutores");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Abrigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Tutores",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Abrigo",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
