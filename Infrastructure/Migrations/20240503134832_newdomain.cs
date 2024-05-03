using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newdomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_AppUserId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_BlogID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_AspNetUsers_AppUserId",
                table: "Reactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Blogs_BlogId",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_Reactions_AppUserId",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_Reactions_BlogId",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "BlogID",
                table: "Comments",
                newName: "BlogId");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Comments",
                newName: "LoginUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_BlogID",
                table: "Comments",
                newName: "IX_Comments_BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments",
                newName: "IX_Comments_LoginUserId");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Blogs",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_AppUserId",
                table: "Blogs",
                newName: "IX_Blogs_AuthorId");

            migrationBuilder.AddColumn<Guid>(
                name: "BloggingBlogId",
                table: "Reactions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BlogId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "DislikeCount",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LikeCount",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_BloggingBlogId",
                table: "Reactions",
                column: "BloggingBlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_AuthorId",
                table: "Blogs",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_LoginUserId",
                table: "Comments",
                column: "LoginUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blogs_BlogId",
                table: "Comments",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Blogs_BloggingBlogId",
                table: "Reactions",
                column: "BloggingBlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_AuthorId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_LoginUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_BlogId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Blogs_BloggingBlogId",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_Reactions_BloggingBlogId",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "BloggingBlogId",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "DislikeCount",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "LikeCount",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "Comments",
                newName: "BlogID");

            migrationBuilder.RenameColumn(
                name: "LoginUserId",
                table: "Comments",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_BlogId",
                table: "Comments",
                newName: "IX_Comments_BlogID");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_LoginUserId",
                table: "Comments",
                newName: "IX_Comments_AppUserId");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Blogs",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_AuthorId",
                table: "Blogs",
                newName: "IX_Blogs_AppUserId");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Reactions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BlogId",
                table: "Reactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Reactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BlogID",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_AppUserId",
                table: "Reactions",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_BlogId",
                table: "Reactions",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_AppUserId",
                table: "Blogs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blogs_BlogID",
                table: "Comments",
                column: "BlogID",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_AspNetUsers_AppUserId",
                table: "Reactions",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Blogs_BlogId",
                table: "Reactions",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
