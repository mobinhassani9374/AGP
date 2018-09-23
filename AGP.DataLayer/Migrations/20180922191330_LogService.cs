using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AGP.DataLayer.Migrations
{
    public partial class LogService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogServices",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Elapsed = table.Column<TimeSpan>(nullable: false),
                    Method = table.Column<string>(nullable: true),
                    QueryString = table.Column<string>(nullable: true),
                    RelativePath = table.Column<string>(nullable: true),
                    RequestContentLength = table.Column<long>(nullable: true),
                    RequestIp = table.Column<string>(nullable: true),
                    ResponseContentLength = table.Column<long>(nullable: true),
                    StatusCode = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogServices_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogServices_UserId",
                table: "LogServices",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogServices");
        }
    }
}
