using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



ESirketDbContext context = new();


#region Default Convention
// One to One ilişki türünde dependent entity'nin hangisi oluğunu default olarak belirleyebilmek pek kolay değildir budurumda fiziksel olarak bir foreign key tanımlamak gerekiyor
//class Calisan
//{
//    public int Id { get; set; }
//    public string Adi { get; set; }
//    public CalisanAdresi CalisanAdresi { get; set; }

//}

//class CalisanAdresi
//{
//    public int Id { get; set; }
//    public int CalisanId { get; set; }
//    public string Adres { get; set; }

//    public Calisan Calisan { get; set; }

//}
#endregion

#region Data Annotations
//class Calisan
//{
//    public int Id { get; set; }
//    public string Adi { get; set; }
//    public CalisanAdresi CalisanAdresi { get; set; }

//}

//class CalisanAdresi
//{
//    [Key, ForeignKey(nameof(Calisan))]
//    public int Id { get; set; }
//    public string Adres { get; set; }
//    public Calisan Calisan { get; set; }

//}
#endregion

#region Fluent Api(HasOne, HasMany, WithOne, WithMany)
class Calisan
{
    public int Id { get; set; }
    public string Adi { get; set; }
    public CalisanAdresi CalisanAdresi { get; set; }

}

class CalisanAdresi
{
    public int Id { get; set; }
    public string Adres { get; set; }
    public Calisan Calisan { get; set; }

}
#endregion

class ESirketDbContext : DbContext
{
    public DbSet<Calisan> Calisanlar { get; set; }
    public DbSet<CalisanAdresi> calisanAdresleri { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = ESirketDb; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");


    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CalisanAdresi>().HasKey(c => c.Id);
        modelBuilder.Entity<Calisan>()
            .HasOne(c => c.CalisanAdresi)
            .WithOne(c => c.Calisan).HasForeignKey<CalisanAdresi>(c => c.Id);
    }
}

