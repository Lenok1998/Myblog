using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace My_blog.Models
{
    public class User
    {
        public Guid ID { get; set; }
        public string Username { get; set; }
        public byte YOB { get; set; }
        public string Email { get; set; }
        public string Workexperience { get; set; }
        public string Education { get; set; }
        public string Specialization { get; set; }
        public string Avatar { get; set; }
    }
}