using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;
using System.Transactions;

ApplicationDbContext context = new();

#region EF Core 7 Öncesi Toplu Güncelleme
//var persons = await context.Persons.Where(p => p.Id > 5).ToListAsync();
//foreach (var person in persons)
//{
//    person.Name = "Updated Name";
//}
//await context.SaveChangesAsync();
#endregion
#region EF Core 7 Öncesi Toplu Silme
//var persons = await context.Persons.Where(p => p.Id > 5).ToListAsync();
//context.RemoveRange(persons);
//await context.SaveChangesAsync();
#endregion


#region ExecuteUpdate
//await context.Persons.Where(p => p.Id > 60)
//    .ExecuteUpdateAsync(p => p.SetProperty(p => p.Name, v => v.Name + " Yeni"));
#endregion
#region ExecuteDelete
//await context.Persons.Where(p => p.Id > 5).ExecuteDeleteAsync();
#endregion

//ExecuteUpdate ve ExecuteDelete işlemleri ile bulk(toplu) veri güncelleme ve silme işlmelleri gerçekleştirirken SaveChanges fonksiyonunu çaprınamamıza gerek yoktur Çünkü bu fonksiyonlar adları üzerinde Execute... fonksiyonlarıdr. 

//Eğer ki istiyorsanız transaction kontroloünü ele alarak bu fonksiyonların işlevlerinide süreöte konrrol edebilirsiniz.


Console.WriteLine();
public class Person
{

    public int Id { get; set; }

    public string Name { get; set; }
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
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppBulkUpdateAndDelete; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");


    }


}
