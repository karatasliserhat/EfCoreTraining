using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loading_Related_Data.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        void IEntityTypeConfiguration<Person>.Configure(EntityTypeBuilder<Person> builder)
        {


            builder.HasOne(e => e.Photo).WithOne(r => r.Person).HasForeignKey<Photo>(r => r.PersonId);
            builder.HasMany(e => e.Orders).WithOne(o => o.Person).HasForeignKey(o => o.PersonId);

            Random rnd = new();
            HashSet<Person> persons = new();
            for (int i = 1; i <= 100; i++)
            {
                var sayi = 0;
                if (i <= 50)
                    sayi = 0;
                else
                    sayi = 1;
                persons.Add(new Person()
                {
                    Id = i,
                    Name = $"Person {i}",
                    Gender = (Gender)sayi
                });

            }
            builder.HasData(persons);
        }
    }
}
