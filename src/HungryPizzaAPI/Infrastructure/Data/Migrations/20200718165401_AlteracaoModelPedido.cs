using Microsoft.EntityFrameworkCore.Migrations;

namespace HungryPizzariaAPI.Infrastructure.Data.Migrations
{
    public partial class AlteracaoModelPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "valor_total",
                table: "pedido");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "item_pedido",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "pedido_id",
                table: "item_pedido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_item_pedido_pedido_id",
                table: "item_pedido",
                column: "pedido_id");

            migrationBuilder.AddForeignKey(
                name: "FK_item_pedido_pedido_pedido_id",
                table: "item_pedido",
                column: "pedido_id",
                principalTable: "pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_item_pedido_pedido_pedido_id",
                table: "item_pedido");

            migrationBuilder.DropIndex(
                name: "IX_item_pedido_pedido_id",
                table: "item_pedido");

            migrationBuilder.DropColumn(
                name: "pedido_id",
                table: "item_pedido");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "item_pedido",
                newName: "Id");

            migrationBuilder.AddColumn<decimal>(
                name: "valor_total",
                table: "pedido",
                type: "decimal(8, 2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
