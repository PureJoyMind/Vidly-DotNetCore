using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VidlyWeb.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEnumToMembershipType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NameId",
                table: "MembershipTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameId",
                table: "MembershipTypes");
        }
    }
}
