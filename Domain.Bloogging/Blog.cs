using System;
namespace Domain.Entities
{
    public class Blog
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }  // Assuming this is a URL or a path to an image file
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        // Navigation property to reactions
        public List<Reaction> Reactions { get; set; } = new List<Reaction>();
    }
}
