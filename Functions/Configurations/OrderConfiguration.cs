using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loading_Related_Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        void IEntityTypeConfiguration<Order>.Configure(EntityTypeBuilder<Order> builder)
        {

            HashSet<Order> orders = new();
            for (int i = 1; i <= 100; i++)
            {
                orders.Add(new Order()
                {
                    Id = i,
                    PersonId = i,
                    Description = $"Order {i}",
                    Price = i * 10
                });
            }
            builder.HasData(orders);

        }
    }
}
