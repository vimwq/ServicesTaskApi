#pragma warning disable 1591
using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sber.Migrations
{
    public partial class MyServicesTasksMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServicesTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<bool>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesTasks", x => x.Id);
                    table.UniqueConstraint("UQ_ServicesTasks_Description", x=> x.Description);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicesTasks");
        }
    }
}
#pragma warning restore 1591
