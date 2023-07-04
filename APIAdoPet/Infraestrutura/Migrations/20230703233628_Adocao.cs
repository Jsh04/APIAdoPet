using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIAdoPet.Migrations
{
    /// <inheritdoc />
    public partial class Adocao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Tutores",
                type: "varchar(15)",
                maxLength: 15,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15,
                oldDefaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Tutores",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Tutores",
                type: "longtext",
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldDefaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "AdocaoId",
                table: "Pets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Adocaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Telefone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mensagem = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adocaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adocaos_Tutores_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_AdocaoId",
                table: "Pets",
                column: "AdocaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Adocaos_TutorId",
                table: "Adocaos",
                column: "TutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Adocaos_AdocaoId",
                table: "Pets",
                column: "AdocaoId",
                principalTable: "Adocaos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Adocaos_AdocaoId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "Adocaos");

            migrationBuilder.DropIndex(
                name: "IX_Pets_AdocaoId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "AdocaoId",
                table: "Pets");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Tutores",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15,
                oldNullable: true,
                oldDefaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Tutores",
                keyColumn: "Nome",
                keyValue: null,
                column: "Nome",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Tutores",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Tutores",
                type: "longtext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true,
                oldDefaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
