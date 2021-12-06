using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreApp.Infrastructure.Migrations
{
    public partial class finalCommentChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Authors_AuthorId1",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Books_BookId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AuthorId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BookId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AuthorId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BookId1",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId1",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BookId1",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId1",
                table: "Comments",
                column: "AuthorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BookId1",
                table: "Comments",
                column: "BookId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Authors_AuthorId1",
                table: "Comments",
                column: "AuthorId1",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Books_BookId1",
                table: "Comments",
                column: "BookId1",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
