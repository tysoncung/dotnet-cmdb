using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCMDB.Migrations
{
    /// <inheritdoc />
    public partial class AddExternalServiceFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExternalUrl",
                table: "Services",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsExternal",
                table: "Services",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalUrl",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "IsExternal",
                table: "Services");
        }
    }
}
