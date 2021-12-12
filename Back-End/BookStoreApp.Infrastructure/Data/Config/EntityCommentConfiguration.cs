using BookStoreApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Infrastructure.Data.Config
{
    public class EntityCommentConfiguration : IEntityTypeConfiguration<EntityComment>
    {
        public void Configure(EntityTypeBuilder<EntityComment> builder)
        {
            builder.ToTable("EntityComment");

            builder.HasKey(x=>x.Id);

            builder.Property(x => x.CommentContent).HasMaxLength(500);

            builder.Property(x => x.PostDate)
                   .HasColumnType("date")
                   .HasDefaultValueSql("GetDate()");

        }
    }
}
