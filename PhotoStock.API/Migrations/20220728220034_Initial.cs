using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotoStock.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 60, nullable: false),
                    LastName = table.Column<string>(maxLength: 60, nullable: false),
                    NickName = table.Column<string>(maxLength: 60, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DateOfRegistration = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PhotoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Link = table.Column<string>(nullable: false),
                    OriginalSize = table.Column<string>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    NumberOfSales = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotoId);
                });

            migrationBuilder.CreateTable(
                name: "Texts",
                columns: table => new
                {
                    TextId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Note = table.Column<string>(maxLength: 60, nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    NumberOfSales = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Texts", x => x.TextId);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "DateOfBirth", "DateOfRegistration", "FirstName", "LastName", "NickName" },
                values: new object[,]
                {
                    { 1, new DateTime(1996, 7, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 7, 27, 0, 0, 0, 0, DateTimeKind.Local), "Sanjar", "Tursunov", "Sancho" },
                    { 2, new DateTime(1999, 7, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 7, 29, 0, 0, 0, 0, DateTimeKind.Local), "Shokhzod", "Azamatov", "AshoT" },
                    { 3, new DateTime(2000, 7, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 7, 28, 0, 0, 0, 0, DateTimeKind.Local), "Aziz", "Kholkazakov", "ICloud" }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "PhotoId", "AuthorId", "Cost", "DateOfCreation", "Link", "Name", "NumberOfSales", "OriginalSize", "Rating" },
                values: new object[,]
                {
                    { 1, 2, 100m, new DateTime(2022, 7, 29, 0, 0, 0, 0, DateTimeKind.Local), "C:\\Users\\ashot\\source\\repos\\PhotoStockSolution\\PhotoStock.API\\Images\\Furniture\\Furniture1.png", "Antaliya", 5, "1280 x 720", 2 },
                    { 2, 3, 120m, new DateTime(2022, 7, 28, 0, 0, 0, 0, DateTimeKind.Local), "C:\\Users\\ashot\\source\\repos\\PhotoStockSolution\\PhotoStock.API\\Images\\Furniture\\Furniture2.png", "Monaliza", 10, "1280 x 720", 3 },
                    { 3, 1, 95m, new DateTime(2022, 7, 27, 0, 0, 0, 0, DateTimeKind.Local), "C:\\Users\\ashot\\source\\repos\\PhotoStockSolution\\PhotoStock.API\\Images\\Furniture\\Furniture3.png", "Madonna", 3, "1280 x 720", 1 }
                });

            migrationBuilder.InsertData(
                table: "Texts",
                columns: new[] { "TextId", "AuthorId", "Cost", "DateOfCreation", "Name", "Note", "NumberOfSales", "Rating" },
                values: new object[,]
                {
                    { 1, 2, 50m, new DateTime(2022, 7, 29, 0, 0, 0, 0, DateTimeKind.Local), "MY5 Chanel", "This is a great chanel", 3, 2 },
                    { 2, 3, 200m, new DateTime(2022, 7, 28, 0, 0, 0, 0, DateTimeKind.Local), "FCB", "professional football club", 18, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Texts");
        }
    }
}
