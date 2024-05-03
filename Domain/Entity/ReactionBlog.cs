using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entity
{
    public class ReactionBlog
    {

        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(userFK))]

        public string User { get; set; }

        public bool ReactionType { get; set; }

        public virtual AppUser? userFK { get; set; }

        [ForeignKey(nameof(blogFK))]

        public Guid Blog { get; set; }

        public virtual Blogging? blogFK { get; set; }

        public DateTime CreatedAt { get; set; }


    }

}
