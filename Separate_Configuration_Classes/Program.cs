using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Reflection;

Console.ReadLine();
#region OnModelCreating
//Genel anlamda ceritabnı ile ilgili konfigürasyonel operasyonların dışında Entityler üzerinde konfigürasyonel çalışma yapmamızı sağlayan bir fonksiyondur.
#endregion

#region IEntityTypeConfiguration<T> Arayüzü
//Entity bazlı yapılacak olan konfigürasyonları o entitye özgü özel harici bir dosya üzrinden yapmamızı sağlayan bir arayüzdür.

//Harici bir dosyada kongürasypnların yürütülmesi merkezi bir yapılandırma noktası oluşturmamnızı sağlamaktadır.
#endregion

#region ApplyConfiguration Metodu
// Bu metod harici konfigürasyonel sınıflarımızı EF COre'a bildirmek için kullandığımız bir metod.
#endregion

#region ApplyConfigurationsFromAssembly
//Uygulama bazında oluturulan harici konfigürasyonel sınıfıların herbirini onmodel creatin metounda apply konfiguration ile tek tek bişldirmek yerine bu sınıfların bulunduğu asseblye bildirerek IEntityTypeConfiguraton aratyüzünden türeyen tüm sınıfların ilgili netitye karşılı konfügrasyonel değer olarak baz alınması tek kalemde gerçekleştirmemizi sağlayan bir metoddur.
#endregion
class ApplicationDbContext : DbContext
{

    public DbSet<Order> Orders { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppIEntityTypeDb; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

class Order
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime OrderDate { get; set; }
}

class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Description).HasMaxLength(123);

        builder.Property(p => p.OrderDate)
            .HasDefaultValueSql("GETDATE()");
    }
}
