using BookStoreApp.Core.Entity;
using BookStoreApp.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookStoreApp.Infrastructure.Data.Config
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Author).WithMany(x => x.Books);

            builder.HasMany(x => x.BookComments);

            builder.Property(x => x.Name).HasMaxLength(100);

            var categoryConverter = new ValueConverter<Category, string>(cc=>cc.ToString(), cc=> Category.Create(cc));

            builder.Property(x=>x.Category)
               .HasConversion(categoryConverter)
               .HasColumnName("Category");

            builder.OwnsOne(x => x.PublicationDate);
        }
    }
}