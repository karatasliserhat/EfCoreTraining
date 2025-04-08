using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

#region Data Seeding Nedir?
//EF Core ile inşa edilen vertiabanı içerisnde veratabanı nesneleri olabileceği gibi verilerinde migrate sürecinde üretilmesini isteyebiliriz

//Bu süreci ihtiyaca istinaden Seed DAta özelliği ile Ef Core üzerinden nmigrationlarda verile oluşturabilir ve migrate ederken bu verileri hedef tablolara basabiliriz.
#endregion
Console.WriteLine();
#region Seed Data Ekleme
//OnModelCreatin metodu içerisinde Hasdata fonksiyonuyla ilgili entitye karşılık seed data oluşturmamızı sağlar.
#endregion

#region İlişkisel Tablolar için Seed Data Ekleme

#endregion

#region Seed Datanın Primary Key'ini Değiştirme

#endregion


class ApplicationDbContext : DbContext
{

    public DbSet<Post> Posts { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppSeedingDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>()
            .HasData(new HashSet<Post>() {

               new (){Id=1,BlogId=1,Content="İçerik",Title="Başlık" },
                new(){ Id=2,BlogId=2,Content="İçerik2",Title="Başlık1"},
                new(){ Id=3,BlogId=1,Content="İçerik3",Title="Başlık1"},
                new(){ Id=4,BlogId=1,Content="İçerik4",Title="Başlık1"},

            });
        modelBuilder.Entity<Blog>()
            .HasData(
            new HashSet<Blog>()
            {
                new () {Id=1,Url="serhatkaratsli.com/blog"},
                 new (){Id = 2, Url = "alikaratsli.com/blog"}
       });

    }
}

class Post
{
    public int Id { get; set; }
    public int BlogId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Blog Blog { get; set; }
}
class Blog
{
    public Blog()
    {
        Posts = new HashSet<Post>();
    }
    public int Id { get; set; }
    public string Url { get; set; }
    public ICollection<Post> Posts { get; set; }
}


