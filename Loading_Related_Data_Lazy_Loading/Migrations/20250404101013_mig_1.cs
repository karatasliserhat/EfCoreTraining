using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Loading_Related_Data_Lazy_Loading.Migrations
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
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Regions_RegionId",
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
                        name: "FK_Orders_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
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
                table: "Employees",
                columns: new[] { "Id", "Name", "RegionId", "Salary", "Surname" },
                values: new object[,]
                {
                    { 1, "Ali 1", 1, 1001, "Veli 1" },
                    { 2, "Ali 2", 2, 1002, "Veli 2" },
                    { 3, "Ali 3", 3, 1003, "Veli 3" },
                    { 4, "Ali 4", 4, 1004, "Veli 4" },
                    { 5, "Ali 5", 5, 1005, "Veli 5" },
                    { 6, "Ali 6", 6, 1006, "Veli 6" },
                    { 7, "Ali 7", 7, 1007, "Veli 7" },
                    { 8, "Ali 8", 8, 1008, "Veli 8" },
                    { 9, "Ali 9", 9, 1009, "Veli 9" },
                    { 10, "Ali 10", 10, 1010, "Veli 10" },
                    { 11, "Ali 11", 11, 1011, "Veli 11" },
                    { 12, "Ali 12", 12, 1012, "Veli 12" },
                    { 13, "Ali 13", 13, 1013, "Veli 13" },
                    { 14, "Ali 14", 14, 1014, "Veli 14" },
                    { 15, "Ali 15", 15, 1015, "Veli 15" },
                    { 16, "Ali 16", 16, 1016, "Veli 16" },
                    { 17, "Ali 17", 17, 1017, "Veli 17" },
                    { 18, "Ali 18", 18, 1018, "Veli 18" },
                    { 19, "Ali 19", 19, 1019, "Veli 19" },
                    { 20, "Ali 20", 20, 1020, "Veli 20" },
                    { 21, "Ali 21", 21, 1021, "Veli 21" },
                    { 22, "Ali 22", 22, 1022, "Veli 22" },
                    { 23, "Ali 23", 23, 1023, "Veli 23" },
                    { 24, "Ali 24", 24, 1024, "Veli 24" },
                    { 25, "Ali 25", 25, 1025, "Veli 25" },
                    { 26, "Ali 26", 26, 1026, "Veli 26" },
                    { 27, "Ali 27", 27, 1027, "Veli 27" },
                    { 28, "Ali 28", 28, 1028, "Veli 28" },
                    { 29, "Ali 29", 29, 1029, "Veli 29" },
                    { 30, "Ali 30", 30, 1030, "Veli 30" },
                    { 31, "Ali 31", 31, 1031, "Veli 31" },
                    { 32, "Ali 32", 32, 1032, "Veli 32" },
                    { 33, "Ali 33", 33, 1033, "Veli 33" },
                    { 34, "Ali 34", 34, 1034, "Veli 34" },
                    { 35, "Ali 35", 35, 1035, "Veli 35" },
                    { 36, "Ali 36", 36, 1036, "Veli 36" },
                    { 37, "Ali 37", 37, 1037, "Veli 37" },
                    { 38, "Ali 38", 38, 1038, "Veli 38" },
                    { 39, "Ali 39", 39, 1039, "Veli 39" },
                    { 40, "Ali 40", 40, 1040, "Veli 40" },
                    { 41, "Ali 41", 41, 1041, "Veli 41" },
                    { 42, "Ali 42", 42, 1042, "Veli 42" },
                    { 43, "Ali 43", 43, 1043, "Veli 43" },
                    { 44, "Ali 44", 44, 1044, "Veli 44" },
                    { 45, "Ali 45", 45, 1045, "Veli 45" },
                    { 46, "Ali 46", 46, 1046, "Veli 46" },
                    { 47, "Ali 47", 47, 1047, "Veli 47" },
                    { 48, "Ali 48", 48, 1048, "Veli 48" },
                    { 49, "Ali 49", 49, 1049, "Veli 49" },
                    { 50, "Ali 50", 50, 1050, "Veli 50" },
                    { 51, "Ali 51", 51, 1051, "Veli 51" },
                    { 52, "Ali 52", 52, 1052, "Veli 52" },
                    { 53, "Ali 53", 53, 1053, "Veli 53" },
                    { 54, "Ali 54", 54, 1054, "Veli 54" },
                    { 55, "Ali 55", 55, 1055, "Veli 55" },
                    { 56, "Ali 56", 56, 1056, "Veli 56" },
                    { 57, "Ali 57", 57, 1057, "Veli 57" },
                    { 58, "Ali 58", 58, 1058, "Veli 58" },
                    { 59, "Ali 59", 59, 1059, "Veli 59" },
                    { 60, "Ali 60", 60, 1060, "Veli 60" },
                    { 61, "Ali 61", 61, 1061, "Veli 61" },
                    { 62, "Ali 62", 62, 1062, "Veli 62" },
                    { 63, "Ali 63", 63, 1063, "Veli 63" },
                    { 64, "Ali 64", 64, 1064, "Veli 64" },
                    { 65, "Ali 65", 65, 1065, "Veli 65" },
                    { 66, "Ali 66", 66, 1066, "Veli 66" },
                    { 67, "Ali 67", 67, 1067, "Veli 67" },
                    { 68, "Ali 68", 68, 1068, "Veli 68" },
                    { 69, "Ali 69", 69, 1069, "Veli 69" },
                    { 70, "Ali 70", 70, 1070, "Veli 70" },
                    { 71, "Ali 71", 71, 1071, "Veli 71" },
                    { 72, "Ali 72", 72, 1072, "Veli 72" },
                    { 73, "Ali 73", 73, 1073, "Veli 73" },
                    { 74, "Ali 74", 74, 1074, "Veli 74" },
                    { 75, "Ali 75", 75, 1075, "Veli 75" },
                    { 76, "Ali 76", 76, 1076, "Veli 76" },
                    { 77, "Ali 77", 77, 1077, "Veli 77" },
                    { 78, "Ali 78", 78, 1078, "Veli 78" },
                    { 79, "Ali 79", 79, 1079, "Veli 79" },
                    { 80, "Ali 80", 80, 1080, "Veli 80" },
                    { 81, "Ali 81", 81, 1081, "Veli 81" },
                    { 82, "Ali 82", 82, 1082, "Veli 82" },
                    { 83, "Ali 83", 83, 1083, "Veli 83" },
                    { 84, "Ali 84", 84, 1084, "Veli 84" },
                    { 85, "Ali 85", 85, 1085, "Veli 85" },
                    { 86, "Ali 86", 86, 1086, "Veli 86" },
                    { 87, "Ali 87", 87, 1087, "Veli 87" },
                    { 88, "Ali 88", 88, 1088, "Veli 88" },
                    { 89, "Ali 89", 89, 1089, "Veli 89" },
                    { 90, "Ali 90", 90, 1090, "Veli 90" },
                    { 91, "Ali 91", 91, 1091, "Veli 91" },
                    { 92, "Ali 92", 92, 1092, "Veli 92" },
                    { 93, "Ali 93", 93, 1093, "Veli 93" },
                    { 94, "Ali 94", 94, 1094, "Veli 94" },
                    { 95, "Ali 95", 95, 1095, "Veli 95" },
                    { 96, "Ali 96", 96, 1096, "Veli 96" },
                    { 97, "Ali 97", 97, 1097, "Veli 97" },
                    { 98, "Ali 98", 98, 1098, "Veli 98" },
                    { 99, "Ali 99", 99, 1099, "Veli 99" },
                    { 100, "Ali 100", 100, 1100, "Veli 100" }
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
                name: "IX_Employees_RegionId",
                table: "Employees",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeId",
                table: "Orders",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
