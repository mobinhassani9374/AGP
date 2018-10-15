using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AGP.DataLayer.Migrations
{
    public partial class AccountGameTransactionRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Users_UserId",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "Transactions");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_UserId",
                table: "Transactions",
                newName: "IX_Transactions_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountGameId",
                table: "Transactions",
                column: "AccountGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AccountGames_AccountGameId",
                table: "Transactions",
                column: "AccountGameId",
                principalTable: "AccountGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AccountGames_AccountGameId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AccountGameId",
                table: "Transactions");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transaction");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_UserId",
                table: "Transaction",
                newName: "IX_Transaction_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Users_UserId",
                table: "Transaction",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
