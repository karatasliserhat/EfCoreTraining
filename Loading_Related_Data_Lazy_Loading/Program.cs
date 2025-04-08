using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection;
using System.Runtime.CompilerServices;

ApplicationDbContext context = new();

#region Lazy Loading Nedir?
//Navigation propertyleri üzerinden bir işlem yapılmaya çalışıldığı takdirde ilgili propertyniin veya temsil ettiği /karşılık gelen tabloya özel bir sorgu oluşturulup execute edilmesini ve verilerin yüklenmesini sağlayan bir yaklaşımdır.
#endregion

//var employee = await context.Employees.FindAsync(2);
//Console.WriteLine(employee?.Region.Name);

#region Prox'lerle Lazy Loading
//Microsoft.EntityFrameworkCore.Proxies
// optionsBuilder.UseLazyLoadingProxies();
//Proxy üzerinden lazy loading işlemi gerçekleştiroyrsanız Navigation propertylerin VIRTUAL olması gerekmektedir. Aksi takdirde proxy oluşturulamaz ve lazy loading işlemi gerçekleşmez. bu durumda patlama meydana gelecektir.
#endregion

#region Proxy olmaksızın Lazy Loading

//Prox'ler tüm platformlarda deteklenmeyebilir. Böyle bir durumda manuel bir şekilde lazy loading'i uygulamak mecvuriyetinde kalabiliriz.
//Manuel yapılan LazyLoading operasyonlarında Navigation Propertylerin virtual olmasına gerek yoktur. Çünkü proxy oluşturulmayacaktır.
#region ILazyLoader Interface'i ile Lazy Loading
//Microsoft.EntityFrameworkCore.Abstraction

//var employee = await context.Employees.FindAsync(2);
#endregion
#region ILazyLoader ile çalışma

//public class Employee
//{

//    ICollection<Order> _orders;
//    Region _region;
//    ILazyLoader _lazyLoader;
//    public Employee(ILazyLoader lazyLoader) => _lazyLoader = lazyLoader;

//    public Employee() { }
//    public int Id { get; set; }
//    public int RegionId { get; set; }
//    public string? Name { get; set; }
//    public string? Surname { get; set; }
//    public Region Region
//    {
//        get => _lazyLoader.Load(this, ref _region);
//        set => _region = value;
//    }

//    public ICollection<Order> Orders { get => _lazyLoader.Load(this, ref _orders); set => _orders = value; }
//    public int Salary { get; set; }
//}

//public class Region
//{
//    ICollection<Employee> _employees;
//    ILazyLoader _lazyLoader;
//    public Region(ILazyLoader lazyLoader) => _lazyLoader = lazyLoader;
//    public Region() { }
//    public int Id { get; set; }
//    public string? Name { get; set; }
//    public ICollection<Employee> Employees
//    {
//        get => _lazyLoader.Load(this, ref _employees);
//        set => _employees = value;
//    }
//}

//public class Order
//{
//    Employee _employee;
//    ILazyLoader _lazyLoader;

//    public Order() { }
//    public Order(ILazyLoader lazyLoader) => _lazyLoader = lazyLoader;
//    public int Id { get; set; }
//    public int EmployeeId { get; set; }
//    public DateTime OrderDate { get; set; }
//    public Employee Employee { get => _lazyLoader.Load(this, ref _employee); set => _employee = value; }
//}
#endregion
#region Delegate ile Lazy Loading
//var employee = await context.Employees.FindAsync(2);

#endregion
#region Delete ile Lazy Loading Çalışma
//public class Employee
//{
//    Action<object, string> _lazyLoader;

//    ICollection<Order> _orders;
//    Region _region;

//    public Employee(Action<object, string> lazyLoader) => _lazyLoader = lazyLoader;

//    public Employee() { }
//    public int Id { get; set; }
//    public int RegionId { get; set; }
//    public string? Name { get; set; }
//    public string? Surname { get; set; }
//    public Region Region
//    {
//        get => _lazyLoader.Load(this, ref _region);
//        set => _region = value;
//    }

//    public ICollection<Order> Orders { get => _lazyLoader.Load(this, ref _orders); set => _orders = value; }
//    public int Salary { get; set; }
//}

//public class Region
//{
//    ICollection<Employee> _employees;
//    Action<object, string> _lazyLoader;
//    public Region(Action<object, string> lazyLoader) => _lazyLoader = lazyLoader;
//    public Region() { }
//    public int Id { get; set; }
//    public string? Name { get; set; }
//    public ICollection<Employee> Employees
//    {
//        get => _lazyLoader.Load(this, ref _employees);
//        set => _employees = value;
//    }
//}

//public class Order
//{
//    Employee _employee;
//    Action<object, string> _lazyLoader;

//    public Order() { }
//    public Order(Action<object, string> lazyLoader) => _lazyLoader = lazyLoader;
//    public int Id { get; set; }
//    public int EmployeeId { get; set; }
//    public DateTime OrderDate { get; set; }
//    public Employee Employee { get => _lazyLoader.Load(this, ref _employee); set => _employee = value; }
//}

//static class LazyLoadingExtensiona
//{
//    //CallerMemberName attiribute=> TRelated parametresinin ismini otomatik olarak alması için ekledik.
//    public static TReleated Load<TReleated>(this Action<object, string> loader, object entity, ref TReleated navigation, [CallerMemberName] string navigationName = null)
//    {
//        loader.Invoke(entity, navigationName);

//        return navigation;
//    }
//}


#endregion

#endregion

#region N+1 Problemi
//var region = await context.Regions.FindAsync(1);

//foreach (var item in region.Employees) //Her bir tetiklemeye karşılık bir istek oluşturacaktır bu duruma N+1 problemi denir.
//{
//    var orders = item.Orders;

//    foreach (var order in orders)
//    {
//        Console.WriteLine(order.OrderDate);
//    }
//}
#endregion

//Lazy Loading kullanım açısından oldukça maliyetli ve performans düşürücüsü etkiye sahiptir O yüzden kullanırken mümkün mertebe dikkatli olmalı ve özellikle navigation propertylerin döngüsel tetikleme durumlarında lazy loadingg'i tercih etmemeye odaklanmalıyız Aksi takdirde her bir tetikleme için ayrı bir istek oluşturulacaktır. bu durumu N+1 problemi olarak adlandırıyoruz.
//Mümkün mertebe ilişkisel verileri eklerken lazy loading'i kullanmamaya odaklanmalıyız.



Console.Read();

public class Employee
{

    public Employee() => Orders = new HashSet<Order>();
    public int Id { get; set; }
    public int RegionId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public virtual Region Region { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
    public int Salary { get; set; }
}

public class Region
{
    public Region() => Employees = new HashSet<Employee>();
    public int Id { get; set; }
    public string? Name { get; set; }
    public virtual ICollection<Employee> Employees { get; set; }

}

public class Order
{


    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime OrderDate { get; set; }
    public virtual Employee Employee { get; set; }
}


class ApplicationDbContext : DbContext
{

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Order> Orders { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppLoadingLazyDataDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");


        optionsBuilder.UseLazyLoadingProxies();
    }


}