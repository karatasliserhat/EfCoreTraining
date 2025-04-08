using Microsoft.EntityFrameworkCore;

ETicaretDbContext context = new();


#region Default Convention

//class Kitap
//{
//    public int Id { get; set; }
//    public string KitapAdi { get; set; }

//    public ICollection<Yazar> Yazarlar { get; set; }
//}

//class Yazar
//{
//    public int Id { get; set; }

//    public string YazarAdi { get; set; }

//    public ICollection<Kitap> Kitaplar { get; set; }

//}
#endregion

#region Data Annotations
//class Kitap
//{
//    public int Id { get; set; }
//    public string KitapAdi { get; set; }

//    public ICollection<Yazar> Yazarlar { get; set; }
//}

//class Yazar
//{
//    public int Id { get; set; }

//    public string YazarAdi { get; set; }

//    public ICollection<Kitap> Kitaplar { get; set; }

//}

//class KitapYazar
//{
//    [Key, ForeignKey(nameof(Kitap))]
//    public int KitapId { get; set; }
//    [Key, ForeignKey(nameof(Yazar))]
//    public int YazarId { get; set; }

//    public Kitap Kitap { get; set; }
//    public Kitap Yazar { get; set; }
//}
#endregion

#region Fluent Api(HasOne, HasMany, WithOne, WithMany)

class Kitap
{
    public int Id { get; set; }
    public string KitapAdi { get; set; }
    public ICollection<KitapYazar> Yazarlar { get; set; }
}
class Yazar
{
    public int Id { get; set; }

    public string YazarAdi { get; set; }

    public ICollection<KitapYazar> Kitaplar { get; set; }

}

class KitapYazar
{
    public int KitapId { get; set; }
    public int YazarId { get; set; }
    public Kitap Kitap { get; set; }
    public Yazar Yazar { get; set; }

}
#endregion

class ETicaretDbContext : DbContext
{
    public DbSet<Kitap> Kitaplar { get; set; }
    public DbSet<Yazar> Yazarlar { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = ETicaretDb; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");


    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<KitapYazar>()
            .HasKey(x => new { x.YazarId, x.KitapId });

        modelBuilder.Entity<KitapYazar>()
            .HasOne(x => x.Kitap)
            .WithMany(x => x.Yazarlar);

        modelBuilder.Entity<KitapYazar>()
            .HasOne(x => x.Yazar)
            .WithMany(x => x.Kitaplar);
    }

}

