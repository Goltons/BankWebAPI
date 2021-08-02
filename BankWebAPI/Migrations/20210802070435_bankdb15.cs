using Microsoft.EntityFrameworkCore.Migrations;

namespace BankWebAPI.Migrations
{
    public partial class bankdb15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsApproved",
                table: "Bills",
                newName: "IsPaid");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CustomerId",
                table: "Cards",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Customers_CustomerId",
                table: "Cards",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Customers_CustomerId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_CustomerId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "IsPaid",
                table: "Bills",
                newName: "IsApproved");
        }
    }
}
