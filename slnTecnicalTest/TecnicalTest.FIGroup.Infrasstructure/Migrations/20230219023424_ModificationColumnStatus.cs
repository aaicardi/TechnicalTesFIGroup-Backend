using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TecnicalTest.FIGroup.Infrastructure.Migrations
{
    public partial class ModificationColumnStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                schema: "FIGroup",
                table: "Task",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.UpdateData(
                schema: "FIGroup",
                table: "Task",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                schema: "FIGroup",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.UpdateData(
                schema: "FIGroup",
                table: "Task",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);
        }
    }
}
