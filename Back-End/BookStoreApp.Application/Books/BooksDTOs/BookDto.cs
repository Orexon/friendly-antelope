using BookStoreApp.Application.Common.Mappings;
using BookStoreApp.Core.Entity;
using BookStoreApp.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Application.Books.BooksDTOs
{
    public class BookDto : IMapFrom<Book>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid AuthorId { get; set; }
        public Category Category { get; set; }
        public string Language { get; set; }
        public string About { get; set; }
        public PublicationDate PublicationDate { get; set; }
        public string CoverPicture { get; set; }
    }
}
