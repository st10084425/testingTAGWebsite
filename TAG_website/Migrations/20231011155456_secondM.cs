using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TAG_website.Migrations
{
    public partial class secondM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeOfItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    otherItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameOfItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    DateOfDonation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donation", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donation");
        }
    }
}
