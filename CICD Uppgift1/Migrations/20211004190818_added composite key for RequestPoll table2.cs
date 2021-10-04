using Microsoft.EntityFrameworkCore.Migrations;

namespace CICD_Uppgift1.Migrations
{
    public partial class addedcompositekeyforRequestPolltable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestPolls",
                table: "RequestPolls");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "RequestPolls",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestPolls",
                table: "RequestPolls",
                columns: new[] { "Username", "Salary", "Role" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestPolls",
                table: "RequestPolls");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "RequestPolls",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestPolls",
                table: "RequestPolls",
                column: "Username");
        }
    }
}
