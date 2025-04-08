using Microsoft.EntityFrameworkCore;

ApplicationDbContext context = new();



#region TPC (Table Per Concrete) Nedir?
// Table per Concrete type davranışı kalıtımsal ilişkiye sahi olan entitylerin oluğu çalışmalarda sadece concreate/somut olan entity'lere karşılık bir tablo oluşturacak bir davranış modelidir.
//TCP, TPT'nin daha performaslı halidir. nedeni join sayısı düşeceğinden..
#endregion

#region TPC Nasıl Uygulanır
// Hiyerarşik düzlemde abstract olan yapılar üzerinden Entity fonksiyonuyl akonfigürasyona girip ardından UseTpcMappingStrategy fonksiyonu eşliğinden davranışın Tpc olacağını belirtebiliriz.
#endregion

#region TPC'da VEri Ekleme
//Technician technician = new() { Name = "Yavuz", Surname = "Karataşlı", Department = "Yazılım Uzmanı1", Branch = "Geliştirme1" };
//await context.Employees.AddAsync(technician);

//Customer customer = new() { Name = "Yılmaz", Surname = "Yavuz", CompanyName = "Çaykur1" };
//Customer customer1 = new() { Name = "Semih", Surname = "Miran", CompanyName = "Teknical1" };

//await context.Customers.AddRangeAsync(customer, customer1);


//Employee employee = new() { Name = "Test1", Surname = "Test Surname1", Department = "Test Departman1" };
//await context.Employees.AddAsync(employee);
//await context.SaveChangesAsync();
#endregion

#region TPC'da VEri Silme
//var employee = await context.Employees.FindAsync(3);
//context.Employees.Remove(employee);
//await context.SaveChangesAsync();
#endregion

#region TPC'da VEri Güncleleme

//var technician = await context.Technicians.FindAsync(8);

//technician.Name = "Selim Yılmaz";
//technician.Surname = "Aziz Mahmut";

//await context.SaveChangesAsync();
#endregion

#region TPC'da VEri Sorgulama
var employees = await context.Employees.ToListAsync();
var technicians = await context.Technicians.ToListAsync();
#endregion

Console.Read();

abstract class Person
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
    public string? CompanyName { get; set; }
}
class Technician : Employee
{
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
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppTablePerConcreteDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().UseTpcMappingStrategy();

    }
}