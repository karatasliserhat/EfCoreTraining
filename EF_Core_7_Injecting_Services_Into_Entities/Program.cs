using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;
using System.Transactions;

ApplicationDbContext context = new();

var persons = await context.Persons.ToListAsync();
foreach (var item in persons)
{
    item.ToString();
}


Console.WriteLine();

public class PersonServiceInjectionInterceptor : IMaterializationInterceptor
{
    public object InitializedInstance(MaterializationInterceptionData materializationData, object entity)
    {
        if (entity is IHasPersonService hasPersonService)
        {
            hasPersonService.PersonService = new PersonLogService();
        }
        return entity;
    }
}
public interface IHasPersonService
{
    IPersonLogService PersonService { get; set; }
}
public interface IPersonLogService
{
    void LogPerson(string name);
}

public class PersonLogService : IPersonLogService
{
    public void LogPerson(string name)
    {
        Console.WriteLine($"{name} isimli personel loglanmıltır");
    }
}


public class Person : IHasPersonService
{

    public int Id { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        PersonService?.LogPerson(Name);
        return base.ToString() ?? string.Empty;
    }
    public IPersonLogService? PersonService { get; set; }
}



class ApplicationDbContext : DbContext
{

    public DbSet<Person> Persons { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .Ignore(p => p.PersonService);


        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppInjectionInterceptorDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");

        optionsBuilder.AddInterceptors(new PersonServiceInjectionInterceptor());


    }


}
