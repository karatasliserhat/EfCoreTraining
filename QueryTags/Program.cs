using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;


ApplicationDbContext context = new();


#region Query Tags Nedir?
//EF Core ile generate edilen sorgulara açıklama eklememizi sağlayarak SQL Profiler, Query log vs gibi yapılarda bu açıklamalar eşliğinde sorguları gözlemlememizi sağlar.
#endregion

#region TagWith Metodu

//await context.Persons.TagWith("Örnek bir açıklama......").ToListAsync();

#endregion
#region Multiple TagWith
//await context.Persons.TagWith("Tüm personneller çekilmiştir.").Include(o=> o.Orders).TagWith("Personellerin yaptığı satışlar sorguya çekilmiştir.").Where(p=> p.Name.Contains("a")).TagWith("Personel adlarının içerisinde a harfi olanlar filtre olarak eklenmiştir.").ToListAsync();
#endregion
#region TagWithCallSite Metodu
//oluşturulan sorguya açıklamaya satırı ekler ve bu sorgunun hangi dosyada ve hangi satırda üretildiği bilgisini verir.
await context.Persons.TagWithCallSite("Tüm personneller çekilmiştir.").Include(o => o.Orders).TagWithCallSite("Personellerin yaptığı satışlar sorguya çekilmiştir.").Where(p => p.Name.Contains("a")).TagWithCallSite("Personel adlarının içerisinde a harfi olanlar filtre olarak eklenmiştir.").ToListAsync();
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


    readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddFilter((category, level) =>
    {
        return category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information;
    }).AddConsole());
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppQueryTagsDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");

        optionsBuilder.UseLoggerFactory(loggerFactory);
    }

}
