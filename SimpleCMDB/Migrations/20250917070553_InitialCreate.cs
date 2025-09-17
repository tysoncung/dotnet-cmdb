using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCMDB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Language = table.Column<string>(type: "TEXT", nullable: true),
                    Criticality = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "medium"),
                    Owner = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "datetime('now')"),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "datetime('now')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Hostname = table.Column<string>(type: "TEXT", nullable: false),
                    IpAddress = table.Column<string>(type: "TEXT", nullable: true),
                    OsType = table.Column<string>(type: "TEXT", nullable: true),
                    OsVersion = table.Column<string>(type: "TEXT", nullable: true),
                    Environment = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "production"),
                    Status = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "active"),
                    Owner = table.Column<string>(type: "TEXT", nullable: true),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    CpuCount = table.Column<int>(type: "INTEGER", nullable: true),
                    MemoryGb = table.Column<decimal>(type: "TEXT", nullable: true),
                    DiskGb = table.Column<decimal>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "datetime('now')"),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "datetime('now')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceName = table.Column<string>(type: "TEXT", nullable: false),
                    ServerId = table.Column<int>(type: "INTEGER", nullable: true),
                    ApplicationId = table.Column<int>(type: "INTEGER", nullable: true),
                    Port = table.Column<int>(type: "INTEGER", nullable: true),
                    Protocol = table.Column<string>(type: "TEXT", nullable: true, defaultValue: "tcp"),
                    Status = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "running"),
                    ProcessName = table.Column<string>(type: "TEXT", nullable: true),
                    StartCommand = table.Column<string>(type: "TEXT", nullable: true),
                    ConfigFile = table.Column<string>(type: "TEXT", nullable: true),
                    LogFile = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "datetime('now')"),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "datetime('now')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Services_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dependencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SourceServiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    TargetServiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "datetime('now')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dependencies_Services_SourceServiceId",
                        column: x => x.SourceServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dependencies_Services_TargetServiceId",
                        column: x => x.TargetServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_Name",
                table: "Applications",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dependencies_SourceServiceId_TargetServiceId",
                table: "Dependencies",
                columns: new[] { "SourceServiceId", "TargetServiceId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dependencies_TargetServiceId",
                table: "Dependencies",
                column: "TargetServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Servers_Hostname",
                table: "Servers",
                column: "Hostname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_ApplicationId",
                table: "Services",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServerId",
                table: "Services",
                column: "ServerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dependencies");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Servers");
        }
    }
}
