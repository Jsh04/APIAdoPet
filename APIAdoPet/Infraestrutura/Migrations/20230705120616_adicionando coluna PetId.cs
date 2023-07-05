using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIAdoPet.Migrations
{
    /// <inheritdoc />
    public partial class adicionandocolunaPetId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Adocaos_AdocaoId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_AdocaoId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "AdocaoId",
                table: "Pets");

            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "Adocaos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Adocaos_PetId",
                table: "Adocaos",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adocaos_Pets_PetId",
                table: "Adocaos",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adocaos_Pets_PetId",
                table: "Adocaos");

            migrationBuilder.DropIndex(
                name: "IX_Adocaos_PetId",
                table: "Adocaos");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Adocaos");

            migrationBuilder.AddColumn<int>(
                name: "AdocaoId",
                table: "Pets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_AdocaoId",
                table: "Pets",
                column: "AdocaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Adocaos_AdocaoId",
                table: "Pets",
                column: "AdocaoId",
                principalTable: "Adocaos",
                principalColumn: "Id");
        }
    }
}
