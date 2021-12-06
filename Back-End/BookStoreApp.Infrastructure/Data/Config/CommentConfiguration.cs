using BookStoreApp.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BookStoreApp.Infrastructure.Data.Config
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.Property<Guid>("Id");

            builder.Property(x => x.CommentContent).HasMaxLength(500);

            builder.Property(x => x.PostDate)
                .HasColumnType("date")
                .HasDefaultValueSql("GetDate()");
        }
    }
}
