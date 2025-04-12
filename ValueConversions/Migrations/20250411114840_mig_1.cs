using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ValueConversions.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender2 = table.Column<int>(type: "int", nullable: false),
                    Married = table.Column<bool>(type: "bit", nullable: false),
                    Titles = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Gender", "Gender2", "Married", "Name", "Titles" },
                values: new object[,]
                {
                    { 1, "M", 0, true, "Serhat", null },
                    { 2, "M", 0, false, "Kamil", null },
                    { 3, "M", 0, true, "Cemil", null },
                    { 4, "M", 0, true, "Boran", null },
                    { 5, "F", 1, false, "Selin", null },
                    { 6, "F", 1, false, "Şeyma", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
