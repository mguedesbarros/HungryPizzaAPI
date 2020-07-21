using Microsoft.EntityFrameworkCore.Migrations;

namespace HungryPizzariaAPI.Infrastructure.Data.Migrations
{
    public partial class RemoveCpfEntityCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cpf",
                table: "cliente");

            migrationBuilder.AlterColumn<int>(
                name: "pizza_id2",
                table: "item_pedido",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "pizza_id2",
                table: "item_pedido",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cpf",
                table: "cliente",
                type: "varchar(15) CHARACTER SET utf8mb4",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }
    }
}
