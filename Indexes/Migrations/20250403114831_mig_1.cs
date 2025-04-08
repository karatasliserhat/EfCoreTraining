﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indexes.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Salary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Name",
                table: "Employees",
                column: "Name",
                unique: true,
                descending: new bool[0],
                filter: "[NAME] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Name_Surname",
                table: "Employees",
                columns: new[] { "Name", "Surname" },
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "surname_index",
                table: "Employees",
                column: "Surname");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
