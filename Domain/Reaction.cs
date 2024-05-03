using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain
{
    public enum ReactionType
    {
        Like = 2,
        Dislike = 1
    }
   
    public class Reaction
    {
        public Reaction() 
        {      
            Type = 0;  
        }
        [Key]
        public Guid ReactId { get; set; }
        public ReactionType? Type { get; set; }
        
    }
}
