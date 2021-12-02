using BookStoreApp.Core.Entity;
using BookStoreApp.Core.Interfaces.Repositories;
using BookStoreApp.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.Infrastructure.Data.Repositories
{
    internal class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private readonly DbSet<Author> _authors;

        public AuthorRepository(AppDbContext dbContext) : base(dbContext)
        {
            _authors = dbContext.Set<Author>();
        }

        public async Task<Author> GetAuthorWithBooks(Guid authorId)
        {
            return await _authors.Include(x=>x.Books).SingleOrDefaultAsync(a=>a.Id == authorId);
        }
    }
}
