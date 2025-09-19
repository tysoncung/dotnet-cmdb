using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCMDB.Migrations
{
    /// <inheritdoc />
    public partial class AddDependencyDetailsFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApiVersion",
                table: "Dependencies",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthType",
                table: "Dependencies",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Certificate",
                table: "Dependencies",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCritical",
                table: "Dependencies",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Port",
                table: "Dependencies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Protocol",
                table: "Dependencies",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RetryCount",
                table: "Dependencies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceAccount",
                table: "Dependencies",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeoutSeconds",
                table: "Dependencies",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApiVersion",
                table: "Dependencies");

            migrationBuilder.DropColumn(
                name: "AuthType",
                table: "Dependencies");

            migrationBuilder.DropColumn(
                name: "Certificate",
                table: "Dependencies");

            migrationBuilder.DropColumn(
                name: "IsCritical",
                table: "Dependencies");

            migrationBuilder.DropColumn(
                name: "Port",
                table: "Dependencies");

            migrationBuilder.DropColumn(
                name: "Protocol",
                table: "Dependencies");

            migrationBuilder.DropColumn(
                name: "RetryCount",
                table: "Dependencies");

            migrationBuilder.DropColumn(
                name: "ServiceAccount",
                table: "Dependencies");

            migrationBuilder.DropColumn(
                name: "TimeoutSeconds",
                table: "Dependencies");
        }
    }
}
