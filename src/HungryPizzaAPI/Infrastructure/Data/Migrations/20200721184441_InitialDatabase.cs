using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HungryPizzariaAPI.Infrastructure.Data.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data_criacao = table.Column<DateTime>(nullable: false),
                    data_atualizacao = table.Column<DateTime>(nullable: false),
                    nome = table.Column<string>(maxLength: 200, nullable: false),
                    telefone = table.Column<string>(maxLength: 15, nullable: false),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    endereco = table.Column<string>(maxLength: 200, nullable: false),
                    numero = table.Column<string>(maxLength: 10, nullable: false),
                    complemento = table.Column<string>(maxLength: 20, nullable: true),
                    bairro = table.Column<string>(maxLength: 100, nullable: true),
                    cidade = table.Column<string>(maxLength: 100, nullable: true),
                    cep = table.Column<string>(maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pizza",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data_criacao = table.Column<DateTime>(nullable: false),
                    data_atualizacao = table.Column<DateTime>(nullable: false),
                    sabor = table.Column<string>(maxLength: 100, nullable: false),
                    valor = table.Column<decimal>(type: "decimal(8, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pizza", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data_criacao = table.Column<DateTime>(nullable: false),
                    data_atualizacao = table.Column<DateTime>(nullable: false),
                    cod_pedido = table.Column<string>(maxLength: 10, nullable: false),
                    cliente_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pedido_cliente_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "item_pedido",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    pedido_id = table.Column<int>(nullable: false),
                    quantidade = table.Column<int>(nullable: false),
                    valor_unitario = table.Column<decimal>(type: "decimal(8, 2)", nullable: false),
                    quantidade_sabor = table.Column<int>(nullable: false),
                    pizza_id1 = table.Column<int>(nullable: false),
                    pizza_id2 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_item_pedido_pedido_pedido_id",
                        column: x => x.pedido_id,
                        principalTable: "pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_item_pedido_pedido_id",
                table: "item_pedido",
                column: "pedido_id");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_cliente_id",
                table: "pedido",
                column: "cliente_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "item_pedido");

            migrationBuilder.DropTable(
                name: "pizza");

            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}
