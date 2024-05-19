using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Blogging
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? BlogTitle { get; set; }

        [Required]
        public string? BlogContent { get; set; } 

        public string? ImageName { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now; 

        [ForeignKey(nameof(UserFK))]
        public string? User { get; set; }

        public virtual AppUser? UserFK { get; set; }

        public int LikeCount { get; set; } = 0;
        public int DislikeCount { get; set; } = 0;
        public int CommentCount { get; set; } = 0;
        public int Popularity { get; set; } = 0;
        public List<Comment>? Comments { get; set; }
    }
}
