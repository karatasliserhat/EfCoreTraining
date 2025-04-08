using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stored_Procedures.Migrations
{
    /// <inheritdoc />
    public partial class mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                                    Create Proc sp_BestSellingStaff
                                    AS
	                                    Declare @name Nvarchar(MAX),@count INT
	                                    SELECT TOP 1 @name= p.Name, @count=COUNT(*) FROM Persons p
	                                    JOIN Orders o
	                                    on p.Id=o.PersonId
	                                    GROUP BY p.Name
	                                    Order By COUNT(*) DESC
	                                    return @count
                                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                                    Drop Proc sp_BestSellingStaff
                                ");
        }
    }
}
