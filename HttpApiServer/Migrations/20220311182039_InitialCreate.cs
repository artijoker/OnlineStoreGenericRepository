using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HttpApiServer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Login = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UrlImage = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("063ebf69-a031-4328-ac73-85a60b930f4f"), "Игровые консоли" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("5a4c651b-b83e-4fb5-ba5e-e6d9b80407a4"), "Наушники" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("e3564cdc-b71c-4501-bf7c-654d21a7dbc9"), "Смарфоны" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("e5939c6a-048f-4a2b-a1cc-6856a8e578bf"), "Телевизоры" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("e63338e7-8916-4a81-bb70-3f147b781e8c"), "Ноутбуки" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("fae008cc-7fc1-4c18-96b8-653fcd884bdf"), "USB накопители" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "Price", "Quantity", "UrlImage" },
                values: new object[] { new Guid("1c406f52-e4f1-4259-a768-9a548cad6d98"), new Guid("5a4c651b-b83e-4fb5-ba5e-e6d9b80407a4"), "Наушники Sony WH-CH56030NW", 130.60m, 25, "https://cdn1.ozone.ru/s3/multimedia-r/wc1200/6179635779.jpg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "Price", "Quantity", "UrlImage" },
                values: new object[] { new Guid("2639c484-30e1-428e-840e-e745e3ad5b14"), new Guid("e63338e7-8916-4a81-bb70-3f147b781e8c"), "Ноутбук Lenovo IdeaPad 4 15IX5P6", 830.50m, 15, "https://cdn1.ozone.ru/s3/multimedia-7/wc1200/6166994971.jpg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "Price", "Quantity", "UrlImage" },
                values: new object[] { new Guid("415ad2a3-2141-44da-b33d-3d4409126642"), new Guid("e3564cdc-b71c-4501-bf7c-654d21a7dbc9"), "Смартфон Google Pixel 5a", 560m, 20, "https://cdn1.ozone.ru/s3/multimedia-3/wc250/6237328203.jpg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "Price", "Quantity", "UrlImage" },
                values: new object[] { new Guid("92ae2eb4-de13-4da4-99f7-e6777e16e2c6"), new Guid("e5939c6a-048f-4a2b-a1cc-6856a8e578bf"), "Телевизор Sony KD50X81J 50", 1000.89m, 15, "https://cdn1.ozone.ru/s3/multimedia-n/wc1200/6068732087.jpg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "Price", "Quantity", "UrlImage" },
                values: new object[] { new Guid("a66bb5b5-8862-42b2-86bd-e3d0a41ea247"), new Guid("063ebf69-a031-4328-ac73-85a60b930f4f"), "Microsoft Xbox Series X", 985m, 2, "https://cdn1.ozone.ru/s3/multimedia-l/wc1200/6232471137.jpg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "Price", "Quantity", "UrlImage" },
                values: new object[] { new Guid("a9dc85e6-138d-45a3-9378-e74709d1290c"), new Guid("fae008cc-7fc1-4c18-96b8-653fcd884bdf"), "USB накопитель Samsung", 30m, 35, "https://cdn1.ozone.ru/multimedia/wc1200/1026248251.jpg" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
