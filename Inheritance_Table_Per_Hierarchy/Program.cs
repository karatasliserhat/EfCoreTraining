using Microsoft.EntityFrameworkCore;

ApplicationDbContext context = new();


#region TPH Nasıl Uygulanır
//Kalıtımsal ilişkiye sahip olan entitylerin sahip olduğu senaryolarda her bir hiyerarşiye karşılık bir tablo oluşturan davranıştır.
#endregion

#region Neden Table Per Hierarchy Yakalşımında Bir Tabloya İhtiyacımız Olsun
//İçerisinde benzer alanlara saip olan entityleri her entitye karşılıx bir tablo oluşturmaktansa bu entityleri bu tabloda modellemek isteyebiliriz bu kayıtları Discrimanator kolunu üzerinden birbirlerinden ayırabiliriz.
#endregion

#region Discrimanator Kolonu Nedir?
//Table Per Hirarchy yaklaşımı neticesinde kümülatif olarak inşa edilmiş tablomnun hangi entitye karşılık veri tuttuğunu ayırt edebilmemizi sağlayan kolondur. EF Core tarafından otomotik olarak tabloya yerleştirilir Default olarak içerisinden entity isimlerini tutuar.
#endregion

#region Discriminator Kolonu Adı Nasıl Değiştirilir.

#endregion

#region Discrimnator Değerleri Nasıl Değiştirilir.

#endregion

#region TPH'da VEri Ekleme
//Davranışların hiçbirinde ver eklerken silerken güncellerken vs. normal operasyonların dışında bir işlem yapılmaz.
//Hangi davranışı kullanıyorsanız EF Core arka planda modellemeyi gerçekleştirecektir.

//Employee employee = new() { Name = "Serhat", Surname = "Karataşlı", Department = "Yazılım Uzmanı" };
//Employee employee2 = new() { Name = "Ali", Surname = "Karataşlı", Department = "Yazılım Bilgi İşlem Uzmanı" };

//Customer customer = new() { Name = "Ahmet", Surname = "Yılmaz", CompanyName = "AhmetYilmaz şirketi" };
//Customer customer2 = new() { Name = "Cevdet", Surname = "Sami", CompanyName = "cevdet Sami şirketi" };

//Technician technician = new() { Name = "Salim", Surname = "Kıllıbacak", Department = "Muhasebe", Branch = "Şoför" };

//await context.AddRangeAsync(employee, employee2, customer, customer2, technician);
//await context.SaveChangesAsync();
#endregion

#region TPH'da VEri Silme
//Employee? employee = await context.Employees.FindAsync(3);
//if (employee is not null)
//    context.Employees.Remove(employee);
//await context.SaveChangesAsync();


//var customers = await context.Customers.ToListAsync();

//context.Customers.RemoveRange(customers);
//await context.SaveChangesAsync();

#endregion

#region TPH'da VEri Güncleleme
//var technician = await context.Technicians.FindAsync(5);

//technician.Name= "Test";

//await context.SaveChangesAsync();
#endregion

#region TPH'da VEri Sorgulama
// Veri sorgulama operasyonu bilinen dbset propertiysi üzerinden sorgulamadır ancak burada dikkar edilmesi gereken bir husus vardır;

var employees = context.Employees.ToListAsync();
var technicians = context.Technicians.ToListAsync();

#endregion

#region Farklı Entity'ler de Aynı isimde Sütunların olduğu durumlar
//Entitylerde mükerrer kolonlar olabilir, Bu kolonları EF core isimsel olarak özelleştirip ayıracaktır.
#endregion

#region IsComplete Konfigürasyonu

#endregion

Console.Read();

class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
}

class Employee : Person
{

    public string? Department { get; set; }
}
class Customer : Person
{
    public string A { get; set; }
    public string? CompanyName { get; set; }
}
class Technician : Employee
{
    public string A { get; set; }

    public string? Branch { get; set; }
}


class ApplicationDbContext : DbContext
{

    public DbSet<Person> Persons { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Technician> Technicians { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppTablePerHierarchyDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().HasDiscriminator<string>("Ayirici").HasValue(nameof(Person));
        modelBuilder.Entity<Technician>().HasDiscriminator<string>("Ayirici").HasValue(nameof(Technician));
        modelBuilder.Entity<Employee>().HasDiscriminator<string>("Ayirici").HasValue(nameof(Employee));
        modelBuilder.Entity<Customer>().HasDiscriminator<string>("Ayirici").HasValue(nameof(Customer));
    }

}
