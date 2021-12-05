using BookStoreApp.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreApp.Infrastructure.Data.Config
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.BookComments);

            builder.Property(x => x.Name).HasMaxLength(100);

            builder.OwnsOne(x => x.Category);

            builder.OwnsOne(x => x.PublicationDate);
        }
    }
}