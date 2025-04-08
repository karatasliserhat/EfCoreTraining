using Microsoft.EntityFrameworkCore;


ApplicationDbContext context = new();
#region Temporal Tables Nedir?
//Temporal Tables: SQL Server 2016 ile birlikte gelen bir özellik olup, verilerin geçmişini tutmak için kullanılır. Bu özellik sayesinde, verilerin geçmişi tutulabilir ve geçmiş verilere kolayca erişilebilir. Temporal Tables, verilerin geçmişini tutmak için iki tablo kullanır: birincil tablo ve geçmiş tablo. Birincil tablo, güncel verileri tutarken, geçmiş tablo ise geçmiş verileri tutar. Bu sayede, verilerin geçmişi tutulabilir ve geçmiş verilere kolayca erişilebilir.
//EF COre 6.0 ile desteklenmektedir.
//Veri değişikliği süreçlerinde kayıtları depolayan ve zaman içinde farklı noktalardaki tablo verilerinin analizi için kullanılan ve sitem tarafından yönetilen tablodur
#endregion
#region Temporal Tables Özelliği Nasıl Çalışır
//EF Core'daki migration yapıları sayeside tempral table'lar oluşturulup veritabanında üretebilmektedir.
//Mevcut tabloları migrationlar aracılığı ile tempral table'lara dönüştürebilmektedir.
//Herhangi bir tablonun verisel olrak geçmişini rahatlıkla sorgulayabiliriz.
//Herhangi bir tablodaki bir verinin geçmişteki herhangi bir T anındaki hali verileri geri getirilebilmektedir.
#endregion
#region Temporal Table Nasıl Uygulanır?
#region IsTemporal Yapılandırması
//Ef Core bu yapılandırma fonksiyonu sayesinde ilgili entity'e karşılık üretilecek tabloda Temparoral Table oluşturulacağını anlamaktadır.
//Eğer ki önceden ilgili tablo üretilmişse eğer onu temporal table 'a dönüştürülecektir.
#endregion
#region Temporal Table için Üretilen Migration'ın İncelenmesi

#endregion
#endregion
#region Temporal Tables'i Test Edelim
#region Veri Ekleme
//Temporal Table'a veri ekleme süreçlerinde herhangi bir kayıt atılmaz çünkü Temporal table'in yapısı varolan veriler üzerindenki zamansa değişimler takip etmek üzere kuruludr

//var persons = new List<Person>
//{
//    new() { Name = "Ali", Surname = "Veli", BirthDate = DateTime.Now },
//    new() { Name = "Ali1", Surname = "Veli1", BirthDate = DateTime.Now },
//    new() { Name = "Ali2", Surname = "Veli2", BirthDate = DateTime.Now },
//    new() { Name = "Ali3", Surname = "Veli3", BirthDate = DateTime.Now }
//};

//await context.Person.AddRangeAsync(persons);
//await context.SaveChangesAsync();
#endregion
#region Veri Güncellerken
//var person = await context.Person.FindAsync(3);
//person.Name= "Ali Zahid";
//context.SaveChanges();
#endregion
#region Veri Silerken
//var person = await context.Person.FindAsync(3);
//context.Person.Remove(person!);
//context.SaveChanges();
#endregion
#endregion
#region Temporal Table Üzerinden Geçmiş Verisel İzleri Sorgulama
#region TemporalAsOf
//Belirli bir zaman için değişikliğe uğrayan tüm öğreleri dönüdüren bir fonksiyondur.

//var dataPersons = await context.Person.TemporalAsOf(/*new DateTime(2025, 04, 08, 12, 46, 18)*/ DateTime.UtcNow).Select(x => new
//{
//    x.Id,
//    x.Name,
//    PeriodStart = EF.Property<DateTime>(x, "PeriodStart"),
//    PeriodEnd = EF.Property<DateTime>(x, "PeriodEnd")
//}).ToListAsync();

//dataPersons.ForEach(c => Console.WriteLine(c.Id + " " + c.Name + " " + c.PeriodStart + " " + c.PeriodEnd));
#endregion
#region TemporalAll
//Güncellenmiş veya silinmiş olan tüm verilen geçmiş sürümlerini veya geçerli durumlarını dönüdüren bir fonksiyondur
//var dataPersons = await context.Person.TemporalAll().Select(x => new
//{
//    x.Id,
//    x.Name,
//    PeriodStart = EF.Property<DateTime>(x, "PeriodStart"),
//    PeriodEnd = EF.Property<DateTime>(x, "PeriodEnd")
//}).ToListAsync();

