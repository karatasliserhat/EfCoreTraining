using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


ApplicationDbContext context = new();

//Eğer ki sorgunuzu LINQ ile ifade edemiyorsanız yahut LINQ'in ürettiği sorguya nazaran daha optimize bir sorguyu manuel geliştirmek ve EF Core üzerinden execute etmek istiyorsanız EF Core'un bu davranışını desteklediğini bilmelisiniz.

// Manuel bir şekilde yani tarafımızda oluşturulmuş olan sorguların EF Core tarafından execute edebilmek için o sorgunun sonucunu karşılayacak bir entity model'in tasarlanmış ve bunun Dbset olarak context nesnesine tanımlanmış olması gerekmektedir.

#region FromSqlInterpolated

//EF Core 7.0 sürümünden önce ham sorguları execute etmemizi sağlayan fonsiyondur.

//var persons = await context.Persons.FromSqlInterpolated($"SELECT * FROM Persons").ToListAsync();

#endregion

#region FromSql - EF Core 7.0

//EF Core 7.0 ile gelen metottur.

#region QueryExecute
//var persons = await context.Persons.FromSql($"Select * From Persons").ToListAsync();
#endregion
#region StoreProcedure Execute
//var personse = await context.Persons.FromSql($"exec dbo.sp_GetAllPersons null").ToListAsync();
//var personse = await context.Persons.FromSql($"exec dbo.sp_GetAllPersons 5").ToListAsync();

#endregion
#region Parametreli Sorgu Oluşturma
//bu arada sorguya geçirilen personId değişkeni arkaplanda bir DBparameter olarak oluşturulup sorguya eklenmektedir.
#region Ornek1
//int personId = 65;
//var persons = await context.Persons.FromSql($"SELECT * FROM Persons WHERE Id={personId}")
//    .ToListAsync();
#endregion
#region Ornek2
//int personId = 65;
//var persons = await context.Persons.FromSql($"EXECUTE dbo.sp_GetAllPersons {personId}")
//    .ToListAsync();
#endregion
#region Ornek3
//SqlParameter personId = new("personId", 65);
//personId.DbType = System.Data.DbType.Int32;
//personId.Direction = System.Data.ParameterDirection.Input;

//var persons = await context.Persons.FromSql($"EXECUTE dbo.sp_GetAllPersons {personId}")
//    .ToListAsync();
#endregion
#region Ornek4
//SqlParameter personId = new SqlParameter("personId", 65);
//var persons = await context.Persons.FromSql($"SELECT * FROM Persons WHERE Id={personId}")
//    .ToListAsync();
#endregion
#region Ornek5
//SqlParameter personId = new("farketmez", 65);
//var persons = await context.Persons.FromSql($"EXECUTE dbo.sp_GetAllPersons @personId={personId}")
//    .ToListAsync();
#endregion
#endregion

#endregion

#region Dynamic Sql Oluşturma ve Parametre Girme -FromSqlRaw
//string columnName = "Id", value = "65";

//var persons = await context.Persons.FromSql($"SELECT * FROM Persons WHERE {columnName}={value}")
//    .ToListAsync();

//EF Core dynamic olarak oluşturulan sorgularda özellikle kolon isimleri parametreleştirilmişse o sorguyu ÇALIŞTIRMAYACAKTIR.

//string columnName = "Id";
//SqlParameter value = new("Id", "65");
//var persons = await context.Persons
//    .FromSqlRaw($"SELECT * FROM [Persons] WHERE {columnName} = @Id", value)
//    .ToListAsync();

//FRom Sql ve FromSqlInterpolated metodlarında SQL Injection vs. gibi gücenlik önlemleri almış vaziyettedir. Lakin dinamik olarak sorguları oluşturuyorsanız eğer burada güvenlik geliştirici sorumludur. Yani gelen sorguda/veri yorumlar, noktalı virgüller yahut Sql'e özel karekterlerin algılanması ve bunların temizlenmesi geliştirici tarafından gerekmektedir.
#endregion

#region SqlQuery-Entity Olmayan Scalar Sorguların Çalıştırılması - Non Entity - EF Core 7.0
// Entity olmayan scalar sorguların çalıştırılması için EF Core 7.0 ile birlikte gelen metottur.

//var data = await context.Database.SqlQuery<int>($"SELECT Id FROM Persons").ToListAsync();

//var persone = await context.Persons.FromSql($"Select * From Persons")
//    .Where(x => x.Id % 2 == 1)
//    .ToListAsync();

//var data = await context.Database.SqlQuery<int>($"SELECT Id Value FROM Persons")
//    .Where(x => x % 2 == 0)
//    .ToListAsync();

//Sql Query'de LINQ operastorüyle sorguya extradan katkıda bulunmak istiyorsanız eğer bu sorgu neticesinde gelecek olan kolonun adını VALUE olarak bildirmeniz gerekmektedir. Çünkü, SqlQuery metodu sorguyu bir subquery olarak generate etmektedir Haliyle bu durumdam dolayı LINQ ile verilen şart ifadeleri statik olarak VALUE kolonuna göre tasarlanmıştır. O yüzden bu şekilde bir çalışma zorunlu gerekmiştir.
#endregion

#region ExecuteSql
//Insert, Update, Delete işlemlerinin yapılması için kullanılan metottur.

//await context.Database.ExecuteSqlAsync($"Update persons set Name='Serhat' Where Id=3");
#endregion

#region Sınırlılıklar
//Queryler entity türünün tüm özellikleri için kolonlarda değer döndürülmelir.
//var persons = await context.Persons.FromSql($"SELECT Name,Id FROM Persons")
//    .ToListAsync();

//Sutun isimleri property isimleriyle birebir örtüşmelidir.
//var persons = await context.Persons.FromSql($"SELECT Id,Name FROM Persons")
//    .ToListAsync();

//SQl sorgusu join yapısı içeremez haliyle b tarz durumlarda include fonksiyonu kullanılmalıdır.
//var persons = await context.Persons.FromSql($"SELECT * FROM Persons JOIN Orders ON Persons.Id=Orders.PersonId")
//    .ToListAsync();

//var person = await context.Persons.FromSql($"SELECT * FROM Persons")
//    .Include(x => x.Orders)
//    .ToListAsync();
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
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppSqlQueriesDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");


    }


}