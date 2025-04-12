using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connection_Resiliency.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        void IEntityTypeConfiguration<Person>.Configure(EntityTypeBuilder<Person> builder)
        {
            List<Person> list = new() {
                    new Person { Id = 1, Name = "Serhat" },
                    new Person { Id = 2, Name = "Kamil" },
                    new Person { Id = 3, Name = "Cemil" },
                    new Person { Id = 4, Name = "Boran" },
                    new Person { Id = 5, Name = "Selin" },
                    new Person { Id = 6, Name = "Şeyma" }
                };
            builder.HasData(list);
        }
    }
}
