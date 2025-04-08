using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;


ApplicationDbContext context = new();

#region Scalar Function Nedir?
// Geriye herhangi bir türde değer döndüren bir fonksiyondur.
#endregion
#region Scalar Function Oluşturma
//1.adım boş migration oluşturulmadı.
//2.adım bu migration içerisinde UP metodunda Sql metodu eşliğinde fonksiyon create kodları yazılacak, Down metodunda ise fonksiyonun silinmesi için drop kodları yazılacak.
//3.adım migration uygulanmalı.
#endregion
#region Scalar Function'ı EF Core'a Entegre Etme
#region HasDBFunction
//Veritabanı seviyesindeki herhangi bir fonksiyonu EF Core/yazılınm kısmında bir metoda bind etmemizi sağlayan fonksiyondur.

//var persons = await (from person in context.Persons
//                     where context.GetPersonTOTALPRICE(person.Id) > 500
//                     select person).ToListAsync();

//Console.WriteLine();
#endregion
#endregion

#region Inline Function Nedir?
//Geriye bir değer değil tablo döndüren bir fonksiyondur.
#endregion
#region Inline Function Oluşturma
//1.adım boş bir migration oluşturun
//2.adım bu migration içerisindeki up fonksiyonunda create işlemini, down fonksiyonunda drop işlemini yapın.
//3.adım migration'ı uygulayın.
#endregion
#region Inline Function'ı EF Core'a Entegre Etme
var data = await context.BestSellingStaff(500).ToListAsync();
#endregion

data.ForEach(x => Console.WriteLine($"Name: {x.Name} Order Count: {x.OrderCount} Total Order Price: {x.TotalOrderPrice}"));
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

public class PersonOrder
{
    public string Name { get; set; }
    public int OrderCount { get; set; }
    public int TotalOrderPrice { get; set; }
}

class ApplicationDbContext : DbContext
{

    public DbSet<Person> Persons { get; set; }
    public DbSet<Order> Orders { get; set; }

    public DbSet<PersonOrder> PersonOrders { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore(typeof(PersonOrder));
        modelBuilder.Entity<PersonOrder>().HasNoKey();

        #region Scalar
        modelBuilder.HasDbFunction(typeof(ApplicationDbContext).GetMethod(nameof(ApplicationDbContext.GetPersonTOTALPRICE), new[] { typeof(int) })!)
            .HasName("GetPersonTOTALPRICE");
        #endregion

        #region Inline
        modelBuilder.HasDbFunction(typeof(ApplicationDbContext).GetMethod(nameof(ApplicationDbContext.BestSellingStaff), new[] { typeof(int) })!)
            .HasName("bestSellingStaff");
        #endregion

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


    }

    #region Scalar Functions
    public int GetPersonTOTALPRICE(int personId)
        => throw new Exception();
    #endregion

    #region Inline Function
    public IQueryable<PersonOrder> BestSellingStaff(int totalOrderPrice = 0) => FromExpression(() => BestSellingStaff(totalOrderPrice));
    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppFunctionsDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");


    }


}
