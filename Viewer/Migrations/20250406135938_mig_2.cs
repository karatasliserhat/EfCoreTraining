using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Viewer.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"Create view vm_PersonOrders
                    as
                    select TOP 100 p.Name, COUNT(*) [Count] from persons p 
                    inner join Orders o
                    on p.Id =o.PersonId
                    Group By p.Name
                    order by [Count] DESC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"Drop view vm_PersonOrders");
        }
    }
}
