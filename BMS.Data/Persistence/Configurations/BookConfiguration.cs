using BMS.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BMS.Data.Persistence.Configurations;

public class BookConfiguration : BaseConfiguration<Book>
{
    public override void Configure(EntityTypeBuilder<Book> builder)
    {
        base.Configure(builder);

        builder.HasOne(p => p.Publisher)
            .WithMany()
            .HasForeignKey(p => p.PublisherId);

        builder.HasOne(p => p.Category)
            .WithMany()
            .HasForeignKey(p => p.CategoryId);

        builder.HasMany(p => p.Authors)
             .WithMany(p => p.Books);
    }
}