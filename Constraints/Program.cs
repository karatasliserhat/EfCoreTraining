using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

ApplicationDbContext context = new();


#region PK Constraint
// Bir kolunu PK constrail ile birincil anahtar yapmak istiyorsak eğer bunun için conventiondan istifade edebiliriz. ID, Id, EntitNameId, EntityNameID şekliden tanımlanan propertyler default olarak ED Core tarafından PK constraint olarak generate edilirler.

// Eğer ki farklı bir propertyi PK yapmak istiyorsak Haskey Flunt API ile yada KEY data Annotation attribute ile yapabiliriz.
#region HasKey Fonksiyonu

#endregion

#region Key Attribute'u

#endregion

#region Alternate Keys-HasAlternateKey
// Bir entity içerisinde PK ye ek olarak her entity intance için alternatif bir benzersiz tanımlayıcı işlevine sahip olan bir key'dir
#endregion

#region Composite Alternate Key
//modelBuilder.Entity<Blog>()
//            .HasAlternateKey(b => new { b.Url, b.BlogName });
#endregion

#region HasName Fonksiyonu ile Primary Key Constraint'e isim verme

#endregion

#endregion

#region FK Constraint

#endregion

#region Unique Constraint

#endregion

#region Check Constraint

#endregion

Console.Read();




//[Index(nameof(Blog.Url), IsUnique = true)]
class Blog
{
    public Blog()
    {
        Posts = new HashSet<Post>();
    }
    public int Id { get; set; }
    //[Key]
    public string BlogName { get; set; }
    public string Url { get; set; }
    public ICollection<Post> Posts { get; set; }
}
class Post
{
    public int Id { get; set; }
    //[ForeignKey(nameof(Blog))]

    //BlogId properpety si kaldırılırsa ve migrate işlemi gerçekleştirilirse shadow propery devreye girip otomotik kendisi oluşturacaktır.
    public int BlogId { get; set; }
    public string Title { get; set; }
    public string BlogUrl { get; set; }
    public Blog Blog { get; set; }

    public int A { get; set; }
    public int B { get; set; }

}
class ApplicationDbContext : DbContext
{

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppConstraintsDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        //modelBuilder.Entity<Blog>()
        //    .HasMany(x => x.Posts)
        //    .WithOne(y => y.Blog)
        //    .HasForeignKey(x => x.BlogId)
        //    .HasConstraintName("BlogForeingKey");

        /*Composite Foreign Key*/

        //modelBuilder.Entity<Blog>()
        //    .HasMany(x => x.Posts)
        //    .WithOne(y => y.Blog)
        //    .HasForeignKey(x => new { x.BlogId, x.BlogUrl });

        //modelBuilder.Entity<Blog>()
        //    .HasKey(b => b.Id).HasName("BlogIdcim");

        /*Alternate Key*/
        //modelBuilder.Entity<Blog>()
        //    .HasAlternateKey(b => b.Url);

        /*Composite Key*/
        //modelBuilder.Entity<Blog>()
        //    .HasAlternateKey(b => new { b.Url, b.BlogName });

        modelBuilder.Entity<Post>()
            .ToTable(x => x
                .HasCheckConstraint("a_b_const", "[A]>[B]")
                );
    }
}