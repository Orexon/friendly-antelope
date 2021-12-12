using BookStoreApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Domain.Entities
{
    public class EntityComment
    {
        public Guid Id { get; } 
        public Guid EntityId { get; }
        public DateTime PostDate { get; }
        public string CommentContent { get; }


        public EntityComment() //For Ef
        {

        }
        public EntityComment(Guid entityId,DateTime postDate, string commentContent)
        {
            EntityId = entityId;
            PostDate = postDate;
            CommentContent = commentContent;
        }

        //Create Comment -> Post -> EntityID -> Comment.
        //Write to table Comment -> EntityID

        //Request comes with EntityID. Find Comment  -> Find Entity ID


    }
}