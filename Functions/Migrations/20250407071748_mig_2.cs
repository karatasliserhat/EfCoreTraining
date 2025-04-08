using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Functions.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"CREATE FUNCTION getPersonTOTALPRICE(@personId INT)
	                                Returns INT
                                as
                                BEGIN
                                declare @totalprice int
                                select @totalprice=sum(o.Price) from Persons p
                                join orders o
	                                on p.Id=o.PersonId
                                where p.Id=@personId
                                return(@totalprice)
                                END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DROP FUNCTION getPersonTOTALPRICE");
        }
    }
}
