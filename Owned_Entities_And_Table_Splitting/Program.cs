using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;


ApplicationDbContext context = new();


#region Owned Entity Types Nedir?
//Ef Core sınıflarını parçalayarak, propertylerini kümesel olarak farklı sınıfılarda barındırmamıza ve tüm sınıfıları ilgili entity'de birleştirerek bütünsel olarak çalışmamıza izin vermektedir.
//Böyle bir entity, sahip olunan(owned) birden fazla alt sınıfın birleşmesiyle meydana gelmektedir.
#endregion
#region Owned Entity Types'ı Neden Kullanırız?
//Domain Driven Design(DDD) yaklaşımında Value Object'lere karşılık olarak owned Entity Types'lar kullanılır.
#endregion

#region Owned Entity Types Nasıl Uygulanır?

#region OwnsOne Metodu

#endregion
#region Owned Attribute'u

#endregion
#region IEntityTypeConfigution<T> Arayüzü

#endregion
#region OwnedMany Metodu
//OwnsMany Metodu entity'nin farklı özelliklerine başka bir sınıftan ICollection türünde navigation property aracılığıyla ilişkisel olarak erişebilmemizi sağlayan bir işleve sahiptir.

//Normalde Has ilişkisi olarak kurulabilecek bu ilişkinin temel farklı, Has ilişkisi DbSet property'si gerektiren OwnsMany metodu ise Dbset'ihtiyaç duyulmaksınız gerçekleştirmemizi sağlamaktadır.
#endregion
#endregion

#region Sınırlılıklar
//herhangi bir owned Entity Type için Dbset property'sine gerek yoktur
//OnModelCreating fonksiyonunda Entity<T> metodu ile Owned Entity type türünden bir sınıf üerinden herhnagi bir konfigürasyon gerçekleştirilemez.
//Owned Entity Type'ların kalıtımsal hiyerarşi desteği yoktur.
#endregion

Console.WriteLine();

class Employee
{
    public int Id { get; set; }
    //public string Name { get; set; }
    //public string MiddleName { get; set; }
    //public string LastName { get; set; }
    //public string StreedAddress { get; set; }
    //public string Location { get; set; }
    public bool IsActive { get; set; }
    public EmployeeName EmployeeName { get; set; }
    public EmployeeAddress EmployeeAddress { get; set; }
    public ICollection<Order> Orders { get; set; }
}
//[Owned]
class EmployeeName()
{
    public string Name { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
}
//[Owned]
class EmployeeAddress
{
    public string StreedAddress { get; set; }
    public string Location { get; set; }
}

class Order
{
    public DateTime OrderDate { get; set; }
    public int Price { get; set; }
}
class ApplicationDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        #region OwnedOne
        //modelBuilder.Entity<Employee>()
        //    .OwnsOne(x => x.EmployeeName, builder =>
        //    {
        //        builder.Property(p => p.Name).HasColumnName("Name");
        //    });
        //modelBuilder.Entity<Employee>()
        //    .OwnsOne(x => x.EmployeeAddress);
        #endregion

        #region OwnsMany
        modelBuilder.Entity<Employee>().OwnsMany(e => e.Orders, builder =>
        {
            builder.WithOwner().HasForeignKey("OwnedEmployeeId");
            builder.Property<int>("Id");
            builder.HasKey("Id");
        });
        #endregion

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppOwnedEntitiesTypeDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");


    }

}
