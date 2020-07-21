using Microsoft.EntityFrameworkCore.Migrations;

namespace HungryPizzariaAPI.Infrastructure.Data.Migrations
{
    public partial class AtualizandoModelCliente1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "cep",
                table: "cliente",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8) CHARACTER SET utf8mb4",
                oldMaxLength: 8);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "cep",
                table: "cliente",
                type: "varchar(8) CHARACTER SET utf8mb4",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 8,
                oldNullable: true);
        }
    }
}
