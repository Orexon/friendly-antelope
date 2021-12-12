using BookStoreApp.Core.Entity;
using BookStoreApp.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Globalization;

namespace BookStoreApp.Infrastructure.Data.Config
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Author).WithMany(x => x.Books);

            builder.HasMany(x => x.Comments);

            builder.Property(x => x.Name).HasMaxLength(100);

            var categoryConverter = new ValueConverter<Category, string>(cc=>cc.ToString(), cc=> Category.Create(cc));

            builder.Property(x=>x.Category)
               .HasConversion(categoryConverter)
               .HasColumnName("Category");

            var datetimeConverter = new ValueConverter<PublicationDate, string>(p => p.ToString(), p => PublicationDate.Create(DateTime.ParseExact(p, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None)));

            builder.Property(e => e.PublicationDate)
                     .HasConversion(datetimeConverter)
                     .HasColumnName("Date");
        }
    }
}