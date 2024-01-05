using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teploobmen.Migrations
{
    public partial class TableInputDatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "inDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    H0 = table.Column<double>(type: "REAL", nullable: true),
                    t0_ = table.Column<double>(type: "REAL", nullable: true),
                    T_ = table.Column<double>(type: "REAL", nullable: true),
                    wg = table.Column<double>(type: "REAL", nullable: true),
                    Cg = table.Column<double>(type: "REAL", nullable: true),
                    av = table.Column<double>(type: "REAL", nullable: true),
                    Cm = table.Column<double>(type: "REAL", nullable: true),
                    Gm = table.Column<double>(type: "REAL", nullable: true),
                    r = table.Column<double>(type: "REAL", nullable: true),
                    DateAdd = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inDatas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inDatas");
        }
    }
}
