using System;
namespace Domain.Entities
{
    public class Reaction
    {
        public Guid Id { get; set; }
        public Guid BlogId { get; set; }  
        public int Upvote { get; set; }
        public int Downvote { get; set; }
        public string Comment { get; set; }

        // Navigation property back to the blog
        public Blog Blog { get; set; }
    }
}
