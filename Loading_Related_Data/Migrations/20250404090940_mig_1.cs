using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Loading_Related_Data_Eager_Loading.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Persons_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Region 1" },
                    { 2, "Region 2" },
                    { 3, "Region 3" },
                    { 4, "Region 4" },
                    { 5, "Region 5" },
                    { 6, "Region 6" },
                    { 7, "Region 7" },
                    { 8, "Region 8" },
                    { 9, "Region 9" },
                    { 10, "Region 10" },
                    { 11, "Region 11" },
                    { 12, "Region 12" },
                    { 13, "Region 13" },
                    { 14, "Region 14" },
                    { 15, "Region 15" },
                    { 16, "Region 16" },
                    { 17, "Region 17" },
                    { 18, "Region 18" },
                    { 19, "Region 19" },
                    { 20, "Region 20" },
                    { 21, "Region 21" },
                    { 22, "Region 22" },
                    { 23, "Region 23" },
                    { 24, "Region 24" },
                    { 25, "Region 25" },
                    { 26, "Region 26" },
                    { 27, "Region 27" },
                    { 28, "Region 28" },
                    { 29, "Region 29" },
                    { 30, "Region 30" },
                    { 31, "Region 31" },
                    { 32, "Region 32" },
                    { 33, "Region 33" },
                    { 34, "Region 34" },
                    { 35, "Region 35" },
                    { 36, "Region 36" },
                    { 37, "Region 37" },
                    { 38, "Region 38" },
                    { 39, "Region 39" },
                    { 40, "Region 40" },
                    { 41, "Region 41" },
                    { 42, "Region 42" },
                    { 43, "Region 43" },
                    { 44, "Region 44" },
                    { 45, "Region 45" },
                    { 46, "Region 46" },
                    { 47, "Region 47" },
                    { 48, "Region 48" },
                    { 49, "Region 49" },
                    { 50, "Region 50" },
                    { 51, "Region 51" },
                    { 52, "Region 52" },
                    { 53, "Region 53" },
                    { 54, "Region 54" },
                    { 55, "Region 55" },
                    { 56, "Region 56" },
                    { 57, "Region 57" },
                    { 58, "Region 58" },
                    { 59, "Region 59" },
                    { 60, "Region 60" },
                    { 61, "Region 61" },
                    { 62, "Region 62" },
                    { 63, "Region 63" },
                    { 64, "Region 64" },
                    { 65, "Region 65" },
                    { 66, "Region 66" },
                    { 67, "Region 67" },
                    { 68, "Region 68" },
                    { 69, "Region 69" },
                    { 70, "Region 70" },
                    { 71, "Region 71" },
                    { 72, "Region 72" },
                    { 73, "Region 73" },
                    { 74, "Region 74" },
                    { 75, "Region 75" },
                    { 76, "Region 76" },
                    { 77, "Region 77" },
                    { 78, "Region 78" },
                    { 79, "Region 79" },
                    { 80, "Region 80" },
                    { 81, "Region 81" },
                    { 82, "Region 82" },
                    { 83, "Region 83" },
                    { 84, "Region 84" },
                    { 85, "Region 85" },
                    { 86, "Region 86" },
                    { 87, "Region 87" },
                    { 88, "Region 88" },
                    { 89, "Region 89" },
                    { 90, "Region 90" },
                    { 91, "Region 91" },
                    { 92, "Region 92" },
                    { 93, "Region 93" },
                    { 94, "Region 94" },
                    { 95, "Region 95" },
                    { 96, "Region 96" },
                    { 97, "Region 97" },
                    { 98, "Region 98" },
                    { 99, "Region 99" },
                    { 100, "Region 100" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Discriminator", "Name", "RegionId", "Salary", "Surname" },
                values: new object[,]
                {
                    { 1, "Employee", "Ali 1", 1, 1001, "Veli 1" },
                    { 2, "Employee", "Ali 2", 2, 1002, "Veli 2" },
                    { 3, "Employee", "Ali 3", 3, 1003, "Veli 3" },
                    { 4, "Employee", "Ali 4", 4, 1004, "Veli 4" },
                    { 5, "Employee", "Ali 5", 5, 1005, "Veli 5" },
                    { 6, "Employee", "Ali 6", 6, 1006, "Veli 6" },
                    { 7, "Employee", "Ali 7", 7, 1007, "Veli 7" },
                    { 8, "Employee", "Ali 8", 8, 1008, "Veli 8" },
                    { 9, "Employee", "Ali 9", 9, 1009, "Veli 9" },
                    { 10, "Employee", "Ali 10", 10, 1010, "Veli 10" },
                    { 11, "Employee", "Ali 11", 11, 1011, "Veli 11" },
                    { 12, "Employee", "Ali 12", 12, 1012, "Veli 12" },
                    { 13, "Employee", "Ali 13", 13, 1013, "Veli 13" },
                    { 14, "Employee", "Ali 14", 14, 1014, "Veli 14" },
                    { 15, "Employee", "Ali 15", 15, 1015, "Veli 15" },
                    { 16, "Employee", "Ali 16", 16, 1016, "Veli 16" },
                    { 17, "Employee", "Ali 17", 17, 1017, "Veli 17" },
                    { 18, "Employee", "Ali 18", 18, 1018, "Veli 18" },
                    { 19, "Employee", "Ali 19", 19, 1019, "Veli 19" },
                    { 20, "Employee", "Ali 20", 20, 1020, "Veli 20" },
                    { 21, "Employee", "Ali 21", 21, 1021, "Veli 21" },
                    { 22, "Employee", "Ali 22", 22, 1022, "Veli 22" },
                    { 23, "Employee", "Ali 23", 23, 1023, "Veli 23" },
                    { 24, "Employee", "Ali 24", 24, 1024, "Veli 24" },
                    { 25, "Employee", "Ali 25", 25, 1025, "Veli 25" },
                    { 26, "Employee", "Ali 26", 26, 1026, "Veli 26" },
                    { 27, "Employee", "Ali 27", 27, 1027, "Veli 27" },
                    { 28, "Employee", "Ali 28", 28, 1028, "Veli 28" },
                    { 29, "Employee", "Ali 29", 29, 1029, "Veli 29" },
                    { 30, "Employee", "Ali 30", 30, 1030, "Veli 30" },
                    { 31, "Employee", "Ali 31", 31, 1031, "Veli 31" },
                    { 32, "Employee", "Ali 32", 32, 1032, "Veli 32" },
                    { 33, "Employee", "Ali 33", 33, 1033, "Veli 33" },
                    { 34, "Employee", "Ali 34", 34, 1034, "Veli 34" },
                    { 35, "Employee", "Ali 35", 35, 1035, "Veli 35" },
                    { 36, "Employee", "Ali 36", 36, 1036, "Veli 36" },
                    { 37, "Employee", "Ali 37", 37, 1037, "Veli 37" },
                    { 38, "Employee", "Ali 38", 38, 1038, "Veli 38" },
                    { 39, "Employee", "Ali 39", 39, 1039, "Veli 39" },
                    { 40, "Employee", "Ali 40", 40, 1040, "Veli 40" },
                    { 41, "Employee", "Ali 41", 41, 1041, "Veli 41" },
                    { 42, "Employee", "Ali 42", 42, 1042, "Veli 42" },
                    { 43, "Employee", "Ali 43", 43, 1043, "Veli 43" },
                    { 44, "Employee", "Ali 44", 44, 1044, "Veli 44" },
                    { 45, "Employee", "Ali 45", 45, 1045, "Veli 45" },
                    { 46, "Employee", "Ali 46", 46, 1046, "Veli 46" },
                    { 47, "Employee", "Ali 47", 47, 1047, "Veli 47" },
                    { 48, "Employee", "Ali 48", 48, 1048, "Veli 48" },
                    { 49, "Employee", "Ali 49", 49, 1049, "Veli 49" },
                    { 50, "Employee", "Ali 50", 50, 1050, "Veli 50" },
                    { 51, "Employee", "Ali 51", 51, 1051, "Veli 51" },
                    { 52, "Employee", "Ali 52", 52, 1052, "Veli 52" },
                    { 53, "Employee", "Ali 53", 53, 1053, "Veli 53" },
                    { 54, "Employee", "Ali 54", 54, 1054, "Veli 54" },
                    { 55, "Employee", "Ali 55", 55, 1055, "Veli 55" },
                    { 56, "Employee", "Ali 56", 56, 1056, "Veli 56" },
                    { 57, "Employee", "Ali 57", 57, 1057, "Veli 57" },
                    { 58, "Employee", "Ali 58", 58, 1058, "Veli 58" },
                    { 59, "Employee", "Ali 59", 59, 1059, "Veli 59" },
                    { 60, "Employee", "Ali 60", 60, 1060, "Veli 60" },
                    { 61, "Employee", "Ali 61", 61, 1061, "Veli 61" },
                    { 62, "Employee", "Ali 62", 62, 1062, "Veli 62" },
                    { 63, "Employee", "Ali 63", 63, 1063, "Veli 63" },
                    { 64, "Employee", "Ali 64", 64, 1064, "Veli 64" },
                    { 65, "Employee", "Ali 65", 65, 1065, "Veli 65" },
                    { 66, "Employee", "Ali 66", 66, 1066, "Veli 66" },
                    { 67, "Employee", "Ali 67", 67, 1067, "Veli 67" },
                    { 68, "Employee", "Ali 68", 68, 1068, "Veli 68" },
                    { 69, "Employee", "Ali 69", 69, 1069, "Veli 69" },
                    { 70, "Employee", "Ali 70", 70, 1070, "Veli 70" },
                    { 71, "Employee", "Ali 71", 71, 1071, "Veli 71" },
                    { 72, "Employee", "Ali 72", 72, 1072, "Veli 72" },
                    { 73, "Employee", "Ali 73", 73, 1073, "Veli 73" },
                    { 74, "Employee", "Ali 74", 74, 1074, "Veli 74" },
                    { 75, "Employee", "Ali 75", 75, 1075, "Veli 75" },
                    { 76, "Employee", "Ali 76", 76, 1076, "Veli 76" },
                    { 77, "Employee", "Ali 77", 77, 1077, "Veli 77" },
                    { 78, "Employee", "Ali 78", 78, 1078, "Veli 78" },
                    { 79, "Employee", "Ali 79", 79, 1079, "Veli 79" },
                    { 80, "Employee", "Ali 80", 80, 1080, "Veli 80" },
                    { 81, "Employee", "Ali 81", 81, 1081, "Veli 81" },
                    { 82, "Employee", "Ali 82", 82, 1082, "Veli 82" },
                    { 83, "Employee", "Ali 83", 83, 1083, "Veli 83" },
                    { 84, "Employee", "Ali 84", 84, 1084, "Veli 84" },
                    { 85, "Employee", "Ali 85", 85, 1085, "Veli 85" },
                    { 86, "Employee", "Ali 86", 86, 1086, "Veli 86" },
                    { 87, "Employee", "Ali 87", 87, 1087, "Veli 87" },
                    { 88, "Employee", "Ali 88", 88, 1088, "Veli 88" },
                    { 89, "Employee", "Ali 89", 89, 1089, "Veli 89" },
                    { 90, "Employee", "Ali 90", 90, 1090, "Veli 90" },
                    { 91, "Employee", "Ali 91", 91, 1091, "Veli 91" },
                    { 92, "Employee", "Ali 92", 92, 1092, "Veli 92" },
                    { 93, "Employee", "Ali 93", 93, 1093, "Veli 93" },
                    { 94, "Employee", "Ali 94", 94, 1094, "Veli 94" },
                    { 95, "Employee", "Ali 95", 95, 1095, "Veli 95" },
                    { 96, "Employee", "Ali 96", 96, 1096, "Veli 96" },
                    { 97, "Employee", "Ali 97", 97, 1097, "Veli 97" },
                    { 98, "Employee", "Ali 98", 98, 1098, "Veli 98" },
                    { 99, "Employee", "Ali 99", 99, 1099, "Veli 99" },
                    { 100, "Employee", "Ali 100", 100, 1100, "Veli 100" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "EmployeeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 },
                    { 11, 11 },
                    { 12, 12 },
                    { 13, 13 },
                    { 14, 14 },
                    { 15, 15 },
                    { 16, 16 },
                    { 17, 17 },
                    { 18, 18 },
                    { 19, 19 },
                    { 20, 20 },
                    { 21, 21 },
                    { 22, 22 },
                    { 23, 23 },
                    { 24, 24 },
                    { 25, 25 },
                    { 26, 26 },
                    { 27, 27 },
                    { 28, 28 },
                    { 29, 29 },
                    { 30, 30 },
                    { 31, 31 },
                    { 32, 32 },
                    { 33, 33 },
                    { 34, 34 },
                    { 35, 35 },
                    { 36, 36 },
                    { 37, 37 },
                    { 38, 38 },
                    { 39, 39 },
                    { 40, 40 },
                    { 41, 41 },
                    { 42, 42 },
                    { 43, 43 },
                    { 44, 44 },
                    { 45, 45 },
                    { 46, 46 },
                    { 47, 47 },
                    { 48, 48 },
                    { 49, 49 },
                    { 50, 50 },
                    { 51, 51 },
                    { 52, 52 },
                    { 53, 53 },
                    { 54, 54 },
                    { 55, 55 },
                    { 56, 56 },
                    { 57, 57 },
                    { 58, 58 },
                    { 59, 59 },
                    { 60, 60 },
                    { 61, 61 },
                    { 62, 62 },
                    { 63, 63 },
                    { 64, 64 },
                    { 65, 65 },
                    { 66, 66 },
                    { 67, 67 },
                    { 68, 68 },
                    { 69, 69 },
                    { 70, 70 },
                    { 71, 71 },
                    { 72, 72 },
                    { 73, 73 },
                    { 74, 74 },
                    { 75, 75 },
                    { 76, 76 },
                    { 77, 77 },
                    { 78, 78 },
                    { 79, 79 },
                    { 80, 80 },
                    { 81, 81 },
                    { 82, 82 },
                    { 83, 83 },
                    { 84, 84 },
                    { 85, 85 },
                    { 86, 86 },
                    { 87, 87 },
                    { 88, 88 },
                    { 89, 89 },
                    { 90, 90 },
                    { 91, 91 },
                    { 92, 92 },
                    { 93, 93 },
                    { 94, 94 },
                    { 95, 95 },
                    { 96, 96 },
                    { 97, 97 },
                    { 98, 98 },
                    { 99, 99 },
                    { 100, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeId",
                table: "Orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_RegionId",
                table: "Persons",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
