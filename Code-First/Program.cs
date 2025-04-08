// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;


EcommerceDbContext ecommerceDbContext = new();
await ecommerceDbContext.Database.MigrateAsync();//Runtime da veritabanı oluşturulur.



#region Dotnet CLI Migration

// dotnet ef migrations add mig_1

// dotnet ef database update

// dotnet ef migrations remove

//dotnet ef Migrations --output-dir pathName

//dotnet ef migrations remove --force

//dotnet ef migrations list

//dotnet ef database update migrationsName
#endregion


Console.WriteLine("Hello, World!");



public class EcommerceDbContext : DbContext
{

    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=ECommerceDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

}
public class Product
{

    public int Id { get; set; }
    public string Name { get; set; }
    public string Quantity { get; set; }
    public float Price { get; set; }
}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string FirstName { get; set; }
}