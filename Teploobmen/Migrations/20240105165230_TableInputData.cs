using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teploobmen.Migrations
{
    public partial class TableInputData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "inDatas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "inDatas");
        }
    }
}
