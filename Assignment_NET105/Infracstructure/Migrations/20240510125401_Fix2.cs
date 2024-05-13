using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_NET105.Migrations
{
    /// <inheritdoc />
    public partial class Fix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDonCT_HoaDon_ID_HoaDonCT",
                table: "HoaDonCT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_HoaDonCT_HoaDon_ID_HoaDonCT",
                table: "HoaDonCT",
                column: "ID_HoaDonCT",
                principalTable: "HoaDon",
                principalColumn: "ID_HoaDon",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
