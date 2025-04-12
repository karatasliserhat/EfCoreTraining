using Microsoft.EntityFrameworkCore;
using System.Reflection;

ApplicationDbContext context = new();


//await context.Persons.AddAsync(new Person
//{
//    Name = "John",
//    Surname = "Doe",
//    Street = "123 Main St",
//    City = "Anytown",
//    PostCode = 12345,
//    Country = "USA",
//    PhoneNumber = "555-1234"
//});
//await context.SaveChangesAsync();

//var persons = await context.Persons.ToListAsync();

var person = await context.Persons.FindAsync(101);


Console.WriteLine();


class Person
{
    #region PersonTable
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    #endregion
    #region AddressTable
    public string Street { get; set; }
    public string City { get; set; }
    public int PostCode { get; set; }
    public string Country { get; set; }
    #endregion
    #region PhoneTable
    public string PhoneNumber { get; set; }

    #endregion


}
class ApplicationDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppEntitySplittingDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
    }
}