using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Functions.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"Create Function bestSellingStaff(@totalOrderPrice INT=10000)
	                                    returns table
                                    as
                                    return
                                    select top(1) p.Name, COUNT(*) OrderCount, Sum(o.price) TotalOrderPrice from Persons p
                                    join Orders o
	                                    on p.Id=o.PersonId
                                    Group BY p.Name
                                    having Sum(o.price) < @totalOrderPrice
                                    order by OrderCount desc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"Drop Function bestSellingStaff");
        }
    }
}
