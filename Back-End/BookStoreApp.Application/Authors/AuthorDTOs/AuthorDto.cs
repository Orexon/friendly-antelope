using BookStoreApp.Application.Common.Mappings;
using BookStoreApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Application.Authors.AuthorDTOs
{
    public class AuthorDto : IMapFrom<Author>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AboutAuthor { get; set; }
        public string Picture { get; set; }
        public IReadOnlyCollection<AuthorBookDto> Books { get; set; }
    }
}
