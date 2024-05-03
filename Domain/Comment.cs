using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Comment
    {
        [Key]
        public Guid CommentId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int LikeCount { get; set; } = 0;
        public int DislikeCount { get; set; } = 0;
        public Blogging? Blog { get; set; }
        public AppUser? LoginUser { get; set; }
        public List<Reaction> Reactions { get; set; } = new List<Reaction>();
    }
}
