using Microsoft.EntityFrameworkCore;

ApplicationDbContext context = new();



#region TPT Nedir?

//Entitylerin aralarında kalıtımsal ilişkiye sahip olduğu durumlarda her bir türe/Entity/tip/referans karşılık bir tablo generate eden davranıştır.

// Her Generate edilen bu tablola hireşik düzlemde kendi aralarında birebir ilişkiye sahip olacaktır.
#endregion

#region TPT Nasıl Uygulanır
//TPT'yi uygulayabilmek için öncelikle entityleri kedndi aralarında olması gereken mantıkta inşa edilmesi gerekmektedir.
//Tüm entityleri dbset olarak bildirilmelidir
//Hiyerarşik olarak kalıtımsal ilişki olarak OnModelCreating fonksiyonunda ToTable("") metodu ile konfigüre edilmelidr. böylece EF Core kalıtısal ilişki olan bu tablolar arasında TPT davrınışı olarak algılayacaktır.
#endregion

#region TPT'da VEri Ekleme
//Technician technician = new() { Name = "Mehmet", Surname = "Karataşlı", Department = "Yazılım Uzmanı", Branch = "Geliştirme" };
//await context.Employees.AddAsync(technician);

//Customer customer = new() { Name = "Necmi", Surname = "Yavuz", CompanyName = "Çaykur" };
//Customer customer1 = new() { Name = "Yavuz", Surname = "Miran", CompanyName = "Teknical" };

//await context.Customers.AddRangeAsync(customer, customer1);


//Employee employee = new() { Name = "Test", Surname = "Test Surname", Department = "Test Departman" };
//await context.Employees.AddAsync(employee);
//await context.SaveChangesAsync();
#endregion

#region TPT'da VEri Silme
//var employee = await context.Employees.FindAsync(3);
//context.Employees.Remove(employee);
//await context.SaveChangesAsync();
#endregion

#region TPT'da VEri Güncleleme
//var technician = await context.Technicians.FindAsync(2);

//technician.Name = "Selim Yılmaz";
//technician.Surname = "Aziz Mahmut";

//await context.SaveChangesAsync();

#endregion

#region TPT'da VEri Sorgulama

//var employees = await context.Employees.ToListAsync();
//var technicians = await context.Technicians.ToListAsync();
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
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppTablePerTypeDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Table Per Taype Davranışı sergileme
        modelBuilder.Entity<Person>().ToTable(nameof(Persons));
        modelBuilder.Entity<Employee>().ToTable(nameof(Employees));
        modelBuilder.Entity<Customer>().ToTable(nameof(Customers));
        modelBuilder.Entity<Technician>().ToTable(nameof(Technicians));

    }

}
