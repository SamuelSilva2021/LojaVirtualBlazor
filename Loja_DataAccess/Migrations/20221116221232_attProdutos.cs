using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class attProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavoritosCliente",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "FavoritosShop",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Produtos",
                newName: "Cor");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "Produtos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "PrecoVenda",
                table: "Produtos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ValorCompra",
                table: "Produtos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PrecoVenda",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ValorCompra",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "Cor",
                table: "Produtos",
                newName: "Color");

            migrationBuilder.AddColumn<bool>(
                name: "FavoritosCliente",
                table: "Produtos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FavoritosShop",
                table: "Produtos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
