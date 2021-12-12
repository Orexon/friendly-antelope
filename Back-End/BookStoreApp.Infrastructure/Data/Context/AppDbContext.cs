using BookStoreApp.Application.Common.Interfaces;
using BookStoreApp.Core.Entity;
using BookStoreApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookStoreApp.Infrastructure.Data.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<EntityComment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
