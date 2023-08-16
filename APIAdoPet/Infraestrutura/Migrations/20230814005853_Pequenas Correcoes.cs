using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIAdoPet.Migrations
{
    /// <inheritdoc />
    public partial class PequenasCorrecoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tutores_AspNetUsers_UsuarioId",
                table: "Tutores");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Tutores",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Tutores_AspNetUsers_UsuarioId",
                table: "Tutores",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tutores_AspNetUsers_UsuarioId",
                table: "Tutores");

            migrationBuilder.UpdateData(
                table: "Tutores",
                keyColumn: "UsuarioId",
                keyValue: null,
                column: "UsuarioId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Tutores",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Tutores_AspNetUsers_UsuarioId",
                table: "Tutores",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
