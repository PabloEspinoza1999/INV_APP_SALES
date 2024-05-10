using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INV_APPLICATION.Migrations
{
    /// <inheritdoc />
    public partial class M_MIGRATION : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NIF",
                table: "TbCustomer",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NIF",
                table: "TbCustomer");
        }
    }
}
