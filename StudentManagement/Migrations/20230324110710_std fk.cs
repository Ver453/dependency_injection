using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagement.Migrations
{
    public partial class stdfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Academics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Academics_StudentId",
                table: "Academics",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Academics_Students_StudentId",
                table: "Academics",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Academics_Students_StudentId",
                table: "Academics");

            migrationBuilder.DropIndex(
                name: "IX_Academics_StudentId",
                table: "Academics");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Academics");
        }
    }
}
