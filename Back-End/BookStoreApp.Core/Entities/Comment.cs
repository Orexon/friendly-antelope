using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Core.Entity
{
    public class Comment : BaseEntity
    {
        public DateTime PostDate { get; set; }
        public string CommentContent { get; set; }

    }
}
