using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoLot.Dal.EfStructures.Migrations
{
    public partial class Initial_Fixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonalInformation_LastName",
                table: "Customers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "PersonalInformation_LastName",
                table: "CreditRisks",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Customers",
                newName: "PersonalInformation_LastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "CreditRisks",
                newName: "PersonalInformation_LastName");
        }
    }
}
