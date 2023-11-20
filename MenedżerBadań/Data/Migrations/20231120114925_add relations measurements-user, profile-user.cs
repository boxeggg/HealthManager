using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenedżerBadań.Data.Migrations
{
    /// <inheritdoc />
    public partial class addrelationsmeasurementsuserprofileuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BloodType",
                table: "ProfileEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Height",
                table: "ProfileEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ProfileEntity",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Weight",
                table: "ProfileEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MeasurementEntity",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProfileID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileEntity_UserId",
                table: "ProfileEntity",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementEntity_UserId",
                table: "MeasurementEntity",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeasurementEntity_AspNetUsers_UserId",
                table: "MeasurementEntity",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileEntity_AspNetUsers_UserId",
                table: "ProfileEntity",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeasurementEntity_AspNetUsers_UserId",
                table: "MeasurementEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileEntity_AspNetUsers_UserId",
                table: "ProfileEntity");

            migrationBuilder.DropIndex(
                name: "IX_ProfileEntity_UserId",
                table: "ProfileEntity");

            migrationBuilder.DropIndex(
                name: "IX_MeasurementEntity_UserId",
                table: "MeasurementEntity");

            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "ProfileEntity");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "ProfileEntity");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProfileEntity");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "ProfileEntity");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MeasurementEntity");

            migrationBuilder.DropColumn(
                name: "ProfileID",
                table: "AspNetUsers");
        }
    }
}
