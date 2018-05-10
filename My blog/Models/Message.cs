using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace My_blog.Models
{
    public class Message
    {
        public Guid ID { get; set; }
        public Guid Senderid { get; set; }
        public Guid Receiverid { get; set; }
        public DateTime Departuredate { get; set; }

    }
}