using Microsoft.EntityFrameworkCore.Migrations;

namespace BankWebAPI.Migrations
{
    public partial class bankdb11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IBAN",
                table: "Carts");

            migrationBuilder.AddColumn<string>(
                name: "CartNumber",
                table: "Carts",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountSupplementNumber",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IBAN",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartNumber",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "AccountSupplementNumber",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "IBAN",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "IBAN",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
