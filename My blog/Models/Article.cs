using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using My_blog.Models;

namespace My_blog.Models
{
    public class Article
    {
        public Guid ID { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public string Rating { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}