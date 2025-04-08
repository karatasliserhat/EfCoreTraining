using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;


ApplicationDbContext context = new();
#region Index Nedir?
//Index, bir sutuna dayalı sorgulamaları daha verimli ve performanslı hale getirmek iin kullanılan yapıdır.

#endregion

#region Indexleme Nasıl Yapılır?
//PK, FK, AK olan kolonlar otomatik olarak indexlenir.

#region Index

#endregion

#region HasIndex

#endregion

#endregion

#region Composite Index

#endregion

#region Birden fazla Index Tanımlama

#endregion

#region Index Uniqueness

#endregion

#region Index Sort Order-Sıralama Düzeni

#endregion

#region Name

#endregion

#region Filter

#endregion

#region Included Columns
/*Aşağaki durumlarda IncludeProperties 'i kullanabiliriz*/

//await context.Employees.Where(x => x.Name == "asdsadd" || x.Surname == "asad").Select(y => new
//{
//    y.Name,
//    y.Surname,
//    y.Salary
//}).ToListAsync();
#endregion


Console.ReadLine();


/*[Index(nameof(Name))]*/ //Generate edilecek name kolonuna bir index atmaması yap dedik.
//[Index(nameof(Name), IsUnique = true)]
//[Index(nameof(Name), nameof(Surname), IsDescending = new[] { true, false })]
//[Index(nameof(Name), nameof(Surname), AllDescending = true)]
//[Index(nameof(Surname), Name = "surname_index")]

class Employee
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public int Salary { get; set; }
}
class ApplicationDbContext : DbContext
{

    public DbSet<Employee> Employees { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>() // Name için Özel
            .HasIndex(e => e.Name).IsDescending().IsUnique().HasFilter("[NAME] IS NOT NULL");
        modelBuilder.Entity<Employee>() // SurName için Özel
            .HasIndex(e => e.Surname).HasDatabaseName("surname_index");
        modelBuilder.Entity<Employee>() //Her ikisi için özel
            .HasIndex(e => new { e.Name, e.Surname })
            .IncludeProperties(e => e.Salary).IsDescending();


    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppIndexesDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
    }


}