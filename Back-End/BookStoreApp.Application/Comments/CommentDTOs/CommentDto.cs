using BookStoreApp.Application.Common.Mappings;
using BookStoreApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Application.Comments.CommentDTOs
{
    public class CommentDto : IMapFrom<Comment>
    {
        public DateTime PostDate { get; set; }
        public string CommentContent { get; set; }
    }
}
