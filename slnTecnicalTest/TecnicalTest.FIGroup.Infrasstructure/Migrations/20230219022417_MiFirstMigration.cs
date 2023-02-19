using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TecnicalTest.FIGroup.Infrastructure.Migrations
{
    public partial class MiFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FIGroup");

            migrationBuilder.CreateTable(
                name: "Task",
                schema: "FIGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "FIGroup",
                table: "Task",
                columns: new[] { "Id", "Description", "IsCompleted", "Status" },
                values: new object[] { 1, "Tarea de prueba", false, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Task_Id",
                schema: "FIGroup",
                table: "Task",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task",
                schema: "FIGroup");
        }
    }
}
