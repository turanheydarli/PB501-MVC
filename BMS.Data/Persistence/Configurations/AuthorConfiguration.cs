using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BMS.Data.Persistence.Configurations;

public class AuthorConfiguration : BaseConfiguration<Models.Author>
{
    public override void Configure(EntityTypeBuilder<Models.Author> builder)
    {
        base.Configure(builder);

        builder.HasMany(p => p.Contacts)
            .WithOne(p => p.Author);

        builder.HasMany(p => p.Books)
            .WithMany(p => p.Authors);
    }
}