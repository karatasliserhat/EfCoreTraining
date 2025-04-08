using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loading_Related_Data.Configurations
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        void IEntityTypeConfiguration<Region>.Configure(EntityTypeBuilder<Region> builder)
        {
            HashSet<Region> regions = new();
            for (int i = 1; i <= 100; i++)
            {
                regions.Add(new Region()
                {
                    Id = i,
                    Name = $"Region {i}",
                });
            }
            builder.HasData(regions);
        }
    }
}
