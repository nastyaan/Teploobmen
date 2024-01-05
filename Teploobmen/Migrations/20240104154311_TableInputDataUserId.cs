using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teploobmen.Migrations
{
    public partial class TableInputDataUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "inDatas",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "inDatas");
        }
    }
}
