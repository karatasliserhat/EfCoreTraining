using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inheritance_Table_Per_Hierarchy.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "A",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Technician_A",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "A",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Technician_A",
                table: "Persons");
        }
    }
}