//dataPersons.ForEach(c => Console.WriteLine(c.Id + " " + c.Name + " " + c.PeriodStart + " " + c.PeriodEnd));
#endregion
#region TemporalFromTo
//Belirli bir zaman aralığı içerisindeki verileri döndüren fonksiyondur.Başlangış ve bitiş zamanı dahil dğeildir.

//var baslangic = new DateTime(2025, 04, 08, 12, 41, 22);
//var bitis = new DateTime(2025, 04, 08, 12, 46, 18);
//var dataPersons = await context.Person.TemporalFromTo(baslangic, bitis).Select(x => new
//{
//    x.Id,
//    x.Name,
//    PeriodStart = EF.Property<DateTime>(x, "PeriodStart"),
//    PeriodEnd = EF.Property<DateTime>(x, "PeriodEnd")
//}).ToListAsync();

//dataPersons.ForEach(c => Console.WriteLine(c.Id + " " + c.Name + " " + c.PeriodStart + " " + c.PeriodEnd));

#endregion
#region TemporalBetween
//Belirli bir zaman aralığı içerisindeki verileri döndüren fonksiyondur.başlangıç veerisi dahil değildir, bitiş zamanı dahildir.
//var baslangic = new DateTime(2025, 04, 08, 12, 41, 22);
//var bitis = new DateTime(2025, 04, 08, 12, 46, 18);
//var dataPersons = await context.Person.TemporalBetween(baslangic, bitis).Select(x => new
//{
//    x.Id,
//    x.Name,
//    PeriodStart = EF.Property<DateTime>(x, "PeriodStart"),
//    PeriodEnd = EF.Property<DateTime>(x, "PeriodEnd")
//}).ToListAsync();

//dataPersons.ForEach(c => Console.WriteLine(c.Id + " " + c.Name + " " + c.PeriodStart + " " + c.PeriodEnd));
#endregion
#region TemporalContainedIn
//Belirli bir zaman aralığı içerisindeki verileri döndüren fonksiyondur.başlangıç veerisi ve bitiş zamanı dahildir.
//var baslangic = new DateTime(2025, 04, 08, 12, 41, 22);
//var bitis = new DateTime(2025, 04, 08, 12, 46, 18);
//var dataPersons = await context.Person.TemporalBetween(baslangic, bitis).Select(x => new
//{
//    x.Id,
//    x.Name,
//    PeriodStart = EF.Property<DateTime>(x, "PeriodStart"),
//    PeriodEnd = EF.Property<DateTime>(x, "PeriodEnd")
//}).ToListAsync();

//dataPersons.ForEach(c => Console.WriteLine(c.Id + " " + c.Name + " " + c.PeriodStart + " " + c.PeriodEnd));
#endregion
#endregion
#region Silinmiş Bir Veriyi Temporal Table'dan Geri Getirme
//Silinmiş bir veriyi temporal Table^den getirebilmek için öncelikle yapılması gerekeen ilgili verinin silindiği tarihi bulmamız gerekmektedir. Ardından TemporalAsOf fonksiyonu ile geçşmiş değeri elde edilebilir ve fizksel tabloya bu veri taşınabilir.

//Silindiği tarihi elde etme
var dateOfDelete = await context.Persons.TemporalAll()
    .Where(p => p.Id == 3)
    .OrderByDescending(p => EF.Property<DateTime>(p, "PeriodEnd"))
    .Select(p => EF.Property<DateTime>(p, "PeriodEnd"))
    .FirstAsync();
//Silinen veriyi elde etme
var deletedPerson = await context.Persons.TemporalAsOf(dateOfDelete.AddMicroseconds(-1))
    .FirstOrDefaultAsync(p => p.Id == 3);


await context.AddAsync(deletedPerson!);
await context.Database.OpenConnectionAsync();
await context.Database.ExecuteSqlInterpolatedAsync($"SET IDENTITY_INSERT dbo.persons ON");
await context.SaveChangesAsync();
await context.Database.ExecuteSqlInterpolatedAsync($"SET IDENTITY_INSERT dbo.persons OFF");
await context.Database.CloseConnectionAsync();
#region Set Identity_Insert Konfigürasyonu


//ID ile veri ekleme sürecinde  ilgili verinin id sütununa kayıt işleyebilmek için veriyi fiziksel tabloya taşıma işlemindne önce vertiabaı seviyesinde Set Identity_Insert komutu eşliğinde id bazlı veri ekleme işlemi  aktifleştirilmeldir.
#endregion
#endregion
Console.ReadLine();


class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
}

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}
class ApplicationDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Employee> Employees { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().ToTable("Employees", builder =>
        {
            builder.IsTemporal();
        });

        modelBuilder.Entity<Person>().ToTable("Persons", builder => builder.IsTemporal());
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppTemporalTablesDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");

    }


}