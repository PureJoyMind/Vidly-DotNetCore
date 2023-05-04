using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VidlyWeb.Migrations
{
    /// <inheritdoc />
    public partial class ExcludedNameFromMembershipTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "MembershipTypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "MembershipTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
