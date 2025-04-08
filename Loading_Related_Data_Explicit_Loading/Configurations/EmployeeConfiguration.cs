using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loading_Related_Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        void IEntityTypeConfiguration<Employee>.Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasOne(e => e.Region).WithMany(r => r.Employees).HasForeignKey(r => r.RegionId);
            builder.HasMany(e => e.Orders).WithOne(o => o.Employee).HasForeignKey(o => o.EmployeeId);

            builder.Navigation(x => x.Region)
                .AutoInclude();

            HashSet<Employee> employees = new();

            for (int i = 1; i <= 100; i++)
            {
                employees.Add(new Employee()
                {
                    Id = i,
                    Name = $"Ali {i}",
                    Surname = $"Veli {i}",
                    Salary = 1000 + i,
                    RegionId = i
                });
            }
            builder.HasData(employees);
        }
    }
}
