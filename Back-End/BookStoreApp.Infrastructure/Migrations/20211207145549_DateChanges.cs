using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreApp.Infrastructure.Migrations
{
    public partial class DateChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicationDate_Date",
                table: "Books");

            migrationBuilder.AddColumn<DateTime>(
                name: "PublicationDate",
                table: "Books",
                type: "date",
                nullable: false,
                defaultValueSql: "GetDate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicationDate",
                table: "Books");

            migrationBuilder.AddColumn<DateTime>(
                name: "PublicationDate_Date",
                table: "Books",
                type: "datetime2",
                nullable: true);
        }
    }
}
