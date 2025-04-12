using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loading_Related_Data.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        void IEntityTypeConfiguration<Person>.Configure(EntityTypeBuilder<Person> builder)
        {


            builder.ToTable("Persons")
                   .SplitToTable("PhoneNumbers", builder =>
                   {
                       builder.Property(p => p.Id).HasColumnName("PersonId");
                       builder.Property(p => p.PhoneNumber).HasColumnName("PhoneNumber");
                   })
                   .SplitToTable("Addresses", addressTable =>
                   {
                       addressTable.Property(p => p.Id).HasColumnName("PersonId");
                       addressTable.Property(p => p.Street).HasColumnName("Street");
                       addressTable.Property(p => p.City).HasColumnName("City");
                       addressTable.Property(p => p.PostCode).HasColumnName("PostCode");
                       addressTable.Property(p => p.Country).HasColumnName("Country");
                   });

            Random rnd = new();
            HashSet<Person> persons = new();
            for (int i = 1; i <= 100; i++)
            {

                persons.Add(new Person()
                {
                    Id = i,
                    Name = $"Person {i}",
                    Surname = $"Surname {i}",
                    Street = $"Street {i}",
                    City = $"City {i}",
                    PostCode = i,
                    Country = $"Country {i}",
                    PhoneNumber = $"Phone {i}"
                });

            }
            builder.HasData(persons);
        }
    }
}
