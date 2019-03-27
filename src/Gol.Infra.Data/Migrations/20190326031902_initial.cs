using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gol.Infra.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airplane",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Model = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    QtdPassagers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airplane");
        }
    }
}
