using BookStoreApp.Application.Common.Interfaces;
using BookStoreApp.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Infrastructure.Data.Context
{
    internal class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
