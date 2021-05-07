namespace TR.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddBlogandAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    AddTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime", nullable: false),
                    Intridution = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 32, nullable: true),
                    Password = table.Column<string>(maxLength: 32, nullable: true),
                    AddTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EditTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDelete = table.Column<int>(type: "int(11)", nullable: false),
                    AuthenticationType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "blog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 64, nullable: true),
                    Top = table.Column<int>(type: "int(2)", nullable: false),
                    Content = table.Column<string>(maxLength: 51200, nullable: true),
                    Summary = table.Column<string>(maxLength: 2000, nullable: true),
                    Category = table.Column<string>(maxLength: 32, nullable: true),
                    CategoryID = table.Column<string>(maxLength: 32, nullable: true),
                    Tags = table.Column<string>(maxLength: 32, nullable: true),
                    SourceUrl = table.Column<string>(maxLength: 64, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EditTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Pv = table.Column<string>(maxLength: 32, nullable: true),
                    AuthorId = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blog_author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_blog_AuthorId",
                table: "blog",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blog");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "author");
        }
    }
}
