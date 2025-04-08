using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loading_Related_Data.Configurations
{
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        void IEntityTypeConfiguration<Photo>.Configure(EntityTypeBuilder<Photo> builder)
        {

            builder.HasKey(e => e.PersonId);

            HashSet<Photo> photos = new();
            for (int i = 1; i <= 100; i++)
            {
                photos.Add(new Photo()
                {
                    PersonId = i,
                    Url = $"https://example.com/photo{i}.jpg"

                });
            }
            builder.HasData(photos);
        }
    }
}
