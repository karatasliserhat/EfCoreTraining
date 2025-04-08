using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

ApplicationDbContext context = new();

Person person = new()
{
    Name = "Salime",
    Surname = "Yılmaz",
    Premium = 10
};

await context.Persons.AddAsync(person);
await context.SaveChangesAsync();

#region Generated Value Nedir?
//EF Coreda üretilen değerler ile ilgili çeşitli modellerin ayrıntılarını yapılandırmamızı sağlayan bir özelliktir.
#endregion

#region Default Values
// Ef Core da herhangi bir tablonunu herhangi bir kolununa yazılım tarafdından herhangi bir değer gönderilmediği takdirde bu kolona hangi değerin üretilip yazıdırlacağını belirleyen yapılnadırmadır.
#region HasDefaultValue
//Static değer veriyoruz
#endregion

#region HasDefaultValueSql
//SQl cümleciği veriyoruz GETDATE()
#endregion

#endregion

#region Computed Columns

#region HasComputedColumnSql
//Tablo içerisinde kolonlar üzerinde yapılan aritmetik işlemler neticesinde üretilen kolondur.
#endregion

#endregion

#region Value Generation

#endregion

#region Primary Keys
//herhangi bir tablodaki hehangi bir satırı kimlik vari şekilde tanımlayan, tekil olan, sutun veya sutunlardır.  
#endregion

#region Identity
// Identity yalnızca otomatik olarak artan bir sutundur. Bir sutun PK olmaksızın identity olarak tanımlanabilir.
#endregion
// Bu iki özellik genellijle birlikte kullanılmaktadır PK olan bir kolonu otomotik olarak Identity olacak şekilde yapılandırmaktadır Ancak böyle olması için gereklilik yoktur. Bir tablo içerisinde ıdentity kolunu tek bir tane olabilir.

#region DatabaseGenerated

#region DatabaseGeneratedOptions.None -ValueGeneratedNever
//Bir kolonda değer üretilmeyecekse none ile işaretliyoruz.
// Ef core un default olarak PK kolonlarda getirdiği ıdentity özelliğini kaldırmak istiyorsak none kullanabiliriz.
#endregion

#region DatabaseGeneratedOptions.Identity - ValueGeneratedOnAdd
//Bir kolonda ardışık olarka bir artış gösteremek istiyorsak kullanıılır.

#region SAyısaş Türlerde
//Eğer ki Identity özelliği bir tabloda sayısal olan bir kolonda kullanılacaksa o durumda ilgili kolondaki PK olan kolondan özellikle iradeli bir şekilde ıdentity özelliğini kaldırmamız gerekiyor.
#endregion

#region SAyısal Olmayan Türlerde
//Eğer ki Identity özelliği sayısal olamyan bir kolonda kullanılacaksa o durumda ilgili tablodaki PK olan kolondan ireadeli bir şekilde ıdentity özelliğinin kaldırılmasına gerek yoktur ve sayısal olmayan kolona değer otomotik artacağından dolayı varsayılan değer ataması yapmamız gerekiyor.
#endregion
#endregion

#region DatabaseGeneratedOptionsComputed -ValueGeneratedOnAddOrUpdate
//EF Core üzerinden bir kolon Computed column ise ister Conmputed olarak belirleyebilirsiniz isterseniz de belirlemeden kullanmaya devam edeilirsiniz.

//Kullanıp kullanmamanın herhangi bir artısı yok.
#endregion

#endregion


class ApplicationDbContext : DbContext
{

    public DbSet<Person> Persons { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppGeneratedValueDb; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .Property(p => p.Salary)
            //.HasDefaultValue(100);
            .HasDefaultValueSql("Floor(Rand() *1000)");
        modelBuilder.Entity<Person>()
            .Property(x => x.TotalGain).HasComputedColumnSql($"{nameof(Person.Salary)} + {nameof(Person.Premium)} * 10");

        //Identity Özelliğini kaldırma //modelBuilder.Entity<Person>()
        //    .Property(p => p.Id).ValueGeneratedNever();

        /*//Identity Özelliği Verme*/
        modelBuilder.Entity<Person>()
            .Property(p => p.PersonCode).ValueGeneratedOnAdd();
        /*//Sayısal Olmayan Türde değer veriyorsak Default olarak value değeri vermemiz gerekiyor. Oda Guid*/
        modelBuilder.Entity<Person>()
            .Property(p => p.PersonCode).HasDefaultValueSql("NewID()");
    }
}

class Person
{

    //[DatabaseGenerated(DatabaseGeneratedOption.None)] ıdentity özelliği kaldırıldı
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Premium { get; set; }
    public decimal Salary { get; set; }
    public decimal TotalGain { get; set; }
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] Ardışık ekleme Identity özelliği
    public Guid PersonCode { get; set; }
}





