using BookStoreApp.Application.Common.Mappings;
using BookStoreApp.Core.Entity;
using BookStoreApp.Domain.Entities;
using System;

namespace BookStoreApp.Application.Comments.CommentDTOs
{
    public class CommentDto : IMapFrom<EntityComment>
    {
        public BaseEntity EntityId { get; }
        public DateTime PostDate { get; set; }
        public string CommentContent { get; set; }
    }
}
