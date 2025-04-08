using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


ApplicationDbContext context = new();

#region Stored Procedure Nedir?
// Stored Procedure, veritabanında önceden tanımlanmış, parametreli veya parametresiz saklanan bir SQL sorgusudur. Bu sorgular, belirli bir işlevi yerine getirmek için kullanılabilir ve genellikle performansı artırmak, kod tekrarını azaltmak ve güvenliği sağlamak amacıyla kullanılır. 
#endregion
#region EF Core ile Stored Procedure Kullanımı
#region Stored Procedure Oluşturma
//1.Adım Boş bir migration oluşturulmalıdır.
//2.Adım Stored Procedure'ün oluşturulması için gerekli SQL sorgusu migration dosyasında Up metoduna yazılmalıdır. down metoduna ise stored procedure'ün silinmesi için gerekli SQL sorgusu yazılmalıdır.
//3.Adım Migration'ı uygulamak için Update-Database komutu çalıştırılmalıdır.
#endregion
#region Stored Procedure'ü Kullanma
//SP'yi kullanabilmek için bir entity sınıfı oluşturulup, DbContext sınıfında DbSet türünden bir property tanımlanmalıdır. Bu property, stored procedure'ün döndüreceği verileri temsil eder. Ayrıca, DbSet'in PK olmadığını belirtmek için HasNoKey() metodu kullanılmalıdır.
#region FromSql
//var datas = await context.PersonOrders.FromSql($"EXEC sp_PersonOrders").ToListAsync();
#endregion
#endregion
#region Geriye değer döndüren Stored Procedure'ü Kullanma

//SqlParameter countParamater = new()
//{
//    ParameterName = "count",
//    SqlDbType = System.Data.SqlDbType.Int,
//    Direction = System.Data.ParameterDirection.Output
//};
//var count = await context.Database.ExecuteSqlRawAsync($"EXEC @count= sp_BestSellingStaff", countParamater);
//Console.WriteLine($"En çok satan personel sayısı: {countParamater.Value}");
#endregion
#region Parametreli Stored Procedure Kullanımı
#region Input Parametreli Stored Procedure'ü Kullanma

#endregion

#region Output Parametreli Stored Procedure'ü Kullanma

#endregion

SqlParameter nameParameter = new()
{
    ParameterName = "name",
    SqlDbType = System.Data.SqlDbType.NVarChar,
    Direction = System.Data.ParameterDirection.Output,
    Size = 100
};
SqlParameter idParameter = new()
{
    ParameterName = "id",
    Value = 5,
    SqlDbType = System.Data.SqlDbType.Int,
    Direction = System.Data.ParameterDirection.Input,
    Size = 100
};
await context.Database.ExecuteSqlRawAsync($"EXEC sp_PersonOrders2 @id,@name OUTPUT", idParameter, nameParameter);

Console.WriteLine($"Şarta göre gelen person Adı: {nameParameter.Value}");

#endregion

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

        modelBuilder.Ignore(nameof(PersonOrder))
            .Entity<PersonOrder>()
            .HasNoKey();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppStoredProcedureDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");


    }


}