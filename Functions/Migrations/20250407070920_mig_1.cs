using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Functions.Migrations
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

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Description", "PersonId", "Price" },
                values: new object[,]
                {
                    { 1, "Order 1", 1, 10 },
                    { 2, "Order 2", 2, 20 },
                    { 3, "Order 3", 3, 30 },
                    { 4, "Order 4", 4, 40 },
                    { 5, "Order 5", 5, 50 },
                    { 6, "Order 6", 6, 60 },
                    { 7, "Order 7", 7, 70 },
                    { 8, "Order 8", 8, 80 },
                    { 9, "Order 9", 9, 90 },
                    { 10, "Order 10", 10, 100 },
                    { 11, "Order 11", 11, 110 },
                    { 12, "Order 12", 12, 120 },
                    { 13, "Order 13", 13, 130 },
                    { 14, "Order 14", 14, 140 },
                    { 15, "Order 15", 15, 150 },
                    { 16, "Order 16", 16, 160 },
                    { 17, "Order 17", 17, 170 },
                    { 18, "Order 18", 18, 180 },
                    { 19, "Order 19", 19, 190 },
                    { 20, "Order 20", 20, 200 },
                    { 21, "Order 21", 21, 210 },
                    { 22, "Order 22", 22, 220 },
                    { 23, "Order 23", 23, 230 },
                    { 24, "Order 24", 24, 240 },
                    { 25, "Order 25", 25, 250 },
                    { 26, "Order 26", 26, 260 },
                    { 27, "Order 27", 27, 270 },
                    { 28, "Order 28", 28, 280 },
                    { 29, "Order 29", 29, 290 },
                    { 30, "Order 30", 30, 300 },
                    { 31, "Order 31", 31, 310 },
                    { 32, "Order 32", 32, 320 },
                    { 33, "Order 33", 33, 330 },
                    { 34, "Order 34", 34, 340 },
                    { 35, "Order 35", 35, 350 },
                    { 36, "Order 36", 36, 360 },
                    { 37, "Order 37", 37, 370 },
                    { 38, "Order 38", 38, 380 },
                    { 39, "Order 39", 39, 390 },
                    { 40, "Order 40", 40, 400 },
                    { 41, "Order 41", 41, 410 },
                    { 42, "Order 42", 42, 420 },
                    { 43, "Order 43", 43, 430 },
                    { 44, "Order 44", 44, 440 },
                    { 45, "Order 45", 45, 450 },
                    { 46, "Order 46", 46, 460 },
                    { 47, "Order 47", 47, 470 },
                    { 48, "Order 48", 48, 480 },
                    { 49, "Order 49", 49, 490 },
                    { 50, "Order 50", 50, 500 },
                    { 51, "Order 51", 51, 510 },
                    { 52, "Order 52", 52, 520 },
                    { 53, "Order 53", 53, 530 },
                    { 54, "Order 54", 54, 540 },
                    { 55, "Order 55", 55, 550 },
                    { 56, "Order 56", 56, 560 },
                    { 57, "Order 57", 57, 570 },
                    { 58, "Order 58", 58, 580 },
                    { 59, "Order 59", 59, 590 },
                    { 60, "Order 60", 60, 600 },
                    { 61, "Order 61", 61, 610 },
                    { 62, "Order 62", 62, 620 },
                    { 63, "Order 63", 63, 630 },
                    { 64, "Order 64", 64, 640 },
                    { 65, "Order 65", 65, 650 },
                    { 66, "Order 66", 66, 660 },
                    { 67, "Order 67", 67, 670 },
                    { 68, "Order 68", 68, 680 },
                    { 69, "Order 69", 69, 690 },
                    { 70, "Order 70", 70, 700 },
                    { 71, "Order 71", 71, 710 },
                    { 72, "Order 72", 72, 720 },
                    { 73, "Order 73", 73, 730 },
                    { 74, "Order 74", 74, 740 },
                    { 75, "Order 75", 75, 750 },
                    { 76, "Order 76", 76, 760 },
                    { 77, "Order 77", 77, 770 },
                    { 78, "Order 78", 78, 780 },
                    { 79, "Order 79", 79, 790 },
                    { 80, "Order 80", 80, 800 },
                    { 81, "Order 81", 81, 810 },
                    { 82, "Order 82", 82, 820 },
                    { 83, "Order 83", 83, 830 },
                    { 84, "Order 84", 84, 840 },
                    { 85, "Order 85", 85, 850 },
                    { 86, "Order 86", 86, 860 },
                    { 87, "Order 87", 87, 870 },
                    { 88, "Order 88", 88, 880 },
                    { 89, "Order 89", 89, 890 },
                    { 90, "Order 90", 90, 900 },
                    { 91, "Order 91", 91, 910 },
                    { 92, "Order 92", 92, 920 },
                    { 93, "Order 93", 93, 930 },
                    { 94, "Order 94", 94, 940 },
                    { 95, "Order 95", 95, 950 },
                    { 96, "Order 96", 96, 960 },
                    { 97, "Order 97", 97, 970 },
                    { 98, "Order 98", 98, 980 },
                    { 99, "Order 99", 99, 990 },
                    { 100, "Order 100", 100, 1000 }
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
                name: "Persons");
        }
    }
}
