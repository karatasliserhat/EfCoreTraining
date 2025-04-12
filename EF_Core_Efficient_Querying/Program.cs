using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;
using System.Transactions;

ApplicationDbContext context = new();

#region EF Core Select Sorgularını Güçlendirme Teknikleri

//IQueryable ve IEnumarable davranışsal olarak aralarında farklar barındırsalarda her ikisi de Deffered Execution (Gecikmeli Çalıştırma) özelliğine sahiptir. Bu özellik sayesinde sorguların çalıştırılması, sonuçların ihtiyaç duyulduğu anda gerçekleştirilir. Bu sayede gereksiz yere veritabanına sorgu gönderilmesi engellenir ve performans artışı sağlanır. bunları execute edebilmek için .ToList() gibi tetikleyici fonksiyonlar veya Foreach gibi döngü yapıları kullanılmalıdır. Bu tetikleyici fonksiyonlar, sorgunun çalıştırılmasını ve sonuçların elde edilmesini sağlar. Bu sayede, sorguların performansı artırılır ve gereksiz yere veritabanına sorgu gönderilmesi engellenir.
#region IQueryable - IEnumerable Farkı
//IQueryable, bu arayüz üzerinden yapılacak işlemler direkt generate edilecke olan sorguya yansıtılacaktır.
//IEnumerable ise, bu arayüz üzerinden yapılacak işlemler, temel srogu netieicesinde in-memory'e yüklenen intanceler üzerinde gerçekleştirilir Yani sorguya yansıtılmaz.

//IQueryable ile yapılan sorgulama çalışmalarında sql sorguyu hedef verileri elde edecek şekilde generate edilecekken, IEnumarable ile yapılan sorgulama çalışmalarında sql daha geniş verileri getirebilelcek şekilede execute edilerek hedef verileri in-memory'de ayıklanır.

//IQueryable hedef verileri getirirken , IEnumarable ise hedef verileri in-memory'de ayıklar.

#region IQueryable
//var persons = await context.Persons.Where(p => p.Name.Contains("a"))
//                                   .Take(3).ToListAsync();


//var persons = await context.Persons.Where(p => p.Name.Contains("a"))
//                                   .Where(p => p.Id > 3)
//                                   .Take(3)
//                                   .Skip(3)
//                                   .ToListAsync();

//var persons =  context.Persons.Where(p => p.Name.Contains("e"))
//                                    .Take(3);

//foreach (var person in persons)
//{

//}
#endregion

#region IEnumerable
//var persons =  context.Persons.Where(p => p.Name.Contains("a"))
//                                   .AsEnumerable()
//                                   .Take(3)
//                                   .ToList();

//var persons = context.Persons.Where(p => p.Name.Contains("o"))
//                                   .AsEnumerable()
//                                   .Where(p => p.Id > 3)
//                                   .Skip(3)
//                                   .Take(3)
//                                   .ToList();

//Console.WriteLine();
#endregion

#region AsQueryable

#endregion
#region AsEnumerable

#endregion

#endregion

#region Yalnıca ihtiyaç olan kolonları Listeleyin - Select
//var persons = await context.Persons
//    .Select(x => new { x.Name })
//    .ToListAsync();
#endregion

#region Result'ı Limitleyin - Take
//var person = await context.Persons
//                          .Take(50)
//                          .ToListAsync();

//Console.WriteLine();
#endregion

#region Join Sorgularında Eager Loaindg Sürecinde Verileri Filtreleyin
//var persons = await context.Persons
//    .Include(x => x.Orders
//                   .Where(o => o.Price > 500)
//                   .OrderByDescending(x => x.Id)
//                   .Take(4))
//    .ToListAsync();
#endregion

#region Şartlara bağlı Join Yapılacaksa Eğer Explicit Loading Kullanın
//var person = await context.Persons
//    .FirstOrDefaultAsync(x => x.Id == 1);

//if (person is { Name: "Person 1" })
//    await context.Entry(person).Collection(x => x.Orders).LoadAsync();

//await context.Entry(person).Collection(x => x.Orders).Query()
//    .Where(x => x.PersonId == person.Id).LoadAsync();
#endregion

#region Lazy Loading Kullanırken Dikkatli Olun
#region Riskli Durum Her persona karşı bir sorgu
//var persons = await context.Persons.ToListAsync();

//foreach (var person in persons)
//{
//    foreach (var order in person.Orders)
//    {
//        Console.WriteLine($"{person.Name} - {order.Id} ");
//    }
//    Console.WriteLine("************************************************");
//}
#endregion
#region İdeal Durum
//var persons = await context.Persons.Select(p => new { p.Name, p.Orders }).ToListAsync();

//foreach (var person in persons)
//{
//    foreach (var order in person.Orders)
//    {
//        Console.WriteLine($"{person.Name} - {order.Id} ");
//    }
//    Console.WriteLine("************************************************");
//}
#endregion
#endregion

#region İhtiyaç Noktalarında Ham SQL Kullanın - FromSql

#endregion

#region Asenkron Fonksiyonları Tercih Edin

#endregion
#endregion
Console.WriteLine();
public class Person
{
    readonly ILazyLoader _lazyLoader;
    private ICollection<Order> _orders;
    public Person(ILazyLoader lazyLoader) =>
        _lazyLoader = lazyLoader;
    public Person() => Orders = new HashSet<Order>();
    public int Id { get; set; }

    public string Name { get; set; }
    public ICollection<Order> Orders { get => _lazyLoader.Load(this, ref _orders); set => _orders = value; }
}
public class Order
{
    readonly ILazyLoader _lazyLoader;

    private Person _person;
    public Order(ILazyLoader lazyLoader) =>
        _lazyLoader = lazyLoader;
    public Order() { }
    public int Id { get; set; }
    public int PersonId { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public Person Person { get => _lazyLoader.Load(this, ref _person); set => _person = value; }
}


class ApplicationDbContext : DbContext
{

    public DbSet<Person> Persons { get; set; }
    public DbSet<Order> Orders { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {



        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppEfficientQueryingDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");


    }


}
