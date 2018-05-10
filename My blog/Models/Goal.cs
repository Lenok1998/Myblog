using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace My_blog.Models
{
    public class Goal
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public int Term { get; set; }
        public double Progress { get; set; }
    }
}