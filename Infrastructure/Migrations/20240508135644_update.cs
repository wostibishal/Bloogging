using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Comments_CommentId",
                table: "Reactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reactions",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_Reactions_BloggingBlogId",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_Reactions_CommentId",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "BloggingBlogId",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "ReactId",
                table: "Reactions",
                newName: "Blog");

            migrationBuilder.RenameColumn(
                name: "LoginUserId",
                table: "Comments",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "Comments",
                newName: "PostedAt");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Comments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_LoginUserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Blogs",
                newName: "ImageName");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Blogs",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "Blogs",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_AuthorId",
                table: "Blogs",
                newName: "IX_Blogs_User");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Reactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "ReactionType",
                table: "Reactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Reactions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "BlogId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlogContent",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BlogTitle",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CommentCount",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Blogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DislikeCount",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LikeCount",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Popularity",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reactions",
                table: "Reactions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BlogsHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogTitlePrevious = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogContentPrevious = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogImageNamePrevious = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogCreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BlogModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Blog = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogsHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogsHistories_Blogs_Blog",
                        column: x => x.Blog,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentContentPrevious = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentCreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CommwntModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comments = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentHistories_Comments_Comments",
                        column: x => x.Comments,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReactionComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReactionType = table.Column<bool>(type: "bit", nullable: false),
                    Comment = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReactionComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReactionComments_AspNetUsers_User",
                        column: x => x.User,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReactionComments_Comments_Comment",
                        column: x => x.Comment,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_Blog",
                table: "Reactions",
                column: "Blog");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_User",
                table: "Reactions",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_BlogsHistories_Blog",
                table: "BlogsHistories",
                column: "Blog");

            migrationBuilder.CreateIndex(
                name: "IX_CommentHistories_Comments",
                table: "CommentHistories",
                column: "Comments");

            migrationBuilder.CreateIndex(
                name: "IX_ReactionComments_Comment",
                table: "ReactionComments",
                column: "Comment");

            migrationBuilder.CreateIndex(
                name: "IX_ReactionComments_User",
                table: "ReactionComments",
                column: "User");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_User",
                table: "Blogs",
                column: "User",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blogs_BlogId",
                table: "Comments",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_AspNetUsers_User",
                table: "Reactions",
                column: "User",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Blogs_Blog",
                table: "Reactions",
                column: "Blog",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_User",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_BlogId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_AspNetUsers_User",
                table: "Reactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Blogs_Blog",
                table: "Reactions");

            migrationBuilder.DropTable(
                name: "BlogsHistories");

            migrationBuilder.DropTable(
                name: "CommentHistories");

            migrationBuilder.DropTable(
                name: "ReactionComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reactions",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_Reactions_Blog",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_Reactions_User",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "ReactionType",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BlogContent",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogTitle",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "CommentCount",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "DislikeCount",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "LikeCount",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Popularity",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "Blog",
                table: "Reactions",
                newName: "ReactId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "LoginUserId");

            migrationBuilder.RenameColumn(
                name: "PostedAt",
                table: "Comments",
                newName: "DateModified");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                newName: "IX_Comments_LoginUserId");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "Blogs",
                newName: "AuthorId");

            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Blogs",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Blogs",
                newName: "BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_User",
                table: "Blogs",
                newName: "IX_Blogs_AuthorId");

            migrationBuilder.AddColumn<Guid>(
                name: "BloggingBlogId",
                table: "Reactions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CommentId",
                table: "Reactions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Reactions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BlogId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reactions",
                table: "Reactions",
                column: "ReactId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_BloggingBlogId",
                table: "Reactions",
                column: "BloggingBlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_CommentId",
                table: "Reactions",
                column: "CommentId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Comments_CommentId",
                table: "Reactions",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "CommentId");
        }
    }
}
