using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BMS.Data.Persistence.Configurations;

public class PublisherConfiguration : BaseConfiguration<Models.Publisher>
{
    public override void Configure(EntityTypeBuilder<Models.Publisher> builder)
    {
        base.Configure(builder);

        builder.HasMany(p => p.Books)
            .WithOne(p => p.Publisher)
            .HasForeignKey(p => p.PublisherId);
    }
}