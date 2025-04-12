using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;
using System.Transactions;

ApplicationDbContext context = new();

#region Transaction Nedir?
//Transaction, Veritabanınındaki kümülatif işlemleri atomik bir şekilde gerçekleştirmemizi sağlayan bir özelliktir.
//Bir transaction içersiindeki tüm işlemler commit edildiği takdirde fiziksel olarak yansılacaktır Ya da rollback edilirse tüm işlemler geri alıancak ve fiziksel olarak veritabanına herhangi bir verisel değişikşik durumu olmayacaktır.
//Transaction'un genel amacı vertiabanaındaki tuturlılık durumnu korumaktır ya da  bir başka deyişrle veritabanındaki tutuarsızlık durumlarına karşı önlem almaktır.
#endregion
#region Default Transaction Davranışı
//EF Core da varsayılan olarak yapılan tüm işlemler SavwChanges fonksiyonuyla fiziksel olarak uygulanır.
//çünkü SavChanges defaul tolarka bir transaction'a sahipt Eğer ki bu seüreçte hata vey abir bşarısızlık olursa tüm işlemler geri alınır ve işlemler veritbanına uygulanmaz.
//Böylece SaveChanges tüm işlemlerin ya tamamen başarılı olacağı yada bir hata olşursa veritabannı değştirmeden işlemleri sonlandıracağını ifade etmektedir.
#endregion
#region Transaction Kontrolünü Manuel Sağlama
//using IDbContextTransaction transaction = await context.Database.BeginTransactionAsync();
////EfCore dak transaction kontrolü iradeli bir şekilde maneul sağlamak yani elede etmek istiyordsak eğer BEginTransactionAsync fonksiyonu çağrılmalıdır.
//Person p = new() { Name = "Abuzettin 3" };
//await context.Persons.AddAsync(p);
//await context.SaveChangesAsync();
//await transaction.CommitAsync();
#endregion
#region SavePoints
//EF Core 5.0 sürümüyle gelmiştir.

//Save point veritabanı işlemleri sürecinde bir hata aoluşrusda veya yapılan işlemlerin geri alınması isteniyorsa transaction içerisinde dönüş yapılabilecek noktraları ifade eden bir özelliktir.
using IDbContextTransaction transaction = await context.Database.BeginTransactionAsync();
#region CreateSavepoint
//Transaction içerisinde geri dönüş noktası oluşturmamızı sağlayan bir fonskiyondur.
#endregion
#region RollBackSavepoint
//Trnsaction içerisinde herhnagi bir geri dönüş nokjtasına(SavePonite) rollback yapmamızı sağlayan fonksiyondur.
#endregion

//SavePoint özelliği bir transaction içerisinde istenildiği kadar kullanılabilir.
//Person p103= await context.Persons.FindAsync(103);
//Person p101= await context.Persons.FindAsync(101);
//context.Persons.RemoveRange(p103, p101);
//await context.SaveChangesAsync();
//transaction.CreateSavepoint("t1");

//Person p100 = await context.Persons.FindAsync(100);
//context.Persons.Remove(p100);
//await context.SaveChangesAsync();
//await transaction.RollbackToSavepointAsync("t1");

//await transaction.CommitAsync();
#endregion
#region TransactionScope
//veritabanı işlemlerini bir grup olarak yapmamızı sağlayan bir  sınıftır. Çünkü Ado.Net ile de kullanılabilir olduğu için

using TransactionScope scope = new();
//Veritaban işlemleri
//..
//..
//....
scope.Complete();//complete fonksiyınu yapılan veritabanı işlemlerinin commit edilmesini sağlar Eğer li rollback yapacaksanız complete fonksiyonunun tetiklenmesi yeterlidir.
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
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppTransactionDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");


    }


}
