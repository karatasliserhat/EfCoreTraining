using Microsoft.EntityFrameworkCore;
using System.Reflection;

ApplicationDbContext context = new();


#region Join

#region Query Syntax
//var query =from photo in context.Photos
//           join person in context.Persons
//           on photo.PersonId equals person.Id
//           select new {person.Name, photo.Url};

//var datas =await query.ToListAsync();
#endregion
#region Method Syntax
//var query = context.Photos
//    .Join(
//    context.Persons,
//    photo => photo.PersonId,
//    person => person.Id,
//    (photo, person) => new { person.Name, photo.Url }
//    );
//var photos = await query.ToListAsync();
#endregion

#region Multiple Columns Join
#region Query Syntax
//var query = await (from photo in context.Photos
//                   join person in context.Persons
//                   on new { photo.PersonId, photo.Url } equals new { person.Id, Url = person.Name }
//                   select new
//                   {
//                       person.Name,
//                       photo.Url

//                   }).ToListAsync();



#endregion
#region Method Syntax
//var query = context.Photos
//    .Join(context.Persons,
//    photo => new
//    {
//        photo.PersonId,
//        photo.Url
//    },
//    person => new
//    {
//        person.Id,
//        Url = person.Name
//    },
//    (photo, person) => new
//    {
//        person.Name,
//        photo.Url
//    });
//var photos = await query.ToListAsync();
#endregion

#endregion

#region 2 den fazla Tabloyla Join
#region Query Syntax
//var query = await (from photo in context.Photos
//                   join person in context.Persons
//                        on photo.PersonId equals person.Id
//                   join order in context.Orders
//                        on person.Id equals order.PersonId
//                   select new
//                   {
//                       person.Name,
//                       photo.Url,
//                       order.Description
//                   }).ToListAsync();
#endregion
#region Method Syntax
//var query = await context.Photos
//    .Join(context.Persons,
//    Photo => Photo.PersonId,
//    Person => Person.Id,
//   (photo, person) => new
//   {
//       person.Id,
//       photo.Url,
//       person.Name
//   })
//    .Join(context.Orders,
//   x => x.Id,
//   order => order.PersonId,
//   (x, order) => new
//   {
//       x.Name,
//       x.Url,
//       order.Description,
//   }
//    ).ToListAsync();

#endregion

#endregion

#region Group Join - GroupBy Değil!
//var query = await (from person in context.Persons
//                   join order in context.Orders
//                   on person.Id equals order.PersonId into personOrders
//                   select new
//                   {
//                       person.Name,
//                       Count = personOrders.Count(),
//                       personOrders
//                   }).ToListAsync();
#endregion
#endregion

#region Left Join
//DefaultifEmpty : Sorgulama sürecinde ilişkisel olarak karşılığı olmayan verilere default değerini yazdıran yani Left Join işlemi yapan bir metottur.
//var query = await (from person in context.Persons
//                   join order in context.Orders
//                        on person.Id equals order.PersonId into personOrders
//                   from order in personOrders.DefaultIfEmpty()
//                   select new
//                   {
//                       person.Name,
//                       order.Description

//                   }).ToListAsync();
#endregion

#region Right Join
//var query = await (from order in context.Orders
//                   join person in context.Persons
//                        on order.PersonId equals person.Id into ordersPerson
//                   from person in ordersPerson.DefaultIfEmpty()
//                   select new
//                   {
//                       person.Name,
//                       order.Description
//                   }).ToListAsync();
#endregion

#region Full Join
//var leftQuery = from person in context.Persons
//                join order in context.Orders
//                 on person.Id equals order.PersonId into personOrders
//                from order in personOrders.DefaultIfEmpty()
//                select new
//                {
//                    person.Name,
//                    order.Description
//                };

//var rightJoin = from order in context.Orders
//                join person in context.Persons
//                 on order.PersonId equals person.Id into ordersPerson
//                from person in ordersPerson.DefaultIfEmpty()
//                select new
//                {
//                    person.Name,
//                    order.Description
//                };

//var fullJoin = await leftQuery.Union(rightJoin).ToListAsync();
#endregion

#region Cross Join
//Cross Join, iki tablo arasında bir ilişki olmadan tüm kayıtların birbiriyle eşleşmesini sağlar.
//var query = await (from person in context.Persons
//                   from order in context.Orders
//                   select new { person, order }).ToListAsync();
#endregion

#region Collection Selector'da Where Kullanma Durumu
//var query = await (from person in context.Persons
//                   from order in context.Orders.Where(x => x.PersonId == person.Id)
//                   select new
//                   {
//                       person,
//                       order
//                   }).ToListAsync();
#endregion

#region Cross Apply
//inner join
//var query = await (from person in context.Persons
//                   from order in context.Orders.Select(o => person.Name)
//                   select new
//                   {
//                       person,
//                       order
//                   }).ToListAsync();
#endregion
#region Outhor Apply
//left Join
//var query = await (from person in context.Persons
//                   from order in context.Orders.Select(o => person.Name).DefaultIfEmpty()
//                   orderby person.Id descending
//                   select new
//                   {
//                       person,
//                       order
//                   }).ToListAsync();
#endregion

Console.WriteLine();

public class Photo
{

    public int PersonId { get; set; }
    public string Url { get; set; }
    public Person Person { get; set; }
}

public enum Gender
{
    Man,
    Women
}

public class Person
{
    public Person() => Orders = new HashSet<Order>();
    public int Id { get; set; }

    public string Name { get; set; }
    public Gender Gender { get; set; }
    public Photo Photo { get; set; }
    public ICollection<Order> Orders { get; set; }
}
public class Order
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public string Description { get; set; }
    public Person Person { get; set; }
}


class ApplicationDbContext : DbContext
{

    public DbSet<Person> Persons { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<Order> Orders { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = AppComplexQueryDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");


    }


}