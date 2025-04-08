using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



ESirketDbContext context = new();


#region Default Convention

//class Calisan
//{
//    public int Id { get; set; }
//    public int DepartmanId { get; set; } //Foreing key propertisini oluşturmasak dahik migrate işleminde geleceketir.
//    public string Adi { get; set; }
//    public Departman Departman { get; set; }

//}

//class Departman
//{
//    public int Id { get; set; }

//    public string Name { get; set; }
//    public ICollection<Calisan> Calisanlar { get; set; }

//}
#endregion

#region Data Annotations
//class Calisan
//{
//    public int Id { get; set; }
//    [ForeignKey(nameof(Departman))]
//    public int DId { get; set; } //Foreing key propertisini oluşturmasak dahik migrate işleminde geleceketir.
//    public string Adi { get; set; }
//    public Departman Departman { get; set; }

//}

//class Departman
//{
//    public int Id { get; set; }

//    public string Name { get; set; }
//    public ICollection<Calisan> Calisanlar { get; set; }

//}
#endregion

#region Fluent Api(HasOne, HasMany, WithOne, WithMany)
class Calisan
{
    public int Id { get; set; }
    public int DId { get; set; }
    public string Adi { get; set; }
    public Departman Departman { get; set; }

}

class Departman
{
    public int Id { get; set; }

    public string Name { get; set; }
    public ICollection<Calisan> Calisanlar { get; set; }

}
#endregion

class ESirketDbContext : DbContext
{
    public DbSet<Calisan> Calisanlar { get; set; }
    public DbSet<Departman> Departmanlar { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = ESirketDb; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");


    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calisan>()
            .HasOne(c => c.Departman)
            .WithMany(c => c.Calisanlar).HasForeignKey(c => c.DId);
    }
}

