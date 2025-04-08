using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security;
Console.ReadLine();
ApplicationDbContext context = new();

#region HasDicriminator Çalışması Örnek Add
//A a = new()
//{
//    X = "Adan geldi",
//    Y = 2
//};
//B b = new()
//{
//    X = "Bdan geldi",
//    Z= 1
//};
//Entity entity = new()
//{
//    X = "Entityden geldi"
//};

//await context.AddRangeAsync(entity,a,b);

//await context.SaveChangesAsync();
#endregion

#region EF Core'da neden yapılandırmaya ihtiyaç duyarız
//Default davranışları yeri geldiğinde yeri geldiğinde geçersiz kılmak ve özelleştirmek isteyebiliriz. Bundan dolayı yapılandırmalara ihtiyaçımız olacaktır.
#endregion

#region OnModelCreating Metodu
//EF Core'da yapılandırma diyince akla ilk gelen metod bu metottur. Bizle bu metodu kullanarak model lerimizle ilgili temel konfigürasyonle davranışları(Fluent API) sergileyebilirz.

#region GetEntityTypes
// Ef Core da kulanılan entityleri elde etmek programatik olarak öprenemek istiyorsak kullanabiliriz.


#endregion


#endregion

#region Configuration | Data Annotations & Fluent API

#region Table-ToTable
//Generate edilecek tablonun adını belirlememizi sağlayan yapılandırmadır.
#endregion

#region Cloumn-HasColumnName, HasColumnType HasColumnOrder

#endregion

#region ForeignKey, HasForeignKey

#endregion

#region NotMapped - Ignore
//veritabanına istemediğimiz propertylerin yansımasını istemiyorsak kullanılan yapılandırmadır.
#endregion

#region Key - HasKey

#endregion

#region TimeStamp - IsRowVersion
//Veri tutarlılığı sağlamak için kullanılıyor.
// Bir satırdaki verinin bütünsel olarak değişikliğini takip etmemnizi sağlayacak oan versiyon mantığını konuşuyor olacağız
#endregion

#region Required - IsRequired

#endregion

#region MaxLength | SttirngLenth - HasMaxLength

#endregion

#region Precision - HasPrecision
//Küsüratlı sayısal değerlerde kesinliği ortaya koyak için kullandığımız özelliktir.
#endregion

#region UniCode - IsUnicode
//Kolon içerisinde unicode karekterler kullanılcaksa bu yapılandırmadan istifade edebiliiz.
#endregion

#region ConcurencyCheck - IsConcurencyCheck
//Veri tutarlılığı sağlamak için kullanılıyor.
// Bir satırdaki verinin bütünsel olarak tutarlığını sağlayacak concurency token yapılandırmasından bahsedeceğiz.
#endregion

#region Comment - HasComment
// veritabanı nesneleri üzerinden bir açıklama / yorum yapmak istiyorsak Commenti veya HasCommenti kullanabiliriz.
#endregion

#region InverseProperty
//2 entity arasunda birden fazla ilişki varsa hangi navigation properyler üzerinden olcağınız ayarlamamızı sağlayan bir konfügürasyondur.
#endregion

#endregion



#region Configurations | FluenAPI

#region Composite Key
//tablolarda birden fazla kolonu kümüatif olarak primary key yapmak istiyorsak buna composite key denir
#endregion

#region HasDefaultSchema
//Ef core üzerinden inşa edilen jherhangi bir veritbanı nesnesi default olarak dbo şemasında kaydedilir bunu değiştirmek içşn kullanılır.
#endregion

#region Property

#region HasDefaultValue
//Tablodaki herhangi bir kolnun değer göndereilmediği durumlarda varsayulan olarak hangi  değeri alacağını belirler verir.
#endregion

#region HasDefaultValueSql
//Tablodaki herhangi bir kolnun değer göndereilmediği durumlarda varsayulan olarak hangi sql cümleciğinden değeri alacağını belirler verir.
#endregion

#endregion

#region HasComputedColumnSql
//Tablolarda birden fazla kolondaki verileri işleyerek değerlerini tutan kolona computed column denmektedir.
#endregion

#region HasConstraintName

//Ef Core üzerinden oluşturulan constraint'lere(Kısıtlara) default isim yerine özelleştirilmiş bir isim vrerebilmek için kullanılına bir yapılanmadır.
#endregion

