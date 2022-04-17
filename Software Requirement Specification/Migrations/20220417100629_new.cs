using Microsoft.EntityFrameworkCore.Migrations;

namespace Software_Requirement_Specification.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonHoc",
                table: "VaiTro");

            migrationBuilder.DropColumn(
                name: "SoTaiLieuChoDuyet",
                table: "TaiLieu");

            migrationBuilder.AddColumn<int>(
                name: "MonHocId",
                table: "VaiTro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TenTaiLieu",
                table: "TaiLieu",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaiTro_MonHoc_MonHocId",
                table: "VaiTro");

            migrationBuilder.DropIndex(
                name: "IX_VaiTro_MonHocId",
                table: "VaiTro");

            migrationBuilder.DropColumn(
                name: "MonHocId",
                table: "VaiTro");

            migrationBuilder.DropColumn(
                name: "TenTaiLieu",
                table: "TaiLieu");

            migrationBuilder.AddColumn<string>(
                name: "MonHoc",
                table: "VaiTro",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoTaiLieuChoDuyet",
                table: "TaiLieu",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
