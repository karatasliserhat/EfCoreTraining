using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;


ApplicationDbContext context = new();
//var datas = await context.Persons.ToListAsync();

#region Neden Loglama Yaparız?
//Çalışan bir sistemin runtime'da nasıl davranış gerçekleştirdiğini gözlemlemek için loglama yaparız.
#endregion
#region Neleri Loglarız?
//yapılan sorguların çalışma süreçlerindeki davranışlarını
//Gerekirse hassas veriler üzerinde loglama işlemi gerçekleştiriyoruz.
#endregion
#region Basit Olarak Loglama Nasıl Yapılır?
//Minumum yapılandırma gerektirmesi.
//herhangi bir nuget paketine ihtiyaç duyulmaksızın loglamanın yapılabilmesi.


#region Debug penceresine log nasıl atılır?
//optionsBuilder.LogTo(message => Debug.WriteLine(message));
#endregion
#region Bir dosyaya log nasıl atılır?
//Normalde console yahut debug pencerelerine atılan loglar pek takip edilebilir nitelikte olmamaktadır.


#endregion
#endregion
#region Hassas Verilerin Loglanması - EnableSensetiveDataLogging
//Default olarak Ef COre log mesajlarında herhangi bir verinin değerini içermemektedi bunun nedir gizlilik teşkil edebilecek verilerin loglama sürecinde yanlışlıklada olsa açığa çıkmamasıdır.

//Bazen alınan hatalarda verinin değerini bilmek, hatayı debug edebilmek için oldukça yardımcı olmaktdır, bu durumda hassas verilen loglanmasını sağlamakdır.
#endregion
#region Exception Ayrıntısını Loglama - EnableDetailedErrors

#endregion
#region Log Levels
//EF Core default olarak DEbug seviyesinin (debug dahil) üstündeki tüm davranışları loglar.
//Seviyeler şu şekildedir: 
//Trace, Debug, Information, Warning, Error, Critical

//Error seviyesinde loglama yaparsam şu seviyeleri alır: 

#endregion


//////////////////////////////////////////////////////////////////////////////////////////////////////////////


#region Query Log Nedir?
//LINQ sorguları neticesinde generate edilen sorguları izleyebilmek ve olası teknik hataları ayıklayabilmek amacıyla query log mekanızmasından istifade etmekteyiz.
#endregion
#region Nasıl Konfigure Edilir?
//Microsoft.Extensions.Logging.Console

var datas = await context.Persons.ToListAsync();
await context.Persons
    .Include(o => o.Orders)
    .Where(p => p.Name.Contains("a"))
    .Select(p => new { p.Name, p.Id }).ToListAsync();
#endregion

#region Filtreleme Nasıl Yapılır?
//readonly ILoggerFactory loggerFactory = LoggerFactory.Create(conf => conf.AddFilter((category, level) =>
//{
//    return category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information;
//}).AddConsole());
#endregion
Console.WriteLine();
public class Person
{
    public Person() => Orders = new HashSet<Order>();
    public int Id { get; set; }

    public string Name { get; set; }
    public ICollection<Order> Orders { get; set; }
}
public class Order
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public Person Person { get; set; }
}

class ApplicationDbContext : DbContext
{

    public DbSet<Person> Persons { get; set; }
    public DbSet<Order> Orders { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


    }


    #region Log

    //StreamWriter _log = new("logs.txt", append: true);

    #endregion

    #region QueryLog
    readonly ILoggerFactory loggerFactory = LoggerFactory.Create(conf => conf.AddFilter((category, level) =>
    {
        return category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information;
    }).AddConsole());
    #endregion
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppEFCoreLoggingDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");

        #region Log
        //optionsBuilder.LogTo(Console.WriteLine);
        //optionsBuilder.LogTo(message => Debug.WriteLine(message));
        //optionsBuilder.LogTo(async message => await _log.WriteLineAsync(message), LogLevel.Error)
        //    .EnableSensitiveDataLogging(true)
        //    .EnableDetailedErrors(true);
        #endregion

        #region Query Log
        optionsBuilder.UseLoggerFactory(loggerFactory);
        #endregion
    }

    #region Log
    //public override void Dispose()
    //{
    //    base.Dispose();
    //    _log.Dispose();
    //}
    //public override async ValueTask DisposeAsync()
    //{
    //    await _log.DisposeAsync();
    //    await base.DisposeAsync();

    //}
    #endregion
}
