using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vosplzen.sem2h1.Migrations
{
    /// <inheritdoc />
    public partial class chan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "externalId",
                table: "Students",
                newName: "ExternalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExternalId",
                table: "Students",
                newName: "externalId");
        }
    }
}
