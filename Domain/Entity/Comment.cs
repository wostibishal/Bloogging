using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Domain.Entity
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }


        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }

        public virtual AppUser? User { get; set; }


        public string? Content { get; set; }


        public DateTime PostedAt { get; set; } = DateTime.UtcNow;


        [ForeignKey(nameof(Blog))]
        public Guid BlogId { get; set; }


        public virtual Blogging? Blog { get; set; }

        public int LikeCount { get; set; } = 0;
        public int DislikeCount { get; set; } = 0;
    }
}
