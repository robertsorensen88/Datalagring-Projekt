using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseConnection.Migrations
{
    public partial class no_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] {"Id", "FirstName", "LastName"  , "Email", "Password", "Username"},
                values: new object[] { 1, "Björn", "Strömberg", "bjorn@email.com", "user1", "Bjarne" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FirstName", "LastName", "Email", "Password", "Username" },
                values: new object[] { 2, "Robert", "Sörensen", "robert@email.com", "user2", "Rhabby" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FirstName", "LastName", "Email", "Password", "Username" },
                values: new object[] { 3, "Lujain", "Al-shammari", "lujain@email.com", "user", "Lujain123" });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "CustomerId", "Date", "MovieId" },
                values: new object[] { 1, 1, new DateTime(2020, 11, 16, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "CustomerId", "Date", "MovieId" },
                values: new object[] { 3, 1, new DateTime(2020, 11, 16, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "CustomerId", "Date", "MovieId" },
                values: new object[] { 2, 2, new DateTime(2020, 11, 16, 0, 0, 0, 0, DateTimeKind.Local), null });
        }
    }
}
