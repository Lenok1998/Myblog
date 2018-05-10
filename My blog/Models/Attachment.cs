using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace My_blog.Models
{
    public class Attachment
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        public Guid ArticleId { get; set; }
        public string ContentType { get; set; }
    }
}