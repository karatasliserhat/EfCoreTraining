using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loading_Related_Data.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        void IEntityTypeConfiguration<Person>.Configure(EntityTypeBuilder<Person> builder)
        {


           
            Random rnd = new();
            HashSet<Person> persons = new();
            for (int i = 1; i <= 100; i++)
            {
              
                persons.Add(new Person()
                {
                    Id = i,
                    Name = $"Person {i}",
                });

            }
            builder.HasData(persons);
        }
    }
}
