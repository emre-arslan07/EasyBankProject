using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyBankProject.DAL.Migrations
{
    public partial class mig_description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CustomerAccountProcesses",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CustomerAccountProcesses");
        }
    }
}
