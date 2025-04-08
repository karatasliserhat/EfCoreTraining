using Microsoft.EntityFrameworkCore;
using System.Reflection;


ApplicationDbContext context = new();

#region View Nedir?
//Oluşturduğumuz complex sorguları ihtiyaç durumlarında daha rahat bir şekilde kullanabilmek için basitleştiren bir veritabanı nesnesidir.
#endregion
#region EF Core ile View Kullanımı

#endregion

#region View Oluşturma
//1.Adım Boş bir migration oluşturulmalıdır.
//2.Adım View'in oluşturulması için gerekli SQL sorgusu migration dosyasında Up metoduna yazılmalıdır. down metoduna ise view'in silinmesi için gerekli SQL sorgusu yazılmalıdır.
//3.Adım Migration'ı uygulamak için Update-Database komutu çalıştırılmalıdır.
#endregion
#region View'i DbSet olarak ayarlama
//View'i EF Core üzerinden sorgulayamabilmek için view neticesini katşılayabilecek bir entity oluşturulması ve bu entity türünden DbSet property'sinin tanımlanması gerekmektedir.
#endregion

#region DbSet'in bir view olduğunu bildirmek
//modelBuilder sınıfında DbSet'in bir view olduğunu bildirmek için HasNoKey() metodu kullanılmalıdır. Bu metot view'in bir tablo olmadığını ve birincil anahtarının olmadığını belirtir. Ayrıca ToView() metodu ile view'in adı belirtilmelidir.

var personOrders = await context.PersonOrders
    .Where(po => po.Name == "Person 86")
    .ToListAsync();
#endregion

#region EF Core'da View'lerin Özellikleri
//View'lerde PK Olmaz! Bu yüzden ilgili dbset'e HasNoKey() metodu uygulanmalıdır.
//View neticesinde gelen veriler Change Tracker ile takip edilmezler Haliyle üzerlerinde yapılan değişiklikler EF Core veri tabanına yansıtılmaz.
//View'ler sadece okunabilir. Haliyle üzerinde Insert, Update ve Delete işlemleri yapılamaz.
//View'ler sadece SELECT sorguları ile kullanılabilir.
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
    public Person Person { get; set; }
}

public class PersonOrder
{
    public string Name { get; set; }
    public int Count { get; set; }
}

class ApplicationDbContext : DbContext
{

    public DbSet<Person> Persons { get; set; }
    public DbSet<Order> Orders { get; set; }

    public DbSet<PersonOrder> PersonOrders { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<PersonOrder>(entity =>
        {
            entity.HasNoKey();
            entity.ToView("vm_PersonOrders");
        });
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppViewerDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");


    }


}