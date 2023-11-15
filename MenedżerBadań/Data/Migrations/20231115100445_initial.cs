using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenedżerBadań.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_deviceEntity",
                table: "deviceEntity");

            migrationBuilder.RenameTable(
                name: "deviceEntity",
                newName: "DeviceEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceEntity",
                table: "DeviceEntity",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceEntity",
                table: "DeviceEntity");

            migrationBuilder.RenameTable(
                name: "DeviceEntity",
                newName: "deviceEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_deviceEntity",
                table: "deviceEntity",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntity", x => x.Id);
                });
        }
    }
}
