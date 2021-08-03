using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankWebAPI.Migrations
{
    public partial class bankdb20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Customers_CustomerId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Customers_CustomerId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Accounts_AccountId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Customers_CustomerId",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Customers_CustomerId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ReceiverIBAN",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SenderIBAN",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionBalance",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "TransactionFee",
                table: "Transactions",
                newName: "TransactionAmount");

            migrationBuilder.RenameColumn(
                name: "IsPaid",
                table: "Bills",
                newName: "IsApproved");

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Transfer",
                columns: table => new
                {
                    TransferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferAmount = table.Column<double>(type: "float", nullable: false),
                    TransferFee = table.Column<double>(type: "float", nullable: false),
                    SenderIBAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiverIBAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfer", x => x.TransferId);
                    table.ForeignKey(
                        name: "FK_Transfer_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_CustomerId",
                table: "Transfer",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Customers_CustomerId",
                table: "Accounts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Customers_CustomerId",
                table: "Bills",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Accounts_AccountId",
                table: "Cards",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Customers_CustomerId",
                table: "Loans",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Customers_CustomerId",
                table: "Transactions",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Customers_CustomerId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Customers_CustomerId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Accounts_AccountId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Customers_CustomerId",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Customers_CustomerId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "Transfer");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "TransactionAmount",
                table: "Transactions",
                newName: "TransactionFee");

            migrationBuilder.RenameColumn(
                name: "IsApproved",
                table: "Bills",
                newName: "IsPaid");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverIBAN",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderIBAN",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TransactionBalance",
                table: "Transactions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Customers_CustomerId",
                table: "Accounts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Customers_CustomerId",
                table: "Bills",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Accounts_AccountId",
                table: "Cards",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Customers_CustomerId",
                table: "Loans",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Customers_CustomerId",
                table: "Transactions",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
