using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Core.Entity
{
    public class Comment
    {
        public DateTime PostDate { get;}
        public string CommentContent { get; }

        public Comment(DateTime postDate, string commentContent)
        {
            PostDate = postDate;
            CommentContent = commentContent;
        }
    }
}
