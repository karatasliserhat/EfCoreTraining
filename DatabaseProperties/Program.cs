using Microsoft.EntityFrameworkCore;
using System.Reflection;




ApplicationDbContext context = new();

#region DatabaseProperty'si
//DabaseProperty'si  vertibanını temsil eden ve EF Core 'un bazı işlevlerinin detaylarına erişmemizi sağlayan bir property'dir.
#endregion
#region BeginTransaction
//BeginTransaction metodu, Ef Core transaction yönetimini otomotik bir şekilde kendisi gerçekleştirmektedir. Eğer ki transaction yönetimini manuel olarak anlık ele almak istiyorsak BeginTransaction fonksiyonunu kullanabiliriz.

//IDbContextTransaction transaction = context.Database.BeginTransaction();

#endregion
#region CommitTransaction

//CommitTransaction metodu, EF Core üzerinde yapılan çalışmaların commit edilebilmesi için kullanılan bir fonksiyondur.

//context.Database.CommitTransaction();
#endregion
#region RollbackTransaction
//RollbackTransaction metodu, EF Core üzerinde yapılan çalışmaların  geri alınabilmesi için kullanılan bir fonksiyondur.
//context.Database.RollbackTransaction();
#endregion
#region CanConnect
//CanConnect metodu, EF Core üzerinde veritabanı bağlantısının sağlanıp sağlanmadığını kontrol etmek için kullanılan bir fonksiyondur.

//bool connect = context.Database.CanConnect();
//Console.WriteLine();
#endregion
#region EnsureCreated
//EnsureCreated metodu, EF Core da tasarlanan migrate kullanmaksızın, runtime^da yani kod üzerinde veritabanı sunucusuna inşa edebilmek için kullanılan bir fonksiyondur.
//bool ensureCreated=context.Database.EnsureCreated();
//Console.WriteLine(ensureCreated);
#endregion
#region EnsureDeleted
//EnsureDeleted metodu, EF Core üzerinde tasarlanan veritabanının silinmesi için kullanılan bir fonksiyondur.
//context.Database.EnsureDeleted();
#endregion
#region GenerateCreateScript
//GenerateCreateScript metodu, EF Core üzerinde tasarlanan veritabanının oluşturulması için gerekli olan SQL scriptini string olarak döndürmektedir.
//var database =context.Database.GenerateCreateScript();
//Console.WriteLine(database);
#endregion
#region ExecuteSql
//ExecuteSQl metodu, EF Core üzerinde veritabanına SQL komutları göndermek için kullanılan bir fonksiyondur.
//var result = context.Database.ExecuteSql($"INSERT Persons Values('Kemal')");

//string name = Console.ReadLine()!;

//var result = context.Database.ExecuteSql($"INSERT Persons Values('{name}')");

#endregion
#region ExecuteSqlRaw
//ExecuteSqlRaw metodu, EF Core üzerinde veritabanına SQL komutları göndermek için kullanılan bir fonksiyondur. ExecuteSqlRaw metodu, sql injection açıklarıba karşı alma sorumluluğu geliştiriciye aittir. ExecuteSql kullanılması daha mantıklıdır.
#endregion
#region SqlQuery
//SqlQuery kullanılmıyor DBSet property'si  üzerinden erişilebilen fromsql fonskiyonların kullanıyoruz.
#endregion
#region SqlQueryRaw
//SqlQueryRaw kullanılmıyor DBSet üzerinden fromsqlraw fonskiyonların kullanıyoruz.
#endregion
#region GetMigrations
//GetMigrations metodu, EF Core üzerinde migrationların listelenmesi için kullanılan bir fonksiyondur.
//IEnumerable<string> migrations = context.Database.GetMigrations();
//migrations.ToList().ForEach(m => Console.WriteLine(m));
#endregion
#region GetAppliedMigrations
//GetAppliedMigrations metodu, EF Core üzerinde uygulanan migrationların listelenmesi için kullanılan bir fonksiyondur.
//var migs = context.Database.GetAppliedMigrations();
//migs.ToList().ForEach(m => Console.WriteLine(m));
#endregion
#region GetPendingMigrations
//GetPendingMigrations metodu, EF Core üzerinde bekleyen migrationların listelenmesi için kullanılan bir fonksiyondur.
//var pendingMigrations = context.Database.GetPendingMigrations();
//pendingMigrations.ToList().ForEach(x => Console.WriteLine(x));
#endregion
#region Migrate
//Migrate metodu, EF Core üzerinde migrationların uygulanması için kullanılan bir fonksiyondur. Migrationlar uygulandıktan sonra veritabanı güncellenmiş olur.
//context.Database.Migrate();
#endregion
#region OpenConnection
//OpenConnection metodu, EF Core üzerinde veritabanı bağlantısının açılması için kullanılan bir fonksiyondur.
//context.Database.OpenConnection();
#endregion
#region CloseConnection
//CloseConnection metodu, EF Core üzerinde veritabanı bağlantısının kapatılması için kullanılan bir fonksiyondur.

//context.Database.CloseConnection();
#endregion
#region GetConnectionString
//GetConnectionString metodu, EF Core üzerinde veritabanı bağlantı dizesini almak için kullanılan bir fonksiyondur.

//var databaseString = context.Database.GetConnectionString();
#endregion
#region GetDbConnection
//GetDbConnection metodu, EF Core'un kullanmış olduğu Ado.Net altyapısının kullnadığı DbConection elde etmemizisağlyan bir fonksiyondur. yani bizleri Ado.Net kanadına götürür.GetDbConnection metodu, DbConnection nesnesini döndürmektedir.
//SqlConnection dbConnection = (SqlConnection)context.Database.GetDbConnection();
#endregion
#region SetDbConnection
//SetDbConnection metodu, EF Core'un kullanmış olduğu Ado.Net altyapısının kullnadığı DbConection elde etmemizisağlyan bir fonksiyondur. yani bizleri Ado.Net kanadına götürür.SetDbConnection metodu, DbConnection nesnesini döndürmektedir.
//özellştirilmiş connection nesnelerini Ef Core mimarisine dahil etmemmizi sağlayan bir fonksiyondur.
//context.Database.SetDbConnection()
#endregion
#region ProviderName Property'si
//ProviderName property'si, EF Core üzerinde kullanılan veritabanı sağlayıcısının adını almak için kullanılan bir property'dir.
//Console.WriteLine(context.Database.ProviderName);
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppDatabasePropertiesDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");


    }


}
