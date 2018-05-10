using System.Collections.Generic;

namespace My_blog.Models
{
    public class ArticleRepository
    {
        public static ICollection<Article> Articles { get; } = new HashSet<Article>();
        public static ICollection<Attachment> Attachments { get; } = new HashSet<Attachment>();
        public static ICollection<User> Users { get; } = new HashSet<User>();
        public static ICollection<Goal> Goals { get; } = new HashSet<Goal>();
        public static ICollection<Message> Messages { get; } = new HashSet<Message>();
        public static ICollection<string> RoleNames { get; } = new HashSet<string>();
        public static ICollection<Comment> Comments { get; } = new HashSet<Comment>();
    }
}
