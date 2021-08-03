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

            


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.RenameColumn(
                name: "IsPaid",
                table: "Bills",
                newName: "IsApproved");
        }
    }
}
