using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Domain
{
    public class Blogging
    {
        public Blogging()
        {
            Title = string.Empty;
            Image = string.Empty;
            Content = string.Empty;
        }
        [Key]
        public Guid BlogId{ get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }  
        public string? Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public AppUser? Author { get; set; }
        public List<Reaction> Reactions { get; set; } = new List<Reaction>();
        public List<Comment> Comments { get; set; } = new List<Comment>();

    }
}
