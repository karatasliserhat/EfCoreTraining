using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;

ApplicationDbContext context = new();

#region Value Conversions Nedir?
//EF COre üzerinden vertianamı ile yapılan sorgulama süreçelrinde veriler üzerinden dönüşümler yapmamızı sağlayan bir özelliktir

//Select sogurları sürecinde gelecek olan veriler üzerinden dönüşüö yapabiliriz

//Update veyahur insert soruglarında da yazılım üzeerinden veritabanına gönderdiğimiz veriler üzerinde de dönüşümler yapabilir ve böyleece fiziksel olarak da verileri manipüle edebilir.
#endregion
#region Value Converter Kullanımı Nasıldır?
//Value Conversions özelliğini Ef Core 'daki Value Converter yapıları tarafından uygulayabilmekteyiz.

#region HasConversion
//HasConversyion fonkisynu en sade haliyle Ef Core üerinden valu converter özelliği gören bir fonksiyondur.
//modelBuilder.Entity<Person>().Property(p => p.Gender)
//.HasConversion(/*İnsert- Updateg*/g => g.ToUpper(),/*Select*/ g => g == "M" ? "Male" : "Female");

//var persons = await context.Persons.ToListAsync();
//Console.WriteLine();
#endregion
#endregion
#region Enum değerle ile Value Convert Kullanımı

//Normal durumlarda Enum türünde tutulan propertylerin veritabanındaki karşıkları int olacak şekilde aktarımı gerçekleştrimektedir. ValueConverter sayaesinde enum türündeki olan propertylerin dönüşümleri istediğimiz türlerde sağlayarak hem ilgili kolunun türünü o türde ayarlayabilir hem de enum üzerinden çalışm asürecinde verisel dönüşümleri ilgili türde sağlayabiliriz.

//var personNew = new Person() { Name = "Rakıf", Gender2 = Gender.Male, Gender = "M" };
//await context.Persons.AddAsync(personNew);
//await context.SaveChangesAsync();
//var person = await context.Persons.FindAsync(personNew.Id);
//Console.WriteLine();
#endregion
#region Value Converter Sınıfı
//Value Converter sınıfı verisel dönüşümlerdeki çalışmalar /sorumlulukları üstlenecbilecek  bir sınıftır yani bu sınıfın instance iele HasConvetion fonksiyonun yapılan çalışmaları üstlenebilir ve direk  bu instance'ı ilgili fonksiyona vererek dönüşümsel çalışmalarımızı gerçekleştirebiliriz.

//var person = await context.Persons.FindAsync(5);
//Console.WriteLine();
#endregion
#region Custom Value Convert Sınıfı
// EF Core'da verisel dönüşümler için custom olarak Converter Sınıfıları üretebilmekteyiz Bunun için tek yapılması gereek custom sınıfı ValuConverter sınıfından miras almasını sağlamaktadır.

//public class GenderConverter : ValueConverter<Gender, string>
//{
//    public GenderConverter() : base(
//        //Insert-Update
//        g => g.ToString(),
//        //Select
//        g => (Gender)Enum.Parse(typeof(Gender), g))
//    {

//    }
//}

#endregion
#region Built-in Converters Yapıları
//Ef Core basit dönüşümler için kendi bünyesinde yerleşik convert sınıfıları barındımaktadır.
#region BoolToZeroOneConverter
//Bool olan verinin int olarak tutulmasını sağlar.

#endregion
#region BoolToStringConverter
//Bool olan verinin string olarak tutulmasını sağlar.

#endregion
#region BoolToTwoValuConverter
// Bool olarak verilen değerin char olaran tutulmasını sağlar.
#endregion
#endregion
#region İlkel Koleksyionların Serilizasyonları
//içerisinde ilkel türlerden oluişutulmuş koleksiyonları barındıran modelleri migrate etmeye çalıştığınızda hata ile karşılaşmaktayız bu hatadan kurulmak ve ilgili verrye koleksiyondaki verieri serilize ederek işleyebilmek için bu koleysiyonu normal metinse değerlere dönüştümemize fırsat veren bir conversion operasonu gerçekleştirebiliriz.

var person = await context.Persons.AddAsync(new Person { Name = "Ali", Gender = "M", Gender2 = Gender.Male, Married = false, Titles = new() { "B2", "b2", "b3" } });
await context.SaveChangesAsync();
var personList = await context.Persons.ToListAsync();
Console.WriteLine();
#endregion
#region .Net 6 Value Converter For Nullable Fields

#endregion



public class Person
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Gender { get; set; }
    public Gender Gender2 { get; set; }
    public bool Married { get; set; }

    public List<string>? Titles { get; set; }
}

public enum Gender
{
    Male,
    Female
}
public class GenderConverter : ValueConverter<Gender, string>
{
    public GenderConverter() : base(
        //Insert-Update
        g => g.ToString(),
        //Select
        g => (Gender)Enum.Parse(typeof(Gender), g))
    {

    }
}
class ApplicationDbContext : DbContext
{

    public DbSet<Person> Persons { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Value convertion Kullanımı
        //modelBuilder.Entity<Person>().Property(p => p.Gender)
        //    .HasConversion(/*İnsert- Updateg*/g => g.ToUpper(),/*Select*/ g => g == "M" ? "Male" : "Female");
        #endregion
        #region Enum Değerler İle Value Converter Kullanımı

        //modelBuilder.Entity<Person>().Property(p => p.Gender2)
        //   .HasConversion(g => g.ToString(), g => (Gender)Enum.Parse(typeof(Gender), g));


        //modelBuilder.Entity<Person>().Property(p => p.Gender2)
        //   .HasConversion(g => g.ToString(), g => (Gender)Enum.Parse(typeof(Gender), g));
        #endregion
        #region ValueConverter Sınıfı
        //ValueConverter<Gender, string> convert = new(
        //    g => g.ToString(),
        //    g => (Gender)Enum.Parse(typeof(Gender), g)
        //    );

        //modelBuilder.Entity<Person>().Property(p => p.Gender2).HasConversion(convert);
        #endregion
        #region Custom  Converter Sınıfı

        //modelBuilder.Entity<Person>().Property(p => p.Gender2).HasConversion(new GenderConverter());
        #endregion
        #region BoolToZeroOneConverter
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Married)
        //    .HasConversion<BoolToZeroOneConverter<int>>();

        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Married)
        //    .HasConversion<int>();
        #endregion
        #region BoolToStringConverter
        //BoolToStringConverter converter = new("Bekar", "Evli");
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Married)
        //    .HasConversion(converter);
        #endregion
        #region BoolToTwoValuConverter
        //BoolToTwoValuesConverter<char> converter = new('B', 'E');
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Married)
        //    .HasConversion(converter);
        #endregion

        #region İlkel Koleksyionların Serilizasyonları
        modelBuilder.Entity<Person>().Property(p => p.Titles)
            .HasConversion(
            t => JsonSerializer.Serialize(t, (JsonSerializerOptions)null),
            t=> JsonSerializer.Deserialize<List<string>>(t, (JsonSerializerOptions)null));
        #endregion
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppValueConversionsDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
    }
}

