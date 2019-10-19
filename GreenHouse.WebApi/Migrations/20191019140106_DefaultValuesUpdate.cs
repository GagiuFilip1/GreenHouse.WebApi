using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GreenHouse.Migrations
{
    public partial class DefaultValuesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Friends_AccountId",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Friends");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Reports",
                type: "varchar(40)",
                nullable: false,
                defaultValue: "InProgress",
                oldClrType: typeof(string),
                oldType: "varchar(40)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReportedAt",
                table: "Reports",
                nullable: false,
                defaultValue: new DateTime(2019, 10, 19, 14, 1, 6, 312, DateTimeKind.Utc).AddTicks(3104),
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Reports",
                type: "varchar(40)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldDefaultValue: "InProgress");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReportedAt",
                table: "Reports",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 10, 19, 14, 1, 6, 312, DateTimeKind.Utc).AddTicks(3104));

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "Friends",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Friends_AccountId",
                table: "Friends",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Accounts_AccountId",
                table: "Friends",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
