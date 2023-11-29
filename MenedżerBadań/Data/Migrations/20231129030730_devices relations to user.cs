using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenedżerBadań.Data.Migrations
{
    /// <inheritdoc />
    public partial class devicesrelationstouser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "DeviceEntity",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceEntity_UserId",
                table: "DeviceEntity",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceEntity_AspNetUsers_UserId",
                table: "DeviceEntity",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceEntity_AspNetUsers_UserId",
                table: "DeviceEntity");

            migrationBuilder.DropIndex(
                name: "IX_DeviceEntity_UserId",
                table: "DeviceEntity");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DeviceEntity");
        }
    }
}
