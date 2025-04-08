using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stored_Procedures.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                                Create Proc sp_PersonOrders2
                                (
	                                @PersonId INT,
	                                @Name NVARCHAR(MAX) OUTPUT
                                )
                                AS
	                                SELECT @Name=p.Name FROM Persons p
	                                JOIN Orders o
	                                on p.Id=o.PersonId
	                                WHERE p.Id=@PersonId
                                                        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                                Drop Proc sp_PersonOrders2
                                                        ");
        }
    }
}
