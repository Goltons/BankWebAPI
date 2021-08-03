using Microsoft.EntityFrameworkCore.Migrations;

namespace BankWebAPI.Migrations
{
    public partial class bankdb21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfer_Customers_CustomerId",
                table: "Transfer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transfer",
                table: "Transfer");

            migrationBuilder.RenameTable(
                name: "Transfer",
                newName: "Transfers");

            migrationBuilder.RenameIndex(
                name: "IX_Transfer_CustomerId",
                table: "Transfers",
                newName: "IX_Transfers_CustomerId");

            migrationBuilder.AddColumn<int>(
                name: "AccountNumber",
                table: "Transfers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BranchCode",
                table: "Transfers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverName",
                table: "Transfers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplementNumber",
                table: "Transfers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TransferType",
                table: "Transfers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transfers",
                table: "Transfers",
                column: "TransferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Customers_CustomerId",
                table: "Transfers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Customers_CustomerId",
                table: "Transfers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transfers",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "BranchCode",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "ReceiverName",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "SupplementNumber",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "TransferType",
                table: "Transfers");

            migrationBuilder.RenameTable(
                name: "Transfers",
                newName: "Transfer");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_CustomerId",
                table: "Transfer",
                newName: "IX_Transfer_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transfer",
                table: "Transfer",
                column: "TransferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfer_Customers_CustomerId",
                table: "Transfer",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
