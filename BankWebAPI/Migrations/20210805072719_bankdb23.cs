using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankWebAPI.Migrations
{
    public partial class bankdb23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SupplementNumber",
                table: "Transfers",
                newName: "senderCardId");

            migrationBuilder.RenameColumn(
                name: "AccountSupplementNumber",
                table: "Accounts",
                newName: "AccountAdditionalNumber");

            migrationBuilder.AddColumn<int>(
                name: "AdditionalNumber",
                table: "Transfers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApproverTcNo",
                table: "Transfers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "receiverAccId",
                table: "Transfers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "receiverCardId",
                table: "Transfers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "senderAccId",
                table: "Transfers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApproverTcNo",
                table: "Loans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApproverTcNo",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApproverTcNo",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BankEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TcNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankEmployees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerRelations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TcNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRelations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankEmployees");

            migrationBuilder.DropTable(
                name: "CustomerRelations");

            migrationBuilder.DropColumn(
                name: "AdditionalNumber",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "ApproverTcNo",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "receiverAccId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "receiverCardId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "senderAccId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "ApproverTcNo",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "ApproverTcNo",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ApproverTcNo",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "senderCardId",
                table: "Transfers",
                newName: "SupplementNumber");

            migrationBuilder.RenameColumn(
                name: "AccountAdditionalNumber",
                table: "Accounts",
                newName: "AccountSupplementNumber");
        }
    }
}
