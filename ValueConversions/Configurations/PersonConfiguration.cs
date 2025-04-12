using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connection_Resiliency.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        void IEntityTypeConfiguration<Person>.Configure(EntityTypeBuilder<Person> builder)
        {
            List<Person> list = new() {
                    new Person { Id = 1, Name = "Serhat", Gender="M", Gender2=Gender.Male, Married=true },
                    new Person { Id = 2, Name = "Kamil",Gender="M", Gender2=Gender.Male, Married=false },
                    new Person {Id = 3, Name = "Cemil", Gender = "M", Gender2 = Gender.Male, Married=true},
                    new Person {Id = 4, Name = "Boran", Gender = "M", Gender2 = Gender.Male, Married = true},
                    new Person {Id = 5, Name = "Selin", Gender = "F", Gender2 = Gender.Female ,Married=false},
                    new Person {Id = 6, Name = "Şeyma", Gender = "F", Gender2 = Gender.Female , Married = false}
                };
            builder.HasData(list);
        }
    }
}
