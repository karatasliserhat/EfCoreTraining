using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Complex_Relational_Queries.Migrations
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Photos_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Gender", "Name" },
                values: new object[,]
                {
                    { 1, 0, "Person 1" },
                    { 2, 0, "Person 2" },
                    { 3, 0, "Person 3" },
                    { 4, 0, "Person 4" },
                    { 5, 0, "Person 5" },
                    { 6, 0, "Person 6" },
                    { 7, 0, "Person 7" },
                    { 8, 0, "Person 8" },
                    { 9, 0, "Person 9" },
                    { 10, 0, "Person 10" },
                    { 11, 0, "Person 11" },
                    { 12, 0, "Person 12" },
                    { 13, 0, "Person 13" },
                    { 14, 0, "Person 14" },
                    { 15, 0, "Person 15" },
                    { 16, 0, "Person 16" },
                    { 17, 0, "Person 17" },
                    { 18, 0, "Person 18" },
                    { 19, 0, "Person 19" },
                    { 20, 0, "Person 20" },
                    { 21, 0, "Person 21" },
                    { 22, 0, "Person 22" },
                    { 23, 0, "Person 23" },
                    { 24, 0, "Person 24" },
                    { 25, 0, "Person 25" },
                    { 26, 0, "Person 26" },
                    { 27, 0, "Person 27" },
                    { 28, 0, "Person 28" },
                    { 29, 0, "Person 29" },
                    { 30, 0, "Person 30" },
                    { 31, 0, "Person 31" },
                    { 32, 0, "Person 32" },
                    { 33, 0, "Person 33" },
                    { 34, 0, "Person 34" },
                    { 35, 0, "Person 35" },
                    { 36, 0, "Person 36" },
                    { 37, 0, "Person 37" },
                    { 38, 0, "Person 38" },
                    { 39, 0, "Person 39" },
                    { 40, 0, "Person 40" },
                    { 41, 0, "Person 41" },
                    { 42, 0, "Person 42" },
                    { 43, 0, "Person 43" },
                    { 44, 0, "Person 44" },
                    { 45, 0, "Person 45" },
                    { 46, 0, "Person 46" },
                    { 47, 0, "Person 47" },
                    { 48, 0, "Person 48" },
                    { 49, 0, "Person 49" },
                    { 50, 0, "Person 50" },
                    { 51, 1, "Person 51" },
                    { 52, 1, "Person 52" },
                    { 53, 1, "Person 53" },
                    { 54, 1, "Person 54" },
                    { 55, 1, "Person 55" },
                    { 56, 1, "Person 56" },
                    { 57, 1, "Person 57" },
                    { 58, 1, "Person 58" },
                    { 59, 1, "Person 59" },
                    { 60, 1, "Person 60" },
                    { 61, 1, "Person 61" },
                    { 62, 1, "Person 62" },
                    { 63, 1, "Person 63" },
                    { 64, 1, "Person 64" },
                    { 65, 1, "Person 65" },
                    { 66, 1, "Person 66" },
                    { 67, 1, "Person 67" },
                    { 68, 1, "Person 68" },
                    { 69, 1, "Person 69" },
                    { 70, 1, "Person 70" },
                    { 71, 1, "Person 71" },
                    { 72, 1, "Person 72" },
                    { 73, 1, "Person 73" },
                    { 74, 1, "Person 74" },
                    { 75, 1, "Person 75" },
                    { 76, 1, "Person 76" },
                    { 77, 1, "Person 77" },
                    { 78, 1, "Person 78" },
                    { 79, 1, "Person 79" },
                    { 80, 1, "Person 80" },
                    { 81, 1, "Person 81" },
                    { 82, 1, "Person 82" },
                    { 83, 1, "Person 83" },
                    { 84, 1, "Person 84" },
                    { 85, 1, "Person 85" },
                    { 86, 1, "Person 86" },
                    { 87, 1, "Person 87" },
                    { 88, 1, "Person 88" },
                    { 89, 1, "Person 89" },
                    { 90, 1, "Person 90" },
                    { 91, 1, "Person 91" },
                    { 92, 1, "Person 92" },
                    { 93, 1, "Person 93" },
                    { 94, 1, "Person 94" },
                    { 95, 1, "Person 95" },
                    { 96, 1, "Person 96" },
                    { 97, 1, "Person 97" },
                    { 98, 1, "Person 98" },
                    { 99, 1, "Person 99" },
                    { 100, 1, "Person 100" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Description", "PersonId" },
                values: new object[,]
                {
                    { 1, "Order 1", 1 },
                    { 2, "Order 2", 2 },
                    { 3, "Order 3", 3 },
                    { 4, "Order 4", 4 },
                    { 5, "Order 5", 5 },
                    { 6, "Order 6", 6 },
                    { 7, "Order 7", 7 },
                    { 8, "Order 8", 8 },
                    { 9, "Order 9", 9 },
                    { 10, "Order 10", 10 },
                    { 11, "Order 11", 11 },
                    { 12, "Order 12", 12 },
                    { 13, "Order 13", 13 },
                    { 14, "Order 14", 14 },
                    { 15, "Order 15", 15 },
                    { 16, "Order 16", 16 },
                    { 17, "Order 17", 17 },
                    { 18, "Order 18", 18 },
                    { 19, "Order 19", 19 },
                    { 20, "Order 20", 20 },
                    { 21, "Order 21", 21 },
                    { 22, "Order 22", 22 },
                    { 23, "Order 23", 23 },
                    { 24, "Order 24", 24 },
                    { 25, "Order 25", 25 },
                    { 26, "Order 26", 26 },
                    { 27, "Order 27", 27 },
                    { 28, "Order 28", 28 },
                    { 29, "Order 29", 29 },
                    { 30, "Order 30", 30 },
                    { 31, "Order 31", 31 },
                    { 32, "Order 32", 32 },
                    { 33, "Order 33", 33 },
                    { 34, "Order 34", 34 },
                    { 35, "Order 35", 35 },
                    { 36, "Order 36", 36 },
                    { 37, "Order 37", 37 },
                    { 38, "Order 38", 38 },
                    { 39, "Order 39", 39 },
                    { 40, "Order 40", 40 },
                    { 41, "Order 41", 41 },
                    { 42, "Order 42", 42 },
                    { 43, "Order 43", 43 },
                    { 44, "Order 44", 44 },
                    { 45, "Order 45", 45 },
                    { 46, "Order 46", 46 },
                    { 47, "Order 47", 47 },
                    { 48, "Order 48", 48 },
                    { 49, "Order 49", 49 },
                    { 50, "Order 50", 50 },
                    { 51, "Order 51", 51 },
                    { 52, "Order 52", 52 },
                    { 53, "Order 53", 53 },
                    { 54, "Order 54", 54 },
                    { 55, "Order 55", 55 },
                    { 56, "Order 56", 56 },
                    { 57, "Order 57", 57 },
                    { 58, "Order 58", 58 },
                    { 59, "Order 59", 59 },
                    { 60, "Order 60", 60 },
                    { 61, "Order 61", 61 },
                    { 62, "Order 62", 62 },
                    { 63, "Order 63", 63 },
                    { 64, "Order 64", 64 },
                    { 65, "Order 65", 65 },
                    { 66, "Order 66", 66 },
                    { 67, "Order 67", 67 },
                    { 68, "Order 68", 68 },
                    { 69, "Order 69", 69 },
                    { 70, "Order 70", 70 },
                    { 71, "Order 71", 71 },
                    { 72, "Order 72", 72 },
                    { 73, "Order 73", 73 },
                    { 74, "Order 74", 74 },
                    { 75, "Order 75", 75 },
                    { 76, "Order 76", 76 },
                    { 77, "Order 77", 77 },
                    { 78, "Order 78", 78 },
                    { 79, "Order 79", 79 },
                    { 80, "Order 80", 80 },
                    { 81, "Order 81", 81 },
                    { 82, "Order 82", 82 },
                    { 83, "Order 83", 83 },
                    { 84, "Order 84", 84 },
                    { 85, "Order 85", 85 },
                    { 86, "Order 86", 86 },
                    { 87, "Order 87", 87 },
                    { 88, "Order 88", 88 },
                    { 89, "Order 89", 89 },
                    { 90, "Order 90", 90 },
                    { 91, "Order 91", 91 },
                    { 92, "Order 92", 92 },
                    { 93, "Order 93", 93 },
                    { 94, "Order 94", 94 },
                    { 95, "Order 95", 95 },
                    { 96, "Order 96", 96 },
                    { 97, "Order 97", 97 },
                    { 98, "Order 98", 98 },
                    { 99, "Order 99", 99 },
                    { 100, "Order 100", 100 }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "PersonId", "Url" },
                values: new object[,]
                {
                    { 1, "https://example.com/photo1.jpg" },
                    { 2, "https://example.com/photo2.jpg" },
                    { 3, "https://example.com/photo3.jpg" },
                    { 4, "https://example.com/photo4.jpg" },
                    { 5, "https://example.com/photo5.jpg" },
                    { 6, "https://example.com/photo6.jpg" },
                    { 7, "https://example.com/photo7.jpg" },
                    { 8, "https://example.com/photo8.jpg" },
                    { 9, "https://example.com/photo9.jpg" },
                    { 10, "https://example.com/photo10.jpg" },
                    { 11, "https://example.com/photo11.jpg" },
                    { 12, "https://example.com/photo12.jpg" },
                    { 13, "https://example.com/photo13.jpg" },
                    { 14, "https://example.com/photo14.jpg" },
                    { 15, "https://example.com/photo15.jpg" },
                    { 16, "https://example.com/photo16.jpg" },
                    { 17, "https://example.com/photo17.jpg" },
                    { 18, "https://example.com/photo18.jpg" },
                    { 19, "https://example.com/photo19.jpg" },
                    { 20, "https://example.com/photo20.jpg" },
                    { 21, "https://example.com/photo21.jpg" },
                    { 22, "https://example.com/photo22.jpg" },
                    { 23, "https://example.com/photo23.jpg" },
                    { 24, "https://example.com/photo24.jpg" },
                    { 25, "https://example.com/photo25.jpg" },
                    { 26, "https://example.com/photo26.jpg" },
                    { 27, "https://example.com/photo27.jpg" },
                    { 28, "https://example.com/photo28.jpg" },
                    { 29, "https://example.com/photo29.jpg" },
                    { 30, "https://example.com/photo30.jpg" },
                    { 31, "https://example.com/photo31.jpg" },
                    { 32, "https://example.com/photo32.jpg" },
                    { 33, "https://example.com/photo33.jpg" },
                    { 34, "https://example.com/photo34.jpg" },
                    { 35, "https://example.com/photo35.jpg" },
                    { 36, "https://example.com/photo36.jpg" },
                    { 37, "https://example.com/photo37.jpg" },
                    { 38, "https://example.com/photo38.jpg" },
                    { 39, "https://example.com/photo39.jpg" },
                    { 40, "https://example.com/photo40.jpg" },
                    { 41, "https://example.com/photo41.jpg" },
                    { 42, "https://example.com/photo42.jpg" },
                    { 43, "https://example.com/photo43.jpg" },
                    { 44, "https://example.com/photo44.jpg" },
                    { 45, "https://example.com/photo45.jpg" },
                    { 46, "https://example.com/photo46.jpg" },
                    { 47, "https://example.com/photo47.jpg" },
                    { 48, "https://example.com/photo48.jpg" },
                    { 49, "https://example.com/photo49.jpg" },
                    { 50, "https://example.com/photo50.jpg" },
                    { 51, "https://example.com/photo51.jpg" },
                    { 52, "https://example.com/photo52.jpg" },
                    { 53, "https://example.com/photo53.jpg" },
                    { 54, "https://example.com/photo54.jpg" },
                    { 55, "https://example.com/photo55.jpg" },
                    { 56, "https://example.com/photo56.jpg" },
                    { 57, "https://example.com/photo57.jpg" },
                    { 58, "https://example.com/photo58.jpg" },
                    { 59, "https://example.com/photo59.jpg" },
                    { 60, "https://example.com/photo60.jpg" },
                    { 61, "https://example.com/photo61.jpg" },
                    { 62, "https://example.com/photo62.jpg" },
                    { 63, "https://example.com/photo63.jpg" },
                    { 64, "https://example.com/photo64.jpg" },
                    { 65, "https://example.com/photo65.jpg" },
                    { 66, "https://example.com/photo66.jpg" },
                    { 67, "https://example.com/photo67.jpg" },
                    { 68, "https://example.com/photo68.jpg" },
                    { 69, "https://example.com/photo69.jpg" },
                    { 70, "https://example.com/photo70.jpg" },
                    { 71, "https://example.com/photo71.jpg" },
                    { 72, "https://example.com/photo72.jpg" },
                    { 73, "https://example.com/photo73.jpg" },
                    { 74, "https://example.com/photo74.jpg" },
                    { 75, "https://example.com/photo75.jpg" },
                    { 76, "https://example.com/photo76.jpg" },
                    { 77, "https://example.com/photo77.jpg" },
                    { 78, "https://example.com/photo78.jpg" },
                    { 79, "https://example.com/photo79.jpg" },
                    { 80, "https://example.com/photo80.jpg" },
                    { 81, "https://example.com/photo81.jpg" },
                    { 82, "https://example.com/photo82.jpg" },
                    { 83, "https://example.com/photo83.jpg" },
                    { 84, "https://example.com/photo84.jpg" },
                    { 85, "https://example.com/photo85.jpg" },
                    { 86, "https://example.com/photo86.jpg" },
                    { 87, "https://example.com/photo87.jpg" },
                    { 88, "https://example.com/photo88.jpg" },
                    { 89, "https://example.com/photo89.jpg" },
                    { 90, "https://example.com/photo90.jpg" },
                    { 91, "https://example.com/photo91.jpg" },
                    { 92, "https://example.com/photo92.jpg" },
                    { 93, "https://example.com/photo93.jpg" },
                    { 94, "https://example.com/photo94.jpg" },
                    { 95, "https://example.com/photo95.jpg" },
                    { 96, "https://example.com/photo96.jpg" },
                    { 97, "https://example.com/photo97.jpg" },
                    { 98, "https://example.com/photo98.jpg" },
                    { 99, "https://example.com/photo99.jpg" },
                    { 100, "https://example.com/photo100.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PersonId",
                table: "Orders",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
