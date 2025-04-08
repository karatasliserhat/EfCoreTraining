using Microsoft.EntityFrameworkCore;
using System.Reflection;


ApplicationDbContext context = new();

#region Keyless Entity Types
//Normal entity type'lara ek olarka PK içermeyen querylere karşı veritabanı sorguları yürütmek için kullanılan bir özelliktir.

//Aggregate operasyonlarıın yapıldığı group by yahut pivot table gibi işlemler neticesinde elde edilen istiatiksel sonuçlar primary kolunu barındırmazlar. Bizler bu tarz sorguları Keyless entity Types özelliği ile sanki bir entity'e karşılık geliyormuşl gibi çalıştırabiliriz.
#endregion

#region Keyless Entity Types Tanımlama

//1. Hangi sorgu olursan olsun EF Core üzerinden bu sorgunun entity'e karşılık geliyormuş gibi /işleme/Execute'a çalıştırmaya tabi tutulması için o sorgu sonucunu bir entity'e karşılık geliyormuş gibi tanımlamamız gerekir. Bunun için Keyless attribute'u kullanılır.
//2. Bu entity'nin DbSet property'si DbContexte tanımlanması gerekiyor.
//3. boş migration oluşturulmalı
//4. tanımlamış olduğumuz entitye onmodelcreateting içerisinde ve PK olmadığonı bildirmeli ve ToView özelliği kazandırılmalı.

//var datas = await context.personOrderCounts.ToListAsync();
#region Keyless Attribute'u

#endregion
#region HasNoKey Fluent API'ı

#endregion
#endregion
#region Keyless Entity Types Özellikleri Nelerdir?
//PK Kolunu Olmaz!
//Aggregate işlemlerinde kullanılır.
//Change racker mekanızması aktif olmayacaktır.
//TPH olarak entity hiyerarşisinde davranışına tabi tutulabilir.
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
//[Keyless]
public class PersonOrderCount
{
    public string Name { get; set; }
    public int TotalOrderCount { get; set; }
}

class ApplicationDbContext : DbContext
{

    public DbSet<Person> Persons { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<PersonOrderCount> personOrderCounts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<PersonOrderCount>()
            .HasNoKey()
            .ToView("vw_PersonOrderCount");

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppKeylesEntityTypesDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");


    }


}
