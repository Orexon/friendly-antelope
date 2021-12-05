using BookStoreApp.Application.Common.Mappings;
using BookStoreApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Application.DTOs.AuthorDTOs
{
    public class AuthorListDto : IMapFrom<Author>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AboutAuthor { get; set; }
        public string Picture { get; set; }
    }
}
