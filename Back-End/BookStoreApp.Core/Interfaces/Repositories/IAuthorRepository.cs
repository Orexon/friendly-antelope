using BookStoreApp.Core.Entity;
using BookStoreApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Core.Interfaces.Repositories
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<Author> GetAuthorWithBooks(Guid id);
    }
}
