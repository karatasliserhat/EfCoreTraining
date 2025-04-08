using Microsoft.EntityFrameworkCore;
using System.Reflection;
ApplicationDbContext context = new();


#region Explicit Loading
//Oluşturulan sorguya eklenecek verilerin şarlara bağlı bir şekilde/ihtiyaçlara istinaden yüklenmesini sağlayan bir yaklaşımdır.

//var employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == 2);

//if (employee is { Name: "Ali 2" })
//{
//    var orders = await context.Orders.Where(x => x.Id == employee.Id).ToListAsync();
//}

#region Reference
//İlişkisel olan Tekil türdeki navigation propertleri ihtiyaca göre context.entry(employee).Reference().loadAsync(); fonksiyonu ile yüklenebilir.

//var employee = await context.Employees.IgnoreAutoIncludes().FirstOrDefaultAsync(x => x.Id == 2);

//await context.Entry(employee)
//    .Reference(x => x.Region)
//    .LoadAsync();

#endregion

#region Collection

//İlişkisel olan Collection türdeki navigation propertleri ihtiyaca göre context.entry(employee).Collection().loadAsync(); fonksiyonu ile yüklenebilir.


//var employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == 2);
//await context.Entry(employee).Collection(x => x.Orders).LoadAsync();
#endregion

#region Collectionlarda Aggregate Operatör Uygulamak
//var employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == 2);
//var count =await context.Entry(employee).Collection(x => x.Orders).Query().CountAsync();
#endregion

#region Collectionlarda Filtreleme Gerçekleştirmek
//var employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == 2);

//var orders = await context.Entry(employee).Collection(x => x.Orders).Query().Where(q => q.OrderDate.Day == DateTime.Now.Day).ToListAsync();
#endregion

#endregion


Console.WriteLine();

class Employee
{
    public Employee()
    {
        Orders = new HashSet<Order>();
    }
    public int Id { get; set; }
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

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Order> Orders { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppLoadingExplicitDataDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
    }


}