using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keyles_Entity_Types.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"create View vw_PersonOrderCount
                                    as
                                    select top(100) p.Name, COUNT(*) TotalOrderCount from persons p
                                    join Orders o
	                                    on p.Id=o.PersonId
                                    group by p.Name
                                    order by TotalOrderCount desc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DROP VIEW vw_PersonOrderCount");
        }
    }
}
