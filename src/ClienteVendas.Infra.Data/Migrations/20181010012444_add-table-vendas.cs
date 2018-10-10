using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClienteVendas.Infra.Data.Migrations
{
    public partial class addtablevendas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false),
                    DataVenda = table.Column<DateTime>(type: "datetime", nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => new { x.ClienteId, x.ProdutoId });
                    table.UniqueConstraint("AK_Venda_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venda_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venda_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Venda_ProdutoId",
                table: "Venda",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Venda");
        }
    }
}
