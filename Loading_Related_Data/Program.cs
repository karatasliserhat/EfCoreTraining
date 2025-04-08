using Microsoft.EntityFrameworkCore;
using System.Reflection;

ApplicationDbContext context = new();

#region Eager Loading
//Eager Loading Genereate edilen bir sorguya ilişkisel verilerin parça parça eklenmesini sağlayan ve bunu yaparken iradeli/istekli bir şekilde yapmamızı sağlayan bir yöntemdir.
#region Include
//Eagder Loading operasyonunu yapmamızı sağlayan bir fonksiyondur.
//Yani üretilen bir sorguya diğer ilişkisel tabloların dahil edilmesini sağlayan bir işleve sahiptir.


//var employees = await context.Employees
//    .Include(e => e.Orders)
//    .Where(e => e.Orders.Count > 2)
//    .Include(e => e.Region)
//    .ToListAsync();

#endregion

#region ThenInclude

//Then Include üretilen sorguda include edilen tabloların ilişkilş olduğu diğer tablolarıda sorguya ekleyeilmek için kullanılan bir fonskiyondur.
//üretilen sorguya include edilen navigation property koleksiyonel bir property ise işte o zaman bu porperty üzerinden diğer ilişkisel tabloya erişim gösterilememektedir. Böyle bir durumda koleksiyonel propepertylerin türlerine erişip, o tür ile ilişkili diper tablolarıda sorguya dahil etmek için ThenInclude fonksiyonunu kullanabiliriz.

//ilişkili olan tablo üzerinden navigation property tekil ise aşağıdaki yapılandırmayı kullanabilirz.
//var orders = await context.Orders
//    //.Include(o => o.Employee)
//    .Include(o => o.Employee.Region)
//    .ToListAsync();

//var orders = await context.Orders
//    .Include(o => o.Employee)
//        .ThenInclude(e => e.Region)
//    .ToListAsync();

//var orders = await context.Regions
//    .Include(r => r.Employees)
//    .ThenInclude(e => e.Orders)
//    .ToListAsync();
#endregion

#region FilteredInclude
//sorgulama süreçlerinden include yaparken sonuçlar üzerinden filtreleme ve sıralama gerçekleştirebilmemizi sağlayan bir özelliktir.

//var region = await context.Regions
//    .Include(r => r.Employees.Where(e=> e.Name!.Contains("1")))
//    .ToListAsync();

//var region = await context.Regions
//    .Include(r => r.Employees.Where(e => e.Name!.Contains("1")).OrderByDescending(x => x.Surname))
//    .ToListAsync();

//Desteklenen Fonskiyorunlar: Where, OrderBy, OrderByDescending, ThenBy, ThenByDescending, Skip, Take, Distinct, Select

//Change Tracker'in aktif olduğu durumlarda include edilmiş sorgular üzerindeki filtreleme sonuçları beklenmeyen olabilir. Bu durum daha önce sorgulanmış ve Change Tracker tarafından takip edilmiş veriler arasında filtrenin gereksinimi dışında kalan veriler için söz konusu olacaktır. Bundan dolayı sağlıklı bir filtred incldude operasyonu için change tracker'in kullanılmadığı sorguları tercih etmeyi düşünebiliriz.
#endregion

#region Eager Loading için Kritik Bir Bilgi
//EF Core önceden üretilmiş ve execute edilerek verileri belleğe alınmış olan sorguların verileri, sonraki sorgularda KULLANIR! bundan dolayı Include edip çekmeye gerek yoktur. aşağıdaki kodda orderslerı çektik sonrasında employee çekerken ordersları include etmeye gerek yoktur çünkü önceki sorguda orderslar belleğe alınmış durumda.

//var orders = await context.Orders.ToListAsync();

//var employees = await context.Employees.ToListAsync();

#endregion



#region AutoInclude - EF Core 6
//Uygulama seviyesinde bir entitye karşılık tüm sorgulamalarda "Kesinlikle" bir tabloya include operasyonu işlemi gerçekleştirilecekse eğer bunu merkezi hale getirip kullanabiliriz.

//builder.Navigation(x => x.Region)
//               .AutoInclude();

//var employees = await context.Employees.ToListAsync();

#endregion

#region IgnoreAutoIncludes

//Auto Include verilen merkezi yapıda include ilişkili tablo gelmesini istemeyeceğimiz durumlarda kullanabiliriz.

//var employees = await context.Employees.IgnoreAutoIncludes().ToListAsync();

#endregion


#region Birbirlerinden Türerilmiş Entity'ler Arasında Include
#region Cast Operatörü ile Include
//var persons = await context.Persons.Include(p => ((Employee)p).Orders).ToListAsync();
#endregion

#region As Operatörü ile Include
//var personsAS = await context.Persons.Include(p => (p as Employee).Orders).ToListAsync();
#endregion

#region 2.Overload ile Include
//var persons2 = await context.Persons.Include("Orders").ToListAsync();
#endregion

#endregion

#endregion




Console.Read();
class Person
{
    public int Id { get; set; }

}
class Employee : Person
{
    public Employee()
    {
        Orders = new HashSet<Order>();
    }
    public int RegionId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public Region Region { get; set; }

    public ICollection<Order> Orders { get; set; }
    public int Salary { get; set; }
}

class Region
{
    public Region()
    {
        Employees = new HashSet<Employee>();
    }
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Employee> Employees { get; set; }
}

class Order
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime OrderDate { get; set; }
    public Employee Employee { get; set; }
}
class ApplicationDbContext : DbContext
{

    public DbSet<Person> Persons { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Order> Orders { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppEagerLoadingDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
    }


}