#region HasData
//Sonraki derslermizde seed Data isimli bir konuyu inceleyeceğiz  Bu konuda migrate sürecinde veritabanında inşa ederken bir yandan da yazılım üzerinden hazır veriler oluşturmak istiyorsak eğer bunun yönetimini usulünü inceliyor olacağız

// iste HasData konfigürasyonu bu operasyonda yapılandırma ayağıdır.
#endregion

#region HasDiscriminator
//ileride entityle arasında kalıtımsal ilişkilerin olduğu TPT(Table Pire Type) ve TPH(Table Pire Hireqy) isminde konuları inceliyor olacağız. işte bu konularla ilgili yapılandırmalarımız HasDiscrminator ve HasValue fonksiyonlarıdır.
#endregion

#region HasField
// Backing fiedl özelliğini kullanmaımız sağlayan bir özelliktir.
#endregion

#region HasNoKey
//Normal şartlarda EF Core da tüm entitylerin bir PK kolonu olmak zorundadır Eğer kii entityde PK kolonu olmayacaksa bunun için kullanılan fonksiyondur.
#endregion

#region HasIndex
// Sonraki derslerimizde EF Core üzerinden INdex yapılanmasını detaylıca inceliyor olacağız
// Bu yapılanma dair Konfigürasyonlarımız HasIndez ve Index attribute'dur
#endregion

#region HasQueryFilter
//ileride göreceğimiz global query filter başlıklı dersin yapılandırmasıdır.

//Temeldeki görevi bir entitye karşılık uygulama bazında bir filtre koymaktır.
#endregion

#region HasValue

#endregion

#region DatabaseGenerated - ValueGeneratedOnAddOrUpdate, ValueGenerateOnAdded, ValueGeneratedNever

#endregion


#endregion

class ApplicationDbContext : DbContext
{

    public DbSet<Person> Persons { get; set; }
    public DbSet<Department> Departments { get; set; }

    public DbSet<Example> Examples { get; set; }

    //public DbSet<Entity> Entities { get; set; }
    //public DbSet<A> As { get; set; }
    //public DbSet<B> Bs { get; set; }


    //public DbSet<Flight> Flights { get; set; }
    //public DbSet<Airport> Airports { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppConfigureDb; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region GetEntityTypes
        //var entities = modelBuilder.Model.GetEntityTypes();
        //foreach (var item in entities)
        //{
        //    Console.WriteLine(item);
        //}
        #endregion

        #region ToTable
        //modelBuilder.Entity<Person>().ToTable("Kisilerrrrrrrrrrrr");
        #endregion

        #region HasColumnType
        //modelBuilder.Entity<Person>().Property(p => p.Name)
        //    .HasColumnName("Adiss")
        //    .HasColumnType("string")
        //    .HasColumnOrder(7);
        #endregion

        #region HasForeignKey
        //modelBuilder.Entity<Person>()
        //    .HasOne(x => x.Department)
        //    .WithMany(d => d.Persons)
        //    .HasForeignKey(p => p.DepartmtId);

        #endregion

        #region Igrone
        //modelBuilder.Entity<Person>().Ignore(p => p.Laylaylommm);
        #endregion

        #region IsRowVersion
        //modelBuilder.Entity<Person>().Property(x => x.RowVersiom).IsRowVersion();

        #endregion

        #region HasPrecision
        modelBuilder.Entity<Person>().Property(p => p.Salary).HasPrecision(5, 3);
        #endregion

        #region IsUnicode
        //modelBuilder.Entity<Person>().Property(p => p.Surname).IsUnicode();
        #endregion

        #region HasComment
        //modelBuilder.Entity<Person>().Property(p => p.Salary).HasComment("Maaş Bilgisi");
        #endregion

        #region IsConcurrencyToken 
        //modelBuilder.Entity<Person>().Property(p => p.Salary).IsConcurrencyToken();
        #endregion

        #region InverseProperty

        #endregion

        #region CompositeKey
        //modelBuilder.Entity<Person>().HasKey(p => new { p.PersonId, p.PersonId2 });
        #endregion

        #region HasDefaultSchema
        //modelBuilder.HasDefaultSchema("serhat");
        #endregion

        #region Property

