using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;


internal class Program
{
    private async static Task Main(string[] args)
    {
        ETicaretContext eTicaretContext = new();

        #region Add AddRange
        //Urun urun = new Urun()
        //{
        //    UrunAdi = "E Ürünü",
        //    Fiyat = 1000
        //};

        //Urun urun2 = new Urun()
        //{
        //    UrunAdi = "F Ürünü",
        //    Fiyat = 1000
        //};

        //Urun urun3 = new Urun()
        //{
        //    UrunAdi = "G Ürünü",
        //    Fiyat = 1000
        //};

        //List<Urun> uruns = new() { urun, urun2, urun3 };
        //Console.WriteLine(eTicaret.Entry(urun).State);
        //await eTicaret.Urunler.AddRangeAsync(uruns);


        //Console.WriteLine(eTicaret.Entry(urun).State);
        //await eTicaret.SaveChangesAsync();
        //uruns.ForEach(x => Console.WriteLine(string.Join(", ", x.Id)));
        //Console.WriteLine(eTicaret.Entry(urun).State);
        #endregion
        #region Veri Güncelleme

        ////Urun urun = await eTicaretContext.Urunler.FirstOrDefaultAsync(x => x.Id == 3);


        ////urun.UrunAdi = "Güncellenmiş Ürün";
        ////urun.Fiyat = 2500;

        //Urun urun = new()
        //{
        //    Id = 3,
        //    Fiyat = 5000,
        //    UrunAdi = "Güncelleme"
        //};

        //eTicaretContext.Urunler.Update(urun);

        //await eTicaretContext.SaveChangesAsync();

        #endregion
        #region EntityState

        //Urun u = await eTicaretContext.Urunler.FirstOrDefaultAsync(x => x.Id == 3);

        //Console.WriteLine(eTicaretContext.Entry(u).State);

        //u.UrunAdi = "Bayat";

        //Console.WriteLine(eTicaretContext.Entry(u).State);

        //await eTicaretContext.SaveChangesAsync();

        //Console.WriteLine(eTicaretContext.Entry(u).State);


        //u.Fiyat = 10001;

        //Console.WriteLine(eTicaretContext.Entry(u).State);



        #endregion

        #region EntityState ile silme işlemi

        //Urun urun = new() { Id = 2 };

        //eTicaretContext.Entry(urun).State = EntityState.Deleted;

        //await eTicaretContext.SaveChangesAsync();
        #endregion

        #region Queries


        #region En temel Basit bir sorugalama nasıl yapılır?
        #region Method Sytax
        //var urunler = await eTicaretContext.Urunler.ToListAsync();
        #endregion
        #region Query Syntax
        //var urunler2 = await (from urun in eTicaretContext.Urunler
        //               select urun).ToListAsync();
        #endregion
        #endregion

        #region Sorguyu Execute Etme
        #region TolistAsync

        #endregion


        //Deffered Execution örnek
        //int urunId = 5;
        //var urunler = (from urun in eTicaretContext.Urunler
        //               where urun.Id > urunId
        //               select urun);


        //urunId = 7;

        //foreach (Urun urun in urunler)
        //{
        //    Console.WriteLine(urun.UrunAdi);
        //}
        //Son
        #endregion


        #region IQueryable ve IEnumerable nedir Basit olarak

        #region IQueryable

        #endregion

        #region IEnumerable

        #endregion

        #endregion
        #endregion

        #region Deffered Execurion(Ertelenmiş Çalışma)
        /*IQueryable çalışmalarında ilgili kod yazıldığı noktada tetiklenmez çalıştırılmaz yani ilgili kod yazıldığı noktada sorguyu generate etmez! nerede eder? çalıştırıldığı exute edildiği noktada tetiklenir işte bu ertlenmiş çalışmayadır.
         
          int urunId = 5;

        var urunler = (from urun in eTicaretContext.Urunler
                       where urun.Id > urunId
                       select urun);


        urunId = 7;

        foreach (Urun urun in urunler)
        {
            Console.WriteLine(urun.UrunAdi);
        }
         
         
         
         */
        #endregion

        #region OrderBy
        //Method Sytax

        //var urunler = await eTicaretContext.Urunler.Where(u => u.Id > 3 || u.UrunAdi.EndsWith("a")).OrderBy(x => x.UrunAdi).ToListAsync(); ;

        //QuerySyntax

        //var urunler2 = (from urun in urunler
        //                where urun.Id > 3 || urun.UrunAdi.EndsWith("a")
        //                orderby urun.UrunAdi
        //                select urun).ToList();
        #endregion

        #region Sorgu sonucu dönüşüm fonksiyonları

        //Bu fonksiyonlar ile sorgu neticesinde elde edilen verileeri istediğimiz doğrultusunda farklı türlerde projeksiyon edebiliyoruz.
        #region ToDictinaryAsync
        //var urunler = await eTicaretContext.Urunler.ToDictionaryAsync(u => u.UrunAdi, u => u.Fiyat);

        //Console.WriteLine();
        #endregion

        #region ToArryaAsync
        //var urunler = await eTicaretContext.Urunler.ToArrayAsync();
        //Console.WriteLine();
        #endregion

        #region Select

        //T Bazlı /Urun Bazlı
        //var urunler = await eTicaretContext.Urunler
        //    .Select(x => new Urun
        //    {
        //        Id = x.Id,
        //        Fiyat = x.Fiyat
        //    })
        //    .ToListAsync();
        //Console.WriteLine();

        //Anonim bazlı

        var urunler = await eTicaretContext.Urunler
        .Select(x => new
        {
            Id = x.Id,
            Fiyat = x.Fiyat
        })
        .ToListAsync();
        Console.WriteLine();
        #endregion

        #region SelectMany
        //var urunlerSelectMany = await eTicaretContext.Urunler.Include(x => x.Parcalar)
        //    .SelectMany(x => x.Parcalar, (u, p) => new
        //    {
        //        Id = u.Id,
        //        Fiyat = u.Fiyat,
        //        ParcaAdi = p.ParcaAdi,
        //    })
        //    .ToListAsync();
        #endregion


        #region GroupBy

        #region Method Sytax

        //var urunlerGroupBy = await eTicaretContext.Urunler.GroupBy(x => x.Fiyat).Select(group => new
        //{
        //    Count = group.Count(),
        //    Fiyat = group.Key
        //}).ToListAsync();
        //Console.WriteLine();

        #endregion

        #region Query Sytax

        //var datas = await (from urun in eTicaretContext.Urunler
        //                   group urun by urun.Fiyat
        //            into @group
        //                   select new
        //                   {
        //                       Fiyat = @group.Key,
        //                       Count = @group.Count()
        //                   }).ToListAsync();
        //Console.WriteLine();
        #endregion

        #endregion
        #endregion


        #region ThenBy
        //order by üzerinden yapılan sıralama işleminde farklı kolonlarada uygulamamamızı sağlayan fonksiyondur.
        #endregion



        #region ChangeTracker
        //Context nesnesi üzerinden gelen nesneler/veriler otomotik olarak bir takio mekanızması tarafından izlenirler. iş bu takip mekanızmasına Change Tracker denir Changer tracker ile nesneler üzerindeki değişikliler/işlemler takip edileerek netice itibariyle bu işlemleri fıtratına uygun sql srgucukları generate edildir işte bıu işleme Change Tracker denir.

        #region Change Tracker Property'si
        //Takip edilen nesnelere erişebilmemizi ve gerektiği takdir gerçekleştirmemizi sağlayan bir propertydir 

        // Context sınıfını base clası olan DbContext sınıfının bir member'ıdır.


        // var urunler3 = await eTicaretContext.Urunler.ToListAsync();

        // urunler3[2].UrunAdi = "Deneme";
        // urunler3[4].Fiyat = 123;
        // eTicaretContext.Remove(urunler3[6]);


        //var datas = eTicaretContext.ChangeTracker.Entries();

        // Console.WriteLine();

        #endregion

        #region DetectChanges Metodu
        //EF Core context nesnesi tarafıdan izlenen tüm nesnelerdeki Change Tracker sayaesinde takip etmekte ve nesnelere olaran verisel değişklikler yakalanarak bunların anlık görüntülerini(snapshot)'ni oluşturabilir.

        //
        //var urun = await eTicaretContext.Urunler.FirstOrDefaultAsync(u=> u.Id==3);

        //urun.Fiyat = 1;
        //eTicaretContext.ChangeTracker.DetectChanges();

        //await eTicaretContext.SaveChangesAsync();
        //Console.WriteLine();

        #endregion

        #region AutoDetectChangesEnabled Property'si
        //ilgili metodlara (SaveChanges, Entries) tarafından detectChanges metodunun otomotik olarak tetiklenmesinin konfügürasyonunun yapılması sağlayan propertiydir.

        //eTicaretContext.ChangeTracker.AutoDetectChangesEnabled = false; oomotik tetiklenmeyecek
        #endregion

        #region Entries Metodu
        // Contexte ki entry metodunun koleksiyonel versiyondur.

        // Change tracker mekanızması tarafından izlenen her entity nesnesinin bilgisini Entry türünden elde etmemizi sağlar ve belirli işlemler yapabilmemize olanak tanır.

        // DEtect Changes metodunu otomotik tetikler. Bu durumda tıpkı Savechangesda olduğu gibi bir maliyettir.

        //var urunler3 = await eTicaretContext.Urunler.ToListAsync();

        //urunler3.FirstOrDefault(u => u.Id == 2).UrunAdi = "Deneme";
        //urunler3.FirstOrDefault(u => u.Id == 4).Fiyat = 123;
        //eTicaretContext.Remove(urunler3.FirstOrDefault(u => u.Id == 6));

        //eTicaretContext.ChangeTracker.Entries().ToList().ForEach(x =>
        //{
        //    if (x.State is EntityState.Unchanged)
        //    {

        //    }
        //    else if(x.State is EntityState.Deleted)
        //    {

        //    }
        //});
        #endregion

        #region AcceptAllChanges Metodu

        //SaveChanges SaveChnages(true) tüm değişiklikleri metodundan sonra başarılı olursa takibi bırakmak için kullanılan metodtur false yapılırsa başarılı veya başarısız olsada takibi bırakmayacaktır.
        //var urunler3 = await eTicaretContext.Urunler.ToListAsync();

        //urunler3.FirstOrDefault(u => u.Id == 2).UrunAdi = "Deneme";
        //urunler3.FirstOrDefault(u => u.Id == 4).Fiyat = 123;
        //eTicaretContext.Remove(urunler3.FirstOrDefault(u => u.Id == 6));

        //false işlemi yapılırsa AcceptAllChanges Metodunu çağrımak gerekiyor.
        //await eTicaretContext.SaveChangesAsync(false);

        //eTicaretContext.ChangeTracker.AcceptAllChanges();
        ////////////////////////////////////////////////////////
        //await eTicaretContext.SaveChangesAsync(true);

        #endregion

        #region HasChanges

        //Tekip edilen nesneler arasından değişiklik yapılanların olup olamadığının bilgisini verir. 
        // arkaplanda DetechChanges metodunu tetikler.

        //var result = eTicaretContext.ChangeTracker.HasChanges();
        #endregion
        #endregion


        #region AsNoTrackingWithIdentityResolition

        //Change Tracking de ilişkili veriler çekilirken yinelenen değerler için bir instance oluşturulur
        //var products = await eTicaretContext.Urunler.Include(u => u.Parcalar).ToListAsync();

        //AsNoTracking metodunda ise ilişkili veriler çekilirken hem change tracking kapatılacak hemde her yinelenen değer için instance oluşturacak.
        //var products = await eTicaretContext.Urunler.Include(u => u.Parcalar).AsNoTracking().ToListAsync();

        //AsNoTrackingWithIdentityResolition metodu ilişkili veriler çekilirken hem change tracking kapatılacak hemde her yinelenen değerler için bir instance oluşturulur
        //var products = await eTicaretContext.Urunler.Include(u => u.Parcalar).AsNoTrackingWithIdentityResolution().ToListAsync();

        //AsTracking metodu UseQueryTrackingBehavior configurasyonunda NoTracking seçilirse uygun noktalarda tracking i aktif etmek için kullanılır.
        #endregion
    }
    public class ETicaretContext : DbContext
    {

        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Parca> Parcalar { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = ETicaretDb; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");

            /*optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);*/ //Uygun noktalarda aktif etmek için AsTracking komutu kullanılır. 
        }

    }

    public class Urun
    {
        public Urun()=> Console.WriteLine("Ürün Sınfı instance edildi");
        public int Id { get; set; }
        public string UrunAdi { get; set; }
        public float Fiyat { get; set; }
        public ICollection<Parca> Parcalar { get; set; }
    }

    public class Parca
    {
        public Parca() => Console.WriteLine("Parça Sınfı instance edildi");

    }
    public int Id { get; set; }
    public string ParcaAdi { get; set; }
    public ICollection<Urun> Urunler { get; set; }
}


