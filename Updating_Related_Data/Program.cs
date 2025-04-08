
using Microsoft.EntityFrameworkCore;
ApplicationDbContext context = new();



#region One To One İlişkisel Senaryolarda Veri Güncelleme

#region Saving
//Person person = new()
//{
//    Name = "Serhat",
//    Address = new() { PersonAddress = "Çankaya/Ankara" }
//};

//Person person1 = new()
//{
//    Name = "Kemal"
//};

//await context.Persons.AddRangeAsync(person, person1);
//await context.SaveChangesAsync();
#endregion

#region 1.Durum | Esas Tablodaki Veriye Bağımlı Veriyi Değiştirme
//Person? person = await context.Persons
//    .Include(x => x.Address)
//    .FirstOrDefaultAsync(x => x.Id == 2);

//context.Addresses.Remove(person.Address);

//person.Address = new()
//{
//    PersonAddress = "Çankaya/Ankara"
//};

//await context.SaveChangesAsync();



#endregion

#region 2.Durum | Bağımlı Verinin İlişkisel Olduğu Ana Veriyi Güncelleme

//Address? address = await context.Addresses.FindAsync(1);

//context.Addresses.Remove(address);

//await context.SaveChangesAsync();

//Person? person=await context.Persons.FindAsync(2);

//address.Person = person;

//await context.Addresses.AddAsync(address);
//await context.SaveChangesAsync();

#endregion

#endregion

#region One To Many İlişkisel Senaryolarda Veri Güncelleme

#region Saving
//Blog blog = new()
//{
//    BlogName = "serhatkaratasliBlog.com",
//    Posts = new HashSet<Post>()
//     {
//         new(){ Title="Post1"},
//         new(){Title="Post2"},
//         new(){Title="Post3"},
//     }
//};

//await context.Blogs.AddAsync(blog);
//await context.SaveChangesAsync();
#endregion

#region 1.Durum | Esas Tablodaki Veriye Bağımlı Veriyi Değiştirme

//Blog? blog = await context.Blogs.Include(x=> x.Posts).FirstOrDefaultAsync(x=> x.Id== 1);


//Post? removePost=blog.Posts.FirstOrDefault(x => x.Id == 2);

//blog.Posts.Remove(removePost);

//blog.Posts.Add(new() { Title = "yeni Post 4" });
//blog.Posts.Add(new() { Title = "yeni Post 5" });


//await context.SaveChangesAsync();

#endregion

#region Bağımlı Verinin İlişkisel Olduğu Ana Veriyi Güncelleme

//Post? post = await context.Posts.FindAsync(4);


//post.Blog = new (){ BlogName = "2. Blog" };


//await context.SaveChangesAsync();


//Post? post = await context.Posts.FindAsync(3);


//Blog? blog = await context.Blogs.FindAsync(4);
//post.Blog = blog;

//await context.SaveChangesAsync();

#endregion

#endregion

#region Many To Many İlişkisel Senaryolarda Veri Güncelleme

#region Saving

//Book book = new()
//{
//    BookName = "Book1",
//    Authors = new HashSet<AuthorBook>()
//    {
//       new (){ Author=new (){ AuthorName="Author 1" } },
//       new (){ Author=new (){ AuthorName="Author 2" } },
//       new (){ Author=new (){ AuthorName="Author 3" } },
//    }
//};

//Author author = new()
//{
//    AuthorName = "Author4",
//    Books = new HashSet<AuthorBook>()
//    {
//        new AuthorBook(){ Book=new(){ BookName="Book4"}},
//        new AuthorBook(){ Book=new(){ BookName="Book5"}},
//        new AuthorBook(){ Book=new(){ BookName="Book3"}}
//    }
//};

//await context.AddRangeAsync(book, author);
//await context.SaveChangesAsync();

#endregion

#region 1.Örnek 1.kitabu 4.yazarla ilişkilendirme

//Book? book = await context.Books.Include(x => x.Authors).FirstOrDefaultAsync(x => x.Id == 1);

//Author? author = await context.Authors.FindAsync(4);
//book.Authors.Add(new AuthorBook() { Author = author });

//await context.SaveChangesAsync();

//Book? book = await context.Books.FindAsync(2);

//Author? author = await context.Authors.FindAsync(2);
//book.Authors.Add(new AuthorBook() { Author = author });

//await context.SaveChangesAsync();

#endregion
#region 2.Örnek 4.yazara sahip kitaplardan sadece 1 nolu kitabın kalması

//Author? authors = await context.Authors.Include(x => x.Books).FirstOrDefaultAsync(x => x.Id == 4);

//foreach (var item in authors.Books)
//{
//    if (item.BookId != 1)
//        context.Remove(item);
//}

//await context.SaveChangesAsync();
#endregion
#region 1.kitaba ait 4.yazarı sileceksin 3.kitaba 4.yazarı ekleyeceksin ve 5.

#endregion
#endregion



class Person
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Address Address { get; set; }
}
class Address
{
    public int Id { get; set; }
    public string PersonAddress { get; set; }

    public Person Person { get; set; }
}

class Blog
{
    public Blog()
    {
        Posts = new HashSet<Post>();
    }
    public int Id { get; set; }
    public string BlogName { get; set; }
    public ICollection<Post> Posts { get; set; }
}

class Post
{
    public int Id { get; set; }
    public int BlogId { get; set; }
    public string Title { get; set; }
    public Blog Blog { get; set; }
}

class Book
{
    public Book()
    {
        Authors = new HashSet<AuthorBook>();
    }
    public int Id { get; set; }
    public string BookName { get; set; }

    public ICollection<AuthorBook> Authors { get; set; }
}
class Author
{
    public Author()
    {
        Books = new HashSet<AuthorBook>();
    }
    public int Id { get; set; }
    public string AuthorName { get; set; }

    public ICollection<AuthorBook> Books { get; set; }
}
class AuthorBook
{
    public int BookId { get; set; }
    public int AuthorId { get; set; }
    public Book Book { get; set; }
    public Author Author { get; set; }
}

class ApplicationDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = ApplicationDb; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasOne(p => p.Address)
            .WithOne(a => a.Person)
            .HasForeignKey<Address>(x => x.Id);

        modelBuilder.Entity<Post>().HasOne(p => p.Blog).WithMany(b => b.Posts).HasForeignKey(x => x.BlogId);

        modelBuilder.Entity<AuthorBook>().HasKey(x => new { x.BookId, x.AuthorId });

        modelBuilder.Entity<AuthorBook>().HasOne(x => x.Book).WithMany(b => b.Authors).HasForeignKey(x => x.BookId);
        modelBuilder.Entity<AuthorBook>().HasOne(x => x.Author).WithMany(b => b.Books).HasForeignKey(x => x.AuthorId);
    }
}