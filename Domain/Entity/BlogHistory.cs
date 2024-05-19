using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class BlogHistory
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? BlogTitlePrevious { get; set; } // Non-nullable

        [Required]
        public string? BlogContentPrevious { get; set; } // Non-nullable

        public string? BlogImageNamePrevious { get; set; }

        public DateTime? BlogCreatedDateTime { get; set; }
        public DateTime? BlogModifiedDateTime { get; set; } = DateTime.Now; // Non-nullable

        [ForeignKey(nameof(blogFK))]
        public Guid Blog { get; set; } // Renamed for clarity

        public virtual Blogging? blogFK { get; set; } // Navigation property
    }
}
