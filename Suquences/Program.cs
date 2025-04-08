using Microsoft.EntityFrameworkCore;


ApplicationDbContext context = new();
#region Sequence Nedir?
//Veritabanında benzersiz ve ardışık sayısal değerler üreten veritabanı nesnesidir.
//Seqeunce herhangi bir tablonun özelliği değildir veritabanı nesnesidir Birden fazla tablo tarafından kulanılabilir.
#endregion
#region Sequence Tanımlama
//Sequence'ler üzerinden değer oluştururken veritabanıa özgü çalışma yapılması zarurdir. Sql server'a ait bir özellik olduğu için Sql server üzerinde çalışmak gerekmektedir.

#region HasSequence

#endregion

#region HasDefaultValuSql

#endregion

#endregion

#region Sequence Yapılandırma
#region StartsAt

#endregion
#region IncrementsBy

#endregion
#endregion

#region Sequence ile Identity Farkı
//Sequence bir veritabanı nesnesidir. Identity ise bir tablo özelliğidir.
//Yani sequence herhangi bir tabloya ait değildir. Birden fazla tablo tarafından kullanılabilir.
//Identity bir sonraki değeri diskten alırken, sequence bir sonraki değeri bellekten alır. Bu yüzden önemli ölçüde daha hızlıdır.
#endregion


await context.Employees.AddAsync(new() { Name = "Ali", Surname = "Veli", Salary = 1000 });
await context.Employees.AddAsync(new() { Name = "Ayşe", Surname = "Fatma", Salary = 2000 });
await context.Employees.AddAsync(new() { Name = "Mehmet", Surname = "Can", Salary = 3000 });

await context.Customers.AddAsync(new() { Name = "Ahmet" });

await context.SaveChangesAsync();


Console.ReadLine();

class Employee
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public decimal Salary { get; set; }
}
class Customer
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
class ApplicationDbContext : DbContext
{

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Customer> Customers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.HasSequence("EC_Sequence")
            .StartsAt(100).IncrementsBy(5);


        modelBuilder.Entity<Employee>()
            .Property(x => x.Id)
            .HasDefaultValueSql("NEXT VALUE FOR EC_Sequence");

        modelBuilder.Entity<Customer>()
            .Property(c => c.Id)
            .HasDefaultValueSql("NEXT VALUE FOR EC_Sequence");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppSequencesDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
    }


}