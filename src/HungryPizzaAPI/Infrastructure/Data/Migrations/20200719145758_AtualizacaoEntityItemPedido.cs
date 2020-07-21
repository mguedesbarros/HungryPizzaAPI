using Microsoft.EntityFrameworkCore.Migrations;

namespace HungryPizzariaAPI.Infrastructure.Data.Migrations
{
    public partial class AtualizacaoEntityItemPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pizza_id",
                table: "item_pedido");

            migrationBuilder.DropColumn(
                name: "tamanho_pizza",
                table: "item_pedido");

            migrationBuilder.AddColumn<int>(
                name: "pizza_id1",
                table: "item_pedido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "pizza_id2",
                table: "item_pedido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "quantidade_sabor",
                table: "item_pedido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "valor_unitario",
                table: "item_pedido",
                type: "decimal(8, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pizza_id1",
                table: "item_pedido");

            migrationBuilder.DropColumn(
                name: "pizza_id2",
                table: "item_pedido");

            migrationBuilder.DropColumn(
                name: "quantidade_sabor",
                table: "item_pedido");

            migrationBuilder.DropColumn(
                name: "valor_unitario",
                table: "item_pedido");

            migrationBuilder.AddColumn<int>(
                name: "pizza_id",
                table: "item_pedido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tamanho_pizza",
                table: "item_pedido",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