        #region HasDefaultValue
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Salary)
        //    .HasDefaultValue(100);
        #endregion

        #region HasDefaultValueSql
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.CreatedDate)
        //    .HasDefaultValueSql("GETDATE()");
        #endregion

        #endregion

        #region HasComputedColumnSql
        modelBuilder.Entity<Example>()
            .Property(p => p.Computed).HasComputedColumnSql($"{nameof(Example.Y)} + {nameof(Example.X)}");

        #endregion

        #region HasConstraintName
        //modelBuilder.Entity<Person>()
        //    .HasOne(p => p.Department)
        //    .WithMany(d => d.Persons)
        //    .HasForeignKey(p => p.DepartmentId)
        //    .HasConstraintName("DefaultForingKeyAdınıDegistirdin");
        #endregion

        #region HasData
        //modelBuilder.Entity<Department>()
        //    .HasData(new Department { Id = 1, Name = "asd" }, new Department { Id = 2, Name = "dsa" });
        //modelBuilder.Entity<Person>()
        //    .HasData(
        //    new Person
        //    {
        //        PersonId = 1,
        //        DepartmentId = 1,
        //        Name = "Ahmet",
        //        Surname = "Filanca",
        //        Salary = 200,
        //        CreatedDate = DateTime.Now
        //    },
        //    new Person
        //    {
        //        PersonId = 2,
        //        DepartmentId = 2,
        //        Name = "Mehmet",
        //        Surname = "Filanca",
        //        Salary = 201,
        //        CreatedDate = DateTime.Now
        //    }
        //    );
        #endregion

        #region HasDiscriminator

        #region Discriminator Kolonu String olacaksa
        //modelBuilder.Entity<Entity>()
        //   .HasDiscriminator<string>("Ayırıcı");
        #endregion
        #region Discriminator Kolonu İnt olacaksa
        //modelBuilder.Entity<Entity>()
        //   .HasDiscriminator<int>("Ayırıcı")
        //   .HasValue<A>(1)
        //   .HasValue<B>(2)
        //   .HasValue<Entity>(3);
        #endregion

        #endregion

        #region HasField
        //modelBuilder.Entity<Person>()
        //    .Property(p => p._name)
        //    .HasField(nameof(Person._name));
        #endregion

        #region HasNoKey
        //modelBuilder.Entity<Example>()
        //    .HasNoKey();
        #endregion

        #region HasIndex
        //modelBuilder.Entity<Person>()
        //    .HasIndex(p => p.Name);
        #endregion

        #region HasQueryFilter
        //modelBuilder.Entity<Person>()
        //    .HasQueryFilter(p => p.CreatedDate.Year == DateTime.Now.Year);
        #endregion
    }

}
//Data Annotation
//[Table("Kisiler")]
class Person
{
    public int PersonId { get; set; }

    //public int PersonId2 { get; set; }

    //[ForeignKey(nameof(Department))]
    //public int DId {get;set;}

    public int DepartmentId { get; set; }
    //[Column("Adı", TypeName = "metin", Order = 7)]
    public string _name;
    public string Name { get => _name; set => _name = value; }
    //[Column("Soyadı")]

    //[Unicode]
    public string Surname { get; set; }

    //[Precision(5,3)]
    //[Comment("Maaş Bilgisi Tutmaktadır")]
    public decimal Salary { get; set; }
    public DateTime CreatedDate { get; set; }

    //[Timestamp]
    //public byte[] RowVersiom { get; set; }
    //[NotMapped]
    //public string Laylaylommm { get; set; }

    //[ConcurrencyCheck]
    //public int ConcurrencyCheck { get; set; }
    public Department Department { get; set; }
}
class Department
{
    public Department()
    {
        Persons = new HashSet<Person>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Person> Persons { get; set; }
}
class Example
{
    public int Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public int Computed { get; set; }
}

#region HasDicriminator Class Oluşturma

///*abstract*/
//class Entity
//{
//    public int Id { get; set; }
//    public string X { get; set; }
//}
//class A : Entity
//{
//    public int Y { get; set; }
//}
//class B : Entity
//{
//    public int Z { get; set; }
//}

#endregion

//Inverse Property anlatmak için aşağıdaki entityler oluşturuldu.

//class Flight
//{
//    public int FlightId { get; set; }
//    public int DepartureAirportId { get; set; }
//    public int ArrivalAirportId { get; set; }
//    public string Name { get; set; }
//    public Airport DepartureAirport { get; set; }
//    public Airport ArrivalAirport { get; set; }
//}
//class Airport
//{
//    public int AirportId { get; set; }
//    public string Name { get; set; }

//    [InverseProperty(nameof(Flight.DepartureAirport))]
//    public virtual ICollection<Flight> DepartureFlights { get; set; }
//    [InverseProperty(nameof(Flight.ArrivalAirport))]
//    public virtual ICollection<Flight> ArrivalFlights { get; set; }
//}
