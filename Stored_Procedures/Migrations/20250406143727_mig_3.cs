using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stored_Procedures.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                                Create Proc sp_PersonOrders
                                AS
	                                SELECT p.Name, COUNT(*) [Count] FROM Persons p
	                                JOIN Orders o
	                                on p.Id=o.PersonId
	                                GROUP BY p.Name
	                                Order By [Count] DESC"
                                    );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DROP PROC sp_PersonOrders");
        }
    }
}
