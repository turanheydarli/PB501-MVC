using BMS.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BMS.Infrastructure.Persistence.Configurations;

public class AuthorConfiguration : BaseConfiguration<Author>
{
    public override void Configure(EntityTypeBuilder<Author> builder)
    {
        base.Configure(builder);

        builder.HasOne(p => p.Contact)
            .WithOne(p => p.Author)
            .HasForeignKey<AuthorContact>(p => p.AuthorId);
    }
}