using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

ApplicationDbContext context = new();

#region Data Concurrency Nedir?
//Geliştirdiğimiz uygulamalarda ister istemez verisel olarak tutarsızlıklar meydana gelmektedir.

//Örneğin birden fazla uygılamnın ve yahut client'ın aynı veritabanı üzerinden eşzamanlı olarak çalıştığı durumlarda verisel anlamda uygulamadan uygulamaya ve yahut client'tan client'a tutarsızlıklar meydana gelebilir.

//DAta Concurrency kavramı veri tutarsızlığına karşılık yönetileilirliği sağlayacak olan davranışları kapsayan bir kavramdır.

//Bir uygulamada veri tutarsızlığının olması demek o uygulamayı kullanan kullanıcıları yanıltmak demektir.

//Verit tutarsızlığının olduğu uygyulamalrda istatistiksel olarak yanlış sonuçları elde edilebilir.
#endregion
#region Stale & Dirty (Bayat & Kirli) Data Nedir?
//Stale Data: Veri tutarsızlığına sebebiyet verebilecek güncellenmiş yahut zamanı geçmiş olan verileri ifade etmektedir. Örneğin bir ürünün stok durumu sıfırlandığı halde arayüz üzerinde bunu ifade eden bir güncelleme durumu söz konusu değilse işte bu stale data durumuna örnektir.

//Dirty Data: Veri tutarsızlığına sebebiyet verebilecek verinin hatalı veyahut yanlış olduğunu ifade etmektedir. Örneğin Adı: Ahmet olan bir kullanıcın veritabnaında 'Mehmet ' olarak tutulması dirty data örneklendirmesidir.
#endregion
#region Last In Wins (Son Gelen  Kazanır)
// Bir veri yapısında son yapılan aksiyona göre en güncel verinin en üstte bulunması sağlayan bir deneyimsel terimdir.
#endregion
#region Pessimistic Lock (Kötümser Kilitleme)
// Bir transaction sürecinde elde edilen veriler üzerinden farklı sorgularla değişiklik yapılmasını engellemek için ilgili verilerin kilitlenmesini(locking) sağlayarak değişikliğe karşı direcç oluşturulmasını ifade eden bir yöntemdir.

//Bu verilerin kilitlenmesi durumu ilgili transaction'ın commit ya da rollback edilmesi ile sınırlıdır.

#region DeadLock Nedir?
//kilitlenmiş olan bir verinin veritabanı seviyesinde meydna gelen sistemsel bir hatadan dolayı kilidinin çözülememesi ve yahut döngüsel olarak kilitlenme durumunun meydana gelmesini ifade eden bir tetimdir.

//Pessimistic lock yönteminde deadlock durumunu yaşamanız bir ihtimaldir O yüzden değerlendirilmesi gerek ve iyi düşnülerek tercih edilmesi gereken pessimistic bir yaklaşımdır.
#endregion
#region Kilitleme çıkmazı - ülüm Kilitlemesi Nedir?

#endregion
#region WITH(XLOCK)
//await using var transaction = await context.Database.BeginTransactionAsync();
//var data = context.Persons.FromSql($"Select * From Persons WITH (XLOCK) Where Id=4").ToListAsync();
//Console.WriteLine();
//await transaction.CommitAsync();
#endregion
#endregion
#region Optimistic Lock (İyimser Kilitleme)
//Bir verinin stale olup olmadığını anlamak için herhangi bir locking işlemi olmaksınızı versiyon mantığında çalışmamızı sağlayan yaklaşımdır.

//Optimistic lock yönteminde, Pessimistic lok'da olduğu gibiveriler üzerinden tutarsızlığa mahale olabilecek değişiklikler fiziksel olarak engellenmemektedir. yani veriler tutarsızlığı sağlayacak şekilde değiştirilebilir.
//Amma velakin optimistic lock yaklaşımı ile bu veriler üzerindeki tutuarsızlık durmunu takip edebilmek için versyion bilgini kullanıyoruz. Bunu da şöyle Kullanıyoruz:

// Her bir veriye akrşılık bir versiyon bilgisi üretiliyor. Bu bilgi ister metinsel istersekte sayısal olabilir Bu versiyon bilgisi veri üzerinden yapılan her bir değişiklik neticesinde güncellenecektir. Dolayısıyla bu güncellemyi daha kolay bir şekilde geçerkleştirebilmek için sayısal olamsını tercih ederiz.

//EF Core üzerinden verileri srogularken ilgili verilen versiyon bilgilerinide in-Memoriye alıyoruz ardından veri üzerinden bir değişiklil yapılırsa eğer bu inmemory'deki versyon bilgisi ile eritbananındaki versiyon bilgisi karşılaştırıyoruz Eğer ki bu karşılaştırma doğrulanıyorsa yapılan aksiyon geçerli olacaktır yok eğer doğrulanmıyorsa demek ki verinin değeri değişmiş anlamına geleek yani bir tutarsızlık durumu oluğu anlaşaılacaktır işte bu durumda bir hata fırlatılacak ve aksiyon gerçekleştirilmeyecektir.

//Ef Core optimistic lock yaklaşımı için genetiğinde yapısal bir özellik barındırmaktadır.
#region Property Based Configuration (ConcurrencyCheck Attribute)
//Verisel tutuarlılığın kontrol edilmkek istendiği propertyler ConCurrencyCheck atribute'u ile işaretlenir bu işaretleme bericesinde her bir entity'nin instance 'ı için in memory'de bir token değeri üretilecektir. Üretilen bu token değeri alınan aksiyon süreçkerinde EF Core tarafından doğrulacak ve eğer ki hrhangi bir değişiklik yoksa aksiyon başarıyla sonladırımlış olacaktır. Yok Eğr transaction sürecinde ilgili veri  üzeride(ConcurrencyCheck attiribute ile işaretlenmiş properylerde) herhangi bir değişiklik durumu söz konusuysa o tarkdirde üretilen token'da değiştirilecek ve hliyle doğrula süreci geçerli olmayacağı anlaşılacağı için veri tutarsızlığı durumu olduğu anlaşılacak ve hata fırlatacaktır.

//var person = await context.Persons.FindAsync(3);
//context.Entry(person).State=EntityState.Modified;
//await context.SaveChangesAsync();
#endregion
#region RowVersion Column
//Bu yaklaşımda ise her bir satıra karşılık versyion bilgisi fiziksel olarak oluşturulmaktadır.

var person = await context.Persons.FindAsync(4);
context.Entry(person).State = EntityState.Modified;
await context.SaveChangesAsync();
#endregion
#endregion
class Person
{
    public int Id { get; set; }
    //Property Based Configuration
    //[ConcurrencyCheck]
    public string Name { get; set; }
    
    //RowVErsion
    //[Timestamp]
    public byte[] RowVersion { get; set; }
}
class ApplicationDbContext : DbContext
{

    public DbSet<Person> Persons { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Property Based Configuration
        //modelBuilder.Entity<Person>().Property(x => x.Name).IsConcurrencyToken();

        //RowVErsion
        modelBuilder.Entity<Person>().Property(p => p.RowVersion).IsRowVersion();

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

    readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppDataConcurrencyDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
        optionsBuilder.UseLoggerFactory(loggerFactory);
    }
}

