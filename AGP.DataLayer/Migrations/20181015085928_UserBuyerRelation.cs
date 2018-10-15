using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AGP.DataLayer.Migrations
{
    public partial class UserBuyerRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AccountGames_UserBuyerId",
                table: "AccountGames",
                column: "UserBuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountGames_Users_UserBuyerId",
                table: "AccountGames",
                column: "UserBuyerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountGames_Users_UserBuyerId",
                table: "AccountGames");

            migrationBuilder.DropIndex(
                name: "IX_AccountGames_UserBuyerId",
                table: "AccountGames");
        }
    }
}
