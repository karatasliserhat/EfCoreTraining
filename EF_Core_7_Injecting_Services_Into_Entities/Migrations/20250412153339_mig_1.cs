using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_Core_7_Injecting_Services_Into_Entities.Migrations
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Person 1" },
                    { 2, "Person 2" },
                    { 3, "Person 3" },
                    { 4, "Person 4" },
                    { 5, "Person 5" },
                    { 6, "Person 6" },
                    { 7, "Person 7" },
                    { 8, "Person 8" },
                    { 9, "Person 9" },
                    { 10, "Person 10" },
                    { 11, "Person 11" },
                    { 12, "Person 12" },
                    { 13, "Person 13" },
                    { 14, "Person 14" },
                    { 15, "Person 15" },
                    { 16, "Person 16" },
                    { 17, "Person 17" },
                    { 18, "Person 18" },
                    { 19, "Person 19" },
                    { 20, "Person 20" },
                    { 21, "Person 21" },
                    { 22, "Person 22" },
                    { 23, "Person 23" },
                    { 24, "Person 24" },
                    { 25, "Person 25" },
                    { 26, "Person 26" },
                    { 27, "Person 27" },
                    { 28, "Person 28" },
                    { 29, "Person 29" },
                    { 30, "Person 30" },
                    { 31, "Person 31" },
                    { 32, "Person 32" },
                    { 33, "Person 33" },
                    { 34, "Person 34" },
                    { 35, "Person 35" },
                    { 36, "Person 36" },
                    { 37, "Person 37" },
                    { 38, "Person 38" },
                    { 39, "Person 39" },
                    { 40, "Person 40" },
                    { 41, "Person 41" },
                    { 42, "Person 42" },
                    { 43, "Person 43" },
                    { 44, "Person 44" },
                    { 45, "Person 45" },
                    { 46, "Person 46" },
                    { 47, "Person 47" },
                    { 48, "Person 48" },
                    { 49, "Person 49" },
                    { 50, "Person 50" },
                    { 51, "Person 51" },
                    { 52, "Person 52" },
                    { 53, "Person 53" },
                    { 54, "Person 54" },
                    { 55, "Person 55" },
                    { 56, "Person 56" },
                    { 57, "Person 57" },
                    { 58, "Person 58" },
                    { 59, "Person 59" },
                    { 60, "Person 60" },
                    { 61, "Person 61" },
                    { 62, "Person 62" },
                    { 63, "Person 63" },
                    { 64, "Person 64" },
                    { 65, "Person 65" },
                    { 66, "Person 66" },
                    { 67, "Person 67" },
                    { 68, "Person 68" },
                    { 69, "Person 69" },
                    { 70, "Person 70" },
                    { 71, "Person 71" },
                    { 72, "Person 72" },
                    { 73, "Person 73" },
                    { 74, "Person 74" },
                    { 75, "Person 75" },
                    { 76, "Person 76" },
                    { 77, "Person 77" },
                    { 78, "Person 78" },
                    { 79, "Person 79" },
                    { 80, "Person 80" },
                    { 81, "Person 81" },
                    { 82, "Person 82" },
                    { 83, "Person 83" },
                    { 84, "Person 84" },
                    { 85, "Person 85" },
                    { 86, "Person 86" },
                    { 87, "Person 87" },
                    { 88, "Person 88" },
                    { 89, "Person 89" },
                    { 90, "Person 90" },
                    { 91, "Person 91" },
                    { 92, "Person 92" },
                    { 93, "Person 93" },
                    { 94, "Person 94" },
                    { 95, "Person 95" },
                    { 96, "Person 96" },
                    { 97, "Person 97" },
                    { 98, "Person 98" },
                    { 99, "Person 99" },
                    { 100, "Person 100" }
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
