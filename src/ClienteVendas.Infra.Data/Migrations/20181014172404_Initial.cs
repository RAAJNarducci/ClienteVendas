using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClienteVendas.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Logradouro = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Numero = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Complemento = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Bairro = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CEP = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    Celular = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true),
                    EnderecoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    table.PrimaryKey("PK_Venda", x => new { x.Id, x.ClienteId, x.ProdutoId });
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

            migrationBuilder.InsertData(
                table: "Endereco",
                columns: new[] { "Id", "Bairro", "CEP", "Cidade", "Complemento", "Estado", "Logradouro", "Numero" },
                values: new object[,]
                {
                    { 1, "Centro", "14801790", "Araraquara", "Casa", "SP", "Av. 13 de maio", "999" },
                    { 2, "Jardim Paulista", "15900000", "Taquaritinga", "Casa", "SP", "Rua 22", "111" }
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "DataCadastro", "Descricao", "Valor" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 10, 14, 14, 24, 3, 128, DateTimeKind.Local), "Celular Motorola G6", 1100.00m },
                    { 2, new DateTime(2018, 10, 14, 14, 24, 3, 134, DateTimeKind.Local), "Celular LG Q6", 1200.00m },
                    { 3, new DateTime(2018, 10, 14, 14, 24, 3, 134, DateTimeKind.Local), "Celular Samsung J7", 1300.00m }
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id", "Ativo", "Celular", "Cpf", "DataCadastro", "DataNascimento", "Email", "EnderecoId", "Nome" },
                values: new object[] { 1, true, "16991388733", "41282809322", new DateTime(2018, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1994, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "cliente01@gmail.com", 1, "Cliente 01" });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id", "Ativo", "Celular", "Cpf", "DataCadastro", "DataNascimento", "Email", "EnderecoId", "Nome" },
                values: new object[] { 2, true, "16981722833", "39902938222", new DateTime(2018, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1989, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "cliente02@gmail.com", 2, "Cliente 02" });

            migrationBuilder.InsertData(
                table: "Venda",
                columns: new[] { "Id", "ClienteId", "ProdutoId", "DataVenda", "Quantidade" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2018, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 1, 2, new DateTime(2018, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 1, 3, new DateTime(2018, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, 2, 1, new DateTime(2018, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, 2, 3, new DateTime(2018, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_EnderecoId",
                table: "Cliente",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venda_ClienteId",
                table: "Venda",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_ProdutoId",
                table: "Venda",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
