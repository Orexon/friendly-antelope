using BookStoreApp.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Infrastructure.Data.Config
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Author.Comments));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasKey(x => x.Id);

            builder.HasMany(c => c.Books)
                   .WithOne(n => n.Author);

            builder.HasMany(typeof(Comment), "_comments");



            builder.Property(x=>x.FirstName)
                   .HasMaxLength(100)
                   .IsRequired();
            builder.Property(x=>x.LastName)
                   .HasMaxLength(100)
                   .IsRequired();

        }
    }
}
