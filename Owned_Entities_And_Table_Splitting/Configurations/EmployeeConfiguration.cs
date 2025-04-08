using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Owned_Entities_And_Table_Splitting.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        void IEntityTypeConfiguration<Employee>.Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.OwnsOne(p => p.EmployeeName, builder =>
            {
                builder.Property(p => p.Name)
                .HasColumnName("Name");
            });
            builder.OwnsOne(p => p.EmployeeAddress);
        }
    }
}
