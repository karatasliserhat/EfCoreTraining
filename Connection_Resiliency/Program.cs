using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;

ApplicationDbContext context = new();
//Bağlantı dayanıklılığı
#region Conneciton_Resiliency Nedir?
//EF Core üzerinden yapılan veritabanı çalışmaları sürecinde ister istemez veritabanı bağlantısında kopumşalr kesintiler vs. mesydana gelmektedir.
//Connection Resiliency ile kopan bağlntıyı tekrar kurmak için ferekli tekrar bağlantı taleplerinde bulunabilir ve biryandan da exucition strategy dedğimiz davrnış modelleri belirleyrek bağktnıların kopması durumunda tekrr edecek olan sorguları baştan sona yeniden tetikleyebiliriz.
#endregion
#region EnableRetryOnFailure
//uygulama sürecinde veritbanaı bağlantısı kopturğu takdirde bu yapılandırma sayesinde bağtıyı tekrardan kurmaya çalışabiliyoruz.

//while (true)
//{
//    await Task.Delay(2000);
//    var persons = await context.Persons.ToListAsync();
//    persons.ForEach(p => Console.WriteLine(p.Name));
//    Console.WriteLine("****************************************");
//}
#region MaxRetryCount
//Yeniden bağlantı sağlanması durumunun kaç kere gerçekleştireeğini bildirmektedir.
//Default değeri 6!dır
#endregion
#region MaxRetryDelay
//Yeniden bağlantı sağlanması periyodunu belirlemektedir.
//Default değeri 30'dur
#endregion
#endregion
#region Execution Strategies
//EF core ile yapılan bir işlem sürecinde veritabanı bağlantısı koptuğu takdirde  yeniden bağldnı denenirken yapılan davranışa/alınan aksiyona Execution Strategy denmektedir.
//Bu strategy'i default değerlerde kullanabiieceğimiz gibi custom olarakta kendimize göre özellştirebilir ve bağlantı koptuğunda istediğimiz aksiyonları alabiliriz.
#region DEfault Execution Strategy
//Eğer ki Connection Resiliency için EnableRetryOnFailure metodunu kullanıyorsak bu default execution strategy'e karşılık gelecektir.
//MaxRetryCount:6
//MaxRetryDelay:30
//Default değerlerin kullanılabilmesi için EnableRetryOnFailure metodunun parametresiz overlodunu kullanılması gerekmektedir.
#endregion
#region Custom Execution Strategy
#region Oluşturma

#endregion
#region Kulanma- ExecutionStrategy
//while (true)
//{
//    await Task.Delay(2000);
//    var persons = await context.Persons.ToListAsync();
//    persons.ForEach(p => Console.WriteLine(p.Name));
//    Console.WriteLine("****************************************");
//}

#endregion
#endregion
#region Bağlantı koptuğu anda Exute edilmesi gereken tüm çalışmaları tekrar işlemek
//EF Core ile yapılan öalışma sürecinde veritabanı bağlantısının kesildiği durumlarda bazen bağlantının kurulması tek başına yetmemekte kesintinin olduğu çalışmanında baştan tekrardan işlenmesi gerekmektedir işte bu tarz durumlara karşılık execute veya executeasync fonksiyonunu bizlere sunmaktadır.

//Execute fonksiyonu, içerisinde vermiş olduğmuz kodları commit edene kardar işleyecektir. Eğer ki tekrardan bağlantı kesilmesi meyadana gelirse bağlantının tektrardan kuruluması durumunda Execute içersindeki öalışmalar tekrar baştan işlenecek ve böylece yapılan işlemintutarlılığı için gerekli çalışmal sağlanmış olacaktır.

//var strategy =context.Database.CreateExecutionStrategy();
//await strategy.ExecuteAsync(async () =>
//{
//    using var transaction = await context.Database.BeginTransactionAsync();
//    await context.Persons.AddAsync(new() { Name = "Hilmi" });
//    await context.SaveChangesAsync();
//    await context.Persons.AddAsync(new() { Name = "Şuayip" });
//    await context.SaveChangesAsync();

//    await transaction.CommitAsync();
//});
#endregion
#region Execution strategy hangi durumlarda kullanılır?
//Veritabanın şifresi belli periyotlarla otomotaik olarak değişen uygulamalrda güncle şifreyle connectionStringi sağlayacak ve güncell şifreyi connectionStringe dahil edecek bir operasyonu Execution strategy belirleyrek gerçekleştirebilirsiniz.
#endregion
#endregion


class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}
class ApplicationDbContext : DbContext
{

    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        #region Default Execution Strategy
        //optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppConnectionResiliencyDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False", builder =>
        //{
        //    builder.EnableRetryOnFailure(
        //        maxRetryCount: 5,
        //        maxRetryDelay: TimeSpan.FromSeconds(15),
        //        errorNumbersToAdd: new[] { 4060 }
        //        );

        //}).LogTo(

        //    filter: (eventId, level) => eventId.Id == CoreEventId.ExecutionStrategyRetrying,
        //    logger: evenData => Console.WriteLine("Bağlantı tekrardan kuruluyor")

        //    );
        #endregion
        #region Custom Execution Strategy
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppConnectionResiliencyDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False", builder => builder.ExecutionStrategy(dependencies => new CustomExecutionStrategy(dependencies, 3, TimeSpan.FromSeconds(15))));
        #endregion

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
}

class CustomExecutionStrategy : ExecutionStrategy
{
    public CustomExecutionStrategy(ExecutionStrategyDependencies dependencies, int maxRetryCount, TimeSpan maxRetryDelay) : base(dependencies, maxRetryCount, maxRetryDelay)
    {

    }

    public CustomExecutionStrategy(DbContext context, int maxRetryCount, TimeSpan maxRetryDelay) : base(context, maxRetryCount, maxRetryDelay)
    {
    }

    int retryCount = 0;
    protected override bool ShouldRetryOn(Exception exception)
    {
        //Yeniden bağlantı durumunun söz konusu olduğu anlarda yapılacak işlemler.
        Console.WriteLine($"{++retryCount}. Bağlantı tekrardan kuruluyor");
        return true;
    }
}