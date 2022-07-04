using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeDataLib.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpName = table.Column<string>(type: "Varchar(50)", nullable: true),
                    EmpPhone = table.Column<string>(type: "char(10)", nullable: true),
                    EmpAddress = table.Column<string>(type: "Varchar(100)", nullable: true),
                    EmpEmail = table.Column<string>(type: "Varchar(20)", nullable: true),
                    Password = table.Column<string>(type: "Varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.EmpId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
