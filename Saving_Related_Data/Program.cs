using Microsoft.EntityFrameworkCore;
using System.Net;
using System;

ApplicationDbContext context = new();

#region One To One ilişkisel senaryolarda Veri Ekleme
#region 1.Yöntem Principal Entity Üzerinden Dependent Entity Verisi Ekleme
//Person person = new();

//person.Name = "Şuayip";
//person.Address = new() { PersonAddress = "Sincan/Ankara" };

//await context.Persons.AddAsync(person);
//await context.SaveChangesAsync();

//#endregion

//#region 2.Yöntem Dependent Entity Üzerinden Principal Entity Verisi Ekleme

//Address address = new();
//address.PersonAddress = "Kayapınar/Diyarbakır";

//address.Person = new() { Name = "Musa" };
//#endregion

//class Person
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public Address Address { get; set; }

//}
//class Address
//{
//    public int Id { get; set; }
//    public string PersonAddress { get; set; }
//    public Person Person { get; set; }
//}

//class ApplicationDbContext : DbContext
//{
//    public DbSet<Person> Persons { get; set; }
//    public DbSet<Address> Addresses { get; set; }
//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = ESirketDb; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
//    }

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Person>()
//            .HasOne(p => p.Address)
//            .WithOne(a => a.Person)
//            .HasForeignKey<Address>(x => x.Id);
//    }
//}

#endregion
#endregion

#region One To Many İlişkisel Senaryolarda Veri Ekleme


#region Principal Entity Üzerinden Dependent Entity Verisi Ekleme

#region Nesne Referensı Üzerinden Ekleme
//Blog blog = new() { Name = "serhatkaratasli.com Blog" };
//blog.Posts.Add(new Post { Title = "Post1" });
//blog.Posts.Add(new Post { Title = "Post2" });
//blog.Posts.Add(new Post { Title = "Post3" });

//await context.Blogs.AddAsync(blog);
//await context.SaveChangesAsync();
#endregion
#region Object İnitilaizer Üzerinden Ekleme


//Blog blog1 = new()
//{
//    Name = "alihaydarkaratasli.com Blog",
//    Posts = new HashSet<Post>()
//    {
//        new (){ Title = "Post4" },
//        new() { Title = "Post5" },
//        new() { Title = "Post6" }}
//};

//await context.Blogs.AddAsync(blog1); ;
//await context.SaveChangesAsync();
#endregion

#endregion

#region Dependent Entity Üzerinden Principal Entity Verisi Ekleme
// Bire Çok ilişkisinde Dependent Entity üzerinden veri eklemesi tercih edilmez.

//Post post = new()
//{
//    Title = "Post Dependent1",
//    Blog = new() { Name = "blog 1 Dependent" }
//};
//await context.Posts.AddAsync(post);
//await context.SaveChangesAsync();
#endregion

#region Foreign Key Kolonu Üzerinden Veri Ekleme
//var posts = new HashSet<Post>(){

//    new() { Title = "Blog1 ", BlogId = 1 },
//    new() { Title = "Blog2 ", BlogId = 1 },
//    new() { Title = "Blog3 ", BlogId = 1 },
//    new() { Title = "Blog4 ", BlogId = 2 }
//};

//#endregion
//await context.Posts.AddRangeAsync(posts);
//await context.SaveChangesAsync();

//class Blog
//{
//    public Blog()
//    {
//        Posts = new HashSet<Post>();
//    }
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public ICollection<Post> Posts { get; set; }
//}

//class Post
//{
//    public int Id { get; set; }

//    public int BlogId { get; set; }
//    public string Title { get; set; }
//    public Blog Blog { get; set; }
//}
//class ApplicationDbContext : DbContext
//{
//    public DbSet<Blog> Blogs { get; set; }
//    public DbSet<Post> Posts { get; set; }
//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = BlogPostDb; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
//    }

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Post>()
//            .HasOne(p => p.Blog)
//            .WithMany(b => b.Posts)
//            .HasForeignKey(p => p.BlogId);
//    }
//}
#endregion

#endregion

#region Many To Many İlişkisel Senaryolarda Veri Ekleme
#region 1.Yöntem
//default convention ile tasarlanmışsa kullan.

//Book book = new()
//{
//    BookName = "A Kitabı",
//    Authors = new HashSet<Author>
//     {
//         new Author{ AuthorName="Ayşe"},
//         new Author{ AuthorName="Fatma"},
//         new Author{ AuthorName="hilmi"},
//     }
//};

//await context.Books.AddAsync(book);
//await context.SaveChangesAsync();


//Author author = new()
//{
//    AuthorName = "Deneme Yazar",
//    Books = new HashSet<Book>
//     {
//         new Book{ BookName="Book1"},
//         new Book{ BookName="Book2"},
//         new Book{ BookName="Book3"},
//     }
//};

//await context.Authors.AddAsync(author);
//await context.SaveChangesAsync();
//class Book
//{
//    public Book()
//    {
//        Authors = new HashSet<Author>();
//    }
//    public int Id { get; set; }
//    public string BookName { get; set; }

//    public ICollection<Author> Authors { get; set; }
//}

//class Author
//{
//    public Author()
//    {
//        Books = new HashSet<Book>();
//    }
//    public int Id { get; set; }
//    public string AuthorName { get; set; }

//    public ICollection<Book> Books { get; set; }

//}


#endregion
#region 2.yöntem
//fluent api ile tasarlanmışsa kullan.


Book book = new()
{
    BookName = "Book1",
    Authors = new HashSet<BookAuthor>
    {
            new (){ AuthorId=3},
            new (){ Author=new Author{ AuthorName="Author10" } },
            new (){ Author=new Author{ AuthorName="Author11" } },
            new (){ Author=new Author{ AuthorName="Author12" } },
    }
};

await context.Books.AddAsync(book);
await context.SaveChangesAsync();


Author author = new()
{
    AuthorName = "Author4",
    Books = new HashSet<BookAuthor>
    {
            new (){BookId=5},
            new (){ Book=new Book{ BookName="Book10" } },
            new (){ Book=new Book{ BookName="Book11" } },
            new (){ Book=new Book{ BookName="Book12" } },
    }
};

await context.Authors.AddAsync(author);
await context.SaveChangesAsync();

class Book
{
    public Book()
    {
        Authors = new HashSet<BookAuthor>();
    }
    public int Id { get; set; }
    public string BookName { get; set; }

    public ICollection<BookAuthor> Authors { get; set; }
}

class BookAuthor
{
    public int BookId { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
    public Book Book { get; set; }
}
class Author
{
    public Author()
    {
        Books = new HashSet<BookAuthor>();
    }
    public int Id { get; set; }
    public string AuthorName { get; set; }

    public ICollection<BookAuthor> Books { get; set; }

}

class ApplicationDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = BookAuthorDb; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthor>().HasKey(x => new { x.BookId, x.AuthorId });

        modelBuilder.Entity<BookAuthor>().HasOne(ba => ba.Book).WithMany(b => b.Authors);
        modelBuilder.Entity<BookAuthor>().HasOne(ba => ba.Author).WithMany(a => a.Books);
    }
}
#endregion
#endregion



