using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindProfessionals.Data.Migrations
{
    /// <inheritdoc />
    public partial class removeconfirmpasswordofuserentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Users",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }
    }
}
