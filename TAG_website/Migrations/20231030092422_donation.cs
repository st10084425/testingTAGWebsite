using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TAG_website.Migrations
{
    public partial class donation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Donation",
                table: "Donation");

            migrationBuilder.RenameTable(
                name: "Donation",
                newName: "Donate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donate",
                table: "Donate",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Donate",
                table: "Donate");

            migrationBuilder.RenameTable(
                name: "Donate",
                newName: "Donation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donation",
                table: "Donation",
                column: "Id");
        }
    }
}
