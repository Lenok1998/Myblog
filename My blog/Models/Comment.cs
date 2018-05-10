using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace My_blog.Models
{
    public class Comment
    {
        public Guid Commentid { get; set;}
        public Guid ArticleId { get; set; }
        public Guid AuthorId { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}