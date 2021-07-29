using Microsoft.EntityFrameworkCore.Migrations;

namespace BankWebAPI.Migrations
{
    public partial class bankdb12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalDeposit",
                table: "Accounts",
                newName: "Balance");

            migrationBuilder.AddColumn<double>(
                name: "CartLimit",
                table: "Carts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartLimit",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Accounts",
                newName: "TotalDeposit");
        }
    }
}
