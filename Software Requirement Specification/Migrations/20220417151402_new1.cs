using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaiTro_MonHoc_MonHocId",
                table: "VaiTro");

            migrationBuilder.DropIndex(
                name: "IX_VaiTro_MonHocId",
                table: "VaiTro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_VaiTro_MonHocId",
                table: "VaiTro",
                column: "MonHocId");

            migrationBuilder.AddForeignKey(
                name: "FK_VaiTro_MonHoc_MonHocId",
                table: "VaiTro",
                column: "MonHocId",
                principalTable: "MonHoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
