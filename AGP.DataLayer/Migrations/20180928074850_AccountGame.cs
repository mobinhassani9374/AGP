using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AGP.DataLayer.Migrations
{
    public partial class AccountGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountGames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuyDate = table.Column<DateTime>(nullable: true),
                    BuyState = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    GameId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeActiveByAdmin = table.Column<bool>(nullable: false),
                    IsDone = table.Column<bool>(nullable: false),
                    Level = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ReasonForCancel = table.Column<string>(nullable: true),
                    ReasonForDeActiveByAdmin = table.Column<string>(nullable: true),
                    RequestDate = table.Column<DateTime>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountGames_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountGames_GameId",
                table: "AccountGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountGames_UserId",
                table: "AccountGames",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountGames");
        }
    }
}
