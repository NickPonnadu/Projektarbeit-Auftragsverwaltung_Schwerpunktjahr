using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjektAuftragsverwaltung.Migrations
{
    /// <inheritdoc />
    public partial class MyNewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressLocations_Addresses_AddressId",
                table: "AddressLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticlePositions",
                table: "ArticlePositions");

            migrationBuilder.DropIndex(
                name: "IX_AddressLocations_AddressId",
                table: "AddressLocations");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "AddressLocations");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Articles",
                newName: "Price");

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ArticlePositionId",
                table: "ArticlePositions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticlePositions",
                table: "ArticlePositions",
                column: "ArticlePositionId");

            migrationBuilder.InsertData(
                table: "AddressLocations",
                columns: new[] { "ZipCode", "Location" },
                values: new object[,]
                {
                    { 12345, "Testort 1" },
                    { 123456, "Testort 2" },
                    { 123457, "Testort 3" },
                    { 123458, "Testort 4" },
                    { 123459, "Testort 5" }
                });

            migrationBuilder.InsertData(
                table: "ArticleGroups",
                columns: new[] { "ArticleGroupId", "Name" },
                values: new object[,]
                {
                    { 1, "Gruppe 1" },
                    { 2, "Gruppe 2" },
                    { 3, "Gruppe 3" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "AddressId", "EMail", "Name", "Password", "PhoneNumber", "Website" },
                values: new object[,]
                {
                    { 1, 1, "test1@test.com", "Test Kunde 1", "pass1", "0123456789", "Website1" },
                    { 2, 2, "test2@test.com", "Test Kunde 2", "pass2", "9876543210", "Website2" },
                    { 3, 3, "test3@test.com", "Test Kunde 3", "pass3", "1234567890", "Website3" },
                    { 4, 4, "test4@test.com", "Test Kunde 4", "pass4", "0987654321", "Website4" },
                    { 5, 5, "test5@test.com", "Test Kunde 5", "pass5", "1023456789", "Website5" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "HouseNumber", "Street", "ZipCode" },
                values: new object[,]
                {
                    { 1, "1", "Teststraße 1", 12345 },
                    { 2, "2", "Teststraße 2", 12345 },
                    { 3, "3", "Teststraße 3", 12345 },
                    { 4, "4", "Teststraße 4", 12345 },
                    { 5, "5", "Teststraße 5", 12345 }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleId", "ArticleGroupId", "ArticleName", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Artikel 1", 10.0m },
                    { 2, 1, "Artikel 2", 20.0m },
                    { 3, 2, "Artikel 3", 30.0m },
                    { 4, 2, "Artikel 4", 40.0m },
                    { 5, 3, "Artikel 5", 50.0m }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "Date" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2022, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "OrderPositions",
                columns: new[] { "OrderPositionId", "OrderId", "amount" },
                values: new object[,]
                {
                    { 1, 1, 5 },
                    { 2, 2, 10 },
                    { 3, 3, 3 },
                    { 4, 4, 8 },
                    { 5, 5, 15 }
                });

            migrationBuilder.InsertData(
                table: "ArticlePositions",
                columns: new[] { "ArticlePositionId", "ArticleId", "OrderPositionId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticlePositions_OrderPositionId",
                table: "ArticlePositions",
                column: "OrderPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ZipCode",
                table: "Addresses",
                column: "ZipCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AddressLocations_ZipCode",
                table: "Addresses",
                column: "ZipCode",
                principalTable: "AddressLocations",
                principalColumn: "ZipCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AddressLocations_ZipCode",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticlePositions",
                table: "ArticlePositions");

            migrationBuilder.DropIndex(
                name: "IX_ArticlePositions_OrderPositionId",
                table: "ArticlePositions");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_ZipCode",
                table: "Addresses");

            migrationBuilder.DeleteData(
                table: "AddressLocations",
                keyColumn: "ZipCode",
                keyValue: 123456);

            migrationBuilder.DeleteData(
                table: "AddressLocations",
                keyColumn: "ZipCode",
                keyValue: 123457);

            migrationBuilder.DeleteData(
                table: "AddressLocations",
                keyColumn: "ZipCode",
                keyValue: 123458);

            migrationBuilder.DeleteData(
                table: "AddressLocations",
                keyColumn: "ZipCode",
                keyValue: 123459);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ArticlePositions",
                keyColumn: "ArticlePositionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ArticlePositions",
                keyColumn: "ArticlePositionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ArticlePositions",
                keyColumn: "ArticlePositionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ArticlePositions",
                keyColumn: "ArticlePositionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ArticlePositions",
                keyColumn: "ArticlePositionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AddressLocations",
                keyColumn: "ZipCode",
                keyValue: 12345);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "OrderPositionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "OrderPositionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "OrderPositionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "OrderPositionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "OrderPositionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ArticleGroups",
                keyColumn: "ArticleGroupId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ArticleGroups",
                keyColumn: "ArticleGroupId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ArticleGroups",
                keyColumn: "ArticleGroupId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Articles",
                newName: "price");

            migrationBuilder.AlterColumn<int>(
                name: "ArticlePositionId",
                table: "ArticlePositions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "AddressLocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticlePositions",
                table: "ArticlePositions",
                columns: new[] { "OrderPositionId", "ArticleId" });

            migrationBuilder.CreateIndex(
                name: "IX_AddressLocations_AddressId",
                table: "AddressLocations",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressLocations_Addresses_AddressId",
                table: "AddressLocations",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
