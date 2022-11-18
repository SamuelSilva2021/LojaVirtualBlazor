using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class remColObsProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "Produtos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
