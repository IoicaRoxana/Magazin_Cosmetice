using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazin_Cosmetice.Migrations
{
    public partial class newmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produs_Status_StatusID",
                table: "Produs");

            migrationBuilder.AlterColumn<int>(
                name: "StatusID",
                table: "Produs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Produs_Status_StatusID",
                table: "Produs",
                column: "StatusID",
                principalTable: "Status",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produs_Status_StatusID",
                table: "Produs");

            migrationBuilder.AlterColumn<int>(
                name: "StatusID",
                table: "Produs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produs_Status_StatusID",
                table: "Produs",
                column: "StatusID",
                principalTable: "Status",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
