using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class lh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDung_LopHoc_LopHocId",
                table: "NguoiDung");

            migrationBuilder.DropIndex(
                name: "IX_NguoiDung_LopHocId",
                table: "NguoiDung");

            migrationBuilder.DropColumn(
                name: "LopHocId",
                table: "NguoiDung");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LopHocId",
                table: "NguoiDung",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_LopHocId",
                table: "NguoiDung",
                column: "LopHocId");

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDung_LopHoc_LopHocId",
                table: "NguoiDung",
                column: "LopHocId",
                principalTable: "LopHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
