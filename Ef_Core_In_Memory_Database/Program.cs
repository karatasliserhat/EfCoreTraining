using Microsoft.EntityFrameworkCore;

ApplicationDbContext context = new();

//In-Memory Dataabase üzerinden çalışırken migration oluşturmaya ve migrate etmeye gerek yoktur.
//In-Memory'de uygulama sona erdiğinde veritabanı kaybolur. Haliyle bellekteki veriler silinecektir.
#region Ef Core'da In-Memory Database ile çalışmanın Gereği Nedir?
//Genellikle bu özelliği yeni çıkan Ef Core özelliklerini test edebilmek için kullananılabilir.
//EF Core fiziksel veritabanlarından ziyade in memory de Database oluşturuo üzerinden birçok işlemi yapmamızıı sağlayabilmektedir. İşte bu zözellikle ile gerçek uygulamarın dışında test gibi operasyonları hızlıca yürütebileceğimiz imkanlar elde edebilemekteyiz.
#endregion
#region Avantajları Nelerderdir?
// Test ve Pre-Prod(Yayıyan çıkmadan önceki ürün) uygulamalarda gerçek/fiziksel veritabanları oluşturmak ve yapılandırmak yerine tüm veritabanını bellekte modelleyebilir ve greekli işlemleri sanki gerçek bir veratanından çalışıyor gibi orada gerçekleştirebiliriz.
// Bu sayede uygulama geliştirme sürecinde daha hızlı ve verimli bir şekilde ilerleyebiliriz.
//Bellkete çalışmak geçici bir deneyim olacağı için veritabanı serverlarda test amaçlı üretilmiş olan vertiabanlarının lüzumsuz yer işgalt etmesini engellemiş olacaktır.
//Bellekte veritabanını modellemek kodun hızlı ir şekilde test edilmesini sağlayacaktır.
#endregion
#region Dezavantajları Nelerdir?
//Bellek tabanlı veritabanları genellikle kalıcı değildir. Uygulama kapatıldığında veya bellekteki veri kaybolduğunda, veriler de kaybolur.
//In-Memory'de yapılacak olan veritbanaı işlevlerinde ilişkisel modellemeler YAPILAMAMAKTADIR! Bu durumdan dolayı veri tutuarlılığı sekteye uğrayabilir ve istatistiksel açıdan yanlış sonuçlar elde edebiliriz.
#endregion
#region Örnek Çalışma
//Microsoft.EntityFrameworkCore.InMemory NuGet paketini yükleyin

await context.AddAsync(new Person { Name = "Ali", Surname = "Yılmaz" });
await context.SaveChangesAsync();

var persons = await context.Persons.ToListAsync();
Console.WriteLine();
#endregion

class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}

class ApplicationDbContext: DbContext
{
    public DbSet<Person> Persons { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       optionsBuilder.UseInMemoryDatabase("ExampleDatabase");
    }
}